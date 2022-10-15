using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ProductController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _repository.Products.GetAllProducts(trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("ProductForCreationDto object is null");
            }

            var productEntity = _mapper.Map<Product>(product);
            _repository.Products.CreateProduct(productEntity);
            _repository.Save();
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute(new { id = productDto.Id }, productDto);
        }
    }
}

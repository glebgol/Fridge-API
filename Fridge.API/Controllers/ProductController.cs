using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects.Dto;
using Entities.DataTransferObjects.DtoForCreation;
using Entities.DataTransferObjects.DtoForUpdate;
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
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.Products.GetAllProductsAsync(false);
            var productsDto = _mapper.Map<ICollection<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _repository.Products.GetProductAsync(id);

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("ProductForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var productEntity = _mapper.Map<Product>(product);
            _repository.Products.CreateProduct(productEntity);
            await _repository.SaveAsync();
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute(new { id = productDto.Id }, productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _repository.Products.GetProductAsync(id);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Products.DeleteProduct(product);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody]
        ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForUpdateDto object sent from client is null.");
                return BadRequest("ProductForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var productEntity = await _repository.Products.GetProductAsync(id);
            if (productEntity == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(product, productEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

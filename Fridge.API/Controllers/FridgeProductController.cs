using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FridgeProductController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFridgeProducts(int fridgeId)
        {
            var products = _repository.FridgeProducts.GetFridgeProducts(fridgeId, trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(products);
            return Ok(productsDto);
        }
    }
}

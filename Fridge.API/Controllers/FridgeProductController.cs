using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects.Dto;
using Entities.DataTransferObjects.DtoForCreation;
using Entities.DataTransferObjects.DtoForUpdate;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/fridges/{fridgeId}/products")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public FridgeProductController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridgeProducts(Guid fridgeId)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var products = await _repository.FridgeProducts.GetFridgeProductsAsync(fridgeId, trackChanges: false);
                var productsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(products);
                return Ok(productsDto);
            }
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateFridgeProduct(Guid fridgeId, Guid productId, [FromBody] FridgeProductForCreationDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForCreationDto object sent from client is null.");
                return BadRequest("FridgeProductForCreationDto object is null");
            }

            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound("Fridge");
            }

            var product = await _repository.Products.GetProductAsync(productId);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound("Product");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeProductForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProduct);
            _repository.FridgeProducts.CreateFridgeProduct(fridgeId, productId, fridgeProductEntity);
            await _repository.SaveAsync();

            var fridgeProductDto = _mapper.Map<FridgeProductDto>(fridgeProductEntity);
            return CreatedAtRoute(new { fridgeId, productId, fridgeProductDto.Id }, fridgeProductDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridgeProduct(Guid fridgeId, Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var fridgeProduct = await _repository.FridgeProducts.GetFridgeProductAsync(id);
            if (fridgeProduct == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.FridgeProducts.DeleteFridgeProduct(fridgeProduct);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFridgeProduct(Guid fridgeId, Guid id, [FromBody]
        FridgeProductForUpdateDto fridgeProduct)
        {
            if (fridgeProduct == null)
            {
                _logger.LogError("FridgeProductForUpdateDto object sent from client is null.");
                return BadRequest("FridgeProductForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeProductForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var fridge = await _repository.Fridges.GetFridgeAsync(fridgeId);
            if (fridge == null)
            {
                _logger.LogError($"Fridge with id: {fridgeId} doesn't exist in the database.");
                return NotFound();
            }

            var fridgeProductEntity = await _repository.FridgeProducts.GetFridgeProductAsync(id);
            if (fridgeProductEntity == null)
            {
                _logger.LogInfo($"FridgeProduct with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridgeProduct, fridgeProductEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects.Dto;
using Entities.DataTransferObjects.DtoForCreation;
using Entities.DataTransferObjects.DtoForUpdate;
using Microsoft.AspNetCore.Mvc;


namespace Fridge.API.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public FridgeController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFridges()
        {
            var fridges = await _repository.Fridges.GetAllFridgesAsync(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var fridgeDto = _mapper.Map<FridgeDto>(fridge);
                return Ok(fridgeDto);
            }
        }

        [HttpPost("{fridgeModelId}")]
        //[ServiceFilter(typeof(ValidationDtoFilterAttribute))]
        public async Task<IActionResult> PostFridge(Guid fridgeModelId, [FromBody] FridgeForCreationDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("FridgeForCreationDto object is null");
            }

            var fridgeModel = await _repository.FridgeModels.GetFridgeModelAsync(fridgeModelId);

            if (fridgeModel == null)
            {
                _logger.LogInfo($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var fridgeEntity = _mapper.Map<Entities.Models.Fridge>(fridge);

            _repository.Fridges.CreateFridge(fridgeModelId, fridgeEntity);
            await _repository.SaveAsync();

            var fridgeDto = _mapper.Map<FridgeDto>(fridgeEntity);

            return CreatedAtRoute(new { fridgeModelId, fridgeDto.Id }, fridgeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridge(Guid id)
        {
            var fridge = await _repository.Fridges.GetFridgeAsync(id);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Fridges.DeleteFridge(fridge);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFridge(Guid id, [FromBody]
        FridgeForUpdateDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForUpdateDto object sent from client is null.");
                return BadRequest("FridgeForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FridgeForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var fridgeEntity = await _repository.Fridges.GetFridgeAsync(id);
            if (fridgeEntity == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridge, fridgeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
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
        public IActionResult GetAllFridges()
        {
            var fridges = _repository.Fridges.GetAllFridges(trackChanges: false);
            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
            return Ok(fridgesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetFridge(Guid id)
        {
            var fridge = _repository.Fridges.GetFridge(id);
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
        public IActionResult PostFridge(Guid fridgeModelId, [FromBody] FridgeForCreationDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForCreationDto object sent from client is null.");
                return BadRequest("FridgeForCreationDto object is null");
            }

            var fridgeModel = _repository.FridgeModels.GetFridgeModel(fridgeModelId);

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
            _repository.Save();

            var fridgeDto = _mapper.Map<FridgeDto>(fridgeEntity);

            return CreatedAtRoute(new { fridgeModelId, fridgeDto.Id }, fridgeDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFridge(Guid id)
        {
            var fridge = _repository.Fridges.GetFridge(id);
            if (fridge == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Fridges.DeleteFridge(fridge);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFridge(Guid id, [FromBody]
        FridgeForUpdateDto fridge)
        {
            if (fridge == null)
            {
                _logger.LogError("FridgeForUpdateDto object sent from client is null.");
                return BadRequest("FridgeForUpdateDto object is null");
            }

            var fridgeEntity = _repository.Fridges.GetFridge(id);
            if (fridgeEntity == null)
            {
                _logger.LogInfo($"Fridge with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridge, fridgeEntity);
            _repository.Save();
            return NoContent();
        }
    }
}

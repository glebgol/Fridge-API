using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/fridge-models")]
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public FridgeModelController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllFridgeModels()
        {
            var models = _repository.FridgeModels.GetAllFridgeModels(trackChanges: false);
            var modelsDto = _mapper.Map<IEnumerable<FridgeModelDto>>(models);
            return Ok(modelsDto);
        }

        [HttpPost]
        public IActionResult CreateFridgeModel([FromBody] FridgeModelForCreationDto model)
        {
            if (model == null)
            {
                _logger.LogError("FridgeModelForCreationDto object sent from client is null");
                return BadRequest("FridgeModelForCreationDto object is null");
            }
            var modelEntity = _mapper.Map<FridgeModel>(model);
            _repository.FridgeModels.CreateFridgeModel(modelEntity);
            _repository.Save();

            var modelToReturn = _mapper.Map<FridgeModelDto>(modelEntity);
            return CreatedAtRoute(new { id = modelToReturn.Id }, modelToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFridgeModel(Guid id)
        {
            var fridgeModel = _repository.FridgeModels.GetFridgeModel(id);
            if (fridgeModel == null)
            {
                _logger.LogInfo($"FridgeModel with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.FridgeModels.DeleteFridgeModel(fridgeModel);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFridgeModel(Guid id, [FromBody]
        FridgeModelForUpdateDto fridgeModel)
        {
            if (fridgeModel == null)
            {
                _logger.LogError("FridgeModelForUpdateDto object sent from client is null.");
                return BadRequest("FridgeModelForUpdateDto object is null");
            }

            var fridgeModelEntity = _repository.FridgeModels.GetFridgeModel(id);
            if (fridgeModelEntity == null)
            {
                _logger.LogInfo($"FridgeModel with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(fridgeModel, fridgeModelEntity);
            _repository.Save();
            return NoContent();
        }
    }
}

using AutoMapper;
using Contracts.Interfaces;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/fridge-models")]
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FridgeModelController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllFridgeModels()
        {
            try
            {
                var models = _repository.FridgeModels.GetAllFridgeModels(trackChanges: false);
                var modelsDto = _mapper.Map<IEnumerable<FridgeModelDto>>(models);
                return Ok(modelsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

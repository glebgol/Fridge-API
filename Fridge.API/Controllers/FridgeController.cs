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
            try
            {
                var fridges = _repository.Fridges.GetAllFridges(trackChanges: false);
                var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);
                return Ok(fridgesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostFridge(Entities.Models.Fridge fridge)
        {
            try
            {
                _repository.Fridges.AddFridge(fridge);
                var fridgeDto = _mapper.Map<FridgeDto>(fridge);
                return CreatedAtAction(nameof(PostFridge), new { id = fridge.Id }, fridgeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

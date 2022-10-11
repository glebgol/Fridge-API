using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public FridgeController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllFridges()
        {
            try
            {
                var fridges = _repository.Fridges.GetAllFridges(trackChanges: false);
                return Ok(fridges);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/products")]
        public IActionResult GetAllFridgeProducts(int id)
        {
            try
            {
                var products = _repository.FridgeProducts.GetAllFridgeProducts(id, trackChanges: false);
                return Ok(products);
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
                return CreatedAtAction(nameof(PostFridge), new { id = fridge.Id }, fridge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

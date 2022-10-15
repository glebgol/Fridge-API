﻿using AutoMapper;
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
        private readonly ILoggerManager _logger;

        public FridgeProductController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetFridgeProducts(Guid fridgeId)
        {
            var products = _repository.FridgeProducts.GetFridgeProducts(fridgeId, trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<FridgeProductDto>>(products);
            return Ok(productsDto);
        }

        //[HttpPost]
        //public IActionResult CreateFridgeProduct(ProductForCreationDto product)
        //{

        //}
    }
}

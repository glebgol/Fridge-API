using AutoMapper;
using Contracts.Interfaces;
using Fridge.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fridge.API.Tests
{
    public class FridgeControllerTests
    {
        private readonly Mock<IRepositoryManager> _mockRepo = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<ILoggerManager> _mockLogger = new();
        private readonly FridgeController _fridgeController;

        [Fact]
        public void GetAllFridges_ReturnsOkObjectResult()
        {
            _mockRepo.Setup(repo => repo.Fridges.GetAllFridges(false)).Returns(GetTestItems.Fridges);
            var controller = new FridgeController(_mockRepo.Object, _mockMapper.Object, _mockLogger.Object);

            var result = controller.GetAllFridges() as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

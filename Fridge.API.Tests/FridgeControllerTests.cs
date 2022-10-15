//using AutoMapper;
//using Contracts.Interfaces;
//using Fridge.API.Controllers;
//using Moq;

//namespace Fridge.API.Tests
//{
//    public class FridgeControllerTests
//    {
//        private readonly Mock<IRepositoryManager> _mockRepo;
//        private readonly Mock<IMapper> _mockMapper;
//        private readonly Mock<ILoggerManager> _mockLogger;
//        private readonly FridgeController _fridgeController;

//        public FridgeControllerTests()
//        {
//            _mockRepo = new Mock<IRepositoryManager>();
//            _mockMapper = new Mock<IMapper>();
//            _mockLogger = new Mock<ILoggerManager>();
//            _fridgeController = new FridgeController(_mockRepo.Object,
//                _mockMapper.Object, _mockLogger.Object);
//        }

//        [Fact]
//        public void GetAllFridges_ReturnsOkObjectResult()
//        {
//            Assert.True(true);
//        }
//    }
//}

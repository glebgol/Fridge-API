using AutoMapper;
using Contracts.Interfaces;
using Fridge.API.AutoMapperProfile;
using Moq;

namespace Fridge.API.Tests
{
    public class FridgeProductControllerTests
    {
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly IMapper _mapper;

        public FridgeProductControllerTests()
        {
            _mockRepo = new Mock<IRepositoryManager>();
            _mockLogger = new Mock<ILoggerManager>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            SetUpMock();
        }

        private void SetUpMock()
        {

        }

        [Fact]
        public void GetFridgeProducts_NotExistingFridge_ReturnsNotFound()
        {

        }

        [Fact]
        public void GetFridgeProducts_ExistingFridge_ReturnsOkObjectResult()
        {

        }

        [Fact]
        public void CreateFridgeProduct_NullProductForCreate_ReturnsBadRequest()
        {

        }

        [Fact]
        public void CreateFridgeProduct_NotExistingFridge_ReturnsNotFound()
        {

        }

        [Fact]
        public void CreateFridgeProduct_NotExistingProduct_ReturnsNotFound()
        {

        }

        [Fact]
        public void CreateFridgeProduct_ExistingProductAndFridge_ReturnsCreatedAtRoute()
        {

        }

        [Fact]
        public void DeleteFridgeProduct_NotExistingFridge_ReturnsNotFound()
        {

        }

        [Fact]
        public void DeleteFridgeProduct_NotExistingFridgeProduct_ReturnsNotFound()
        {

        }

        [Fact]
        public void DeleteFridgeProduct_ExistingFridgeProduct_ReturnsNoContent()
        {

        }

        [Fact]
        public void UpdateFridgeProduct_NullFridgeProductForUpdate_ReturnsBadRequest()
        {

        }

        [Fact]
        public void UpdateFridgeProduct_NotExistingFridgeProduct_ReturnsNotFound()
        {

        }

        [Fact]
        public void UpdateFridgeProduct_ExistingFridgeProduct_ReturnsNoContent()
        {

        }
    }
}

using AutoMapper;
using Contracts.Interfaces;
using Fridge.API.AutoMapperProfile;
using Fridge.API.Controllers;
using Microsoft.AspNetCore.Mvc;
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
            _mockRepo.Setup(repo => repo.Fridges.GetFridge(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.Fridges.FirstOrDefault(f => f.Id == guid));

            _mockRepo.Setup(repo => repo.FridgeProducts.GetFridgeProducts(It.IsAny<Guid>(), It.IsAny<bool>()))
                .Returns((Guid guid, bool b) => TestItems.FridgeProducts.Where(fp => fp.FridgeId == guid));

            _mockRepo.Setup(repo => repo.Fridges.GetFridge(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.Fridges.FirstOrDefault(f => f.Id == guid));

            _mockRepo.Setup(repo => repo.Products.GetProduct(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.Products.FirstOrDefault(p => p.Id == guid));

            _mockRepo.Setup(repo => repo.FridgeProducts.GetFridgeProduct(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.FridgeProducts.FirstOrDefault(fp => fp.ProductId == guid));
        }

        [Fact]
        public void GetFridgeProducts_NotExistingFridge_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeId = TestItems.NotExistingFridgeId;

            // Act
            var result = controller.GetFridgeProducts(notExistingFridgeId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetFridgeProducts_ExistingFridge_ReturnsOkObjectResult()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;

            // Act
            var result = controller.GetFridgeProducts(existingFridgeId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeProduct_NullProductForCreate_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var existingProductId = TestItems.ExistingProductId;

            // Act
            var result = controller.CreateFridgeProduct(existingFridgeId, existingProductId, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeProduct_NotExistingFridge_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            var existingProductId = TestItems.ExistingProductId;
            var fridgeProductForCreation = TestItems.FridgeProductForCreation;

            // Act
            var result = controller.CreateFridgeProduct(notExistingFridgeId, existingProductId, fridgeProductForCreation);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeProduct_NotExistingProduct_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var notExistingProductId = TestItems.NotExistingProductId;
            var fridgeProductForCreation = TestItems.FridgeProductForCreation;

            // Act
            var result = controller.CreateFridgeProduct(existingFridgeId, notExistingProductId, fridgeProductForCreation);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeProduct_ExistingProductAndFridge_ReturnsCreatedAtRoute()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var existingProductId = TestItems.ExistingProductId;
            var fridgeProductForCreation = TestItems.FridgeProductForCreation;

            // Act
            var result = controller.CreateFridgeProduct(existingFridgeId, existingProductId, fridgeProductForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void DeleteFridgeProduct_NotExistingFridge_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            var existingProductId = TestItems.ExistingProductId;

            // Act
            var result = controller.DeleteFridgeProduct(notExistingFridgeId, existingProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteFridgeProduct_NotExistingFridgeProduct_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var notExistingProductId = TestItems.NotExistingProductId;

            // Act
            var result = controller.DeleteFridgeProduct(existingFridgeId, notExistingProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteFridgeProduct_ExistingFridgeProduct_ReturnsNoContent()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var existingProductId = TestItems.ExistingProductId;

            // Act
            var result = controller.DeleteFridgeProduct(existingFridgeId, existingProductId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateFridgeProduct_NullFridgeProductForUpdate_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeProductId = TestItems.ExistingFridgeProductId;
            var existingFridgeId = TestItems.ExistingFridgeId;

            // Act
            var result = controller.UpdateFridgeProduct(existingFridgeId, existingFridgeProductId, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateFridgeProduct_NotExistingFridge_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            var existingFridgeProductId = TestItems.ExistingFridgeProductId;
            var existingProduct = TestItems.FridgeProductForUpdate;

            // Act
            var result = controller.UpdateFridgeProduct(notExistingFridgeId, existingFridgeProductId, existingProduct);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateFridgeProduct_NotExistingFridgeProduct_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.NotExistingFridgeId;
            var NotExistingFridgeProductId = TestItems.ExistingFridgeProductId;
            var existingProduct = TestItems.FridgeProductForUpdate;

            // Act
            var result = controller.UpdateFridgeProduct(existingFridgeId, NotExistingFridgeProductId, existingProduct);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateFridgeProduct_ExistingFridgeProduct_ReturnsNoContent()
        {
            // Assign
            var controller = new FridgeProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;
            var existingFridgeProductId = TestItems.ExistingFridgeProductId;
            var existingProduct = TestItems.FridgeProductForUpdate;

            // Act
            var result = controller.UpdateFridgeProduct(existingFridgeId, existingFridgeProductId, existingProduct);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

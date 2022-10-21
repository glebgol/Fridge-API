using AutoMapper;
using Contracts.Interfaces;
using Fridge.API.AutoMapperProfile;
using Fridge.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fridge.API.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly IMapper _mapper;

        public ProductControllerTests()
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
            _mockRepo.Setup(repo => repo.Products.GetAllProducts(false))
                .Returns(TestItems.Products);

            _mockRepo.Setup(repo => repo.Products.GetProduct(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.Products.FirstOrDefault(p => p.Id == guid));
        }

        [Fact]
        public void PostProduct_NullProductForCreation_ReturnsBadRequest()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.PostProduct(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostProduct_NotNullProductForCreation_ReturnsBadRequest()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notNullProductForCreation = TestItems.ProductForCreation;

            // Act
            var result = controller.PostProduct(notNullProductForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void DeleteProduct_NotExistingProduct_ReturnsNotFound()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingProductId = TestItems.NotExistingProductId;

            // Act
            var result = controller.DeleteProduct(notExistingProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteProduct_ExistingProduct_ReturnsNoContent()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingProductId = TestItems.ExistingProductId;

            // Act
            var result = controller.DeleteProduct(existingProductId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateProduct_NullProductForUpdate_ReturnsBadRequest()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingProductId = TestItems.ExistingProductId;

            // Act
            var result = controller.UpdateProduct(existingProductId, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateProduct_NotExistingProduct_ReturnsNotFound()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingProductId = TestItems.NotExistingProductId;
            var productForUpdate = TestItems.ProductForUpdate;

            // Act
            var result = controller.UpdateProduct(notExistingProductId, productForUpdate);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateProduct_ExistingProduct_ReturnsNoContent()
        {
            // Assign
            var controller = new ProductController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingProductId = TestItems.ExistingProductId;
            var productForUpdate = TestItems.ProductForUpdate;

            // Act
            var result = controller.UpdateProduct(existingProductId, productForUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

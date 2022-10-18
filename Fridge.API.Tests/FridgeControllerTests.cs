using AutoMapper;
using Contracts.Interfaces;
using Fridge.API.AutoMapperProfile;
using Fridge.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fridge.API.Tests
{
    public class FridgeControllerTests
    {
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly IMapper _mapper;

        public FridgeControllerTests()
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
            _mockRepo.Setup(repo => repo.Fridges.GetAllFridges(false)).Returns(TestItems.Fridges);

            _mockRepo.Setup(repo => repo.Fridges.GetFridge(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.Fridges.FirstOrDefault(f => f.Id == guid));

            _mockRepo.Setup(repo => repo.FridgeModels.GetFridgeModel(It.IsAny<Guid>()))
                .Returns<Guid>(guid => TestItems.FridgeModels.FirstOrDefault(fm => fm.Id == guid));

            _mockRepo.Setup(repo => repo.Fridges.CreateFridge(It.IsAny<Guid>(), It.IsNotNull<Entities.Models.Fridge>()))
                .Verifiable();

            _mockRepo.Setup(repo => repo.Fridges.DeleteFridge(It.IsAny<Entities.Models.Fridge>()))
                .Verifiable();
        }

        [Fact]
        public void GetAllFridges_ReturnsOkObjectResult()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.GetAllFridges() as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetFridge_NotExisting_ReturnsNotFound()
        {
            // Assign
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.GetFridge(notExistingFridgeId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetFridge_Existing_ReturnsOkObjectResult()
        {
            // Assign
            var existingFridgeId = new Guid("dbfc4f30-8cc4-47e5-b543-08dab08812cc");
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.GetFridge(existingFridgeId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PostFridge_NullFridge_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var fridgeModelId = TestItems.ExistingFridgeModelId;

            // Act
            var result = controller.PostFridge(fridgeModelId, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostFridge_NullFridgeModel_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var fridgeModelId = TestItems.NotExistingFridgeModelId;
            var fridgeForCreation = TestItems.FridgeForCreation;

            // Act
            var result = controller.PostFridge(fridgeModelId, fridgeForCreation);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PostFridge_NotNullFridge_ReturnsCreatedAtRoute()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var fridgeModelId = TestItems.ExistingFridgeModelId;
            var fridgeForCreation = TestItems.FridgeForCreation;

            // Act
            var result = controller.PostFridge(fridgeModelId, fridgeForCreation);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void DeleteFridge_NotExisting_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            // Act
            var result = controller.DeleteFridge(notExistingFridgeId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteFridge_Existing_ReturnsNoContent()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeId = TestItems.ExistingFridgeId;

            // Act
            var result = controller.DeleteFridge(existingFridgeId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateFridge_NullFridgeForUpdate_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var id = TestItems.ExistingFridgeId;

            // Act
            var result = controller.UpdateFridge(id, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateFridge_NotExisting_ReturnsNotFound()
        {
            // Assign
            var notExistingFridgeId = TestItems.NotExistingFridgeId;
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var fridgeForUpdate = TestItems.FridgeForUpdate;

            // Act
            var result = controller.UpdateFridge(notExistingFridgeId, fridgeForUpdate);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateFridge_Existing_NoContent()
        {
            // Assign
            var existingFridgeId = TestItems.ExistingFridgeId;
            var controller = new FridgeController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var fridgeForUpdate = TestItems.FridgeForUpdate;

            // Act
            var result = controller.UpdateFridge(existingFridgeId, fridgeForUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

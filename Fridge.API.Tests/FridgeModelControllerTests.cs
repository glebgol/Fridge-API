using AutoMapper;
using Contracts.Interfaces;
using Entities.Models;
using Fridge.API.AutoMapperProfile;
using Fridge.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fridge.API.Tests
{
    public class FridgeModelControllerTests
    {
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly Mock<ILoggerManager> _mockLogger;
        private readonly IMapper _mapper;

        public FridgeModelControllerTests()
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
            _mockRepo.Setup(repo => repo.FridgeModels.GetAllFridgeModelsAsync(false))
                .Returns(Task.FromResult(TestItems.FridgeModels));

            _mockRepo.Setup(repo => repo.FridgeModels.CreateFridgeModel(It.IsAny<FridgeModel>()))
                .Verifiable();

            _mockRepo.Setup(repo => repo.FridgeModels.GetFridgeModelAsync(It.IsAny<Guid>()).Result)
                .Returns<Guid>(guid => TestItems.FridgeModels.FirstOrDefault(fm => fm.Id == guid));
        }

        [Fact]
        public void GetAllFridgeModels_ReturnsOkObjectResult()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.GetAllFridgeModels();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeModel_NullModel_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);

            // Act
            var result = controller.CreateFridgeModel(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateFridgeModel_NotNullModel_ReturnsCreatedAtRoute()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var model = TestItems.FridgeModelForCreation;

            // Act
            var result = controller.CreateFridgeModel(model);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void DeleteFridgeModel_NotExisting_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeModelId = TestItems.NotExistingFridgeModelId;

            // Act
            var result = controller.DeleteFridgeModel(notExistingFridgeModelId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteFridgeModel_Existing_ReturnsNoContent()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeModelId = TestItems.ExistingFridgeModelId;

            // Act
            var result = controller.DeleteFridgeModel(existingFridgeModelId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateFridgeModel_NullFridgeModelForUpdate_ReturnsBadRequest()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeModelId = TestItems.ExistingFridgeModelId;

            // Act
            var result = controller.UpdateFridgeModel(existingFridgeModelId, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateFridgeModel_NotExistingFridgeModel_ReturnsNotFound()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var notExistingFridgeModelId = TestItems.NotExistingFridgeModelId;
            var fridgeModelForUpdate = TestItems.FridgeModelForUpdate;

            // Act
            var result = controller.UpdateFridgeModel(notExistingFridgeModelId, fridgeModelForUpdate);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateFridgeModel_ExistingFridgeModel_ReturnsNoContent()
        {
            // Assign
            var controller = new FridgeModelController(_mockRepo.Object, _mapper, _mockLogger.Object);
            var existingFridgeModelId = TestItems.ExistingFridgeModelId;
            var fridgeModelForUpdate = TestItems.FridgeModelForUpdate;

            // Act
            var result = controller.UpdateFridgeModel(existingFridgeModelId, fridgeModelForUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


    }
}

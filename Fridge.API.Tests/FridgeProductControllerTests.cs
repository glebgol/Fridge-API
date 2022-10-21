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
    }
}

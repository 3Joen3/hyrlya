using Application.Dtos;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Moq;

namespace Tests.Unit.Services
{
    public class LandlordServiceTests
    {
        private readonly Mock<ILandlordRepository> _repoMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();

        private readonly MyLandlordService _service;

        public LandlordServiceTests()
        {
            _service = new MyLandlordService(_repoMock.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task CreateAsync_WhenNotAlreadyExists_ShouldCreateLandlord()
        {
            var identityId = "SomeIdentityId";
            var profileName = "John Doe";
            var profilePhone = new PhoneNumber("0712345678");

            var dto = new LandlordDto(profileName, null, profilePhone, null);

            _repoMock.Setup(r => r.GetMyIdAsync(identityId))
                .ReturnsAsync(Guid.Empty);

            var result = await _service.CreateAsync(identityId, dto);

            _repoMock.Verify(r => r.AddAsync(It.IsAny<Landlord>()), Times.Once);
            _unitOfWork.Verify(u => u.WriteChangesAsync(), Times.Once);

            Assert.Equal(identityId, result.IdentityId);
            Assert.Equal(profileName, result.Profile.Name);
            Assert.Equal(profilePhone, result.Profile.PhoneNumber);
        }
    }
}

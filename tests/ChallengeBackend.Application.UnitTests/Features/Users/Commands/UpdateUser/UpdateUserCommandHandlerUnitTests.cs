using AutoMapper;
using ChallengeBackend.Application.Features.Users.Commands.UpdateUser;
using ChallengeBackend.Application.Mappings;
using ChallengeBackend.Application.UnitTests.Mocks;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Insfrastucture.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Application.UnitTests.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandlerUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserRepository> _userRepository;
        private readonly Mock<ILogger<UpdateUserCommandHandler>> _logger;

        public UpdateUserCommandHandlerUnitTests()
        {
            _userRepository = MockUserRepository.GetUnitRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<UpdateUserCommandHandler>>();

            MockUserRepository.AddDataUserRepository(_userRepository.Object.UserDbContext);
        }

        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsObject()
        {
            var streamerInput = new UpdateUserCommand
            {
                Id = 8001,
                Name = "Julio Garcia",
                Email = "Julio@gmail.com",
                BirthDate = "02-01-1992",
                Address = new AddressVm
                {
                    Id = 8001,
                    Street = "Av. San Martin S/N",
                    State = "Lima",
                    City = "Lima",
                    Country = "Peru",
                    Zip = "23001"
                }
            };

            var handler = new UpdateUserCommandHandler(_userRepository.Object, _mapper, _logger.Object);

            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<UserVm>();
        }
    }
}

using AutoMapper;
using ChallengeBackend.Application.Features.Users.Commands;
using ChallengeBackend.Application.Features.Users.Commands.CreateUser;
using ChallengeBackend.Application.Features.Users.Commands.DeleteUser;
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

namespace ChallengeBackend.Application.UnitTests.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandlerUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserRepository> _userRepository;
        private readonly Mock<ILogger<CreateUserCommandHandler>> _logger;

        public CreateUserCommandHandlerUnitTests()
        {
            _userRepository = MockUserRepository.GetUnitRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<CreateUserCommandHandler>>();

            MockUserRepository.AddDataUserRepository(_userRepository.Object.UserDbContext);
        }

        [Fact]
        public async Task CreateStreamerCommand_InputStreamer_ReturnsObject()
        {
            var streamerInput = new CreateUserCommand
            {
                Name = "Pedro Garcia",
                Email = "Pedro76@gmail.com",
                BirthDate = "02-01-1989",
                Address = new AddressVm
                {
                    Street = "Av. Brasil S/N",
                    State = "Lima",
                    City = "Lima",
                    Country = "Peru",
                    Zip = "23001"
                }
            };

            var handler = new CreateUserCommandHandler(_userRepository.Object, _mapper, _logger.Object);

            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<UserVm>();
        }
    }
}

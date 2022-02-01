using AutoMapper;
using ChallengeBackend.Application.Features.Users.Commands.DeleteUser;
using ChallengeBackend.Application.Mappings;
using ChallengeBackend.Application.UnitTests.Mocks;
using ChallengeBackend.Insfrastucture.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Application.UnitTests.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandlerUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserRepository> _userRepository;
        private readonly Mock<ILogger<DeleteUserCommandHandler>> _logger;

        public DeleteUserCommandHandlerUnitTests()
        {
            _userRepository = MockUserRepository.GetUnitRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<DeleteUserCommandHandler>>();

            MockUserRepository.AddDataUserRepository(_userRepository.Object.UserDbContext);
        }


        [Fact]
        public async Task DeleteUserCommand_InputUser_ReturnUnit()
        {
            var userInput = new DeleteUserCommand
            {
                UserId = 8001,
            };

            var handler = new DeleteUserCommandHandler(_userRepository.Object, _mapper, _logger.Object);

            var result = await handler.Handle(userInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}

using AutoMapper;
using ChallengeBackend.Application.Features.Users.Queries.GetUserById;
using ChallengeBackend.Application.Features.Users.Queries.GetUsers;
using ChallengeBackend.Application.Mappings;
using ChallengeBackend.Application.UnitTests.Mocks;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Insfrastucture.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Application.UnitTests.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandlerUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserRepository> _userRepository;
        private readonly Mock<ILogger<GetUserByIdQueryHandler>> _logger;

        public GetUserByIdQueryHandlerUnitTests()
        {
            _userRepository = MockUserRepository.GetUnitRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<GetUserByIdQueryHandler>>();

            MockUserRepository.AddDataUserRepository(_userRepository.Object.UserDbContext);
        }

        [Fact]
        public async Task GetUserByIdTest()
        {
            var handler = new GetUserByIdQueryHandler(_userRepository.Object, _mapper, _logger.Object);
            var request = new GetUserByIdQuery { UserId = 8001};

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<UserVm>();
        }
    }
}

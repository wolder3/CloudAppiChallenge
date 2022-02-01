using AutoMapper;
using ChallengeBackend.Application.Features.Users.Queries.GetUsers;
using ChallengeBackend.Application.Mappings;
using ChallengeBackend.Application.UnitTests.Mocks;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Insfrastucture.Repositories;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBackend.Application.UnitTests.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandlerUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UserRepository> _userRepository;
   
        public GetUsersQueryHandlerUnitTests()
        {
            _userRepository = MockUserRepository.GetUnitRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockUserRepository.AddDataUserRepository(_userRepository.Object.UserDbContext);
        }


        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetUsersQueryHandler(_userRepository.Object, _mapper);
            var request = new GetUsersQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<UserVm>>();
        }
    }
}

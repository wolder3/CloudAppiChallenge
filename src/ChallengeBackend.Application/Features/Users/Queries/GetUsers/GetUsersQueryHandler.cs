using MediatR;
using AutoMapper;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Application.Contracts.Persistence;

namespace ChallengeBackend.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserVm>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetAllAsync();
            
            return _mapper.Map<List<UserVm>>(userList);
        }
    }
}

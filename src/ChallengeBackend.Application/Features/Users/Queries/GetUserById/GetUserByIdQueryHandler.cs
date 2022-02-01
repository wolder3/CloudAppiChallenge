using AutoMapper;
using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Application.Exceptions;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChallengeBackend.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserVm> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId <= 0)
                throw new BadRequestException("Invalid user id");

            var userEntity = await _userRepository.GetByIdAsync(request.UserId);

            if(userEntity == null)
            {
                _logger.LogError($"{request.UserId} User not found");
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserVm>(userEntity);
        }
    }
}

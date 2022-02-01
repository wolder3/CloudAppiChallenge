using AutoMapper;
using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Application.Exceptions;
using ChallengeBackend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChallengeBackend.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userDelete = await _userRepository.GetByIdAsync(request.UserId);
            if(userDelete == null)
            {
                _logger.LogError($"{request.UserId} User not found");
                throw new NotFoundException(nameof(User), request.UserId);
            }

            await _userRepository.DeleteAsync(userDelete);

            _logger.LogInformation($"The {request.UserId} user was successfully deleted");

            return Unit.Value;
        }
    }
}

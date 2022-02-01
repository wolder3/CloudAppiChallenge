using AutoMapper;
using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Application.Exceptions;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChallengeBackend.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userrRepository, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userrRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserVm> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.Id);

            if (userToUpdate == null)
            {
                _logger.LogError($"{request.Id} User not found");
                throw new NotFoundException(nameof(User), request.Id);
            }

            if (userToUpdate.Address.Id != request.Address.Id)
                throw new BadRequestException("address id is different to request address id");

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

            userToUpdate.Address = _mapper.Map<Address>(request.Address);
            userToUpdate.Address.UserId = request.Id;

            var UserUpdated = await _userRepository.UpdateAsync(userToUpdate);

            _logger.LogInformation($"The {request.Id} user was successfully updated");

            return _mapper.Map<UserVm>(UserUpdated);
        }
    }
}

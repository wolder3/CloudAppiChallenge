using AutoMapper;
using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
 

namespace ChallengeBackend.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserVm>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserVm> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            var addressEntity = _mapper.Map<Address>(request.Address);

            userEntity.Address = addressEntity;

            var userRecord = await _userRepository.AddAsync(userEntity);

            if (userRecord == null)
                throw new Exception("Error to insert record of user");

            _logger.LogInformation($"User {userRecord.Id} fue creado existosamente");

            return _mapper.Map<UserVm>(userRecord);

        }
    }
}

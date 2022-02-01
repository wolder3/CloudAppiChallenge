using ChallengeBackend.Application.ViewModels;
using MediatR;

namespace ChallengeBackend.Application.Features.Users.Commands
{
    public class CreateUserCommand: IRequest<UserVm>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public AddressVm Address { get; set; } = new AddressVm();

    }
}

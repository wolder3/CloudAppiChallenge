using MediatR;

namespace ChallengeBackend.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}

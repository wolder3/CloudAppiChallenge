using ChallengeBackend.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery: IRequest<UserVm>
    {
        public int UserId { get; set; }
    }
}

﻿using ChallengeBackend.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserVm>>
    {
        
    }
}

using ChallengeBackend.API.Errors;
using ChallengeBackend.Application.Exceptions;
using ChallengeBackend.Application.Features.Users.Commands;
using ChallengeBackend.Application.Features.Users.Commands.DeleteUser;
using ChallengeBackend.Application.Features.Users.Commands.UpdateUser;
using ChallengeBackend.Application.Features.Users.Queries.GetUserById;
using ChallengeBackend.Application.Features.Users.Queries.GetUsers;
using ChallengeBackend.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ChallengeBackend.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getUsers")]
        [SwaggerOperation(Summary = "Get all users")]
        [ProducesResponseType(typeof(IEnumerable<UserVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserVm>>> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpGet("getusersById/{userId}")]
        [SwaggerOperation(Summary = "Get one user")]
        [ProducesResponseType(typeof(UserVm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVm>> GetUserById(int userId)
        {
            var query = new GetUserByIdQuery 
            { 
                UserId = userId
            };

            var users = await _mediator.Send(query);

            return Ok(users);
        }

        [HttpPost("createUsers")]
        [SwaggerOperation(Summary = "Create user")]
        [ProducesResponseType(typeof(UserVm), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CodeErrorException),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserVm>> CreateUsers([FromBody] CreateUserCommand command)
        {
            var userEntity = await _mediator.Send(command);

            return StatusCode(201, userEntity);
        }

        [HttpPut("updateUsersById/{userId}")]
        [SwaggerOperation(Summary = "Update user by id")]
        [ProducesResponseType(typeof(UserVm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVm>> UpdateUsersById(int userId, [FromBody] UpdateUserCommand command)
        {
            if (userId <= 0 || userId != command.Id)
                throw new BadRequestException("Invalid user id");
          
            var userEntity = await _mediator.Send(command);

            return Ok(userEntity);
        }

        [HttpGet("deleteUsersById/{userId}")]
        [SwaggerOperation(Summary = "Delete user by id")]
        [ProducesResponseType(typeof(UserVm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CodeErrorException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserVm>> DeleteUsersById(int userId)
        {
            var command = new DeleteUserCommand
            {
                UserId = userId
            };

            await _mediator.Send(command);

            return Ok();
        }

    }
}

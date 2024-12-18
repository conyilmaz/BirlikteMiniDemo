using MediatR;
using Microsoft.AspNetCore.Mvc;
using BirlikteMiniDemo.Application.UseCases.Users.Commands;
using BirlikteMiniDemo.Application.UseCases.Users.Queries;

namespace BirlikteMiniDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);
            return NoContent();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail(Guid id)
        {
            var query = new GetUserDetailQuery { Id = id };
            var user = await _mediator.Send(query);
            return Ok(user);
        }


        [HttpPost("{id}/upload-profile-photo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadProfilePhoto(Guid id, [FromBody] UploadProfilePhotoCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Base64Photo))
                return BadRequest("Base64Photo is required.");

            command.UserId = id; 
            var photoUrl = await _mediator.Send(command);

            return Ok(new { PhotoUrl = photoUrl });
        }


    }
}

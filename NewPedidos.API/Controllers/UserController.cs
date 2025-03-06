using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newpedidos.Application.Command.DeleteUser;
using Newpedidos.Application.Command.InsertUser;
using Newpedidos.Application.Command.UpdateUser;
using Newpedidos.Application.Model;
using Newpedidos.Application.Queries.GetAllUsersQuery;
using Newpedidos.Application.Queries.GetOrderByIdQuery;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Auth;

namespace NewPedidos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    
    public class UserController : ControllerBase
    {
        private readonly IUserServices _service;
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;

        public UserController(IUserServices service, IMediator mediator, IAuthService authService)
        {
            _service = service;
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostProduct(InsertUserCommand command)
        {
            var hash = _authService.ComputerHash(command.Password);

            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var query = new GetAllUsersQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        
    }
}

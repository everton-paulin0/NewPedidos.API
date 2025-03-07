using System.Data.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newpedidos.Application.Command.AdministratorUser;
using Newpedidos.Application.Command.DeleteUser;
using Newpedidos.Application.Command.InsertUser;
using Newpedidos.Application.Command.ReaderUser;
using Newpedidos.Application.Command.SetAsPemding;
using Newpedidos.Application.Command.UpdateUser;
using Newpedidos.Application.Model;
using Newpedidos.Application.Queries.GetAllUsersQuery;
using Newpedidos.Application.Queries.GetOrderByIdQuery;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Core.Entities;
using NewPedidos.Infractruture.Auth;
using NewPedidos.Infractruture.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        private readonly AppDbContext _context;

        public UserController(IUserServices service, IMediator mediator, IAuthService authService, AppDbContext context)
        {
            _service = service;
            _mediator = mediator;
            _authService = authService;
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser(CreateUserInputModel command)
        {
            var hash = _authService.ComputerHash(command.Password);

            var user = new User (command.UserName, command.UserEmail, command.UserLevel, hash);
           
            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
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

        [HttpPatch("{id}/administrator")]
        public async Task<IActionResult> Administrator(int id)
        {
            var result = await _mediator.Send(new AdministratorUserCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/reader")]
        public async Task<IActionResult> Reader(int id)
        {
            var result = await _mediator.Send(new ReaderUserCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        

        [HttpPut("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginInputModel command)
        {
            var hash =  _authService.ComputerHash(command.Password);

            var user = _context.Users.SingleOrDefault(u => u.UserEmail == command.UserEmail && u.Password == hash);

            if (user is null)
            {
                var error = ResultViewModel<LoginViewModel?>.Error("Erro de Login");

                return BadRequest(error);
            }
            var token = _authService.GenerateToken(user.UserEmail, user.UserLevel);

            var viewModel = new LoginViewModel(token);

            var result = ResultViewModel<LoginViewModel>.Success();

            return Ok(result);
        }
        
        
    }
}

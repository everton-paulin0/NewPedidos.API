using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newpedidos.Application.Command.CancelOrder;
using Newpedidos.Application.Command.CompleteOrder;
using Newpedidos.Application.Command.DeleteOrder;
using Newpedidos.Application.Command.InsertOrder;
using Newpedidos.Application.Command.SetAsPemding;
using Newpedidos.Application.Command.UpdateOrder;
using Newpedidos.Application.Queries.GetAllOrdersQuery;
using Newpedidos.Application.Queries.GetOrderByIdQuery;
using Newpedidos.Application.Services.Interfaces;

namespace NewPedidos.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly IOrderServices _service;
        private readonly IMediator _mediator;
        public OrderController(IOrderServices service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertOrderCommand command)
        {
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
            var query = new GetAllOrdersQuery();

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
        public async Task<IActionResult> Put(int id, UpdateOrderCommand command)
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
            var result = await _mediator.Send(new DeleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/paymentpending")]
        public async Task<IActionResult> SetPaymentPending(int id)
        {
            var result = await _mediator.Send(new SetAsPendingOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        
    }
}
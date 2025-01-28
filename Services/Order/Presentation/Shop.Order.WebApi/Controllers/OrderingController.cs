using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Shop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace Shop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderingController(IMediator mediator)
        {
                _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);   
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand); 
            return Ok("Ordering added Successfuly");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Ordering updated Successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderig(RemoveOrderingCommand removeOrderingCommand)
        {
            await _mediator.Send(removeOrderingCommand);
            return Ok("Ordering remove Successfuly");
        }

    }
}

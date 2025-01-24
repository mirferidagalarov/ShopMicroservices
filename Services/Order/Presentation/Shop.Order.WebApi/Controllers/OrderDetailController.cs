using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Shop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Shop.Order.Application.Features.CQRS.Queries.OrderDetialQueries;

namespace Shop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler; 
        private readonly CreateOrderDetailCommandHandler _createOrderDetailQueryHandler;   
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailQueryHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailQueryHandler;

        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailQueryHandler, RemoveOrderDetailCommandHandler removeOrderDetailQueryHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailQueryHandler = createOrderDetailQueryHandler;
            _updateOrderDetailQueryHandler = updateOrderDetailQueryHandler;
            _removeOrderDetailQueryHandler = removeOrderDetailQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
         var values=  await _getOrderDetailQueryHandler.Handle();
            return Ok(values);  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int id)
        {
            var value= await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);   
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand  createOrderDetailCommand)
        {
             await _createOrderDetailQueryHandler.Handle(createOrderDetailCommand);  
            return Ok("Data addded Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailQueryHandler.Handle(updateOrderDetailCommand);
            return Ok("Data updated Successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
           await _removeOrderDetailQueryHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Data deleted Successfuly");    
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Shop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Shop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Shop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;  
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressComandHandler;

        public AddressController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressComandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressComandHandler = removeAddressComandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressGetAll()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);    
            return Ok("Address added successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Address updated successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _removeAddressComandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address deleted successfuly");    
        }
    }
}

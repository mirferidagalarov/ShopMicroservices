using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand createOrderDetailCommand)
        {
            var value =await _repository.GetByIdAsync(createOrderDetailCommand.OrderDetailId);
            value.OrderingId=createOrderDetailCommand.OrderingId;
            value.ProductId=createOrderDetailCommand.ProductId;
            value.ProductName=createOrderDetailCommand.ProductName;
            value.TotalPrice=createOrderDetailCommand.TotalPrice;
            value.ProductAmount=createOrderDetailCommand.ProductAmount; 
            value.ProductPrice=createOrderDetailCommand.ProductPrice;   
            await _repository.UpdateAsync(value);    
        }
    }
}

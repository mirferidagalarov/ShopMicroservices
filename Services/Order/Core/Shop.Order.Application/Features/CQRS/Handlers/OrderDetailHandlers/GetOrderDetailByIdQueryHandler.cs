using Shop.Order.Application.Features.CQRS.Queries.OrderDetialQueries;
using Shop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailQuery)
        {
            var value = await _repository.GetByIdAsync(getOrderDetailQuery.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = value.OrderDetailId,
                OrderingId = value.OrderingId,
                ProductAmount = value.ProductAmount,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                TotalPrice = value.TotalPrice,
            };
        }
    }
}

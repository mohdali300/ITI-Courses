using Grpc.Core;
using Orders.API.Services;
using Orders.Service.Protos;
using OrderItem = Orders.API.Models.OrderItem;
using static Orders.Service.Protos.Order;
using Orders.API.Models;

namespace Orders.Service.Services
{
    public class OrderGrpcService: OrderBase
    {
        private readonly OrderProcessingService _processingService;

        public OrderGrpcService(OrderProcessingService processingService)
        {
            _processingService = processingService;
        }

        public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
        {
            var orderRequest = new OrderRequest
            {
                Id = request.Id,
                UserId = request.UserId,
                Items = request.Items.Select(i => new OrderItem
                {
                    ItemId = i.ItemId,
                    Quantity = i.Quantity
                }).ToList()
            };
            var result = await _processingService.ProcessOrderAsync(orderRequest);
            return new CreateOrderResponse
            {
                Success = result.Success,
                Messages = { result.Messages }
            };
        }
    }
}

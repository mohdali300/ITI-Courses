using Grpc.Net.Client;
using Orders.API.Data;
using Orders.API.Models;
using Orders.InventoryService.Protos;
using Orders.PaymentService.Protos;

namespace Orders.API.Services
{
    public class OrderProcessingService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<OrderProcessingService> _logger;

        public OrderProcessingService(IConfiguration config, ILogger<OrderProcessingService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<OrderResult> ProcessOrderAsync(OrderRequest order)
        {
            var result = new OrderResult();

            var inventoryAddress = _config["GrpcServices:InventoryService"];
            var paymentAddress = _config["GrpcServices:PaymentService"];

            using var inventoryChannel = GrpcChannel.ForAddress(inventoryAddress!);
            using var paymentChannel = GrpcChannel.ForAddress(paymentAddress!);

            var inventoryClient = new InventoryService.Protos.InventoryService.InventoryServiceClient(inventoryChannel);
            var paymentClient = new Payment.PaymentClient(paymentChannel);

            foreach (var item in order.Items)
            {
                var inventoryReply = await inventoryClient.DeductQuantityAsync(new DeductQuantityRequest
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity
                });

                _logger.LogInformation("Inventory response: {Message}", inventoryReply.Message);
                result.Messages.Add($"Inventory {inventoryReply.Message}");

                if (!inventoryReply.Success)
                {
                    result.Success = false;
                    return result;
                }
            }

            var totalAmount = order.Items.Sum(i => ItemPrices.GetPrice(i.ItemId) * i.Quantity);

            var paymentReply = await paymentClient.DeductBalanceAsync(new DeductBalanceRequest
            {
                UserId = order.UserId,
                Amount = totalAmount
            });

            _logger.LogInformation("Payment response: {Message}", paymentReply.Message);
            result.Messages.Add($"Payment {paymentReply.Message}");
            result.Success = paymentReply.Success;

            return result;
        }
    }
}

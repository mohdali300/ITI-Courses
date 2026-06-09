using Grpc.Core;
using Orders.InventoryService.Protos;
using static Orders.InventoryService.Protos.InventoryService;

namespace Orders.InventoryService.Services
{
    public class InventoryGrpcService : InventoryServiceBase
    {
        private readonly ILogger<InventoryGrpcService> _logger;

        private static readonly Dictionary<int, int> _stock = new()
        {
            { 1, 100 },
            { 2, 50 },
            { 3, 200 },
            { 4, 20 },
            { 5, 80 },
            { 6, 150 },
        };

        public InventoryGrpcService(ILogger<InventoryGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<DeductQuantityResponse> DeductQuantity(
            DeductQuantityRequest request, ServerCallContext context)
        {
            _logger.LogInformation("DeductQuantity called: itemId={ItemId}, qty={Qty}",
                request.ItemId, request.Quantity);

            if (!_stock.TryGetValue(request.ItemId, out var currentStock))
                return Task.FromResult(new DeductQuantityResponse
                {
                    Success = false,
                    Message = $"Item '{request.ItemId}' not found."
                });

            if (currentStock < request.Quantity)
                return Task.FromResult(new DeductQuantityResponse
                {
                    Success = false,
                    Message = $"Insufficient stock for '{request.ItemId}'. Available: {currentStock}."
                });

            _stock[request.ItemId] -= request.Quantity;

            return Task.FromResult(new DeductQuantityResponse
            {
                Success = true,
                Message = $"Deducted {request.Quantity} from '{request.ItemId}'. Remaining: {_stock[request.ItemId]}."
            });
        }
    }
}
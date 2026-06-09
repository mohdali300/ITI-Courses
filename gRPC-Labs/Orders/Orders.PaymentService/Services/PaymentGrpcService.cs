using Grpc.Core;
using Orders.PaymentService.Protos;
using static Orders.PaymentService.Protos.Payment;

namespace Orders.PaymentService.Services
{
    public class PaymentGrpcService : PaymentBase
    {
        private readonly ILogger<PaymentGrpcService> _logger;

        private static readonly Dictionary<string, double> _balances = new()
        {
            { "user1", 500.00 },
            { "user2", 150.00 },
            { "user3", 1000.00 },
        };

        public PaymentGrpcService(ILogger<PaymentGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<DeductBalanceResponse> DeductBalance(
            DeductBalanceRequest request, ServerCallContext context)
        {
            _logger.LogInformation("DeductBalance called: userId={UserId}, amount={Amount}",
                request.UserId, request.Amount);

            if (!_balances.TryGetValue(request.UserId, out var currentBalance))
                return Task.FromResult(new DeductBalanceResponse
                {
                    Success = false,
                    Message = $"User '{request.UserId}' not found."
                });

            if (currentBalance < request.Amount)
                return Task.FromResult(new DeductBalanceResponse
                {
                    Success = false,
                    Message = $"Insufficient balance for '{request.UserId}'. Available: {currentBalance:C}."
                });

            _balances[request.UserId] -= request.Amount;

            return Task.FromResult(new DeductBalanceResponse
            {
                Success = true,
                Message = $"Deducted {request.Amount:C} from '{request.UserId}'. Remaining: {_balances[request.UserId]:C}."
            });
        }
    }
}

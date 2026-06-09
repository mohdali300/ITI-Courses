using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Models;
using Orders.API.Services;

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderProcessingService _orderService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId) || request.Items.Count == 0)
                return BadRequest("UserId and at least one item are required.");

            var result = await _orderService.ProcessOrderAsync(request);

            if (result.Success)
                return Ok(result);

            return UnprocessableEntity(result);
        }
    }
}

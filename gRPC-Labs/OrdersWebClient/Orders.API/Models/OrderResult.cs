namespace Orders.API.Models
{
    public class OrderResult
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}

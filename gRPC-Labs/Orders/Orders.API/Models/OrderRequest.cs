namespace Orders.API.Models
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}

namespace Orders.API.Data
{
    public static class ItemPrices
    {
        private static readonly Dictionary<int, double> _prices = new()
        {
            { 1, 29 },
            { 2, 50 },
            { 3, 10 },
            { 4, 75 },
            { 5, 30 },
            { 6, 12 },
        };

        public static double GetPrice(int itemId) =>
            _prices.TryGetValue(itemId, out var price) ? price : 0;
    }
}

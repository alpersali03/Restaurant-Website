namespace Restaurant.DTOs
{
    public class OrderItemFormDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public List<ProductDto> Products { get; set; } = new();
    }
}

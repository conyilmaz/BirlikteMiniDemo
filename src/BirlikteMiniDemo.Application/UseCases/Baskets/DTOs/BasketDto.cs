namespace BirlikteMiniDemo.Application.UseCases.Baskets.DTOs
{
    public class BasketDto
    {
        public Guid BasketId { get; set; } 
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>(); 
        public decimal TotalPrice { get; set; } 
    }

    public class BasketItemDto
    {
        public Guid ProductId { get; set; } 
        public string ProductTitle { get; set; } = string.Empty; 
        public int Quantity { get; set; } 
        public decimal Price { get; set; } 
    }
}

namespace BirlikteMiniDemo.Application.UseCases.Products.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}

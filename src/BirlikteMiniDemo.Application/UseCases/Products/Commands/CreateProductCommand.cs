using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Base64Image { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}

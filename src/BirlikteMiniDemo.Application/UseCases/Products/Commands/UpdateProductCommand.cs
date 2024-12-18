using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Products.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Base64Image { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}

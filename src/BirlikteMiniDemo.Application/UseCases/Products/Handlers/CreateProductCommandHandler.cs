using MediatR;
using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Products.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductService _productService;
        private readonly string _imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
            string? imageUrl = null;
            if (!string.IsNullOrEmpty(request.Base64Image))
            {
                imageUrl = SaveImage(request.Base64Image);
            }

            var product = new Product
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                ImageUrl = imageUrl
            };

            return await _productService.CreateProductAsync(product);
        }

        private string SaveImage(string base64Image)
        {
            var imageBytes = Convert.FromBase64String(base64Image);
            var fileName = $"{Guid.NewGuid()}.png";
            var filePath = Path.Combine(_imageUploadPath, fileName);

            if (!Directory.Exists(_imageUploadPath))
                Directory.CreateDirectory(_imageUploadPath);

            File.WriteAllBytes(filePath, imageBytes);

            return $"/uploads/products/{fileName}";
        }
    }
}

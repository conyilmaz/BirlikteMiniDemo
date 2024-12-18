using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Products.Commands;
using BirlikteMiniDemo.Domain.Entities;

namespace BirlikteMiniDemo.Application.UseCases.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductService _productService;
        private readonly string _imageUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
         
            string? imageUrl = null;
            if (!string.IsNullOrEmpty(request.Base64Image))
            {
                imageUrl = SaveImage(request.Base64Image);
            }

       
            var product = new Product
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                ImageUrl = imageUrl
            };

            await _productService.UpdateProductAsync(product);
            return Unit.Value;
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

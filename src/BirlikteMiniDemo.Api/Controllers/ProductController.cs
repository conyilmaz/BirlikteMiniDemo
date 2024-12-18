using MediatR;
using Microsoft.AspNetCore.Mvc;
using BirlikteMiniDemo.Application.UseCases.Products.Commands;
using BirlikteMiniDemo.Application.UseCases.Products.Queries;

namespace BirlikteMiniDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { ProductId = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(Guid id)
        {
            var product = await _mediator.Send(new GetProductDetailQuery { Id = id });
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return Ok(products);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using BirlikteMiniDemo.Application.UseCases.Baskets.Commands;
using BirlikteMiniDemo.Application.UseCases.Baskets.Queries;

namespace BirlikteMiniDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{basketId}/add-product")]
        public async Task<IActionResult> AddProductToBasket(Guid basketId, [FromBody] AddProductToBasketCommand command)
        {
            command.BasketId = basketId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{basketId}/remove-product/{productId}")]
        public async Task<IActionResult> RemoveProductFromBasket(Guid basketId, Guid productId)
        {
            await _mediator.Send(new RemoveProductFromBasketCommand { BasketId = basketId, ProductId = productId });
            return NoContent();
        }

        [HttpGet("{basketId}")]
        public async Task<IActionResult> GetBasketDetail(Guid basketId)
        {
            var basket = await _mediator.Send(new GetBasketDetailQuery { BasketId = basketId });
            return Ok(basket);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using BirlikteMiniDemo.Application.UseCases.Categories.Commands;
using BirlikteMiniDemo.Application.UseCases.Categories.Queries;

namespace BirlikteMiniDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { CategoryId = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetail(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryDetailQuery { Id = id });
            return Ok(category);
        }
    }
}

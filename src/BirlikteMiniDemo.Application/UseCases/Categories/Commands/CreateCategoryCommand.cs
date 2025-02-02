﻿using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
    }
}

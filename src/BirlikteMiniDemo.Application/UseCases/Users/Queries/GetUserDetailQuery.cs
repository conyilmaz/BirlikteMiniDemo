using MediatR;
using BirlikteMiniDemo.Application.UseCases.Users.DTOs;

namespace BirlikteMiniDemo.Application.UseCases.Users.Queries
{
    public class GetUserDetailQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}

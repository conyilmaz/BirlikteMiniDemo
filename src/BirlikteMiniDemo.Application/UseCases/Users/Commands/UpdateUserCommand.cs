using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

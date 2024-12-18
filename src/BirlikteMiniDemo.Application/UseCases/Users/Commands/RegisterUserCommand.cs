using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Users.Commands
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

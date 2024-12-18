using MediatR;
using BirlikteMiniDemo.Domain.Entities;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Users.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Users.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // İş mantığı servise devredilir
            var userId = await _userService.RegisterUserAsync(request.Email, request.Password);
            return userId;
        }
    }
}

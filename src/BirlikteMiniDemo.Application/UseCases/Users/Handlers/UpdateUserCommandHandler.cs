using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Users.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserAsync(request.Id, request.Email,request.Password);
            return request.Id; 
        }
    }
}

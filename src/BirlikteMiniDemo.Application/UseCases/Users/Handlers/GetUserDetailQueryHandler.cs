using MediatR;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Users.Queries;
using BirlikteMiniDemo.Application.UseCases.Users.DTOs;

namespace BirlikteMiniDemo.Application.UseCases.Users.Handlers
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserDetailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                BasketId = user.Basket?.Id
            };
        }
    }
}

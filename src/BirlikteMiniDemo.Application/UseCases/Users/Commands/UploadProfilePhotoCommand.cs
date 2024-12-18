using MediatR;

namespace BirlikteMiniDemo.Application.UseCases.Users.Commands
{
    public class UploadProfilePhotoCommand : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Base64Photo { get; set; } = null!;
    }
}

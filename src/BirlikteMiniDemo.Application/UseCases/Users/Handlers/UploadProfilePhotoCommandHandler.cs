using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BirlikteMiniDemo.Domain.Services;
using BirlikteMiniDemo.Application.UseCases.Users.Commands;

namespace BirlikteMiniDemo.Application.UseCases.Users.Handlers
{
    public class UploadProfilePhotoCommandHandler : IRequestHandler<UploadProfilePhotoCommand, string>
    {
        private readonly IUserService _userService;

        public UploadProfilePhotoCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(UploadProfilePhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");

            var photoBytes = Convert.FromBase64String(request.Base64Photo);

          
            var fileName = $"{request.UserId}_{Guid.NewGuid()}.jpg"; 
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "profile_photos", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

          
            await File.WriteAllBytesAsync(filePath, photoBytes, cancellationToken);

            user.ProfilePhotoUrl = $"/uploads/profile_photos/{fileName}";
            await _userService.UpdateUserAsync(user.Id, user.Email,user.Password);

            return user.ProfilePhotoUrl;
        }
    }
}

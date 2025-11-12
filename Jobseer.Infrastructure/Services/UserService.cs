using Jobseer.Application.Features.User.Dtos;
using Jobseer.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Jobseer.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto payload)
        {
            var result = await _signInManager.PasswordSignInAsync(
                payload.Email,
                payload.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
            {
                throw new Exception("Invalid login attempt");
            }

            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new LoginResponseDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                Username = user.UserName ?? string.Empty
            };
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterDto payload)
        {
            var user = new IdentityUser
            {
                UserName = payload.Email,
                Email = payload.Email
            };

            var result = await _userManager.CreateAsync(user, payload.Password);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMessage);
            }

            return new RegisterResponseDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                Username = user.UserName ?? string.Empty,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}

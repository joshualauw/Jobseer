using Jobseer.Application.Features.User.Dtos;
using Jobseer.Application.Interfaces;
using Jobseer.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Jobseer.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

            var token = await _tokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                Username = user.UserName ?? string.Empty,
                Token = token,
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

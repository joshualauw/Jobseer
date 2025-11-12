using Jobseer.Application.Features.User.Commands.CreateUser;
using Jobseer.Application.Features.User.Dtos;

namespace Jobseer.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterDto payload);
        Task<LoginResponseDto> LoginAsync(LoginDto payload);
    }
}

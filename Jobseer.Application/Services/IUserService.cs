using Jobseer.Application.Features.User.Commands.CreateUser;

namespace Jobseer.Application.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserCommand payload);
    }
}

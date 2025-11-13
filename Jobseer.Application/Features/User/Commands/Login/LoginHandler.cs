using Jobseer.Application.Features.User.Dtos;
using Jobseer.Application.Interfaces;
using MediatR;

namespace Jobseer.Application.Features.User.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserService _userService;
        public LoginHandler(IUserService userService) 
        {
            _userService = userService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginDto = new LoginDto()
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.LoginAsync(loginDto);

            var response = new LoginResponse()
            {
                Id = result.Id,
                Username = result.Username,
                Email = result.Email,
                Token = result.Token,
            };

            return response;
        }
    }
}

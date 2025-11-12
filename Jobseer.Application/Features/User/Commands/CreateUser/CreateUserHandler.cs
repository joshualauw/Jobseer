using Jobseer.Application.Interfaces;
using Jobseer.Application.Features.User.Dtos;
using MediatR;

namespace Jobseer.Application.Features.User.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var registerDto = new RegisterDto()
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.RegisterAsync(registerDto);

            var response = new CreateUserResponse()
            {
                Id = result.Id,
                Email = result.Email,
                Username = result.Username,
                CreatedAt = result.CreatedAt
            };

            return response;
        }
    }
}

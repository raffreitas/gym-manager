using GymManager.Application.ViewModels;

using MediatR;

namespace GymManager.Application.Commands.AuthenticateUser;
public class AuthenticateUserCommand : IRequest<AuthenticateViewModel>
{
    public AuthenticateUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
}

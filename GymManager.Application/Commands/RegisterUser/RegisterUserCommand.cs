using MediatR;

namespace GymManager.Application.Commands.RegisterUser;
public class RegisterUserCommand : IRequest
{
    public RegisterUserCommand(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}

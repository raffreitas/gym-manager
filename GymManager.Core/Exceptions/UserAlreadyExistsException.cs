namespace GymManager.Core.Exceptions;
public class UserAlreadyExistsException : DomainException
{
    private const string ErrorMessage = "Este usuário já existe";
    public UserAlreadyExistsException()
        : base(ErrorMessage)
    {
    }
}

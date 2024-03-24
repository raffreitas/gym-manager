namespace GymManager.Core.Exceptions;
public class InvalidLoginException : DomainException
{
    private const string DefaultErrorMessage = "Usuário ou senhas inválidos";
    public InvalidLoginException()
        : base(DefaultErrorMessage)
    {
    }
}

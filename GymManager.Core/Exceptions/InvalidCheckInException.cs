namespace GymManager.Core.Exceptions;
public class InvalidCheckInException : DomainException
{
    private const string DefaultErrorMessage = "Não foi possivel realizar o check-in";
    public InvalidCheckInException(string message = DefaultErrorMessage) : base(message)
    {
    }
}

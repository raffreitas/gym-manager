namespace GymManager.Core.Exceptions;
public class ResourceNotFoundException : DomainException
{
    private const string DefaultErrorMessage = "Not Found";
    public ResourceNotFoundException()
        : base(DefaultErrorMessage)
    {
    }
}

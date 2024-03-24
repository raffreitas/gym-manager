namespace GymManager.Application.ViewModels;
public class AuthenticateViewModel
{
    public AuthenticateViewModel(Guid id, string token)
    {
        Id = id;
        Token = token;
    }

    public Guid Id { get; private set; }
    public string Token { get; private set; }
}

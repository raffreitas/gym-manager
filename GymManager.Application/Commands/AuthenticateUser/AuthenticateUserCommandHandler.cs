using GymManager.Application.ViewModels;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;
using GymManager.Core.Services;

using MediatR;

namespace GymManager.Application.Commands.AuthenticateUser;
public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public AuthenticateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }
    public async Task<AuthenticateViewModel> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
            throw new InvalidLoginException();

        var passwordHash = _authService.HashPassword(request.Password);

        if (!user.Password.Equals(passwordHash))
            throw new InvalidLoginException();

        var token = _authService.GenerateToken(user.Id, user.Role);

        var authenticateViewModel = new AuthenticateViewModel(user.Id, token);

        return authenticateViewModel;
    }
}

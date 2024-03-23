using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;
using GymManager.Core.Services;

using MediatR;

namespace GymManager.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userWithSameEmail = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (userWithSameEmail is not null)
        {
            throw new UserAlreadyExistsException();
        }

        var passwordHash = _authService.HashPassword(request.Password);

        var user = new User(request.Name, request.Email, passwordHash);

        await _userRepository.AddAsync(user, cancellationToken);
    }
}

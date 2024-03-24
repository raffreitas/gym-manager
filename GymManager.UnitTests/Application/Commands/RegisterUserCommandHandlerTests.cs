using GymManager.Application.Commands.RegisterUser;
using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;
using GymManager.Core.Services;

using NSubstitute;

namespace GymManager.UnitTests.Application.Commands;
public class RegisterUserCommandHandlerTests
{
    [Fact]
    public async Task AlreadyExistsUserWithSameEmail_Executed_ReturnUserAlreadyExistsException()
    {
        // Arange
        var userOnDatabase = new User("Test", "test@test.com", "P4SSW0RD**");

        var userRepository = Substitute.For<IUserRepository>();
        userRepository.GetByEmailAsync(userOnDatabase.Email, Arg.Any<CancellationToken>())
            .Returns(userOnDatabase);

        var authService = Substitute.For<IAuthService>();

        var registerUserCommand = new RegisterUserCommand("Test", "test@test.com", "P4SSW0RD**");
        var registerUserCommandHandler = new RegisterUserCommandHandler(userRepository, authService);

        // Act & Assert
        await Assert.ThrowsAsync<UserAlreadyExistsException>(
            async () => await registerUserCommandHandler.Handle(registerUserCommand, new CancellationToken())
        );
        await userRepository.Received(1).GetByEmailAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task InputDataIsOk_Executed_UserIsCreated()
    {
        // Arrange
        var userRepository = Substitute.For<IUserRepository>();
        var authService = Substitute.For<IAuthService>();

        var registerUserCommand = new RegisterUserCommand("Test", "test@test.com", "P4SSW0RD**");
        var registerUserCommandHandler = new RegisterUserCommandHandler(userRepository, authService);

        // Act
        await registerUserCommandHandler.Handle(registerUserCommand, new CancellationToken());

        // Assert
        await userRepository.Received(1).GetByEmailAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
        await userRepository.Received(1).AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }
}

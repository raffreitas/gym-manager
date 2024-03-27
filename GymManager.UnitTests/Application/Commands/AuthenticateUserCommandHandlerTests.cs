using GymManager.Application.Commands.AuthenticateUser;
using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;
using GymManager.Core.Services;

using NSubstitute;

namespace GymManager.UnitTests.Application.Commands;
public class AuthenticateUserCommandHandlerTests
{
    [Fact]
    public async void UserWithEmailNotExists_Execute_ThrowsInvalidLoginException()
    {
        // Arrange
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var authServiceMock = Substitute.For<IAuthService>();

        var authenticateUserCommand = new AuthenticateUserCommand("test@test.com", "123");
        var authenticateUserCommandHandler = new AuthenticateUserCommandHandler(userRepositoryMock, authServiceMock);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidLoginException>(async () =>
        {
            await authenticateUserCommandHandler.Handle(authenticateUserCommand, CancellationToken.None);
        });
        await userRepositoryMock.Received(1).GetByEmailAsync(Arg.Any<string>(), CancellationToken.None);
    }

    [Fact]
    public async void UserPasswordDoesNotMatch_Executed_ThrowsInvalidLoginException()
    {
        // Arrange
        var userOnDatabase = new User("Test", "test@test.com", "P4SSW0RD**");

        var userRepositoryMock = Substitute.For<IUserRepository>();
        userRepositoryMock.GetByEmailAsync(Arg.Any<string>(), CancellationToken.None)
            .Returns(userOnDatabase);

        var authServiceMock = Substitute.For<IAuthService>();

        authServiceMock.HashPassword(Arg.Any<string>())
            .Returns("TEST");

        var authenticateUserCommand = new AuthenticateUserCommand("test@test.com", "123");
        var authenticateUserCommandHandler = new AuthenticateUserCommandHandler(userRepositoryMock, authServiceMock);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidLoginException>(async () =>
        {
            await authenticateUserCommandHandler.Handle(authenticateUserCommand, CancellationToken.None);
        });
        await userRepositoryMock.Received(1).GetByEmailAsync(Arg.Any<string>(), CancellationToken.None);
    }

    [Fact]
    public async void InputDataIsOk_Exceuted_ReturnAccessToken()
    {
        // Arrange
        var userOnDatabase = new User("Test", "test@test.com", "P4SSW0RD**");

        var userRepositoryMock = Substitute.For<IUserRepository>();
        userRepositoryMock.GetByEmailAsync(Arg.Any<string>(), CancellationToken.None)
            .Returns(userOnDatabase);

        var authServiceMock = Substitute.For<IAuthService>();

        authServiceMock.HashPassword(Arg.Any<string>())
            .Returns(userOnDatabase.Password);

        var authenticateUserCommand = new AuthenticateUserCommand("test@test.com", "123");
        var authenticateUserCommandHandler = new AuthenticateUserCommandHandler(userRepositoryMock, authServiceMock);

        // Act
        var authenticateViewModel = await authenticateUserCommandHandler.Handle(authenticateUserCommand, CancellationToken.None);

        // Assert
        Assert.NotNull(authenticateViewModel);
        Assert.IsType<Guid>(authenticateViewModel.Id);
        Assert.IsType<string>(authenticateViewModel.Token);
        await userRepositoryMock.Received(1).GetByEmailAsync(Arg.Any<string>(), CancellationToken.None);
    }
}

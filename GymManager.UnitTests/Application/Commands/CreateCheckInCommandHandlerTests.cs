using GymManager.Application.Commands.CreateCheckIn;
using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;

using NSubstitute;

namespace GymManager.UnitTests.Application.Commands;
public class CreateCheckInCommandHandlerTests
{
    [Fact]
    public async void InputDataIsOk_Executed_CheckInIsCreated()
    {
        // Arrange
        var gym = new Gym("Test Gym", -20.2441203m, -46.3651947m);
        var user = new User("Test", "test@test.com", "12345");

        var gymRepositoryMock = Substitute.For<IGymRepository>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();

        gymRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(gym);
        userRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(user);


        var createCheckInCommand = new CreateCheckInCommand(Guid.NewGuid(), Guid.NewGuid(), -20.2464657m, -46.365935m);

        var createCheckInCommandHandler = new CreateCheckInCommandHandler(
            gymRepositoryMock,
            checkInRepositoryMock,
            userRepositoryMock
        );

        // Act

        await createCheckInCommandHandler.Handle(createCheckInCommand, CancellationToken.None);

        // Assert
        await checkInRepositoryMock.Received(1).AddAsync(Arg.Any<CheckIn>());
    }

    [Fact]
    public async void DistanceBetweenUserIsGreaterThenValid_Executed_ThrowAnException()
    {
        // Arrange
        var gym = new Gym("Test Gym", -20.2441203m, -46.3651947m);
        var user = new User("Test", "test@test.com", "12345");

        var gymRepositoryMock = Substitute.For<IGymRepository>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();

        gymRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(gym);
        userRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(user);


        var createCheckInCommand = new CreateCheckInCommand(Guid.NewGuid(), Guid.NewGuid(), 0, 0);

        var createCheckInCommandHandler = new CreateCheckInCommandHandler(
            gymRepositoryMock,
            checkInRepositoryMock,
            userRepositoryMock
        );

        // Act & Assert
        await Assert.ThrowsAsync<InvalidCheckInException>(async () =>
        {
            await createCheckInCommandHandler.Handle(createCheckInCommand, CancellationToken.None);
        });
    }

    [Fact]
    public async void UserAlreadyCheckInOnSameDay_Executed_ThrowAnException()
    {
        // Arrange
        var gym = new Gym("Test Gym", -20.2441203m, -46.3651947m);
        var user = new User("Test", "test@test.com", "12345");
        var checkIn = new CheckIn(gym, user);

        var gymRepositoryMock = Substitute.For<IGymRepository>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();

        gymRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(gym);
        userRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(user);
        checkInRepositoryMock.GetByUserIdOnDate(Arg.Any<Guid>(), Arg.Any<DateTime>(), CancellationToken.None)
            .Returns(checkIn);

        var createCheckInCommand = new CreateCheckInCommand(Guid.NewGuid(), Guid.NewGuid(), 0, 0);

        var createCheckInCommandHandler = new CreateCheckInCommandHandler(
            gymRepositoryMock,
            checkInRepositoryMock,
            userRepositoryMock
        );

        // Act & Assert
        await Assert.ThrowsAsync<InvalidCheckInException>(async () =>
        {
            await createCheckInCommandHandler.Handle(createCheckInCommand, CancellationToken.None);
        });
    }

    [Fact]
    public async void GymNotExists_Executed_ThrowAnException()
    {
        // Arrange
        var user = new User("Test", "test@test.com", "12345");

        var gymRepositoryMock = Substitute.For<IGymRepository>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();

        userRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(user);

        var createCheckInCommand = new CreateCheckInCommand(Guid.NewGuid(), Guid.NewGuid(), 0, 0);

        var createCheckInCommandHandler = new CreateCheckInCommandHandler(
            gymRepositoryMock,
            checkInRepositoryMock,
            userRepositoryMock
        );

        // Act & Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(async () =>
        {
            await createCheckInCommandHandler.Handle(createCheckInCommand, CancellationToken.None);
        });
    }

    [Fact]
    public async void UserNotExists_Executed_ThrowAnException()
    {
        // Arrange
        var gym = new Gym("Test Gym", -20.2441203m, -46.3651947m);

        var gymRepositoryMock = Substitute.For<IGymRepository>();
        var userRepositoryMock = Substitute.For<IUserRepository>();
        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();

        gymRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(gym);

        var createCheckInCommand = new CreateCheckInCommand(Guid.NewGuid(), Guid.NewGuid(), 0, 0);

        var createCheckInCommandHandler = new CreateCheckInCommandHandler(
            gymRepositoryMock,
            checkInRepositoryMock,
            userRepositoryMock
        );

        // Act & Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(async () =>
        {
            await createCheckInCommandHandler.Handle(createCheckInCommand, CancellationToken.None);
        });
    }
}

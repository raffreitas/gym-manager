using GymManager.Application.Commands.ValidateCheckIn;
using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using NSubstitute;

namespace GymManager.UnitTests.Application.Commands;
public class ValidateCheckInCommandHandlerTests
{
    [Fact]
    public async void InputIsOk_Executed_CheckInIsValidated()
    {
        // Arrange
        var user = new User("test", "test@test.com", "1235");
        var gym = new Gym("Test Gym", -20.2441203m, -46.3651947m);
        var checkIn = new CheckIn(gym, user);

        var checkInRepositoryMock = Substitute.For<ICheckInRepository>();
        checkInRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(checkIn);

        var validateCheckInCommand = new ValidateCheckInCommand(Guid.NewGuid());
        var validateCheckInCommandHandler = new ValidateCheckInCommandHandler(checkInRepositoryMock);

        // Act
        await validateCheckInCommandHandler.Handle(validateCheckInCommand, CancellationToken.None);

        // Assert
        Assert.NotNull(checkIn.ValidatedAt);
        await checkInRepositoryMock.Received(1).SaveChangesAsync(CancellationToken.None);
    }
}

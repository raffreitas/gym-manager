using GymManager.Application.Commands.CreateGym;

using GymManager.Core.Entities;
using GymManager.Core.Repositories;

using NSubstitute;

namespace GymManager.UnitTests.Application.Commands;
public class CreateGymCommandHandlerTests
{
    [Fact]
    public async void InputDataIsOk_Execute_GymIsCreated()
    {
        // Arrange
        var gymRepositoryMock = Substitute.For<IGymRepository>();

        var createGymCommand = new CreateGymCommand("Test Title", "Test Description", "Test phone", 123, 123);
        var createGymCommandHandler = new CreateGymCommandHandler(gymRepositoryMock);
        // Act

        await createGymCommandHandler.Handle(createGymCommand, CancellationToken.None);

        // Assert
        await gymRepositoryMock.Received(1).AddAsync(Arg.Any<Gym>(), CancellationToken.None);
    }
}

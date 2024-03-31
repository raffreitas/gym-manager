using GymManager.Application.Queries.GetUserProfile;
using GymManager.Core.Entities;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;

using NSubstitute;

namespace GymManager.UnitTests.Application.Queries;
public class GetUserProfileQueryHandlerTests
{
    [Fact]
    public async void UserExists_Executed_ReturnsUserProfileViewModel()
    {
        // Arrange
        var user = new User("test", "Test@test.com", "txtxtx");
        var userRepositoryMock = Substitute.For<IUserRepository>();
        userRepositoryMock.GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None)
            .Returns(user);

        var getUserProfileQuery = new GetUserProfileQuery(Guid.NewGuid());
        var getUserProfileQueryHandler = new GetUserProfileQueryHandler(userRepositoryMock);

        // Act
        var userProfileViewModel = await getUserProfileQueryHandler.Handle(getUserProfileQuery, CancellationToken.None);

        // Assert
        Assert.NotNull(userProfileViewModel);
        await userRepositoryMock.Received(1).GetByIdAsync(Arg.Any<Guid>(), CancellationToken.None);
    }

    [Fact]
    public async void UserNotExists_Executed_ThrowsResourceNotFoundExecption()
    {
        // Arrange
        var userRepositoryMock = Substitute.For<IUserRepository>();

        var getUserProfileQuery = new GetUserProfileQuery(Guid.NewGuid());
        var getUserProfileQueryHandler = new GetUserProfileQueryHandler(userRepositoryMock);

        // Act & Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(async () =>
        {
            var userProfileViewModel = await getUserProfileQueryHandler.Handle(getUserProfileQuery, CancellationToken.None);
        });
    }
}

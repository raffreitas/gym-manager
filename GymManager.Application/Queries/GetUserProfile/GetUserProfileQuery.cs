using GymManager.Application.ViewModels;

using MediatR;

namespace GymManager.Application.Queries.GetUserProfile;
public class GetUserProfileQuery : IRequest<UserProfileViewModel>
{
    public GetUserProfileQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}

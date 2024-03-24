using System.Runtime.CompilerServices;

using GymManager.Application.ViewModels;
using GymManager.Core.Exceptions;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Queries.GetUserProfile;
public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserProfileQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserProfileViewModel> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            throw new ResourceNotFoundException();
        }

        var userProfileViewModel = new UserProfileViewModel(user.Id, user.Name, user.Email, user.Role, user.CreatedAt);

        return userProfileViewModel;
    }
}

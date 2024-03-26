using GymManager.Application.ViewModels;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Queries.SearchNearbyGyms;
public class SearchNearbyGymsQueryHandler : IRequestHandler<SearchNearbyGymsQuery, IList<GymViewModel>>
{
    private readonly IGymRepository _gymRepository;

    public SearchNearbyGymsQueryHandler(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }

    public async Task<IList<GymViewModel>> Handle(SearchNearbyGymsQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _gymRepository.SearchManyNearbyAsync(request.Latitude, request.Longitude, cancellationToken);

        var gymsViewModel = new List<GymViewModel>();

        foreach (var gym in gyms)
        {
            var gymViewModel = new GymViewModel(gym.Title, gym.Description, gym.Phone, gym.Latitude, gym.Longitude);
            gymsViewModel.Add(gymViewModel);
        }

        return gymsViewModel;
    }
}

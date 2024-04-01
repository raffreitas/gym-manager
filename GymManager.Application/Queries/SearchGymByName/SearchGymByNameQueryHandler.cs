using GymManager.Application.ViewModels;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Queries.SearchGymByName;
public class SearchGymByNameQueryHandler : IRequestHandler<SearchGymByNameQuery, IList<GymViewModel>>
{
    private readonly IGymRepository _gymRepository;

    public SearchGymByNameQueryHandler(IGymRepository gymRepository)
    {
        _gymRepository = gymRepository;
    }

    public async Task<IList<GymViewModel>> Handle(SearchGymByNameQuery request, CancellationToken cancellationToken)
    {
        var gyms = await _gymRepository.SearchManyAsync(request.Name, cancellationToken);

        var gymsViewModel = new List<GymViewModel>();

        foreach (var gym in gyms)
        {
            var gymViewModel = new GymViewModel(gym.Title, gym.Description, gym.Phone, gym.Latitude, gym.Longitude);
            gymsViewModel.Add(gymViewModel);
        }

        return gymsViewModel;
    }
}

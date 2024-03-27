using GymManager.Application.ViewModels;

using MediatR;

namespace GymManager.Application.Queries.SearchNearbyGyms;
public class SearchNearbyGymsQuery : IRequest<IList<GymViewModel>>
{
    public SearchNearbyGymsQuery(decimal latitude, decimal longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
}
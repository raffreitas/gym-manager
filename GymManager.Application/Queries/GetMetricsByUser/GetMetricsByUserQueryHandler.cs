using GymManager.Application.ViewModels;
using GymManager.Core.Repositories;

using MediatR;

namespace GymManager.Application.Queries.GetMetricsByUser;
public class GetMetricsByUserQueryHandler : IRequestHandler<GetMetricsByUserQuery, UserMetricsViewModel>
{
    private readonly ICheckInRepository _checkInRepository;

    public GetMetricsByUserQueryHandler(ICheckInRepository checkInRepository)
    {
        _checkInRepository = checkInRepository;
    }

    public async Task<UserMetricsViewModel> Handle(GetMetricsByUserQuery request, CancellationToken cancellationToken)
    {
        var count = await _checkInRepository.CountByUserAsync(request.Id, cancellationToken);

        var userMetricsViewModel = new UserMetricsViewModel(count);

        return userMetricsViewModel;
    }
}

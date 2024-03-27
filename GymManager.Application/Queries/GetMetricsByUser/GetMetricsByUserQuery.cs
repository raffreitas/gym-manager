using GymManager.Application.ViewModels;

using MediatR;

namespace GymManager.Application.Queries.GetMetricsByUser;
public class GetMetricsByUserQuery : IRequest<UserMetricsViewModel>
{
    public GetMetricsByUserQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}

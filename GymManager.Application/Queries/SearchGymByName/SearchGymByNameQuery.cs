using GymManager.Application.ViewModels;

using MediatR;

namespace GymManager.Application.Queries.SearchGymByName;
public class SearchGymByNameQuery : IRequest<IList<GymViewModel>>
{
    public SearchGymByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}

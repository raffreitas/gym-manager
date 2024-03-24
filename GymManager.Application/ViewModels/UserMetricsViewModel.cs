namespace GymManager.Application.ViewModels;
public class UserMetricsViewModel
{
    public UserMetricsViewModel(int count)
    {
        Count = count;
    }

    public int Count { get; private set; }

}

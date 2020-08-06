using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;

namespace Test.MonkeyCache.Client.ViewModels
{
  public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
  {
    private bool _isBusy;
    private bool _isNotConnected;
    private string _title;

    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public bool IsBusy
    {
      get => _isBusy;
      set => SetProperty(ref _isBusy, value);
    }

    public bool IsNotConnected
    {
      get => _isNotConnected;
      set => SetProperty(ref _isNotConnected, value);
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

    protected INavigationService NavigationService { get; private set; }

    public virtual void Destroy()
    {
    }

    public virtual void Initialize(INavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
      Connectivity.ConnectivityChanged -= Network_ConnectivityChanged;
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
      Connectivity.ConnectivityChanged += Network_ConnectivityChanged;
    }

    private void Network_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
    }
  }
}

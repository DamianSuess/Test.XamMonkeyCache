using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Test.MonkeyCache.Client.Models;
using Test.MonkeyCache.Client.Services;
using Xamarin.Essentials;

namespace Test.MonkeyCache.Client.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private string _beverageName;
    private ICacheService _cacheService;
    private IPageDialogService _dialogService;
    private ILogService _log;

    public MainViewModel(INavigationService nav, ILogService logService, IPageDialogService dialogService, ICacheService cacheService)
      : base(nav)
    {
      Title = "Main Page";

      _log = logService;
      _dialogService = dialogService;
      _cacheService = cacheService;

      IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
      IsBusy = false;
    }

    public string BeverageName
    {
      get => _beverageName;
      set => SetProperty(ref _beverageName, value);
    }

    public DelegateCommand CmdGetRandomDrink => new DelegateCommand(OnGetRandomDrinkAsync, () => !IsBusy).ObservesProperty(() => IsBusy);

    public ObservableCollection<CocktailList> DrinkList { get; set; }

    ////public DelegateCommand CmdSampleDialog => new DelegateCommand(OnSampleDialogAsync);
    ////public DelegateCommand CmdSampleLogging => new DelegateCommand(OnSampleLogging);

    /// <summary>
    ///   Gets a random drink name from the site:
    ///   https://www.thecocktaildb.com/api/json/v1/1/random.php
    /// </summary>
    private async void OnGetRandomDrinkAsync()
    {
      IsBusy = true;

      var drinks = await _cacheService.GetRandomBeverageAsync().ConfigureAwait(false);
      if (drinks != null)
      {
        var drink = drinks.Drinks.FirstOrDefault();
        _log.Debug(drink.DrinkName);

        BeverageName = drink.DrinkName;
      }

      ////if (drinks != null)
      ////{
      ////  DrinkList = new ObservableCollection<CocktailList>(drinks);
      ////}

      IsBusy = false;
    }

    ////private async void OnSampleDialogAsync()
    ////{
    ////  // Sample Usage:
    ////  //  https://prismlibrary.com/docs/xamarin-forms/dialogs/page-dialog-service.html
    ////  var result = await _dialogService.DisplayAlertAsync("Alert", "Display a sample pop-up ActionSheet?", "Accept", "Cancel");
    ////  _log.Debug("Response: " + result);
    ////
    ////  if (result)
    ////  {
    ////    var action = await _dialogService.DisplayActionSheetAsync("Sample Action Sheet", "Cancel", null, "Email", "In-App message", "IG");
    ////    _log.Debug("ActionSheet: " + action);
    ////  }
    ////}
    ////
    ////private void OnSampleLogging()
    ////{
    ////  _log.Debug("Debug message.");
    ////  _log.Info("Info message.");
    ////  _log.Warn("Warning message.");
    ////  _log.Error("Error message.");
    ////  _log.Fatal("Fatal-error message.");
    ////}
  }
}

using Prism;
using Prism.Ioc;

namespace Test.MonkeyCache.UWP
{
  public sealed partial class MainPage
  {
    public MainPage()
    {
      this.InitializeComponent();

      // Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path
      // %userprofile%\AppData\Local\Packages\31e6402e-0407-4419-a6c3-7c6d18576017_mm77914cpbf52\LocalCache
      // %userprofile%\AppData\Local\Packages\31e6402e-0407-4419-a6c3-7c6d18576017_mm77914cpbf52\LocalState
      System.Diagnostics.Debug.WriteLine("Barrel Cache Folder (UWP): " + Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path);
      System.Diagnostics.Debug.WriteLine("Barrel Cache Folder (Generic): " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));

      LoadApplication(new Client.App(new UwpInitializer()));
    }
  }

  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}

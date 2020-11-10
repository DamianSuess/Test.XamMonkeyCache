using System;
using System.Net.Http;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using Test.MonkeyCache.Client.Models;
using Xamarin.Essentials;

namespace Test.MonkeyCache.Client.Services
{
  public class CacheService : ICacheService
  {
    private const string ApiHost = "https://www.thecocktaildb.com/api/json/v1";
    private const string ApiKey = "1";
    private ILogService _log;

    public CacheService(ILogService log)
    {
      _log = log;
      Barrel.ApplicationId = "MunkeyCacheSample";
    }

    public async Task<CocktailList> GetRandomBeverageAsync()
    {
      string url = Uri();
      CocktailList drinks = null;

      try
      {
        // Return cached data only if there's no Internet and Cache is not expired
        if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: url))
        {
          return Barrel.Current.Get<CocktailList>(key: url);
          //// return Barrel.Current.Get<IEnumerable<CocktailList>>(key: url);
        }

        using (var client = new HttpClient())
        {
          var json = await client.GetStringAsync(url);
          drinks = Utf8Json.JsonSerializer.Deserialize<CocktailList>(json);
        }

        Barrel.Current.Add(key: url, data: drinks, expireIn: TimeSpan.FromDays(2));
      }
      catch (Exception ex)
      {
        _log.Error($"Failed to get beverages.{Environment.NewLine}{ex.Message}");
      }

      return drinks;
    }

    private string Uri(string filter = "random.php")
    {
      // More examples, https://www.thecocktaildb.com/api.php
      return $"{ApiHost}/{ApiKey}/{filter}";
    }
  }
}

using System;
using System.Collections.Generic;
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

    public CacheService()
    {
      Barrel.ApplicationId = "MunkeyCacheSample";
    }

    public async Task<CocktailList> GetFeedAsync()
    {
      string url = Uri();
      CocktailList drinks = null;

      try
      {
        if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired(key: url))
        {
          // Return our cached data
          return Barrel.Current.Get<CocktailList>(key: url);
          //// return Barrel.Current.Get<IEnumerable<CocktailList>>(key: url);
        }

        var client = new HttpClient();
        var json = await client.GetStringAsync(url);
        drinks = Utf8Json.JsonSerializer.Deserialize<CocktailList>(json);
        //// drinks = Utf8Json.JsonSerializer.Deserialize<IEnumerable<CocktailList>>(json);

        Barrel.Current.Add(key: url, data: drinks, expireIn: TimeSpan.FromDays(2));

        return drinks;
      }
      catch (Exception ex)
      {
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

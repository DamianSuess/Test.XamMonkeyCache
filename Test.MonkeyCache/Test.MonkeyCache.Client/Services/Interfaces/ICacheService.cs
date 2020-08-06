using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.MonkeyCache.Client.Models;

namespace Test.MonkeyCache.Client.Services
{
  public interface ICacheService
  {
    Task<CocktailList> GetFeedAsync();
    //// Task<IEnumerable<CocktailList>> GetFeedAsync();
  }
}

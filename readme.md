# Sample Animated Login Screen

Sample data caching strategy using Xamarin 🐒 Monkey Cache.

Sponsored by Xeno Innovations, this project was made with nerd-love using _Xamarin.Forms and Prism with DryIoc.

This sample uses [The Cocktail DB API](https://www.thecocktaildb.com/api.php) as it's REST API sample for caching.

## NuGets
In this sample uses the following NuGet packages:

This project uses the following NuGets
* [Prism.Forms](https://github.com/PrismLibrary/Prism) _w/ DryIoc_
* MonkeyCache.FileStore 🙈
* [Xamarin.Essentials.Interfaces](https://github.com/rdavisau/essential-interfaces)

## Monkey Cache NuGets

|Name|Description|NuGet|
| ------------------- | -------- | :------------------: |
|🐒 MonkeyCache|Contains base interfaces and helpers|[![NuGet](https://img.shields.io/nuget/v/MonkeyCache.svg?label=NuGet)](https://www.nuget.org/packages/MonkeyCache/)|
|🙊 MonkeyCache.SQLite|A SQLite backing for Monkey Cache|[![NuGet](https://img.shields.io/nuget/v/MonkeyCache.SQLite.svg?label=NuGet)](https://www.nuget.org/packages/MonkeyCache.SQLite/)|
|🙉 MonkeyCache.LiteDB|A LiteDB backing for Monkey Cache|[![NuGet](https://img.shields.io/nuget/v/MonkeyCache.LiteDB.svg?label=NuGet)](https://www.nuget.org/packages/MonkeyCache.LiteDB/)|
|🙈 MonkeyCache.FileStore|A local file based backing for Monkey Cache|[![NuGet](https://img.shields.io/nuget/v/MonkeyCache.FileStore.svg?label=NuGet)](https://www.nuget.org/packages/MonkeyCache.FileStore/)|
|Development Feed| |[MyGet](http://myget.org/F/monkey-cache)|

### Platform Support

Monkey Cache is a .NET Standard 2.0 library, but has some platform specific tweaks for storing data in the correct Cache directory.

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Mac|All|
|Xamarin.Android|API 14+|
|Windows 10 UWP|10.0.16299+|
|.NET Core|2.0+|
|ASP.NET Core|2.0+|
|.NET|4.6.1+|

## References
* [Monkey Cache](https://github.com/jamesmontemagno/monkey-cache)
* [Data caching made simple](https://montemagno.com/data-caching-made-simple-with-monkey-cache/)

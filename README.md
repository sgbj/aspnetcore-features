# Feature gates

> Visual Studio 2017, .NET Core 1.1, C# 7

http://www.batary.io/blog/feature-gates

## Controllers

Disable routes when a feature is off.

```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Feature("Home:About")]
    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    [Feature("Home:Contact")]
    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";

        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
```

## Views

Remove elements from your views when a feature is turned off.

```html
<ul class="nav navbar-nav">
    <li><a asp-area="" asp-controller="Home" asp-action="Index">Home</a></li>
    <li feature="Home:About"><a asp-area="" asp-controller="Home" asp-action="About">About</a></li>
    <li feature="Home:Contact"><a asp-area="" asp-controller="Home" asp-action="Contact">Contact</a></li>
</ul>
```
## Config

Turn features on and off in your `appsettings.json` file.

```json
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "Features": {
    "Home": {
      "About": true,
      "Contact": false
    }
  }
}
```

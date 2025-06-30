using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntraSSODemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace EntraSSODemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
     public IActionResult Index()
    {
        
        var userName = User.Identity?.Name;
        return Content($"歡迎回來，{userName}");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

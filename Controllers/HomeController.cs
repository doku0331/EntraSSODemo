using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntraSSODemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EntraSSODemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GraphServiceClient _graphClient;

    public HomeController(ILogger<HomeController> logger, GraphServiceClient graphClient)
    {
        _logger = logger;
        _graphClient = graphClient;
    }

    [Authorize]
     public IActionResult Index()
    {
        
        ViewBag.UserName = User.Identity?.Name;
        
        return View();
    }

    [HttpGet]
    public IActionResult SignOutUser()
    {
        return SignOut(
            new AuthenticationProperties
            {
                RedirectUri = "/"
            },
            OpenIdConnectDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme
        );
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Me()
    {
        var me = await _graphClient.Me.GetAsync();
        return Ok(me);
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

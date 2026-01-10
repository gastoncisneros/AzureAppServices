using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SitioMVC.Models;

namespace SitioMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        List<Persona> personas = new()
        {
            new Persona { Id = Guid.NewGuid(), Nombre = "Juan" },
            new Persona { Id = Guid.NewGuid(), Nombre = "María" },
            new Persona { Id = Guid.NewGuid(), Nombre = "Pedro" }
        };

        return View(personas);
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

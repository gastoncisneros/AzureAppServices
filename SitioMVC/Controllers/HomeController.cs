using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SitioMVC.Models;

namespace SitioMVC.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        List<Persona> personas = new List<Persona>();
        int cantidadPersonas = _configuration.GetValue<int>("cantidad-personas");

        for (int i = 0; i < cantidadPersonas; i++)
        {
            personas.Add(new Persona { Id = Guid.NewGuid(), Nombre = $"Persona {i}" });
        }

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

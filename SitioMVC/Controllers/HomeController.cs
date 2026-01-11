using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitioMVC.Datos;
using SitioMVC.Models;

namespace SitioMVC.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _configuration = configuration;
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var personas = await _context.Personas.ToListAsync();
        return View(personas);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPersona(CrearPersonaDTO crearPersonaDTO)
    {
        var persona = new Persona { Nombre = crearPersonaDTO.Nombre };

        await _context.Personas.AddAsync(persona);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    } 


    public IActionResult Crear()
    {
        return View();
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

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamMaker_WebApp.Data;
using TeamMaker_WebApp.Models;

namespace TeamMaker_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var players = _context.Players.ToList(); // Pass all players to view
            return View(players);
        }
    }
}

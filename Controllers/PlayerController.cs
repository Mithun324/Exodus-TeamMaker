using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamMaker_WebApp.Data;

namespace TeamMaker_WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var players = _context.Players.ToList();
            return View(players);
        }
    }
}

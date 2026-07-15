using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var players = _context.Players.ToList();
            return View(players);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateTeams(List<int> selectedPlayerIds, int teamCount)
        {
            if (teamCount < 2) teamCount = 2;

            // Validate selection
            if (selectedPlayerIds == null || !selectedPlayerIds.Any())
            {
                TempData["ErrorMessage"] = "Please select at least one player.";
                return RedirectToAction("Index");
            }

            if (selectedPlayerIds.Count < teamCount)
            {
                TempData["ErrorMessage"] = $"You need at least {teamCount} players to make {teamCount} teams.";
                return RedirectToAction("Index");
            }

            // Fetch ONLY selected players
            var selectedPlayers = await _context.Players
                .Where(p => selectedPlayerIds.Contains(p.PlayerId))
                .ToListAsync();

            // Clear old teams
            var oldTeams = await _context.Teams.ToListAsync();
            _context.Teams.RemoveRange(oldTeams);
            await _context.SaveChangesAsync();

            // Shuffle
            var rng = new Random();
            var shuffled = selectedPlayers.OrderBy(_ => rng.Next()).ToList();

            // Create empty teams
            var teams = new List<Team>();
            for (int i = 0; i < teamCount; i++)
            {
                teams.Add(new Team
                {
                    TeamName = $"Team {i + 1}",
                    Players = new List<Player>()
                });
            }

            // Round-robin assign — only selected players
            for (int i = 0; i < shuffled.Count; i++)
            {
                _context.Entry(shuffled[i]).State = EntityState.Unchanged;
                teams[i % teamCount].Players.Add(shuffled[i]);
            }

            _context.Teams.AddRange(teams);
            await _context.SaveChangesAsync();

            return RedirectToAction("GeneratedTeams", "Team");
        }
    }
}


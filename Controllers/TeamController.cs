using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamMaker_WebApp.Data;
using TeamMaker_WebApp.Models;

namespace TeamMaker_WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams
                                .Include(t => t.Players)
                                .ToList();

            return View(teams);
        }

        [HttpPost]
        public IActionResult GenerateTeams(List<int> selectedPlayerIds, int numberOfTeams)
        {
            if (selectedPlayerIds == null || selectedPlayerIds.Count == 0)
            {
                TempData["ErrorMessage"] = "Please select at least one player.";
                return RedirectToAction("Index", "Home");
            }

            if (numberOfTeams <= 0)
            {
                TempData["ErrorMessage"] = "Invalid number of teams.";
                return RedirectToAction("Index", "Home");
            }

            // ==========================================
            // Remove previous team assignments
            // ==========================================

            var allPlayers = _context.Players.ToList();

            foreach (var player in allPlayers)
            {
                player.TeamId = null;
            }

            _context.SaveChanges();

            // ==========================================
            // Delete previous teams
            // ==========================================

            var oldTeams = _context.Teams.ToList();

            if (oldTeams.Any())
            {
                _context.Teams.RemoveRange(oldTeams);
                _context.SaveChanges();
            }

            // ==========================================
            // Get selected players
            // ==========================================

            var players = _context.Players
                                  .Where(p => selectedPlayerIds.Contains(p.PlayerId))
                                  .ToList();

            if (players.Count < numberOfTeams)
            {
                TempData["ErrorMessage"] = "Not enough players to create the selected number of teams.";
                return RedirectToAction("Index", "Home");
            }

            // ==========================================
            // Shuffle players
            // ==========================================

            Random random = new Random();

            players = players
                .OrderBy(x => random.Next())
                .ToList();

            // ==========================================
            // Create teams
            // ==========================================

            List<Team> teams = new();

            for (int i = 0; i < numberOfTeams; i++)
            {
                teams.Add(new Team
                {
                    TeamName = $"Team {i + 1}",
                    Players = new List<Player>()
                });
            }

            // ==========================================
            // Distribute players evenly
            // ==========================================

            for (int i = 0; i < players.Count; i++)
            {
                teams[i % numberOfTeams].Players.Add(players[i]);
            }

            // ==========================================
            // Save new teams
            // ==========================================

            _context.Teams.AddRange(teams);
            _context.SaveChanges();

            return RedirectToAction(nameof(GeneratedTeams));
        }

       
        public IActionResult GeneratedTeams()
        {
            var teams = _context.Teams
                                .Include(t => t.Players)
                                .OrderBy(t => t.TeamId)
                                .ToList();

            return View(teams);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var teams = _context.Teams.Include(t => t.Players).ToList();
            return View("Team"); // Ensure it loads Team.cshtml
        }

        [HttpPost]
        public IActionResult GenerateTeams(List<int> selectedPlayerIds, int numberOfTeams)
        {
            if (selectedPlayerIds == null || selectedPlayerIds.Count == 0)
            {
                return RedirectToAction("Index", "Home"); // Redirect back if no players selected
            }

            var players = _context.Players.Where(p => selectedPlayerIds.Contains(p.PlayerId)).ToList();

            // Ensure the number of teams does not exceed the number of players
            numberOfTeams = Math.Min(numberOfTeams, Math.Max(2, players.Count));

            // Shuffle players randomly
            var random = new Random();
            var shuffledPlayers = players.OrderBy(p => random.Next()).ToList();
            var teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                teams.Add(new Team { TeamName = $"Team {i + 1}", Players = new List<Player>() });
            }

            for (int i = 0; i < shuffledPlayers.Count; i++)
            {
                teams[i % numberOfTeams].Players.Add(shuffledPlayers[i]);
            }

            ViewBag.NumberOfTeams = numberOfTeams; // Pass selected team count to the view
            return View("GeneratedTeams", teams);
        }

        public IActionResult GeneratedTeams()
        {
            return View();
        }
    }
}

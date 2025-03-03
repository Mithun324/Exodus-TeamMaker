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
                TempData["ErrorMessage"] = "Please select at least one player.";
                return RedirectToAction("Index", "Home");
            }

            var players = _context.Players.Where(p => selectedPlayerIds.Contains(p.PlayerId)).ToList();

            if (players.Count < numberOfTeams)
            {
                TempData["ErrorMessage"] = "Not enough players to form the requested number of teams.";
                return RedirectToAction("Index", "Home");
            }

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

            // Save generated teams to the database
            _context.Teams.AddRange(teams);
            _context.SaveChanges();

            ViewBag.NumberOfTeams = numberOfTeams;
            return RedirectToAction("GeneratedTeams");
        }

        public IActionResult GeneratedTeams()
        {
            var teams = _context.Teams
                                .Include(t => t.Players)
                                .OrderByDescending(t => t.TeamId)
                                .ToList();

            return View(teams);
        }
    }
}

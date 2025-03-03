using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamMaker_WebApp.Data;
using TeamMaker_WebApp.Models;

namespace TeamMaker_WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the list of players
        public IActionResult Index()
        {
            var players = _context.Players.ToList();
            return View(players);
        }

        // ---------------------- Edit Player ----------------------

        // GET: Player/Edit/1
        public IActionResult Edit(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Player player)
        {
            if (id != player.PlayerId)
            {
                return BadRequest();
            }

            var existingPlayer = _context.Players.Find(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.PlayerName = player.PlayerName;
            existingPlayer.Position = player.Position;
            existingPlayer.Number = player.Number;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // ---------------------- Delete Player ----------------------

        // GET: Player/Delete/1 (Confirmation Page)
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // ---------------------- Player Details ----------------------

        // GET: Player/Details/1
        public IActionResult Details(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamMaker_WebApp.Data;
using TeamMaker_WebApp.Models;
using TeamMaker_WebApp.ViewModels;

namespace TeamMaker_WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // =======================
        // Display Players
        // =======================
        public async Task<IActionResult> Index(string? position)
        {
            IQueryable<Player> query = _context.Players;

            if (!string.IsNullOrWhiteSpace(position))
            {
                query = query.Where(p => p.Position == position);
            }

            ViewBag.CurrentPosition = position ?? "All";

            return View(await query.AsNoTracking().ToListAsync());
        }

        // =======================
        // Create
        // =======================

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PlayerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var player = new Player
            {
                PlayerName = vm.PlayerName,
                Position = vm.Position,
                Number = vm.Number,
                ImagePath = await SaveImageAsync(vm.ImageFile)
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // Edit
        // =======================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PlayerId == id);

            if (player == null)
                return NotFound();

            var vm = new PlayerViewModel
            {
                PlayerId = player.PlayerId,
                PlayerName = player.PlayerName,
                Position = player.Position,
                Number = player.Number,
                ExistingImagePath = player.ImagePath
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlayerViewModel vm)
        {
            if (id != vm.PlayerId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(vm);

            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            player.PlayerName = vm.PlayerName;
            player.Position = vm.Position;
            player.Number = vm.Number;

            if (vm.ImageFile != null)
            {
                DeleteImageFile(player.ImagePath);
                player.ImagePath = await SaveImageAsync(vm.ImageFile);
            }

            _context.Update(player);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // Details
        // =======================

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var player = await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PlayerId == id);

            if (player == null)
                return NotFound();

            return View(player);
        }

        // =======================
        // Delete
        // =======================

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PlayerId == id);

            if (player == null)
                return NotFound();

            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
                return RedirectToAction(nameof(Index));

            DeleteImageFile(player.ImagePath);

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearAll()
        {
            var allPlayers = await _context.Players.ToListAsync();
            _context.Players.RemoveRange(allPlayers);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // =======================
        // Helper Methods
        // =======================

        private async Task<string?> SaveImageAsync(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            string[] allowedExtensions =
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".webp"
            };

            string extension = Path.GetExtension(imageFile.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                return null;

            string uploadsFolder = Path.Combine(
                _environment.WebRootPath,
                "images",
                "players");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(uploadsFolder, fileName);

            try
            {
                using FileStream stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
            }
            catch
            {
                return null;
            }

            return $"/Images/Players/{fileName}";
        }

        private void DeleteImageFile(string? imagePath)
        {
           
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return;
            }

            try
            {
                string fullPath = Path.Combine(
                    _environment.WebRootPath,
                    imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)
                );

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {

              // _logger.LogError(ex, "Error deleting image file.");


            }
        }

    }
    }

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TeamMaker_WebApp.ViewModels
{
    public class PlayerViewModel
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Player name is required")]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Jersey number is required")]
        [Range(1, 99, ErrorMessage = "Number must be between 1 and 99")]
        [Display(Name = "Jersey Number")]
        public int Number { get; set; }

        [Display(Name = "Player Photo")]
        public IFormFile? ImageFile { get; set; } 

        public string? ExistingImagePath { get; set; } 
    }
}
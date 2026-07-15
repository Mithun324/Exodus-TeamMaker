using System.ComponentModel.DataAnnotations;

namespace TeamMaker_WebApp.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public int Number { get; set; }

        public string? ImagePath { get; set; }

        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
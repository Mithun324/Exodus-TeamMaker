using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamMaker_WebApp.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}

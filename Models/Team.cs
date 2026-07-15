namespace TeamMaker_WebApp.Models  // ← must match
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
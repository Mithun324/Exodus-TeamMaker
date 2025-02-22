using Microsoft.EntityFrameworkCore;
using TeamMaker_WebApp.Models;

namespace TeamMaker_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player { PlayerId = 1, PlayerName = "Mark Himel", Position = "Defender", Number = 19 },
                new Player { PlayerId = 2, PlayerName = "Clamat", Position = "Forward", Number = 20 },
                new Player { PlayerId = 3, PlayerName = "Nipun", Position = "Defender", Number = 30 },
                new Player { PlayerId = 4, PlayerName = "AlexRH", Position = "Forward", Number = 17 },
                new Player { PlayerId = 5, PlayerName = "Ronald", Position = "Forward", Number = 27 },
                new Player { PlayerId = 6, PlayerName = "Protik", Position = "Midfielder", Number = 11 },
                new Player { PlayerId = 7, PlayerName = "Dhrubo", Position = "Forward", Number = 9 },
                new Player { PlayerId = 8, PlayerName = "Chris", Position = "Forward", Number = 14 },
                new Player { PlayerId = 9, PlayerName = "JWH (Joy Da)", Position = "Midfielder", Number = 26 },
                new Player { PlayerId = 10, PlayerName = "O.T. Roy", Position = "Midfielder", Number = 7 },
                new Player { PlayerId = 11, PlayerName = "Stanley", Position = "Goalkeeper", Number = 1 },
                new Player { PlayerId = 12, PlayerName = "Hriday", Position = "Goalkeeper", Number = 18 },
                new Player { PlayerId = 13, PlayerName = "Tanay D.TH", Position = "Defender", Number = 43 },
                new Player { PlayerId = 14, PlayerName = "Mithun", Position = "Forward", Number = 6 },
                new Player { PlayerId = 15, PlayerName = "Edward", Position = "Midfielder", Number = 10 }
            );
        }
    }
}

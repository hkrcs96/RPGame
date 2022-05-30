using Microsoft.EntityFrameworkCore;
using RPGame.Model;

namespace RPGame.Context
{
    public class RPGameSQLiteContext : DbContext
    {
        public RPGameSQLiteContext(DbContextOptions<RPGameSQLiteContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
    }
}
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_rush00.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Habbit> Habbits { get; set; }
        public DbSet<HabitCheck> HabitChecks { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={System.Reflection.Assembly.GetExecutingAssembly().Location}.db");
    }
}
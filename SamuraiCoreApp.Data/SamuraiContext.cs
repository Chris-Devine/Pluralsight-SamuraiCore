using Microsoft.EntityFrameworkCore;
using SamuraiCoreApp.Domain;

namespace SamuraiCoreApp.Data
{
    public class SamuraiContext: DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }


        // Wrong way to to tell EF about DB but it but can be done and works
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = SamuraiCoreData; Trusted_Connection = true;");
        }
    }
}

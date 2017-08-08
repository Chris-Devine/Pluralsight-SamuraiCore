using Microsoft.EntityFrameworkCore;
using SamuraiCoreApp.Domain;

namespace SamuraiCoreApp.Data
{
	public class SamuraiContext : DbContext
	{
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Battle> Battles { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<SamuraiBattle> SamuraiBattles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// NOTE: Create a composite key in the database using entity framework core's Fluent API
			modelBuilder.Entity<SamuraiBattle>()
				.HasKey(s => new {s.BattleId, s.SamuraiId});

			// NOTE: Tells entity framework to enforce that the one to one relation ship is required before insert
			//modelBuilder.Entity<Samurai>()
			//    .Property(s => s.SecretIdentity).IsRequired();

			base.OnModelCreating(modelBuilder);
		}

		// Wrong way to to tell EF about DB but it but can be done and works
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Server = (localdb)\\mssqllocaldb; Database = SamuraiCoreData; Trusted_Connection = true;");

			// NOTE: This allows us to see params passed to database in the logging 
			optionsBuilder.EnableSensitiveDataLogging();
		}
	}
}

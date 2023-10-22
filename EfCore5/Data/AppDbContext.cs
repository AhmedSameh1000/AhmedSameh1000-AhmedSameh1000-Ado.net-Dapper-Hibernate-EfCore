using EfCore5.Data.Configuration;
using EfCore5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCore4.Data
{
	public class AppDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var Config = new ConfigurationBuilder()
			.AddJsonFile("AppSetting.json")
			.Build();
			var Constr = Config.GetSection("ConStr").Value;
			optionsBuilder.UseSqlServer(Constr);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Comment > Comments { get; set; }
		public DbSet<Tweet> Tweets { get; set; }

	}
}

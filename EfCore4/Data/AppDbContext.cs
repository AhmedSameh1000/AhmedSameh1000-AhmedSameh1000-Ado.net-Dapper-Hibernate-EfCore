using EfCore4.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore4.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Wallet> Wallets { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var Config = new ConfigurationBuilder()
			.AddJsonFile("AppSetting.json")
			.Build();
			var Constr = Config.GetSection("ConStr").Value;
			optionsBuilder.UseSqlServer(Constr);
		}

	}
}

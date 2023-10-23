using EfCore7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore7.Data
{
    public class AppDbContext:DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var Config=new ConfigurationBuilder()
				.AddJsonFile("AppSettings.json")
				.Build();
			var ConStr = Config.GetSection("ConStr").Value;
			optionsBuilder.UseSqlServer(ConStr);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Product>()
				.ToTable("Products", "Inventory")
				.HasKey(c => c.Id);

			modelBuilder.Entity<Order>()
				.ToTable("Orders", "Sales")
				.HasKey(c => c.Id);

			modelBuilder.Entity<OrderDetail>()
				.ToTable("OrderDetails", "Sales")
				.HasKey(c => c.Id);

			modelBuilder.Entity<OrderWithDetailsView>()
				.ToView("OrderWithDetailsView")
				.HasNoKey();


			modelBuilder.Entity<OrderBill>()
				.HasNoKey()
				.ToFunction("GetOrderBill");
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<OrderWithDetailsView> OrderWithDetailsView { get; set; }
		public DbSet<OrderBill> OrderBill { get; set; }


	}
}

 
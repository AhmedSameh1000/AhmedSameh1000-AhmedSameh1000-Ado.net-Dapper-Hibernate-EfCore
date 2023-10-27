using EfCore8.Data.Configuration;
using EfCore8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EfCore8.Data
{
	public class AppDbContext:DbContext
	{
		public DbSet<Instructor> Instructors { get; set; } 
		public DbSet<Course> Courses { get; set; } 
		public DbSet<Office>  Offices { get; set; } 
		public DbSet<Schedule> Schedule { get; set; } 
		public DbSet<Section>  Sections { get; set; } 
		public DbSet<Student>  Students { get; set; } 
		public DbSet<EnrollMents>   EnrollMents { get; set; } 
		public DbSet<SectionSchedule>SectionSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var Config = new ConfigurationBuilder()
				.AddJsonFile("AppSettings.json")
				.Build();
			var ConStr = Config.GetSection("ConStr").Value;
			optionsBuilder.UseSqlServer(ConStr);
			base.OnConfiguring(optionsBuilder);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
		}
	}
}

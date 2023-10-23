using EfCore8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore8.Data.Configuration
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c=>c.Id).ValueGeneratedNever();

			builder.Property(c=>c.CourseName)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(c => c.Price)
				.HasPrecision(15, 2); 

			builder.HasData(LoadCourses());

		}

		private static List<Course> LoadCourses()
		{
			return new List<Course>()
			{
				new Course{Id=1,CourseName="Mathemetics",Price=1000},
				new Course{Id=2,CourseName="Physics",Price=2000},
				new Course{Id=3,CourseName="Cemistry",Price=1500},
				new Course{Id=4,CourseName="Biology",Price=1200},
				new Course{Id=5,CourseName="Cs-50",Price=3000}
			};
		}
	}
}

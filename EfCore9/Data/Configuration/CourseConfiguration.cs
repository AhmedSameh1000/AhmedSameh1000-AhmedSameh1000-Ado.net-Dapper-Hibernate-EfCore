using EfCore8.Entities;
using EfCore9;
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


		}
	}	


}

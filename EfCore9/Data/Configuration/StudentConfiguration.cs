using EfCore8.Entities;
using EfCore9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedNever();

			builder.Property(c => c.Name)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired();


	



		}

		
	}
}
 
using EfCore8.Entities;
using EfCore9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedNever();

			builder.Property(c => c.Name)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired();

			builder.HasOne(c => c.Office)
				.WithOne(c => c.Instructor)
				.HasForeignKey<Instructor>(c => c.OfficeId)
				.IsRequired(false);


		}

		
	}	
}
 
using EfCore8.Entities;
using EfCore9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class SectionConfiguration : IEntityTypeConfiguration<Section>
	{
		public void Configure(EntityTypeBuilder<Section> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c=>c.Id).ValueGeneratedNever();

			builder.Property(c=>c.SectionName)
				.HasColumnType("varchar")
				.HasMaxLength(55)
				.IsRequired();



			builder.HasOne(c => c.Course)
				.WithMany(c => c.Sections)
				.HasForeignKey(c => c.CourseId)
				.IsRequired();
			 
			builder.HasOne(c => c.Instructor)
				.WithMany(c => c.Sections)
				.HasForeignKey(c => c.InstructorId)
				.IsRequired(false);

			builder.HasMany(c => c.Students)
				.WithMany(c => c.Sections)
				.UsingEntity<EnrollMents>();

			builder.HasMany(c => c.Schedules)
				.WithMany(c => c.Sections)
				.UsingEntity<SectionSchedule>();
			


		}



	
	}
}

using EfCore8.Entities;
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
			builder.HasData(LoadSection());




		}

		private List<Section> LoadSection()
		{
			return new List<Section>()
			{
				new Section{Id=1,SectionName="S_MA1", CourseId=1,InstructorId=1},
				new Section{Id=2,SectionName="S_MA2", CourseId=1,InstructorId=2},
				new Section{Id=3,SectionName="S_PH1", CourseId=2,InstructorId=1},
				new Section{Id=4,SectionName="S_MA2", CourseId=2,InstructorId=3},
				new Section{Id=5,SectionName="S_CH1", CourseId=3,InstructorId=2},
				new Section{Id=6,SectionName="S_CH2", CourseId=3,InstructorId=3},
				new Section{Id=7,SectionName="S_BI1", CourseId=4,InstructorId=4},
				new Section{Id=8,SectionName="S_BI2", CourseId=4,InstructorId=5},
				new Section{Id=9,SectionName="S_CS1", CourseId=5,InstructorId=4},
				new Section{Id=10,SectionName="S_CS2", CourseId=5,InstructorId=5},
				new Section{Id=11,SectionName="S_CS3", CourseId=5,InstructorId=4},
			};
		}

	
	}
}

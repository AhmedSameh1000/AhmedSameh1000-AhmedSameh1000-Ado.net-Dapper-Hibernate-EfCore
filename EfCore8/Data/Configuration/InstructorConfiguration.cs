using EfCore8.Entities;
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

			builder.HasData(LoadCourses());

		}

		private static List<Instructor> LoadCourses()
		{
			return new List<Instructor>()
			{
				new Instructor{Id=1,Name="Ahmed AbdAllah",OfficeId=1},
				new Instructor{Id=2,Name="Yasmeen Mohamed",OfficeId=2},
				new Instructor{Id=3,Name="Khaled Hassan",OfficeId=3},
				new Instructor{Id=4,Name="Nadia Ali", OfficeId = 4},
				new Instructor{Id=5,Name="Omar Ibrahim", OfficeId = 5},
			};
		}
	}	
}
 
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

			builder.HasData(LoadCourses());

		}

		private static List<Instructor> LoadCourses()
		{
			return new List<Instructor>()
			{
				new Instructor{Id=1,Name="Ahmed AbdAllah"},
				new Instructor{Id=2,Name="Yasmeen Mohamed"},
				new Instructor{Id=3,Name="Khaled Hassan"},
				new Instructor{Id=4,Name="Nadia Ali"},
				new Instructor{Id=5,Name="Omar Ibrahim"},
			};
		}
	}
}

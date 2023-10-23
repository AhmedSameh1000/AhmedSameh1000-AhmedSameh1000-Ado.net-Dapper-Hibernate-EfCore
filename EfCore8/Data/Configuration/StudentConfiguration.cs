using EfCore8.Entities;
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


	

			builder.HasData(LoadStudent());


		}

		private List<Student> LoadStudent()
		{
			return new List<Student>()
			{
				new Student{Id=1,Name="Fatima Ali"},
				new Student{Id=2,Name="Noor Salah"},
				new Student{Id=3,Name="Omar Yousef"},
				new Student{Id=4,Name="Huda Ahmed"},
				new Student{Id=5,Name="Amira Tareq"},
				new Student{Id=6,Name="Zinab Ismaeal"},
				new Student{Id=7,Name="Yousef Farid"},
				new Student{Id=8,Name="Layla Mostafa"},
				new Student{Id=9,Name="Mohamed Adel"},
				new Student{Id=10,Name="Samira Nabil"},
			};
		}
	}
}
 
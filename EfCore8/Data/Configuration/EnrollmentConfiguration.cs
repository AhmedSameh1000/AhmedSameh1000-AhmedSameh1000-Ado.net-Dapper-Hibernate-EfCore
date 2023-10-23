using EfCore8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class EnrollmentConfiguration : IEntityTypeConfiguration<EnrollMents>
	{

		public void Configure(EntityTypeBuilder<EnrollMents> builder)
		{
			builder.HasKey(c => new {c.StudentId,c.SectionId});

			builder.HasData(LoadEnrollMent());



		}

		private List<EnrollMents> LoadEnrollMent()
		{
			return new List<EnrollMents>()
			{
				new EnrollMents{StudentId=1, SectionId = 1},
				new EnrollMents{StudentId=2, SectionId = 1},
				new EnrollMents{StudentId=3, SectionId = 2},
				new EnrollMents{StudentId=4, SectionId = 2},
				new EnrollMents{StudentId=5, SectionId = 3},
				new EnrollMents{StudentId=6, SectionId = 3},
				new EnrollMents{StudentId=7, SectionId = 4},
				new EnrollMents{StudentId=8, SectionId = 4},
				new EnrollMents{StudentId=9, SectionId = 5},
				new EnrollMents{StudentId=10, SectionId = 5},
			};
		}	
	}	


}

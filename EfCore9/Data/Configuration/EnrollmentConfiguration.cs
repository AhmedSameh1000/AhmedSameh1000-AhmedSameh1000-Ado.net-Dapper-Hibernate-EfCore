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

			



		}

	
	}	


}

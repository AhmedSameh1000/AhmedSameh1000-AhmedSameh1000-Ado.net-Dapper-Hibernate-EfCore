using EfCore8.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class SectionScheduleConfiguration : IEntityTypeConfiguration<SectionSchedule>
	{
		public void Configure(EntityTypeBuilder<SectionSchedule> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c=>c.Id).ValueGeneratedNever();

			builder.Property(c => c.StartTime)
				.HasColumnType("time");
			builder.Property(c => c.EndTime)
				.HasColumnType("time");
				
	


		

		}

	

	
	}	


}

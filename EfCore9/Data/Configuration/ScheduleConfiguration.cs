using EfCore8.Entities;
using EfCore9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore8.Data.Configuration
{
	public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
	{
		public void Configure(EntityTypeBuilder<Schedule> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c=>c.Id).ValueGeneratedNever();

			builder.Property(c=>c.Title)
				.HasColumnType("varchar")
				.HasMaxLength(255)
				.IsRequired();



		}


		
	}	

}

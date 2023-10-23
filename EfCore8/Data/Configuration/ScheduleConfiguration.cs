﻿using EfCore8.Entities;
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


			builder.HasData(LoadSchedules());

		}


		private static List<Schedule> LoadSchedules()
		{
			return new List<Schedule>
			{
				new Schedule { Id = 1, Title = "Daily", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
				new Schedule { Id = 2, Title = "DayAfterDay", SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
				new Schedule { Id = 3, Title = "Twice-a-Week", SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
				new Schedule { Id = 4, Title = "Weekend", SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
				new Schedule { Id = 5, Title = "Compact", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
			};
		}
	}	

}
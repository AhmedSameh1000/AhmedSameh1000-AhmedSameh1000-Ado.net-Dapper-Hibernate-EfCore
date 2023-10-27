using EfCore8.Entities;
using EfCore9;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore8.Data.Configuration
{
	public class OfficeConfiguration : IEntityTypeConfiguration<Office>
	{
		public void Configure(EntityTypeBuilder<Office> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(c=>c.Id).ValueGeneratedNever();

			builder.Property(c => c.OfficeName)
			.HasColumnType("varchar")
			.HasMaxLength(55)
			.IsRequired();

			builder.Property(c => c.OfficeLocation)
			.HasColumnType("varchar")
			.HasMaxLength(55)
			.IsRequired();

		}

		
	}
}

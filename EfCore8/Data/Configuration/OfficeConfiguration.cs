using EfCore8.Entities;
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

			builder.HasData(LoadOffices());
		}

		private List<Office> LoadOffices()
		{

			return new List<Office>()
			{
				new Office{Id=1,OfficeName="Off-05",OfficeLocation="Building A"},
				new Office{Id=2,OfficeName="Off-12",OfficeLocation="Building B"},
				new Office{Id=3,OfficeName="Off-32",OfficeLocation="Aminstration"},
				new Office{Id=4,OfficeName="Off-44",OfficeLocation="It Department"},
				new Office{Id=5,OfficeName="Off-43",OfficeLocation="It Department"},
			};
		}
	}
}

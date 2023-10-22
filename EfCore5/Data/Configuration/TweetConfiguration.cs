using EfCore5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore5.Data.Configuration
{
	public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
	{
		public void Configure(EntityTypeBuilder<Tweet> builder)
		{
			builder.ToTable("tblTweets");
		}
	}
}

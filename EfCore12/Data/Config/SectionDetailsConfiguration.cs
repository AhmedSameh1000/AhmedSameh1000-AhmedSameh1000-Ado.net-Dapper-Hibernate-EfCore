using C01.SplitQuery.QueryData.Entities;
using EfCore12.PROCEDUREModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF014.SeedDataInitializationLogic.Data.Config
{
    public class SectionDetailsConfiguration : IEntityTypeConfiguration<SectionDetails>
    {
        public void Configure(EntityTypeBuilder<SectionDetails> builder)
        {
            

        }
    }


    public class AllSectionConfiguration : IEntityTypeConfiguration<AllSections>
    {
        public void Configure(EntityTypeBuilder<AllSections> builder)
        {

        }
    }
}

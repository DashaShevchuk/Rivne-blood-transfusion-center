using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class SicknessConfiguration : IEntityTypeConfiguration<Sickness>
    {
        public void Configure(EntityTypeBuilder<Sickness> builder)
        {
            builder.HasMany(e => e.RecipientProfiles)
                .WithOne(e => e.Sickness);
        }
    }
}

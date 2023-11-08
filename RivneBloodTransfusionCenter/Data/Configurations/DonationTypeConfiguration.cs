using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class DonationTypeConfiguration : IEntityTypeConfiguration<DonationType>
    {
        public void Configure(EntityTypeBuilder<DonationType> builder)
        {
            builder.HasMany(e => e.RecipientProfiles)
                .WithOne(e => e.DonationType);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class BloodTypeConfiguration : IEntityTypeConfiguration<BloodType>
    {
        public void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.HasMany(e => e.DonorProfiles)
                .WithOne(e => e.BloodType);

            builder.HasMany(e => e.RecipientProfile)
               .WithOne(e => e.BloodType);
        }
    }
}

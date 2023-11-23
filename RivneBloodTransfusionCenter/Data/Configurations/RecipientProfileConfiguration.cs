using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class RecipientProfileConfiguration : IEntityTypeConfiguration<RecipientProfile>
    {
        public void Configure(EntityTypeBuilder<RecipientProfile> builder)
        {
            builder.HasOne(x => x.User)
              .WithOne(s => s.RecipientProfile)
              .HasForeignKey<RecipientProfile>(ad => ad.Id);

            builder.HasOne(e => e.DonationType)
             .WithMany(x => x.RecipientProfiles)
             .HasForeignKey(e => e.BloodTypeId);

            builder.HasOne(e => e.BloodType)
            .WithMany(x => x.RecipientProfile)
            .HasForeignKey(e => e.BloodTypeId);

            builder.HasOne(e => e.Sickness)
            .WithMany(x => x.RecipientProfiles)
            .HasForeignKey(e => e.SicknessId);
        }
    }
}

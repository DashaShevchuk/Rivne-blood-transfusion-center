using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class DonorProfileConfiguration : IEntityTypeConfiguration<DonorProfile>
    {
        public void Configure(EntityTypeBuilder<DonorProfile> builder)
        {
            builder.HasOne(x => x.User)
               .WithOne(s => s.DonorProfile)
               .HasForeignKey<DonorProfile>(ad => ad.Id);

            builder.HasOne(e => e.BloodType)
             .WithMany(x => x.DonorProfiles)
             .HasForeignKey(e => e.BloodTypeId);
        }
    }
}

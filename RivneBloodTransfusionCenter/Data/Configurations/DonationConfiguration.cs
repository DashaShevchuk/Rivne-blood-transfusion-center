using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasOne(e => e.DonationType)
             .WithMany(x => x.Donations)
             .HasForeignKey(e => e.TypeId);
        }
    }
}

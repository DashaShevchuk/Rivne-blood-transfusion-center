using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Configurations
{
    public class AdminProfileConfiguration : IEntityTypeConfiguration<AdminProfile>
    {
        public void Configure(EntityTypeBuilder<AdminProfile> builder)
        {
            builder.HasOne(x => x.User)
                .WithOne(s => s.AdminProfile)
                .HasForeignKey<AdminProfile>(ad => ad.Id);
        }
    }
}

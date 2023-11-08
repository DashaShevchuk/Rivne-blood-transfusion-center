using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Configurations;

namespace RivneBloodTransfusionCenter.Data.EfDbContext
{
    public class EfDbContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
                                              DbUserRole, IdentityUserLogin<string>,
                                              IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
        : base(options)
        {

        }
        public virtual DbSet<BloodType> BloodTypes { get; set; }
        public virtual DbSet<DonationType> DonationTypes { get; set; }
        public virtual DbSet<Sickness> Sicknesses { get; set; }
        public virtual DbSet<RecipientProfile> RecipientProfiles { get; set; }
        public virtual DbSet<DonorProfile> DonorProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DbUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyConfiguration(new DbRoleConfiguration());
            modelBuilder.ApplyConfiguration(new BloodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DonationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SicknessConfiguration());
            modelBuilder.ApplyConfiguration(new RecipientProfileConfiguration());
            modelBuilder.ApplyConfiguration(new DonorProfileConfiguration());
        }
    }
}

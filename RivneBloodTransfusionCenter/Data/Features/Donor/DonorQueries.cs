using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;

namespace RivneBloodTransfusionCenter.Data.Features.Donor
{
    public class DonorQueries : IDonorQueries
    {
        //тут тільки get запити
        private readonly EfContext context;
        private readonly UserManager<DbUser> userManager;

        public DonorQueries(EfContext context, 
                            UserManager<DbUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IEnumerable<BloodType> GetBloodTypes()
        {
            return context.BloodTypes.ToList();
        }

        public DbUser GetDonorById(string userId)
        {
            return context.Users.Include(x => x.DonorProfile).FirstOrDefault(x => x.Id == userId);
        }

        public IEnumerable<Sex> GetSexes()
        {
            return context.Sexes.ToList();
        }

        
    }
}

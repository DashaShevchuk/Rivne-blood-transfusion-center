using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces;

namespace RivneBloodTransfusionCenter.Data.Features.Home
{
    public class HomeQueries : IHomeQueries
    {
        private readonly EfContext context;
        public HomeQueries(EfContext context)
        {
            this.context = context;
        }
        public IEnumerable<BloodType> GetBloodTypes()
        {
            return context.BloodTypes.ToList();
        }

        public IEnumerable<DonationType> GetDonationTypes()
        {
            return context.DonationTypes.ToList();
        }

        public IEnumerable<Sickness> GetSicknesses()
        {
            return context.Sicknesses.ToList();
        }

        public IEnumerable<Sex> GetSexes()
        {
            return context.Sexes.ToList();
        }
    }
}

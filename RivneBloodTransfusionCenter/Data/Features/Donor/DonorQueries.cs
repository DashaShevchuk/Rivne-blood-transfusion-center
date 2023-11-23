using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;

namespace RivneBloodTransfusionCenter.Data.Features.Donor
{
    public class DonorQueries : IDonorQueries
    {
        //тут тільки get запити
        private readonly EfContext context;

        public DonorQueries(EfContext context)
        {
            this.context = context;
        }
        public IEnumerable<BloodType> GetBloodTypes()
        {
            return context.BloodTypes.ToList();
        }

        public IEnumerable<Sex> GetSexes()
        {
            return context.Sexes.ToList();
        }
    }
}

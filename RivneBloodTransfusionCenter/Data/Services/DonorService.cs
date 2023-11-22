using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels;

namespace RivneBloodTransfusionCenter.Data.Services
{
    public class DonorService:IDonorService
    {
        private readonly IDonorQueries donorQueries;
        public DonorService(IDonorQueries donorQueries)
        {
            this.donorQueries = donorQueries;
        }

        public DonorRegistrationViewModel GetRegistrationData()
        {
            return new DonorRegistrationViewModel { BloodTypes = donorQueries.GetBloodTypes(), Sexes = donorQueries.GetSexes() };
        }
    }
}

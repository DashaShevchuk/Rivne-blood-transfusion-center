using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;

namespace RivneBloodTransfusionCenter.Data.Services
{
    public class DonorService:IDonorService
    {
        private readonly IDonorQueries donorQueries;
        public DonorService(IDonorQueries donorQueries)
        {
            this.donorQueries = donorQueries;
        }

        public RegistrationViewModel GetRegistrationData()
        {
            return new RegistrationViewModel { BloodTypes = donorQueries.GetBloodTypes(), Sexes = donorQueries.GetSexes() };
        }
    }
}

using RivneBloodTransfusionCenter.ViewModels;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorService
    {
        public DonorRegistrationViewModel GetRegistrationData();
    }
}

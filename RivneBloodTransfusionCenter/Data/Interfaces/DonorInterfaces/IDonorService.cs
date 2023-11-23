using RivneBloodTransfusionCenter.ViewModels.Donor;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorService
    {
        public RegistrationViewModel GetRegistrationData();
        public Task<HttpStatusCode> Registration(RegistrationViewModel model);
        public Task<HttpStatusCode> Login(LoginViewModel model);

    }
}

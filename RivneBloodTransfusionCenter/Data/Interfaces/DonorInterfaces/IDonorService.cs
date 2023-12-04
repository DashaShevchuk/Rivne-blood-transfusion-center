using RivneBloodTransfusionCenter.ViewModels.Donor;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorService
    {
        RegistrationViewModel GetRegistrationData();

        Task<HttpStatusCode> Registration(RegistrationViewModel model);
        
        Task<HttpStatusCode> Logout();

        DonorProfileViewModel GetDonorProfileById(string userId);

        HttpStatusCode EditProfile(DonorProfileViewModel model, string userId);

    }
}

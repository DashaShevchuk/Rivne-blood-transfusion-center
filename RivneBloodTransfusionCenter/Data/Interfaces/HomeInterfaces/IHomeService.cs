using RivneBloodTransfusionCenter.ViewModels.Home;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces
{
    public interface IHomeService
    {
        Task<HttpStatusCode> Registration(RegistrationViewModel model);

        RegistrationViewModel GetRegistrationData();
    }
}

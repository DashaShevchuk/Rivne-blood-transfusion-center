using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.ViewModels.Donor;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorCommands
    {
        void UpdateUserProfile(DbUser user, DonorProfileViewModel model);

        void AddDonation(Donation model);
    }
}

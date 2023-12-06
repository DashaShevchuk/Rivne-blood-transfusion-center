using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.ViewModels.Donor
{
    public class GetRecipientsViewModel
    {
       // public IEnumerable<DbUser> Recipients { get; set; }
       public IEnumerable<RecipientProfileViewModel> Recipients { get; set; }

    }
}

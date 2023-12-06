using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces
{
    public interface IHomeCommands
    {
        void SaveRecipientProfile(RecipientProfile profile);
    }
}

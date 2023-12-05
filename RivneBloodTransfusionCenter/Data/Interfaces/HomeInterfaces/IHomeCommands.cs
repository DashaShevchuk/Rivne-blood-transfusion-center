using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces
{
    public interface IHomeCommands
    {
        void AddRecipientProfile(RecipientProfile profile);

        Task AddUser(DbUser user);
    }
}

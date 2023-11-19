using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class AdminProfile
    {
        public string Id { get; set; }
        public virtual DbUser User { get; set; }
    }
}

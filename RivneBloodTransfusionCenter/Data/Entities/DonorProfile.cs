using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class DonorProfile
    {
        public string Id { get; set; }

        public int BloodTypeId { get; set; }
        public virtual BloodType BloodType { get; set; }

        public virtual DbUser User { get; set; }
    }
}

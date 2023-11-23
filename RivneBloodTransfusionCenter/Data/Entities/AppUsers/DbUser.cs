using Microsoft.AspNetCore.Identity;

namespace RivneBloodTransfusionCenter.Data.Entities.AppUsers
{
    public class DbUser : IdentityUser
    {
        public string Name { get; set; }

        public string SerName { get; set; }

        public string LastName { get; set; }

        public int SexId { get; set; }

        public virtual Sex Sex { get; set; }

        public virtual ICollection<DbUserRole> UserRoles { get; set; }

        public DonorProfile DonorProfile { get; set; }

        public RecipientProfile RecipientProfile { get; set; }

        public AdminProfile AdminProfile { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace RivneBloodTransfusionCenter.Data.Entities.AppUsers
{
    public class DbRole : IdentityRole<string>
    {
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
    }
}

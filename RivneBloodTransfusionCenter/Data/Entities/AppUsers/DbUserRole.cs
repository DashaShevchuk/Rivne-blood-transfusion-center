using Microsoft.AspNetCore.Identity;

namespace RivneBloodTransfusionCenter.Data.Entities.AppUsers
{
    public class DbUserRole : IdentityUserRole<string>
    {
        public virtual DbUser User { get; set; }
        public virtual DbRole Role { get; set; }
    }
}

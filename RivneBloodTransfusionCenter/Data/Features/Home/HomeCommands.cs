using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces;

namespace RivneBloodTransfusionCenter.Data.Features.Home
{
    public class HomeCommands : IHomeCommands
    {
        private readonly EfContext context;
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;
        public HomeCommands(EfContext context,
                            UserManager<DbUser> userManager,
                            SignInManager<DbUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void SaveRecipientProfile(RecipientProfile profile)
        {
            context.RecipientProfiles.Add(profile);
            context.SaveChanges();
        }
    }
}

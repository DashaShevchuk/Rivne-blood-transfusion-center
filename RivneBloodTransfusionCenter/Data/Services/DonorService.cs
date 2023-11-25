using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Services
{
    public class DonorService:IDonorService
    {
        //тут реалізація методів
        private readonly IDonorQueries donorQueries;
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;
        public DonorService(IDonorQueries donorQueries,
                               UserManager<DbUser> userManager,
                               SignInManager<DbUser> signInManager)
        {
            this.donorQueries = donorQueries;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public RegistrationViewModel GetRegistrationData()
        {
            return new RegistrationViewModel { BloodTypes = donorQueries.GetBloodTypes(), Sexes = donorQueries.GetSexes() };
        }

        public async Task<HttpStatusCode> Login(LoginViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return HttpStatusCode.NotFound;
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return HttpStatusCode.NotFound;
                }
                else
                {
                    await signInManager.SignInAsync(user, model.RememberMe);
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.BadRequest;
        }

        public async Task<HttpStatusCode> Logout()
        {
            await signInManager.SignOutAsync();
            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> Registration(RegistrationViewModel model)
        {
            var roleName = "Donor";

            DonorProfile donorProfile = new()
            {
                BloodTypeId = model.BloodTypeId,
            };

            var user = new DbUser()
            {
                Email = model.Email,
                Name = model.Name,
                SerName = model.SerName,
                LastName = model.LastName,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                SexId = model.SexId,
                DonorProfile = donorProfile
            };

            var result = await userManager.CreateAsync(user, model.Password);
            result = userManager.AddToRoleAsync(user, roleName).Result;
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}

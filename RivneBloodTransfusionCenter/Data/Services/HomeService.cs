using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Features.Donor;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Home;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeQueries homeQueries;
        private readonly IHomeCommands homeCommands;
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;

        public HomeService(IHomeQueries homeQueries,
                           IHomeCommands homeCommands,
                            UserManager<DbUser> userManager,
                            SignInManager<DbUser> signInManager)
        {
            this.homeQueries = homeQueries;
            this.homeCommands = homeCommands;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public RegistrationViewModel GetRegistrationData()
        {
            return new RegistrationViewModel { BloodTypes = homeQueries.GetBloodTypes(), 
                                               DonationTypes=homeQueries.GetDonationTypes(), 
                                               Sicknesses=homeQueries.GetSicknesses(),
                                               Sexes=homeQueries.GetSexes()};
        }

        public async Task<HttpStatusCode> Registration(RegistrationViewModel model)
        {

            var roleName = "Recipient";

            RecipientProfile recipientProfile = new()
            {
                PlaceOfTreatment=model.PlaceOfTreatment,
                DonationTypeId=model.DonationTypeId,
                BloodTypeId=model.BloodTypeId,
                SicknessId=model.SicknessId,
                RequiredNumberOfDonors=model.RequiredNumberOfDonors,
                DonationCenter=model.DonationCenter,
                Description=model.Description,
                IsForYourself=model.IsForYourself,
                ContactPerson=model.ContactPerson,
            };

            var user = new DbUser()
            {
                Email = model.Email,
                Name = model.Name,
                SerName = model.SerName,
                LastName = model.LastName,
                UserName = new string(model.LastName
                                 .Concat(model.Name)
                                 .Concat(model.SerName)
                                 .Where(char.IsLetterOrDigit)
                                 .ToArray()),
                PhoneNumber = model.PhoneNumber,
                DateOfBirth=model.DateOfBirth,
                SexId=model.SexId,
                RecipientProfile= recipientProfile
            };
            var result = await userManager.CreateAsync(user);
            var addToRoleResult = await userManager.AddToRoleAsync(user, roleName);
            return HttpStatusCode.OK;
            //var result = await userManager.CreateAsync(user);

            //if (result.Succeeded)
            //{
            //    var addToRoleResult = await userManager.AddToRoleAsync(user, roleName);

            //    if (addToRoleResult.Succeeded)
            //    {
            //        await signInManager.SignInAsync(user, false);
            //        return HttpStatusCode.OK;
            //    }
            //    else
            //    {
            //        return HttpStatusCode.BadRequest;
            //    }
            //}
            //else
            //{
            //    return HttpStatusCode.BadRequest;
            //}
        }
    }
}

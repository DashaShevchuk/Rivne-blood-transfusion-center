using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;
using System.Net;

namespace RivneBloodTransfusionCenter.Data.Services
{
    public class DonorService : IDonorService
    {
        //тут реалізація методів
        private readonly IDonorQueries donorQueries;
        private readonly IDonorCommands donorCommands;
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;
        public DonorService(IDonorQueries donorQueries,
                            IDonorCommands donorCommands,
                            UserManager<DbUser> userManager,
                            SignInManager<DbUser> signInManager)
        {
            this.donorQueries = donorQueries;
            this.donorCommands = donorCommands;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public HttpStatusCode AddDonation(AddDonationViewModel model)
        {
            var newDonation = new Donation()
            {
                TypeId = model.DonationTypeId,
                Date = model.Date,
                DonationCenter=model.DonationCenter,
            };
            donorCommands.AddDonation(newDonation);

            return HttpStatusCode.OK;
        }

        public HttpStatusCode EditProfile(DonorProfileViewModel model, string userId)
        {
            var user = donorQueries.GetDonorById(userId);
            if (user == null)
            {
                return HttpStatusCode.NotFound;
            }

            donorCommands.UpdateUserProfile(user, model);

            return HttpStatusCode.OK;
        }

        public AddDonationViewModel GetAddDonationData()
        {
            AddDonationViewModel model = new()
            {
                DonationTypes = donorQueries.GetDonationTypes(),
                Donations= donorQueries.GetDonations(),
            };

            return model;
        }

        public DonorProfileViewModel GetDonorProfileById(string userId)
        {
            var donor = donorQueries.GetDonorById(userId);

            DonorProfileViewModel donorProfile = new()
            {
                Name = donor.Name,
                SerName = donor.SerName,
                LastName = donor.LastName,
                PhoneNumber = donor.PhoneNumber,
                SexId = donor.SexId,
                BloodTypeId = donor.DonorProfile.BloodTypeId,
                Sexes = donorQueries.GetSexes(),
                BloodTypes = donorQueries.GetBloodTypes()
            };
            return donorProfile;
        }

        public GetRecipientsViewModel GetRecipients()
        {
            var recipients = donorQueries.GetRecipients();
            List<RecipientProfileViewModel> profiles=new List<RecipientProfileViewModel>();

            foreach (var item in recipients)
            {

                RecipientProfileViewModel recipientModel = new()
                {
                    Name = item.Name,
                    SerName = item.SerName,
                    LastName = item.LastName,
                    PhoneNumber=item.PhoneNumber,
                    Email=item.Email,
                    PlaceOfTreatment=item.RecipientProfile.PlaceOfTreatment,
                    RequiredNumberOfDonors=item.RecipientProfile.RequiredNumberOfDonors,
                    DonationCenter=item.RecipientProfile.DonationCenter,
                    Description=item.RecipientProfile.Description,
                    IsForYourself=item.RecipientProfile.IsForYourself,
                    ContactPerson=item.RecipientProfile.ContactPerson,
                    SexId=item.SexId,
                    SicknessId=item.RecipientProfile.SicknessId,
                    DonationTypeId=item.RecipientProfile.DonationTypeId,
                    BloodTypeId=item.RecipientProfile.BloodTypeId,
                    Sexes= donorQueries.GetSexes(),
                    BloodTypes=donorQueries.GetBloodTypes(),
                    DonationTypes=donorQueries.GetDonationTypes(),
                    Sicknesses=donorQueries.GetSicknesses(),
                 };

                profiles.Add(recipientModel);
            }

            return new GetRecipientsViewModel { Recipients = profiles };
        }

        public RegistrationViewModel GetRegistrationData()
        {
            return new RegistrationViewModel { BloodTypes = donorQueries.GetBloodTypes(), Sexes = donorQueries.GetSexes() };
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
                DateOfBirth=model.DateOfBirth,
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

using Microsoft.AspNetCore.Identity;
using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;

namespace RivneBloodTransfusionCenter.Data.Features.Donor
{
    public class DonorCommands : IDonorCommands
    {
        //тут усі інші запити
        private readonly IDonorQueries donorQueries;
        private readonly EfContext context;
        private readonly UserManager<DbUser> userManager;

        public DonorCommands(IDonorQueries donorQueries,
                             EfContext context,
                             UserManager<DbUser> userManager)
        {
            this.donorQueries = donorQueries;
            this.context = context;
            this.userManager = userManager;
        }
        public void UpdateUserProfile(DbUser user, DonorProfileViewModel model)
        {
            //var user = donorQueries.GetDonorById(userId);

            //user.Name=model.Name;
            //user.SerName=model.SerName;
            //user.LastName=model.LastName;
            //user.PhoneNumber=model.PhoneNumber;
            //user.SexId=model.SexId;
            //user.DonorProfile.BloodTypeId=model.BloodTypeId;

            //context.SaveChangesAsync
            //if (user != null)
            //{
            //    user.Name = model.Name;
            //    user.SerName = model.SerName;
            //    user.LastName = model.LastName;
            //    user.PhoneNumber = model.PhoneNumber;
            //    user.SexId = model.SexId;

            //    if (user.DonorProfile != null)
            //    {
            //        user.DonorProfile.BloodTypeId = model.BloodTypeId;
            //    }

            //    context.SaveChanges(); // Note: Use SaveChanges instead of SaveChangesAsync if not awaited
            //}

            if(user.Name != model.Name)
            {
                user.Name = model.Name;
            }

            if (user.SerName != model.SerName)
            {
                user.SerName = model.SerName;
            }

            if (user.LastName != model.LastName)
            {
                user.LastName = model.LastName;
            }

            if (user.PhoneNumber != model.PhoneNumber)
            {
                user.PhoneNumber = model.PhoneNumber;
            }

            if (user.SexId != model.SexId)
            {
                user.SexId = model.SexId;
            }

            if (user.DonorProfile.BloodTypeId != model.BloodTypeId)
            {
                user.DonorProfile.BloodTypeId = model.BloodTypeId;
            }

            context.SaveChanges();
        }
    }
}

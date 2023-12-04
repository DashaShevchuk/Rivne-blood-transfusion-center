﻿using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.ViewModels.Donor;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorQueries
    {
        IEnumerable<Sex> GetSexes();

        IEnumerable<BloodType> GetBloodTypes();

        DbUser GetDonorById(string userId);
    }
}

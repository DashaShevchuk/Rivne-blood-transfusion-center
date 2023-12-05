using RivneBloodTransfusionCenter.Data.Entities;
using System.Numerics;

namespace RivneBloodTransfusionCenter.ViewModels.Home
{
    public class RegistrationViewModel
    {
        public string Name { get; set; }

        public string SerName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public int BloodTypeId { get; set; }

        public int SicknessId { get; set; }

        public string DonationCenter { get; set; }

        public int DonationTypeId { get; set; }

        public int SexId { get; set; }

        public string PlaceOfTreatment { get; set; }

        public int RequiredNumberOfDonors { get; set; }

        public string Description { get; set; }

        public string IsForYourself { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }



        public IEnumerable<BloodType> BloodTypes { get; set; }

        public IEnumerable<Sex> Sexes { get; set; }

        public IEnumerable<Sickness> Sicknesses { get; set; }

        public IEnumerable<DonationType> DonationTypes { get; set; }
    }
}

using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.ViewModels.Donor
{
    public class RegistrationViewModel
    {
        public string Name { get; set; }

        public string SerName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public int SexId { get; set; }

        public int BloodTypeId { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<Sex> Sexes { get; set; }

        public IEnumerable<BloodType> BloodTypes { get; set; }
    }
}

using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.ViewModels.Donor
{
    public class DonorProfileViewModel
    {
        public string Name { get; set; }

        public string SerName { get; set; }

        public string LastName { get; set; }

        public int SexId { get; set; }

        public int BloodTypeId { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<Sex> Sexes { get; set; }

        public IEnumerable<BloodType> BloodTypes { get; set; }

    }
}

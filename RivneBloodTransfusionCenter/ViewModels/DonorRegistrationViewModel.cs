using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.ViewModels
{
    public class DonorRegistrationViewModel
    {
        public IEnumerable<Sex> sexes { get; set; }
        public IEnumerable<BloodType> bloodTypes { get; set; }
    }
}

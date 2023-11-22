using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.ViewModels
{
    public class DonorRegistrationViewModel
    {
        public IEnumerable<Sex> Sexes { get; set; }
        public IEnumerable<BloodType> BloodTypes { get; set; }
    }
}

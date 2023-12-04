using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.ViewModels.Donor
{
    public class AddDonationViewModel
    {
        public int DonationTypeId { get; set; }
        public string Date { get; set; }
        public string DonationCenter { get; set; }
        public IEnumerable<DonationType> DonationTypes { get; set; }
        public IEnumerable<Donation> Donations { get; set; }
    }
}

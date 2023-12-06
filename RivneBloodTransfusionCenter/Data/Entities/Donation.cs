namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class Donation
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string DonationCenter { get; set; }

        public int TypeId { get; set; }
        public virtual DonationType DonationType { get; set; }
    }
}

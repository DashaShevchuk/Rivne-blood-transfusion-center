namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class DonationType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<RecipientProfile> RecipientProfiles { get; set; }

        public virtual IEnumerable<Donation> Donations { get; set; }
    }
}

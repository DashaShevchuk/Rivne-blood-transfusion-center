namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class BloodType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<DonorProfile> DonorProfiles { get; set; }

        public virtual IEnumerable<RecipientProfile> RecipientProfile { get; set; }
    }
}

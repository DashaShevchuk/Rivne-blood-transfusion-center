namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class Sex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<RecipientProfile> RecipientProfiles { get; set; }
        public virtual IEnumerable<DonorProfile> DonorProfiles { get; set; }
    }
}

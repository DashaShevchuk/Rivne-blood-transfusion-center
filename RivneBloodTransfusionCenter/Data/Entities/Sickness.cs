namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class Sickness
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<RecipientProfile> RecipientProfiles { get; set; }
    }
}

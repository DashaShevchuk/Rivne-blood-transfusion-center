using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class Sex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<DbUser> Users { get; set; }
    }
}

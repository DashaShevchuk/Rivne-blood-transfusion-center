using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces
{
    public interface IDonorQueries
    {
        IEnumerable<Sex> GetSexes();
        IEnumerable<BloodType> GetBloodTypes();
    }
}

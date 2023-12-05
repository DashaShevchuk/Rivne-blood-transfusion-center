using RivneBloodTransfusionCenter.Data.Entities;

namespace RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces
{
    public interface IHomeQueries
    {
        IEnumerable<BloodType> GetBloodTypes();
        IEnumerable<Sickness> GetSicknesses();
        IEnumerable<DonationType> GetDonationTypes();
        IEnumerable<Sex> GetSexes();
    }
}

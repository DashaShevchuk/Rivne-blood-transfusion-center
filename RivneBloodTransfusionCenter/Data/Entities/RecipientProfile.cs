using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.Entities
{
    public class RecipientProfile
    {
        public string Id { get; set; }

        public string PlaceOfTreatment { get; set; }

        public int DonationTypeId { get; set; }
        public virtual DonationType DonationType { get; set; }

        public int BloodTypeId { get; set; }
        public virtual BloodType BloodType { get; set; }

        public int SicknessId { get; set; }
        public virtual Sickness Sickness { get; set; }

        public int RequiredNumberOfDonors { get; set; }

        public string Description { get; set; }

        public string IsForYourself { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual DbUser User { get; set; }
    }
}

namespace FarmManagementTracker.Models
{
    public class VaccinationRecord
    {
        public int Id { get; set; }
        public string VaccineName { get; set; }
        public DateTime DateGiven { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? Notes { get; set; }

        // Foreign Key
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}

namespace FarmManagementTracker.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Name of animal
        public string Type { get; set; }  // Type of Animal
        public string Breed { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; } // Active, Sold, Deceased
        public string? Notes { get; set; }

        //public List<VaccinationRecord> Vaccinations { get; set; } = new List<VaccinationRecord>();
    }
}

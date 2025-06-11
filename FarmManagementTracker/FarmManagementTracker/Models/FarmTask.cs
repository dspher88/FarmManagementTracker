namespace FarmManagementTracker.Models
{
    public class FarmTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }           
        public string Frequency { get; set; }          
        public DateTime NextDueDate { get; set; }
        public string? Notes { get; set; }             
    }
}

namespace FarmManagementTracker.Models
{
    public class SupplyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }            
        public string Category { get; set; }        
        public int Quantity { get; set; }           
        public string Unit { get; set; }            
        public string? Notes { get; set; }
    }
}

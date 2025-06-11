namespace FarmManagementTracker.Models
{
    public class PasswordResetRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public bool IsResolved { get; set; } = false;
        public string? ResolutionNotes { get; set; } // Admin note after resetting
    }
}



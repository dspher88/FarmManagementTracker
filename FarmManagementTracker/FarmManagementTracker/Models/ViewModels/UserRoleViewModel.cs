using System.Collections.Generic;

namespace FarmManagementTracker.Models.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AvailableRoles { get; set; }
    }
}



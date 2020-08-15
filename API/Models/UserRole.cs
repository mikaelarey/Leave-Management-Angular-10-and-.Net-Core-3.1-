using System.Collections.Generic;

namespace API.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
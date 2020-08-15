using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [ForeignKey("UserRole")]
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set;}
    }
}
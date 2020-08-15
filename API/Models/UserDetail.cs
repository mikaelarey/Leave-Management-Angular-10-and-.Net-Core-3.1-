using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserPhoto> Photos { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set;}
        public Department Department { get; set; }

        [ForeignKey("EmploymentType")]
        public int EmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }

        [ForeignKey("UserAccount")]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
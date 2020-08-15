using System.Collections.Generic;

namespace API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
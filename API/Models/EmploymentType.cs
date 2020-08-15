using System.Collections.Generic;

namespace API.Models
{
    public class EmploymentType
    {
        public int EmploymentTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
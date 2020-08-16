namespace API.DTO
{
    public class UserListDTO
    {
        public int UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string PhotoUrl { get; set; }
        
        public int DepartmentId { get; set;}
        public string Department { get; set; }

        public int EmploymentTypeId { get; set; }
        public string EmploymentType { get; set; }

        public int UserAccountId { get; set; }
        public string UserRole { get; set; }
    }
}
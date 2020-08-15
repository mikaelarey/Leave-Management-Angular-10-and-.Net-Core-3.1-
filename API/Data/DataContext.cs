using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Department> Departments { get; set;}
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleId = 1, Name = "Directress", Description = "Grants all access" },
                new UserRole { UserRoleId = 2, Name = "Team Leader", Description = "Grants access to his/her team members" },
                new UserRole { UserRoleId = 3, Name = "Employee", Description = "Grants access only to personal account" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Administration", Description = "Administration" },
                new Department { DepartmentId = 2, Name = "Pre School", Description = "Pre School" },
                new Department { DepartmentId = 3, Name = "Elementary", Description = "Elementary" },
                new Department { DepartmentId = 4, Name = "High School", Description = "High School" },
                new Department { DepartmentId = 5, Name = "Senior High School", Description = "Senior High School" }
            );

            modelBuilder.Entity<EmploymentType>().HasData(
                new EmploymentType { EmploymentTypeId = 1, Name = "Regular" },
                new EmploymentType { EmploymentTypeId = 2, Name = "Trainee"}
            );
        }
    }
}
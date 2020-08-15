using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SeedDateForEmploymentTypeAndDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[] { 1, "Administration", "Administration" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[] { 2, "Pre School", "Pre School" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[] { 3, "Elementary", "Elementary" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[] { 4, "High School", "High School" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Description", "Name" },
                values: new object[] { 5, "Senior High School", "Senior High School" });

            migrationBuilder.InsertData(
                table: "EmploymentTypes",
                columns: new[] { "EmploymentTypeId", "Description", "Name" },
                values: new object[] { 1, null, "Regular" });

            migrationBuilder.InsertData(
                table: "EmploymentTypes",
                columns: new[] { "EmploymentTypeId", "Description", "Name" },
                values: new object[] { 2, null, "Trainee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "EmploymentTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmploymentTypes",
                keyColumn: "EmploymentTypeId",
                keyValue: 2);
        }
    }
}

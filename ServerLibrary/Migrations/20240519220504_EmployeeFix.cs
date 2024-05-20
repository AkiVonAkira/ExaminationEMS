using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialSecurityNumberId",
                table: "Employees",
                newName: "SocialSecurityNumber");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Employees",
                newName: "FileNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocialSecurityNumber",
                table: "Employees",
                newName: "SocialSecurityNumberId");

            migrationBuilder.RenameColumn(
                name: "FileNumber",
                table: "Employees",
                newName: "Fullname");
        }
    }
}

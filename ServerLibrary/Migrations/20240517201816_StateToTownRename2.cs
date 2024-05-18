using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Migrations
{
    /// <inheritdoc />
    public partial class StateToTownRename2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Towns_StateId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Employees",
                newName: "TownId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_StateId",
                table: "Employees",
                newName: "IX_Employees_TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Towns_TownId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TownId",
                table: "Employees",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_TownId",
                table: "Employees",
                newName: "IX_Employees_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Towns_StateId",
                table: "Employees",
                column: "StateId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDesignationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignationName",
                table: "Designations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DesignationID",
                table: "Designations",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Designations",
                newName: "DesignationName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Designations",
                newName: "DesignationID");
        }
    }
}

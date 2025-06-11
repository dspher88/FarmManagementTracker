using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagementTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddResolutionNotesToPasswordResetRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResolutionNotes",
                table: "PasswordResetRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolutionNotes",
                table: "PasswordResetRequests");
        }
    }
}

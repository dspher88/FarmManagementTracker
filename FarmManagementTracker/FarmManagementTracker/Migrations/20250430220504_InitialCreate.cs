using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmManagementTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BirthDate", "Breed", "Gender", "Name", "Notes", "Status", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brahma", "Male", "Ace", "Leader of the flock", "Active", "Chicken" },
                    { 2, new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khaki Campbell", "Male", "Waddles", "Eats a lot", "Active", "Duck" },
                    { 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rhode Island Red", "Female", "Rosie", "Calm and productive", "Active", "Chicken" },
                    { 4, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runner Duck", "Female", "Quackers", "Very vocal", "Active", "Duck" }
                });

            migrationBuilder.InsertData(
                table: "FarmTasks",
                columns: new[] { "Id", "Frequency", "NextDueDate", "Notes", "TaskName" },
                values: new object[,]
                {
                    { 1, "Weekly", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use pine shavings", "Clean Chicken Coop" },
                    { 2, "Daily", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Done every morning", "Refill Waterers" }
                });

            migrationBuilder.InsertData(
                table: "SupplyItems",
                columns: new[] { "Id", "Category", "Name", "Notes", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, "Feed", "Layer Pellets", "Buy more if under 2", 3, "bags" },
                    { 2, "Bedding", "Straw Bales", "Used for coop bedding", 5, "bales" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "FarmTasks");

            migrationBuilder.DropTable(
                name: "SupplyItems");
        }
    }
}

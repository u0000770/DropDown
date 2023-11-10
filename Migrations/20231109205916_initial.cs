using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropDown.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Trainers_Categories_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Categories",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "GradeId", "Description" },
                values: new object[] { 1, "Small" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "GradeId", "Description" },
                values: new object[] { 2, "Medium" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "GradeId", "Description" },
                values: new object[] { 3, "Large" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "GradeId", "Description" },
                values: new object[] { 4, "Very Large" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 1, "Inside Cleveland Centre", 1, "Middlesbrough", 10 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 2, "Blah Blah Blah", 2, "Stockton", 11 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 3, "Blah Blah Blah", 3, "Thornaby", 12 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 4, "Blah Blah Blah", 4, "Redcar", 13 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 5, "Blah Blah Blah", 4, "Billingham", 14 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 6, "Blah Blah Blah", 3, "Saltburn", 15 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 7, "Blah Blah Blah", 2, "Darlington", 16 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 8, "Blah Blah Blah", 1, "Eston", 17 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "StoreId", "Description", "GradeId", "StoreName", "StoreNumber" },
                values: new object[] { 9, "Blah Blah Blah", 2, "Sunderland", 18 });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_GradeId",
                table: "Trainers",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

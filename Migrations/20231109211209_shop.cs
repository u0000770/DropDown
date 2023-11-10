using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropDown.Migrations
{
    public partial class shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Categories_GradeId",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Shops");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Grades");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_GradeId",
                table: "Shops",
                newName: "IX_Shops_GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shops",
                table: "Shops",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Grades_GradeId",
                table: "Shops",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Grades_GradeId",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shops",
                table: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.RenameTable(
                name: "Shops",
                newName: "Trainers");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Shops_GradeId",
                table: "Trainers",
                newName: "IX_Trainers_GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Categories_GradeId",
                table: "Trainers",
                column: "GradeId",
                principalTable: "Categories",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

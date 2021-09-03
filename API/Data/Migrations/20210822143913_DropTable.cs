using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DropTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Categories_CategoryFK",
                table: "Threads");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Threads_CategoryFK",
                table: "Threads");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryFK",
                table: "Threads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryFK",
                table: "Threads",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                values: new object[]
                {
                    "Action",
                    "Thriller",
                    "Science Fiction",
                    "Romance",
                    "Mystery",
                    "Music",
                    "Horror",
                    "History",
                    "Fantasy",
                    "Family",
                    "Drama",
                    "Documentary",
                    "Crime",
                    "Comedy",
                    "Animation",
                    "Adventure",
                    "War",
                    "Western"
                });

            migrationBuilder.CreateIndex(
                name: "IX_Threads_CategoryFK",
                table: "Threads",
                column: "CategoryFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Categories_CategoryFK",
                table: "Threads",
                column: "CategoryFK",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

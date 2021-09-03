using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(2200)", maxLength: 2200, nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoryFK = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threads_Categories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2200)", maxLength: 2200, nullable: false),
                    ThreadId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Comments_ThreadId",
                table: "Comments",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Threads_CategoryFK",
                table: "Threads",
                column: "CategoryFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

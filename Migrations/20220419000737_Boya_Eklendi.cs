using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Boya_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boya_Türüs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Boya_Türü_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boya_Türüs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boyas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Boya_Türü_Id = table.Column<int>(type: "int", nullable: false),
                    Boya_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Id = table.Column<int>(type: "int", nullable: false),
                    Birim_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boyas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boya_Türüs");

            migrationBuilder.DropTable(
                name: "Boyas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Tesfiye_Eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tesfiyes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tesfiye_Türü = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim_Id = table.Column<int>(type: "int", nullable: false),
                    Maliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesfiyes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tesfiyes");
        }
    }
}

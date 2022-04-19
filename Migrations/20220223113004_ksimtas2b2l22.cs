using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ksimtas2b2l22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birim_Txt_",
                table: "Birimlers",
                newName: "Birim_Uzun_Ad");

            migrationBuilder.AddColumn<string>(
                name: "Birim_Kısa_ad",
                table: "Birimlers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim_Kısa_ad",
                table: "Birimlers");

            migrationBuilder.RenameColumn(
                name: "Birim_Uzun_Ad",
                table: "Birimlers",
                newName: "Birim_Txt_");
        }
    }
}

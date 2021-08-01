using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_1_EFCORE_CODEFIRST.Migrations
{
    public partial class dungnav3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dungna",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dungna",
                table: "Accounts");
        }
    }
}

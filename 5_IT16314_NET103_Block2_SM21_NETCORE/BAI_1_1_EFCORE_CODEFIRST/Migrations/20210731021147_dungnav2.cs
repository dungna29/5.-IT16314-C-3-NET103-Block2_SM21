using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_1_EFCORE_CODEFIRST.Migrations
{
    public partial class dungnav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acc = table.Column<string>(type: "nvarchar(29)", maxLength: 29, nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(29)", maxLength: 29, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    YearofBirth = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

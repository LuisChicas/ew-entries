using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyWallet.Entries.Data.Migrations
{
    public partial class AddEntryCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Entries",
                type: "int",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Entries");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Repository.Migrations
{
    public partial class addedBoosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoostType",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoostType",
                table: "Users");
        }
    }
}

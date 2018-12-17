using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Repository.Migrations
{
    public partial class TimestampLongToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Timestamp",
                table: "Images",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Timestamp",
                table: "Images",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}

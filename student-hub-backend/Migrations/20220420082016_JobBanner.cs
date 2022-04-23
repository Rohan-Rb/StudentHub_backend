using Microsoft.EntityFrameworkCore.Migrations;

namespace student_hub_backend.Migrations
{
    public partial class JobBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobBanner",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobBanner",
                table: "Job");
        }
    }
}

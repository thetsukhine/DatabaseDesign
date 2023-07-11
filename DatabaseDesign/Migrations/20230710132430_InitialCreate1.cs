using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseDesign.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthDeclaration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessNumber = table.Column<int>(type: "int", nullable: false),
                    NRIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuarantineOrder = table.Column<bool>(type: "bit", nullable: true),
                    CloseContact = table.Column<bool>(type: "bit", nullable: true),
                    Fever = table.Column<bool>(type: "bit", nullable: true),
                    Agreement = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthDeclaration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthDeclaration");
        }
    }
}

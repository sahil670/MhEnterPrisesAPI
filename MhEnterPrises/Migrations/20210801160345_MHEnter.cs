using Microsoft.EntityFrameworkCore.Migrations;

namespace MhEnterPrises.Migrations
{
    public partial class MHEnter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HomeAppliances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeAppliances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOrder",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    homeAppliancesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlaceOrder_HomeAppliances_homeAppliancesid",
                        column: x => x.homeAppliancesid,
                        principalTable: "HomeAppliances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOrder_homeAppliancesid",
                table: "PlaceOrder",
                column: "homeAppliancesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "PlaceOrder");

            migrationBuilder.DropTable(
                name: "StaffMember");

            migrationBuilder.DropTable(
                name: "HomeAppliances");
        }
    }
}

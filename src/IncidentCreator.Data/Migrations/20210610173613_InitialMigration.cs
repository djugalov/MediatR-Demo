using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentCreator.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    impact = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_under_incident = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentProductMaps",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    incident_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentProductMaps", x => x.id);
                    table.ForeignKey(
                        name: "FK_IncidentProductMaps_Incidents_incident_id",
                        column: x => x.incident_id,
                        principalTable: "Incidents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncidentProductMaps_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name" },
                values: new object[] { new Guid("c4ec0869-11aa-43c3-a338-d6f813aba2b1"), false, "TestProduct-1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name" },
                values: new object[] { new Guid("5b99a661-1421-498c-b2aa-9f764dfee832"), false, "TestProduct-2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name" },
                values: new object[] { new Guid("e88fc724-7427-4e48-8b7d-0b702ec2deab"), false, "TestProduct-3" });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentProductMaps_incident_id",
                table: "IncidentProductMaps",
                column: "incident_id");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentProductMaps_product_id",
                table: "IncidentProductMaps",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentProductMaps");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

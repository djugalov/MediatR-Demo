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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impact = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_under_incident = table.Column<bool>(type: "bit", nullable: false),
                    incident_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Incidents_incident_id",
                        column: x => x.incident_id,
                        principalTable: "Incidents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name", "incident_id" },
                values: new object[] { new Guid("8770e553-7b59-41d7-8f57-5a8cfe510b1f"), false, "TestProduct-1", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name", "incident_id" },
                values: new object[] { new Guid("c92f276a-5f2a-455b-9e34-af11cfd4c025"), false, "TestProduct-2", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "is_under_incident", "name", "incident_id" },
                values: new object[] { new Guid("6b6b4d3b-0ff1-4002-8236-d24aa3c6fd98"), false, "TestProduct-3", null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_incident_id",
                table: "Products",
                column: "incident_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}

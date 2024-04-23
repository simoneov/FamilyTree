using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTree.Migrations
{
    public partial class Wedding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Divorce = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HusbandId = table.Column<int>(type: "int", nullable: true),
                    WifeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_People_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Weddings_People_WifeId",
                        column: x => x.WifeId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_HusbandId",
                table: "Weddings",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_WifeId",
                table: "Weddings",
                column: "WifeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weddings");
        }
    }
}

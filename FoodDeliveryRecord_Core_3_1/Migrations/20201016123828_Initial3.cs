using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryRecord_Core_3_1.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SignatureId",
                table: "Receivers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerSignature = table.Column<string>(nullable: true),
                    DateVerified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_SignatureId",
                table: "Receivers",
                column: "SignatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_Signatures_SignatureId",
                table: "Receivers",
                column: "SignatureId",
                principalTable: "Signatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_Signatures_SignatureId",
                table: "Receivers");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropIndex(
                name: "IX_Receivers_SignatureId",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "SignatureId",
                table: "Receivers");
        }
    }
}

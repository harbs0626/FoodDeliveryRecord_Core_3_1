using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryRecord_Core_3_1.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodConditionId",
                table: "Receivers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalDetail = table.Column<string>(nullable: true),
                    CorrectiveAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptable = table.Column<bool>(nullable: false),
                    Unacceptable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageTemperature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptable = table.Column<bool>(nullable: false),
                    Unacceptable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTemperature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptable = table.Column<bool>(nullable: false),
                    Unacceptable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTemperature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceptable = table.Column<bool>(nullable: false),
                    Unacceptable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemperature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageConditionId = table.Column<int>(nullable: true),
                    ProductConditionId = table.Column<int>(nullable: true),
                    PackageTemperatureId = table.Column<int>(nullable: true),
                    ProductTemperatureId = table.Column<int>(nullable: true),
                    DetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodConditions_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConditions_PackageCondition_PackageConditionId",
                        column: x => x.PackageConditionId,
                        principalTable: "PackageCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConditions_PackageTemperature_PackageTemperatureId",
                        column: x => x.PackageTemperatureId,
                        principalTable: "PackageTemperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConditions_ProductCondition_ProductConditionId",
                        column: x => x.ProductConditionId,
                        principalTable: "ProductCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConditions_ProductTemperature_ProductTemperatureId",
                        column: x => x.ProductTemperatureId,
                        principalTable: "ProductTemperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_FoodConditionId",
                table: "Receivers",
                column: "FoodConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConditions_DetailId",
                table: "FoodConditions",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConditions_PackageConditionId",
                table: "FoodConditions",
                column: "PackageConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConditions_PackageTemperatureId",
                table: "FoodConditions",
                column: "PackageTemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConditions_ProductConditionId",
                table: "FoodConditions",
                column: "ProductConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConditions_ProductTemperatureId",
                table: "FoodConditions",
                column: "ProductTemperatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_FoodConditions_FoodConditionId",
                table: "Receivers",
                column: "FoodConditionId",
                principalTable: "FoodConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_FoodConditions_FoodConditionId",
                table: "Receivers");

            migrationBuilder.DropTable(
                name: "FoodConditions");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "PackageCondition");

            migrationBuilder.DropTable(
                name: "PackageTemperature");

            migrationBuilder.DropTable(
                name: "ProductCondition");

            migrationBuilder.DropTable(
                name: "ProductTemperature");

            migrationBuilder.DropIndex(
                name: "IX_Receivers_FoodConditionId",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "FoodConditionId",
                table: "Receivers");
        }
    }
}

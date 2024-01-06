using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doanapi.Migrations
{
    /// <inheritdoc />
    public partial class District : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonViHC");

            migrationBuilder.AddColumn<int>(
                name: "CommuneId",
                table: "Construction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Construction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "Commune",
                columns: table => new
                {
                    CommuneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CommuneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commune", x => x.CommuneId);
                    table.ForeignKey(
                        name: "FK_Commune_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Construction_CommuneId",
                table: "Construction",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Construction_DistrictId",
                table: "Construction",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Commune_DistrictId",
                table: "Commune",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Construction_Commune_CommuneId",
                table: "Construction",
                column: "CommuneId",
                principalTable: "Commune",
                principalColumn: "CommuneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Construction_District_DistrictId",
                table: "Construction",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Construction_Commune_CommuneId",
                table: "Construction");

            migrationBuilder.DropForeignKey(
                name: "FK_Construction_District_DistrictId",
                table: "Construction");

            migrationBuilder.DropTable(
                name: "Commune");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropIndex(
                name: "IX_Construction_CommuneId",
                table: "Construction");

            migrationBuilder.DropIndex(
                name: "IX_Construction_DistrictId",
                table: "Construction");

            migrationBuilder.DropColumn(
                name: "CommuneId",
                table: "Construction");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Construction");

            migrationBuilder.CreateTable(
                name: "DonViHC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommuneId = table.Column<int>(type: "int", nullable: true),
                    CommuneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViHC", x => x.Id);
                });
        }
    }
}

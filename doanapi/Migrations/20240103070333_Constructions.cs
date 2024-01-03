using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doanapi.Migrations
{
    /// <inheritdoc />
    public partial class Constructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Construction_ConstructionType_ConstructionTypeId",
                table: "Construction");

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "Construction",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "Construction",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Construction",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ConstructionTypeId",
                table: "Construction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Construction_ConstructionType_ConstructionTypeId",
                table: "Construction",
                column: "ConstructionTypeId",
                principalTable: "ConstructionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Construction_ConstructionType_ConstructionTypeId",
                table: "Construction");

            migrationBuilder.AlterColumn<double>(
                name: "Y",
                table: "Construction",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "X",
                table: "Construction",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Construction",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConstructionTypeId",
                table: "Construction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Construction_ConstructionType_ConstructionTypeId",
                table: "Construction",
                column: "ConstructionTypeId",
                principalTable: "ConstructionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YarismaSunucusu.Migrations
{
    /// <inheritdoc />
    public partial class otonom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "iha_otonom",
                table: "TelemetriPaketis",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "iha_otonom",
                table: "TelemetriPaketis",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}

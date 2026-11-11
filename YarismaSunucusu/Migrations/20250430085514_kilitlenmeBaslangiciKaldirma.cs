using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YarismaSunucusu.Migrations
{
    /// <inheritdoc />
    public partial class kilitlenmeBaslangiciKaldirma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KilitlenmeBilgis_Saats_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis");

            migrationBuilder.DropIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis");

            migrationBuilder.DropColumn(
                name: "kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBaslangicZamaniId");

            migrationBuilder.AddForeignKey(
                name: "FK_KilitlenmeBilgis_Saats_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBaslangicZamaniId",
                principalTable: "Saats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

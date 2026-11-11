using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YarismaSunucusu.Migrations
{
    /// <inheritdoc />
    public partial class kilitlenmeBilgisiKaldır : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KilitlenmeBilgis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KilitlenmeBilgis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kilitlenmeBitisZamaniId = table.Column<int>(type: "INTEGER", nullable: false),
                    otonom_kilitlenme = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KilitlenmeBilgis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KilitlenmeBilgis_Saats_kilitlenmeBitisZamaniId",
                        column: x => x.kilitlenmeBitisZamaniId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBitisZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBitisZamaniId");
        }
    }
}

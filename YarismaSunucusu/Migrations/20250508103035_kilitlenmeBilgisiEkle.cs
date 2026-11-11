using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YarismaSunucusu.Migrations
{
    /// <inheritdoc />
    public partial class kilitlenmeBilgisiEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KilitlenmeBilgis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kilitlenmeBaslangicZamaniId = table.Column<int>(type: "INTEGER", nullable: false),
                    kilitlenmeBitisZamaniId = table.Column<int>(type: "INTEGER", nullable: false),
                    otonom_kilitlenme = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KilitlenmeBilgis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KilitlenmeBilgis_Saats_kilitlenmeBaslangicZamaniId",
                        column: x => x.kilitlenmeBaslangicZamaniId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KilitlenmeBilgis_Saats_kilitlenmeBitisZamaniId",
                        column: x => x.kilitlenmeBitisZamaniId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBaslangicZamaniId");

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBitisZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBitisZamaniId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KilitlenmeBilgis");
        }
    }
}

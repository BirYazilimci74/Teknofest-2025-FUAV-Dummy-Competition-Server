using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YarismaSunucusu.Migrations
{
    /// <inheritdoc />
    public partial class newdbInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Girises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kadi = table.Column<string>(type: "TEXT", nullable: false),
                    sifre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Girises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QRKoordinatlaris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    qrEnlem = table.Column<double>(type: "REAL", nullable: false),
                    qrBoylam = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRKoordinatlaris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    saat = table.Column<int>(type: "INTEGER", nullable: false),
                    dakika = table.Column<int>(type: "INTEGER", nullable: false),
                    saniye = table.Column<int>(type: "INTEGER", nullable: false),
                    milisaniye = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SunucuSaatis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gun = table.Column<int>(type: "INTEGER", nullable: false),
                    saat = table.Column<int>(type: "INTEGER", nullable: false),
                    dakika = table.Column<int>(type: "INTEGER", nullable: false),
                    saniye = table.Column<int>(type: "INTEGER", nullable: false),
                    milisaniye = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunucuSaatis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KamikazeBilgisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    kamikazeBaslangicZamaniId = table.Column<int>(type: "INTEGER", nullable: false),
                    kamikazeBitisZamaniId = table.Column<int>(type: "INTEGER", nullable: false),
                    qrMetni = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KamikazeBilgisis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KamikazeBilgisis_Saats_kamikazeBaslangicZamaniId",
                        column: x => x.kamikazeBaslangicZamaniId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KamikazeBilgisis_Saats_kamikazeBitisZamaniId",
                        column: x => x.kamikazeBitisZamaniId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TelemetriPaketis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    takim_numarasi = table.Column<int>(type: "INTEGER", nullable: false),
                    iha_enlem = table.Column<double>(type: "REAL", nullable: false),
                    iha_boylam = table.Column<double>(type: "REAL", nullable: false),
                    iha_irtifa = table.Column<double>(type: "REAL", nullable: false),
                    iha_dikilme = table.Column<double>(type: "REAL", nullable: false),
                    iha_yonelme = table.Column<double>(type: "REAL", nullable: false),
                    iha_yatis = table.Column<double>(type: "REAL", nullable: false),
                    iha_hiz = table.Column<double>(type: "REAL", nullable: false),
                    iha_batarya = table.Column<double>(type: "REAL", nullable: false),
                    iha_otonom = table.Column<double>(type: "REAL", nullable: false),
                    iha_kilitlenme = table.Column<int>(type: "INTEGER", nullable: false),
                    hedef_merkez_X = table.Column<int>(type: "INTEGER", nullable: false),
                    hedef_merkez_Y = table.Column<int>(type: "INTEGER", nullable: false),
                    hedef_genislik = table.Column<int>(type: "INTEGER", nullable: false),
                    hedef_yukseklik = table.Column<int>(type: "INTEGER", nullable: false),
                    gps_saatiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetriPaketis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelemetriPaketis_Saats_gps_saatiId",
                        column: x => x.gps_saatiId,
                        principalTable: "Saats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HavaSavumaSahasis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sunucusaatiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HavaSavumaSahasis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HavaSavumaSahasis_SunucuSaatis_sunucusaatiId",
                        column: x => x.sunucusaatiId,
                        principalTable: "SunucuSaatis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelemetriCevabis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sunucusaatiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetriCevabis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelemetriCevabis_SunucuSaatis_sunucusaatiId",
                        column: x => x.sunucusaatiId,
                        principalTable: "SunucuSaatis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HssKoordinats",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hssEnlem = table.Column<double>(type: "REAL", nullable: false),
                    hssBoylam = table.Column<double>(type: "REAL", nullable: false),
                    hssYaricap = table.Column<double>(type: "REAL", nullable: false),
                    HavaSavumaSahasiId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HssKoordinats", x => x.id);
                    table.ForeignKey(
                        name: "FK_HssKoordinats_HavaSavumaSahasis_HavaSavumaSahasiId",
                        column: x => x.HavaSavumaSahasiId,
                        principalTable: "HavaSavumaSahasis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KonumBilgisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    takim_numarasi = table.Column<int>(type: "INTEGER", nullable: false),
                    iha_enlem = table.Column<double>(type: "REAL", nullable: false),
                    iha_boylam = table.Column<double>(type: "REAL", nullable: false),
                    iha_irtifa = table.Column<double>(type: "REAL", nullable: false),
                    iha_dikilme = table.Column<double>(type: "REAL", nullable: false),
                    iha_yönelme = table.Column<double>(type: "REAL", nullable: false),
                    iha_yatis = table.Column<double>(type: "REAL", nullable: false),
                    iha_hizi = table.Column<double>(type: "REAL", nullable: false),
                    zaman_farki = table.Column<double>(type: "REAL", nullable: false),
                    TelemetriCevabiId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonumBilgisis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KonumBilgisis_TelemetriCevabis_TelemetriCevabiId",
                        column: x => x.TelemetriCevabiId,
                        principalTable: "TelemetriCevabis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HavaSavumaSahasis_sunucusaatiId",
                table: "HavaSavumaSahasis",
                column: "sunucusaatiId");

            migrationBuilder.CreateIndex(
                name: "IX_HssKoordinats_HavaSavumaSahasiId",
                table: "HssKoordinats",
                column: "HavaSavumaSahasiId");

            migrationBuilder.CreateIndex(
                name: "IX_KamikazeBilgisis_kamikazeBaslangicZamaniId",
                table: "KamikazeBilgisis",
                column: "kamikazeBaslangicZamaniId");

            migrationBuilder.CreateIndex(
                name: "IX_KamikazeBilgisis_kamikazeBitisZamaniId",
                table: "KamikazeBilgisis",
                column: "kamikazeBitisZamaniId");

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBaslangicZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBaslangicZamaniId");

            migrationBuilder.CreateIndex(
                name: "IX_KilitlenmeBilgis_kilitlenmeBitisZamaniId",
                table: "KilitlenmeBilgis",
                column: "kilitlenmeBitisZamaniId");

            migrationBuilder.CreateIndex(
                name: "IX_KonumBilgisis_TelemetriCevabiId",
                table: "KonumBilgisis",
                column: "TelemetriCevabiId");

            migrationBuilder.CreateIndex(
                name: "IX_TelemetriCevabis_sunucusaatiId",
                table: "TelemetriCevabis",
                column: "sunucusaatiId");

            migrationBuilder.CreateIndex(
                name: "IX_TelemetriPaketis_gps_saatiId",
                table: "TelemetriPaketis",
                column: "gps_saatiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Girises");

            migrationBuilder.DropTable(
                name: "HssKoordinats");

            migrationBuilder.DropTable(
                name: "KamikazeBilgisis");

            migrationBuilder.DropTable(
                name: "KilitlenmeBilgis");

            migrationBuilder.DropTable(
                name: "KonumBilgisis");

            migrationBuilder.DropTable(
                name: "QRKoordinatlaris");

            migrationBuilder.DropTable(
                name: "TelemetriPaketis");

            migrationBuilder.DropTable(
                name: "HavaSavumaSahasis");

            migrationBuilder.DropTable(
                name: "TelemetriCevabis");

            migrationBuilder.DropTable(
                name: "Saats");

            migrationBuilder.DropTable(
                name: "SunucuSaatis");
        }
    }
}

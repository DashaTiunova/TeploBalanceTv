using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeploBalanceKotelCore.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitTverdToplivoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "VarTverdToplivos",
                columns: table => new
                {
                    VarTverd_Toplivo_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateVariant = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NameVariant_TverdToplivo = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerID_User = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarTverdToplivos", x => x.VarTverd_Toplivo_ID);
                    table.ForeignKey(
                        name: "FK_VarTverdToplivos_Users_OwnerID_User",
                        column: x => x.OwnerID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataInputVariants_TverdToplivo",
                columns: table => new
                {
                    ID_DataInputVariant_TverdToplivo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_Variant_TverdToplivo = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerID_User = table.Column<int>(type: "INTEGER", nullable: false),
                    Variant_TverdToplivoId_Variant = table.Column<string>(type: "TEXT", nullable: false),
                    ParVyh = table.Column<double>(type: "REAL", nullable: false),
                    RashWat = table.Column<double>(type: "REAL", nullable: false),
                    TempPitWat = table.Column<double>(type: "REAL", nullable: false),
                    TempHeatWat = table.Column<double>(type: "REAL", nullable: false),
                    Pressure = table.Column<double>(type: "REAL", nullable: false),
                    TempRabT = table.Column<double>(type: "REAL", nullable: false),
                    SodH = table.Column<double>(type: "REAL", nullable: false),
                    SodC = table.Column<double>(type: "REAL", nullable: false),
                    SodO = table.Column<double>(type: "REAL", nullable: false),
                    SodS = table.Column<double>(type: "REAL", nullable: false),
                    SodWP = table.Column<double>(type: "REAL", nullable: false),
                    Alpha = table.Column<double>(type: "REAL", nullable: false),
                    TempVozd = table.Column<double>(type: "REAL", nullable: false),
                    TempOut = table.Column<double>(type: "REAL", nullable: false),
                    QChem = table.Column<double>(type: "REAL", nullable: false),
                    QMech = table.Column<double>(type: "REAL", nullable: false),
                    QCold = table.Column<double>(type: "REAL", nullable: false),
                    QWarm = table.Column<double>(type: "REAL", nullable: false),
                    VariantsTverdToplivoVarTverd_Toplivo_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataInputVariants_TverdToplivo", x => x.ID_DataInputVariant_TverdToplivo);
                    table.ForeignKey(
                        name: "FK_DataInputVariants_TverdToplivo_Users_OwnerID_User",
                        column: x => x.OwnerID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataInputVariants_TverdToplivo_VarTverdToplivos_VariantsTverdToplivoVarTverd_Toplivo_ID",
                        column: x => x.VariantsTverdToplivoVarTverd_Toplivo_ID,
                        principalTable: "VarTverdToplivos",
                        principalColumn: "VarTverd_Toplivo_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataInputVariants_TverdToplivo_OwnerID_User",
                table: "DataInputVariants_TverdToplivo",
                column: "OwnerID_User");

            migrationBuilder.CreateIndex(
                name: "IX_DataInputVariants_TverdToplivo_VariantsTverdToplivoVarTverd_Toplivo_ID",
                table: "DataInputVariants_TverdToplivo",
                column: "VariantsTverdToplivoVarTverd_Toplivo_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VarTverdToplivos_OwnerID_User",
                table: "VarTverdToplivos",
                column: "OwnerID_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataInputVariants_TverdToplivo");

            migrationBuilder.DropTable(
                name: "VarTverdToplivos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

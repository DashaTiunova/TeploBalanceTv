using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeploBalanceKotelCore.Migrations
{
    /// <inheritdoc />
    public partial class NameVariantEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameVariant_TverdToplivo",
                table: "VarTverdToplivos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameVariant_TverdToplivo",
                table: "VarTverdToplivos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

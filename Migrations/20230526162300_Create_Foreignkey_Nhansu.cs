using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    /// <inheritdoc />
    public partial class Create_Foreignkey_Nhansu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaCV",
                table: "Nhansu",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nhansu_MaCV",
                table: "Nhansu",
                column: "MaCV");

            migrationBuilder.AddForeignKey(
                name: "FK_Nhansu_ChucVu_MaCV",
                table: "Nhansu",
                column: "MaCV",
                principalTable: "ChucVu",
                principalColumn: "MaCV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nhansu_ChucVu_MaCV",
                table: "Nhansu");

            migrationBuilder.DropIndex(
                name: "IX_Nhansu_MaCV",
                table: "Nhansu");

            migrationBuilder.DropColumn(
                name: "MaCV",
                table: "Nhansu");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Hopdong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hopdong_Nhansu_MaNV",
                table: "Hopdong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Hopdong_Nhansu_MaNV",
                table: "Hopdong",
                column: "MaNV",
                principalTable: "Nhansu",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

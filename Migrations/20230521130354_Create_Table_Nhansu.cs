using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLNS.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Nhansu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hopdong",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaybatdau = table.Column<string>(type: "TEXT", nullable: false),
                    Ngayketthuc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hopdong", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "Phongban",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "TEXT", nullable: false),
                    TenPhong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongban", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "Nhansu",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    Hoten = table.Column<string>(type: "TEXT", nullable: false),
                    NgaySinh = table.Column<string>(type: "TEXT", nullable: false),
                    Gioitinh = table.Column<string>(type: "TEXT", nullable: false),
                    Chucvu = table.Column<string>(type: "TEXT", nullable: false),
                    MaPhong = table.Column<string>(type: "TEXT", nullable: false),
                    SDT = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhansu", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_Nhansu_Phongban_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongban",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhansu_MaPhong",
                table: "Nhansu",
                column: "MaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hopdong");

            migrationBuilder.DropTable(
                name: "Nhansu");

            migrationBuilder.DropTable(
                name: "Phongban");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Phong_TT_LoaiPhong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_LoaiPhong",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaPhong = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoaiPhong", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TrangThaiPhong",
                columns: table => new
                {
                    MaTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TrangThaiPhong", x => x.MaTT);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Phong",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoNguoi = table.Column<int>(type: "int", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Xoa = table.Column<int>(type: "int", nullable: true),
                    MaLoaiPhong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Phong", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_tbl_Phong_tbl_LoaiPhong_MaLoaiPhong",
                        column: x => x.MaLoaiPhong,
                        principalTable: "tbl_LoaiPhong",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Phong_tbl_TrangThaiPhong_TrangThai",
                        column: x => x.TrangThai,
                        principalTable: "tbl_TrangThaiPhong",
                        principalColumn: "MaTT");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Phong_MaLoaiPhong",
                table: "tbl_Phong",
                column: "MaLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Phong_TrangThai",
                table: "tbl_Phong",
                column: "TrangThai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Phong");

            migrationBuilder.DropTable(
                name: "tbl_LoaiPhong");

            migrationBuilder.DropTable(
                name: "tbl_TrangThaiPhong");
        }
    }
}

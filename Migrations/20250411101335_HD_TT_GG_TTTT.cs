using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class HD_TT_GG_TTTT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_GiamGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoaiGiam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiaTri = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GiamGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PhuongThucThanhToan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhuongThuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PhuongThucThanhToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TrangThaiThanhToan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TrangThaiThanhToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    NgayLapHD = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaPhuongThuc = table.Column<int>(type: "int", nullable: true),
                    MaGiam = table.Column<int>(type: "int", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_tbl_HoaDon_tbl_GiamGia_MaGiam",
                        column: x => x.MaGiam,
                        principalTable: "tbl_GiamGia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_HoaDon_tbl_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "tbl_KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_HoaDon_tbl_PhuongThucThanhToan_MaPhuongThuc",
                        column: x => x.MaPhuongThuc,
                        principalTable: "tbl_PhuongThucThanhToan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_HoaDon_tbl_TrangThaiThanhToan_TrangThai",
                        column: x => x.TrangThai,
                        principalTable: "tbl_TrangThaiThanhToan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_ChiTietHoaDonDV",
                columns: table => new
                {
                    MaChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaDichVu = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ChiTietHoaDonDV", x => x.MaChiTiet);
                    table.ForeignKey(
                        name: "FK_tbl_ChiTietHoaDonDV_tbl_DichVu_MaDichVu",
                        column: x => x.MaDichVu,
                        principalTable: "tbl_DichVu",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ChiTietHoaDonDV_tbl_HoaDon_MaHD",
                        column: x => x.MaHD,
                        principalTable: "tbl_HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ChiTietHoaDonDV_MaDichVu",
                table: "tbl_ChiTietHoaDonDV",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ChiTietHoaDonDV_MaHD",
                table: "tbl_ChiTietHoaDonDV",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HoaDon_MaGiam",
                table: "tbl_HoaDon",
                column: "MaGiam");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HoaDon_MaKH",
                table: "tbl_HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HoaDon_MaPhuongThuc",
                table: "tbl_HoaDon",
                column: "MaPhuongThuc");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HoaDon_TrangThai",
                table: "tbl_HoaDon",
                column: "TrangThai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_ChiTietHoaDonDV");

            migrationBuilder.DropTable(
                name: "tbl_HoaDon");

            migrationBuilder.DropTable(
                name: "tbl_GiamGia");

            migrationBuilder.DropTable(
                name: "tbl_PhuongThucThanhToan");

            migrationBuilder.DropTable(
                name: "tbl_TrangThaiThanhToan");
        }
    }
}

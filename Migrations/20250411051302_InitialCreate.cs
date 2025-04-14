using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CaLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioBatDau = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioKetThuc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CaLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ChucVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_VaiTro",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_VaiTro", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "tbl_NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVuId = table.Column<int>(type: "int", nullable: false),
                    CaLamId = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_NhanVien_tbl_CaLam_CaLamId",
                        column: x => x.CaLamId,
                        principalTable: "tbl_CaLam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_NhanVien_tbl_ChucVu_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "tbl_ChucVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    HinhAnh = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    TenHienThi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LoaiTK = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Xoa = table.Column<bool>(type: "bit", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TaiKhoan", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK_tbl_TaiKhoan_tbl_VaiTro_LoaiTK",
                        column: x => x.LoaiTK,
                        principalTable: "tbl_VaiTro",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NhanVien_CaLamId",
                table: "tbl_NhanVien",
                column: "CaLamId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NhanVien_ChucVuId",
                table: "tbl_NhanVien",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TaiKhoan_LoaiTK",
                table: "tbl_TaiKhoan",
                column: "LoaiTK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_NhanVien");

            migrationBuilder.DropTable(
                name: "tbl_TaiKhoan");

            migrationBuilder.DropTable(
                name: "tbl_CaLam");

            migrationBuilder.DropTable(
                name: "tbl_ChucVu");

            migrationBuilder.DropTable(
                name: "tbl_VaiTro");
        }
    }
}

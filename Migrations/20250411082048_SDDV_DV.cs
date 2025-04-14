using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SDDV_DV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DatPhong_tbl_KhachHang_MaKH",
                table: "tbl_DatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DatPhong_tbl_Phong_MaPhong",
                table: "tbl_DatPhong");

            migrationBuilder.AddColumn<int>(
                name: "MaVaiTro",
                table: "tbl_NhanVien",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaVaiTro",
                table: "tbl_KhachHang",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaPhong",
                table: "tbl_DatPhong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaKH",
                table: "tbl_DatPhong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "tbl_DichVu",
                columns: table => new
                {
                    MaDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DichVu", x => x.MaDichVu);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SuDungDichVu",
                columns: table => new
                {
                    MaSDDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: true),
                    MaDV = table.Column<int>(type: "int", nullable: true),
                    NgaySD = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(200)", nullable: true),
                    Xoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SuDungDichVu", x => x.MaSDDV);
                    table.ForeignKey(
                        name: "FK_tbl_SuDungDichVu_tbl_DichVu_MaDV",
                        column: x => x.MaDV,
                        principalTable: "tbl_DichVu",
                        principalColumn: "MaDichVu");
                    table.ForeignKey(
                        name: "FK_tbl_SuDungDichVu_tbl_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "tbl_KhachHang",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NhanVien_MaVaiTro",
                table: "tbl_NhanVien",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_KhachHang_MaVaiTro",
                table: "tbl_KhachHang",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SuDungDichVu_MaDV",
                table: "tbl_SuDungDichVu",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SuDungDichVu_MaKH",
                table: "tbl_SuDungDichVu",
                column: "MaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DatPhong_tbl_KhachHang_MaKH",
                table: "tbl_DatPhong",
                column: "MaKH",
                principalTable: "tbl_KhachHang",
                principalColumn: "MaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DatPhong_tbl_Phong_MaPhong",
                table: "tbl_DatPhong",
                column: "MaPhong",
                principalTable: "tbl_Phong",
                principalColumn: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_KhachHang_tbl_VaiTro_MaVaiTro",
                table: "tbl_KhachHang",
                column: "MaVaiTro",
                principalTable: "tbl_VaiTro",
                principalColumn: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_NhanVien_tbl_VaiTro_MaVaiTro",
                table: "tbl_NhanVien",
                column: "MaVaiTro",
                principalTable: "tbl_VaiTro",
                principalColumn: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DatPhong_tbl_KhachHang_MaKH",
                table: "tbl_DatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DatPhong_tbl_Phong_MaPhong",
                table: "tbl_DatPhong");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_KhachHang_tbl_VaiTro_MaVaiTro",
                table: "tbl_KhachHang");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_NhanVien_tbl_VaiTro_MaVaiTro",
                table: "tbl_NhanVien");

            migrationBuilder.DropTable(
                name: "tbl_SuDungDichVu");

            migrationBuilder.DropTable(
                name: "tbl_DichVu");

            migrationBuilder.DropIndex(
                name: "IX_tbl_NhanVien_MaVaiTro",
                table: "tbl_NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_tbl_KhachHang_MaVaiTro",
                table: "tbl_KhachHang");

            migrationBuilder.DropColumn(
                name: "MaVaiTro",
                table: "tbl_NhanVien");

            migrationBuilder.DropColumn(
                name: "MaVaiTro",
                table: "tbl_KhachHang");

            migrationBuilder.AlterColumn<int>(
                name: "MaPhong",
                table: "tbl_DatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaKH",
                table: "tbl_DatPhong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DatPhong_tbl_KhachHang_MaKH",
                table: "tbl_DatPhong",
                column: "MaKH",
                principalTable: "tbl_KhachHang",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DatPhong_tbl_Phong_MaPhong",
                table: "tbl_DatPhong",
                column: "MaPhong",
                principalTable: "tbl_Phong",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Phong_tbl_LoaiPhong_MaLoaiPhong",
                table: "tbl_Phong");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "tbl_Phong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "MaLoaiPhong",
                table: "tbl_Phong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "tbl_Phong",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Phong_tbl_LoaiPhong_MaLoaiPhong",
                table: "tbl_Phong",
                column: "MaLoaiPhong",
                principalTable: "tbl_LoaiPhong",
                principalColumn: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Phong_tbl_LoaiPhong_MaLoaiPhong",
                table: "tbl_Phong");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "tbl_Phong",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaLoaiPhong",
                table: "tbl_Phong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "tbl_Phong",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Phong_tbl_LoaiPhong_MaLoaiPhong",
                table: "tbl_Phong",
                column: "MaLoaiPhong",
                principalTable: "tbl_LoaiPhong",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

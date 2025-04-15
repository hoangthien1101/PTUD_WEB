using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class update_MaTK_into_Id_int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_TaiKhoan",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "MaTK",
                table: "tbl_TaiKhoan");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_TaiKhoan",
                table: "tbl_TaiKhoan",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_TaiKhoan",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbl_TaiKhoan");

            migrationBuilder.AddColumn<string>(
                name: "MaTK",
                table: "tbl_TaiKhoan",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_TaiKhoan",
                table: "tbl_TaiKhoan",
                column: "MaTK");
        }
    }
}

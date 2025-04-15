using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class tbl_HinhAnhPhong__ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdHinhAnh",
                table: "tbl_Phong");

            migrationBuilder.CreateTable(
                name: "tbl_HinhAnhPhong",
                columns: table => new
                {
                    IdHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "varchar(max)", nullable: true),
                    isUsed = table.Column<bool>(type: "bit", nullable: true),
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HinhAnhPhong", x => x.IdHinhAnh);
                    table.ForeignKey(
                        name: "FK_tbl_HinhAnhPhong_tbl_Phong_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "tbl_Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_HinhAnhPhong_MaPhong",
                table: "tbl_HinhAnhPhong",
                column: "MaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_HinhAnhPhong");

            migrationBuilder.AddColumn<int>(
                name: "IdHinhAnh",
                table: "tbl_Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

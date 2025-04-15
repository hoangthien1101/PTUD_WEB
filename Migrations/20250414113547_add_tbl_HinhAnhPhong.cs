using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_tbl_HinhAnhPhong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdHinhAnh",
                table: "tbl_Phong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_HinhAnhPhong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "varchar(max)", nullable: true),
                    isUsed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_HinhAnhPhong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_HinhAnhPhong_tbl_Phong_Id",
                        column: x => x.Id,
                        principalTable: "tbl_Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_HinhAnhPhong");

            migrationBuilder.DropColumn(
                name: "IdHinhAnh",
                table: "tbl_Phong");
        }
    }
}

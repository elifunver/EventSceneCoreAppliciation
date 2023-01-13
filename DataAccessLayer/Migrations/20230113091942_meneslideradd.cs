using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class meneslideradd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "adminler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adminler",
                table: "adminler",
                column: "adminId");

            migrationBuilder.CreateTable(
                name: "menuler",
                columns: table => new
                {
                    menuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seoUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuler", x => x.menuId);
                    table.ForeignKey(
                        name: "FK_menuler_menuler_parentId",
                        column: x => x.parentId,
                        principalTable: "menuler",
                        principalColumn: "menuId");
                });

            migrationBuilder.CreateTable(
                name: "slider",
                columns: table => new
                {
                    sliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sliderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    resimUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slider", x => x.sliderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_menuler_parentId",
                table: "menuler",
                column: "parentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menuler");

            migrationBuilder.DropTable(
                name: "slider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adminler",
                table: "adminler");

            migrationBuilder.RenameTable(
                name: "adminler",
                newName: "Admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "adminId");
        }
    }
}

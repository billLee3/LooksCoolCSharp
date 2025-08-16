using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerAppsUIValues.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UISchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TextColorPrimary = table.Column<string>(type: "TEXT", nullable: false),
                    TextColorSecondary = table.Column<string>(type: "TEXT", nullable: false),
                    TextColorTertiary = table.Column<string>(type: "TEXT", nullable: false),
                    TextColorTertiaryLight = table.Column<string>(type: "TEXT", nullable: false),
                    TextColorTertiaryDark = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColorPrimary = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColorSecondary = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColorTertiary = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColorTertiaryLight = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundColorTertiaryDark = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryFontFamily = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryFontFamily = table.Column<string>(type: "TEXT", nullable: false),
                    TertiaryFontFamily = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UISchemas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UISchemas");
        }
    }
}

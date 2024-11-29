using Microsoft.EntityFrameworkCore.Migrations;


namespace LibaryMangement.DL.Migrations;

/// <inheritdoc />
public partial class CreateBooksTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Books",
            columns: table => new
            {
                BookId = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PublishedYear = table.Column<int>(type: "int", nullable: false),
                AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Books", x => x.BookId);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Books");
    }
}

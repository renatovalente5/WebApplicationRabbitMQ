using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationRabbitMQ.Migrations
{
    /// <inheritdoc />
    public partial class Create_GameTypeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameTypeEnumId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameTypeEnum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypeEnum", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeEnumId",
                table: "Games",
                column: "GameTypeEnumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameTypeEnum_GameTypeEnumId",
                table: "Games",
                column: "GameTypeEnumId",
                principalTable: "GameTypeEnum",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameTypeEnum_GameTypeEnumId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameTypeEnum");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameTypeEnumId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameTypeEnumId",
                table: "Games");
        }
    }
}

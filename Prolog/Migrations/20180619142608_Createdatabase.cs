using Microsoft.EntityFrameworkCore.Migrations;

namespace Prolog.Migrations
{
    public partial class Createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arguments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arguments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArgumentPositions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<int>(nullable: false),
                    FactId = table.Column<long>(nullable: true),
                    ArgumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArgumentPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArgumentPositions_Arguments_ArgumentId",
                        column: x => x.ArgumentId,
                        principalTable: "Arguments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdResponse = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    RuleId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArgumentPositions_ArgumentId",
                table: "ArgumentPositions",
                column: "ArgumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArgumentPositions_FactId",
                table: "ArgumentPositions",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_RuleId",
                table: "Facts",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_IdResponse",
                table: "Rules",
                column: "IdResponse",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArgumentPositions_Facts_FactId",
                table: "ArgumentPositions",
                column: "FactId",
                principalTable: "Facts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Facts_IdResponse",
                table: "Rules",
                column: "IdResponse",
                principalTable: "Facts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Facts_IdResponse",
                table: "Rules");

            migrationBuilder.DropTable(
                name: "ArgumentPositions");

            migrationBuilder.DropTable(
                name: "Arguments");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "Rules");
        }
    }
}

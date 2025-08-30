using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NitroSongs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChordTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "chords");

            migrationBuilder.AddColumn<long>(
                name: "chord_type_id",
                table: "chords",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "chord_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chord_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chords_chord_type_id",
                table: "chords",
                column: "chord_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_chords_chord_types_chord_type_id",
                table: "chords",
                column: "chord_type_id",
                principalTable: "chord_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chords_chord_types_chord_type_id",
                table: "chords");

            migrationBuilder.DropTable(
                name: "chord_types");

            migrationBuilder.DropIndex(
                name: "IX_chords_chord_type_id",
                table: "chords");

            migrationBuilder.DropColumn(
                name: "chord_type_id",
                table: "chords");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "chords",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

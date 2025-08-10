using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NitroSongs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    code_es = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    code_en = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    ImgUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chords", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rhythms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    img_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rhythms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "image_chords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    chord_id = table.Column<long>(type: "bigint", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image_chords", x => x.id);
                    table.ForeignKey(
                        name: "FK_image_chords_chords_chord_id",
                        column: x => x.chord_id,
                        principalTable: "chords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chord_tones",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chord_id = table.Column<long>(type: "bigint", nullable: false),
                    tone_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chord_tones", x => x.id);
                    table.ForeignKey(
                        name: "FK_chord_tones_chords_chord_id",
                        column: x => x.chord_id,
                        principalTable: "chords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chord_tones_tones_tone_id",
                        column: x => x.tone_id,
                        principalTable: "tones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    genre_id = table.Column<long>(type: "bigint", maxLength: 255, nullable: false),
                    lyrics = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_private = table.Column<bool>(type: "boolean", nullable: false),
                    rhythm_id = table.Column<long>(type: "bigint", nullable: false),
                    tone_id = table.Column<long>(type: "bigint", nullable: false),
                    author_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.id);
                    table.ForeignKey(
                        name: "FK_songs_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_songs_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_songs_rhythms_rhythm_id",
                        column: x => x.rhythm_id,
                        principalTable: "rhythms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_songs_tones_tone_id",
                        column: x => x.tone_id,
                        principalTable: "tones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "song_chords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    song_id = table.Column<long>(type: "bigint", nullable: false),
                    chord_id = table.Column<long>(type: "bigint", nullable: false),
                    word_index = table.Column<int>(type: "integer", nullable: false),
                    letter_index = table.Column<int>(type: "integer", nullable: false),
                    pixel_movement = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_chords", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_chords_chords_chord_id",
                        column: x => x.chord_id,
                        principalTable: "chords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_song_chords_songs_song_id",
                        column: x => x.song_id,
                        principalTable: "songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_songs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    song_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_songs", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_songs_songs_song_id",
                        column: x => x.song_id,
                        principalTable: "songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_songs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chord_tones_chord_id",
                table: "chord_tones",
                column: "chord_id");

            migrationBuilder.CreateIndex(
                name: "IX_chord_tones_tone_id",
                table: "chord_tones",
                column: "tone_id");

            migrationBuilder.CreateIndex(
                name: "IX_image_chords_chord_id",
                table: "image_chords",
                column: "chord_id");

            migrationBuilder.CreateIndex(
                name: "IX_song_chords_chord_id",
                table: "song_chords",
                column: "chord_id");

            migrationBuilder.CreateIndex(
                name: "IX_song_chords_song_id",
                table: "song_chords",
                column: "song_id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_author_id",
                table: "songs",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_genre_id",
                table: "songs",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_rhythm_id",
                table: "songs",
                column: "rhythm_id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_tone_id",
                table: "songs",
                column: "tone_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_songs_song_id",
                table: "user_songs",
                column: "song_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_songs_user_id",
                table: "user_songs",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chord_tones");

            migrationBuilder.DropTable(
                name: "image_chords");

            migrationBuilder.DropTable(
                name: "song_chords");

            migrationBuilder.DropTable(
                name: "user_songs");

            migrationBuilder.DropTable(
                name: "chords");

            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "rhythms");

            migrationBuilder.DropTable(
                name: "tones");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLibertadoresHAS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESTADIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTADIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "UsuarioComum"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_POSICOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_POSICOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_RODADAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RODADAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIMES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnoFundacao = table.Column<int>(type: "int", nullable: false),
                    Escudo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TitulosLibertadores = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIMES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARTIDAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstadioId = table.Column<int>(type: "int", nullable: false),
                    RodadaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARTIDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PARTIDAS_TB_ESTADIOS_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "TB_ESTADIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PARTIDAS_TB_RODADAS_RodadaId",
                        column: x => x.RodadaId,
                        principalTable: "TB_RODADAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_JOGADORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    PosicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGADORES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_JOGADORES_TB_POSICOES_PosicaoId",
                        column: x => x.PosicaoId,
                        principalTable: "TB_POSICOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_JOGADORES_TB_TIMES_TimeId",
                        column: x => x.TimeId,
                        principalTable: "TB_TIMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARTIDAS_TIMES",
                columns: table => new
                {
                    PartidaId = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    Gols = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARTIDAS_TIMES", x => new { x.PartidaId, x.TimeId });
                    table.ForeignKey(
                        name: "FK_TB_PARTIDAS_TIMES_TB_PARTIDAS_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "TB_PARTIDAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PARTIDAS_TIMES_TB_TIMES_TimeId",
                        column: x => x.TimeId,
                        principalTable: "TB_TIMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGADORES_PosicaoId",
                table: "TB_JOGADORES",
                column: "PosicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGADORES_TimeId",
                table: "TB_JOGADORES",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARTIDAS_EstadioId",
                table: "TB_PARTIDAS",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARTIDAS_RodadaId",
                table: "TB_PARTIDAS",
                column: "RodadaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARTIDAS_TIMES_TimeId",
                table: "TB_PARTIDAS_TIMES",
                column: "TimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "TB_JOGADORES");

            migrationBuilder.DropTable(
                name: "TB_PARTIDAS_TIMES");

            migrationBuilder.DropTable(
                name: "TB_POSICOES");

            migrationBuilder.DropTable(
                name: "TB_PARTIDAS");

            migrationBuilder.DropTable(
                name: "TB_TIMES");

            migrationBuilder.DropTable(
                name: "TB_ESTADIOS");

            migrationBuilder.DropTable(
                name: "TB_RODADAS");
        }
    }
}

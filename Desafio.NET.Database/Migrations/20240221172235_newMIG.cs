using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.NET.Database.Migrations
{
    /// <inheritdoc />
    public partial class newMIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoChave = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagadores_Chaves_ChaveId",
                        column: x => x.ChaveId,
                        principalTable: "Chaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recebedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebedores_Chaves_ChaveId",
                        column: x => x.ChaveId,
                        principalTable: "Chaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "date", nullable: false),
                    PagadorId = table.Column<int>(type: "int", nullable: false),
                    RecebedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Pagadores_PagadorId",
                        column: x => x.PagadorId,
                        principalTable: "Pagadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacoes_Recebedores_RecebedorId",
                        column: x => x.RecebedorId,
                        principalTable: "Recebedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagadores_ChaveId",
                table: "Pagadores",
                column: "ChaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Recebedores_ChaveId",
                table: "Recebedores",
                column: "ChaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_PagadorId",
                table: "Transacoes",
                column: "PagadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_RecebedorId",
                table: "Transacoes",
                column: "RecebedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Pagadores");

            migrationBuilder.DropTable(
                name: "Recebedores");

            migrationBuilder.DropTable(
                name: "Chaves");
        }
    }
}

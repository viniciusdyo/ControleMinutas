using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMinutas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TaxaAbastecimento = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxaTroca = table.Column<decimal>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabalhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EntregaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Terminais_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "Terminais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trabalhos_Terminais_SaidaId",
                        column: x => x.SaidaId,
                        principalTable: "Terminais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrabalhoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Empresa = table.Column<string>(type: "TEXT", nullable: false),
                    Saida = table.Column<string>(type: "TEXT", nullable: false),
                    Entrega = table.Column<string>(type: "TEXT", nullable: false),
                    TaxaAbastecimento = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxaTroca = table.Column<decimal>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minutas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minutas_Trabalhos_TrabalhoId",
                        column: x => x.TrabalhoId,
                        principalTable: "Trabalhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CriadoEm",
                table: "Empresas",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EditadoEm",
                table: "Empresas",
                column: "EditadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Nome",
                table: "Empresas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_CriadoEm",
                table: "Minutas",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_Data",
                table: "Minutas",
                column: "Data");

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_EditadoEm",
                table: "Minutas",
                column: "EditadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_Status",
                table: "Minutas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_TrabalhoId",
                table: "Minutas",
                column: "TrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminais_CriadoEm",
                table: "Terminais",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Terminais_EditadoEm",
                table: "Terminais",
                column: "EditadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Terminais_Nome",
                table: "Terminais",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_CriadoEm",
                table: "Trabalhos",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_EditadoEm",
                table: "Trabalhos",
                column: "EditadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_EmpresaId",
                table: "Trabalhos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_EntregaId",
                table: "Trabalhos",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_SaidaId",
                table: "Trabalhos",
                column: "SaidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Minutas");

            migrationBuilder.DropTable(
                name: "Trabalhos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Terminais");
        }
    }
}

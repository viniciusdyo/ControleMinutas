using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleMinutas.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaModeloDeDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Minutas_TrabalhoId_Data_Status",
                table: "Minutas");

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Trabalhos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditadoEm",
                table: "Trabalhos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Terminais",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditadoEm",
                table: "Terminais",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Minutas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditadoEm",
                table: "Minutas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Empresas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditadoEm",
                table: "Empresas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_CriadoEm",
                table: "Trabalhos",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_EditadoEm",
                table: "Trabalhos",
                column: "EditadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Terminais_CriadoEm",
                table: "Terminais",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_Terminais_EditadoEm",
                table: "Terminais",
                column: "EditadoEm");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trabalhos_CriadoEm",
                table: "Trabalhos");

            migrationBuilder.DropIndex(
                name: "IX_Trabalhos_EditadoEm",
                table: "Trabalhos");

            migrationBuilder.DropIndex(
                name: "IX_Terminais_CriadoEm",
                table: "Terminais");

            migrationBuilder.DropIndex(
                name: "IX_Terminais_EditadoEm",
                table: "Terminais");

            migrationBuilder.DropIndex(
                name: "IX_Minutas_CriadoEm",
                table: "Minutas");

            migrationBuilder.DropIndex(
                name: "IX_Minutas_Data",
                table: "Minutas");

            migrationBuilder.DropIndex(
                name: "IX_Minutas_EditadoEm",
                table: "Minutas");

            migrationBuilder.DropIndex(
                name: "IX_Minutas_Status",
                table: "Minutas");

            migrationBuilder.DropIndex(
                name: "IX_Minutas_TrabalhoId",
                table: "Minutas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_CriadoEm",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_EditadoEm",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_Nome",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Trabalhos");

            migrationBuilder.DropColumn(
                name: "EditadoEm",
                table: "Trabalhos");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Terminais");

            migrationBuilder.DropColumn(
                name: "EditadoEm",
                table: "Terminais");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Minutas");

            migrationBuilder.DropColumn(
                name: "EditadoEm",
                table: "Minutas");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EditadoEm",
                table: "Empresas");

            migrationBuilder.CreateIndex(
                name: "IX_Minutas_TrabalhoId_Data_Status",
                table: "Minutas",
                columns: new[] { "TrabalhoId", "Data", "Status" });
        }
    }
}

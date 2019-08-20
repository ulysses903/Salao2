using Microsoft.EntityFrameworkCore.Migrations;

namespace Salao.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cliente_ClienteId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Procedimentos_ProcedimentosId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedimentosId",
                table: "Servico",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Servico",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Servico",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cliente_ClienteId",
                table: "Servico",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Procedimentos_ProcedimentosId",
                table: "Servico",
                column: "ProcedimentosId",
                principalTable: "Procedimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Cliente_ClienteId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Procedimentos_ProcedimentosId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "ProcedimentosId",
                table: "Servico",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Servico",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Servico",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Cliente_ClienteId",
                table: "Servico",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Funcionario_FuncionarioId",
                table: "Servico",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Procedimentos_ProcedimentosId",
                table: "Servico",
                column: "ProcedimentosId",
                principalTable: "Procedimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

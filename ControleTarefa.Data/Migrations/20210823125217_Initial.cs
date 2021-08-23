using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTarefa.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Finalizado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TarefaID = table.Column<Guid>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    DataAgendada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Tarefas_TarefaID",
                        column: x => x.TarefaID,
                        principalTable: "Tarefas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TarefaID = table.Column<Guid>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Final = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atividades_Tarefas_TarefaID",
                        column: x => x.TarefaID,
                        principalTable: "Tarefas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_TarefaID",
                table: "Agendamentos",
                column: "TarefaID");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_TarefaID",
                table: "Atividades",
                column: "TarefaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}

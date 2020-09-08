using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackatonPWGS.Migrations
{
    public partial class AddedAcompanhante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acompanhante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_acompanhante = table.Column<string>(nullable: false),
                    email_acompanhante = table.Column<string>(nullable: true),
                    numero_contato_acompanhante = table.Column<long>(nullable: false),
                    descricao_acompanhante = table.Column<string>(nullable: true),
                    id_agenda_acompanhante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acompanhante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "acompanhante_local_atendimento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_acompanhante = table.Column<int>(nullable: false),
                    acompanhanteid = table.Column<int>(nullable: true),
                    id_local_atendimento = table.Column<int>(nullable: false),
                    local_atendimentoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acompanhante_local_atendimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_acompanhante_local_atendimento_acompanhante_acompanhanteid",
                        column: x => x.acompanhanteid,
                        principalTable: "acompanhante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_acompanhante_local_atendimento_local_atendimento_local_atendimentoid",
                        column: x => x.local_atendimentoid,
                        principalTable: "local_atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agenda_acompanhante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_acompanhante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda_acompanhante", x => x.id);
                    table.ForeignKey(
                        name: "FK_agenda_acompanhante_acompanhante_id_acompanhante",
                        column: x => x.id_acompanhante,
                        principalTable: "acompanhante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agendamento_acompanhante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_agenda_acompanhante = table.Column<int>(nullable: false),
                    id_paciente = table.Column<int>(nullable: true),
                    dt_hr_inicio = table.Column<DateTime>(nullable: false),
                    dt_ht_fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamento_acompanhante", x => x.id);
                    table.ForeignKey(
                        name: "FK_agendamento_acompanhante_agenda_acompanhante_id_agenda_acompanhante",
                        column: x => x.id_agenda_acompanhante,
                        principalTable: "agenda_acompanhante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agendamento_acompanhante_paciente_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horarios_atendimento_acompanhante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dia_semana = table.Column<int>(nullable: false),
                    id_agenda_acompanhante = table.Column<int>(nullable: false),
                    hr_inicio = table.Column<DateTime>(nullable: false),
                    hr_fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios_atendimento_acompanhante", x => x.id);
                    table.ForeignKey(
                        name: "FK_horarios_atendimento_acompanhante_agenda_acompanhante_id_agenda_acompanhante",
                        column: x => x.id_agenda_acompanhante,
                        principalTable: "agenda_acompanhante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_horarios_atendimento_acompanhante_dia_semana_id_dia_semana",
                        column: x => x.id_dia_semana,
                        principalTable: "dia_semana",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "acompanhante",
                columns: new[] { "id", "descricao_acompanhante", "email_acompanhante", "id_agenda_acompanhante", "nome_acompanhante", "numero_contato_acompanhante" },
                values: new object[,]
                {
                    { 1, "Meu objetivo é garantir uma boa experiência e comunicação em seu compromisso. Me comunico em Libras e Português", "acom1@gmail.com", null, "Junior Silva", 11984574122L },
                    { 2, "Me comunico em Libras e Português, e estou disposta a ajudar", "acom2@gmail.com", null, "Maria Azevedo", 11984574232L }
                });

            migrationBuilder.InsertData(
                table: "acompanhante_local_atendimento",
                columns: new[] { "id", "acompanhanteid", "id_acompanhante", "id_local_atendimento", "local_atendimentoid" },
                values: new object[,]
                {
                    { 1, null, 1, 1, null },
                    { 2, null, 1, 2, null },
                    { 3, null, 1, 3, null },
                    { 4, null, 1, 4, null },
                    { 5, null, 1, 5, null },
                    { 6, null, 1, 6, null },
                    { 7, null, 1, 7, null },
                    { 8, null, 2, 1, null },
                    { 9, null, 2, 2, null },
                    { 10, null, 2, 3, null },
                    { 11, null, 2, 4, null },
                    { 12, null, 2, 5, null },
                    { 13, null, 2, 6, null },
                    { 14, null, 2, 7, null }
                });

            migrationBuilder.InsertData(
                table: "agenda_acompanhante",
                columns: new[] { "id", "id_acompanhante" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "agenda_acompanhante",
                columns: new[] { "id", "id_acompanhante" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "horarios_atendimento_acompanhante",
                columns: new[] { "id", "hr_fim", "hr_inicio", "id_agenda_acompanhante", "id_dia_semana" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 8, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 9, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 10, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 11, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 12, new DateTime(2020, 6, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_acompanhante_local_atendimento_acompanhanteid",
                table: "acompanhante_local_atendimento",
                column: "acompanhanteid");

            migrationBuilder.CreateIndex(
                name: "IX_acompanhante_local_atendimento_local_atendimentoid",
                table: "acompanhante_local_atendimento",
                column: "local_atendimentoid");

            migrationBuilder.CreateIndex(
                name: "IX_agenda_acompanhante_id_acompanhante",
                table: "agenda_acompanhante",
                column: "id_acompanhante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_acompanhante_id_agenda_acompanhante",
                table: "agendamento_acompanhante",
                column: "id_agenda_acompanhante");

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_acompanhante_id_paciente",
                table: "agendamento_acompanhante",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_atendimento_acompanhante_id_agenda_acompanhante",
                table: "horarios_atendimento_acompanhante",
                column: "id_agenda_acompanhante");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_atendimento_acompanhante_id_dia_semana",
                table: "horarios_atendimento_acompanhante",
                column: "id_dia_semana");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acompanhante_local_atendimento");

            migrationBuilder.DropTable(
                name: "agendamento_acompanhante");

            migrationBuilder.DropTable(
                name: "horarios_atendimento_acompanhante");

            migrationBuilder.DropTable(
                name: "agenda_acompanhante");

            migrationBuilder.DropTable(
                name: "acompanhante");
        }
    }
}

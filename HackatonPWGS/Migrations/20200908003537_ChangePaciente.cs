using Microsoft.EntityFrameworkCore.Migrations;

namespace HackatonPWGS.Migrations
{
    public partial class ChangePaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "documento_paciente",
                table: "paciente",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "paciente",
                columns: new[] { "id", "bairro_endereco_paciente", "celular_paciente", "cep_endereco_paciente", "complemento_endereco_paciente", "documento_paciente", "email_paciente", "endereco_paciente", "id_acesso_paciente", "municipio_endereco_paciente", "nome_paciente", "numero_endereco_paciente", "uf_endereco_paciente" },
                values: new object[] { 1, "Pinheiros", "11984571122", 5403900, null, 12454125477L, "paciente@gmail.com", "Avenida Doutor Enéas Carvalho de Aguiar", 1, "São Paulo", "Paciente Hacka", "300", "SP" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "paciente",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "documento_paciente",
                table: "paciente",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}

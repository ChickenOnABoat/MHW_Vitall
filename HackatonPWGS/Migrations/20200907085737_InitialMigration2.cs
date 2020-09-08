using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HackatonPWGS.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dia_semana",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_dia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dia_semana", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "especialidade_medica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_especialidade = table.Column<string>(nullable: false),
                    descricao_especialidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidade_medica", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "habilidade",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_habilidade = table.Column<string>(nullable: false),
                    descricao_habilidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habilidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "local_atendimento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_local_atendimento = table.Column<string>(nullable: true),
                    contato_local_atendimento_1 = table.Column<int>(nullable: false),
                    contato_local_atendimento_2 = table.Column<int>(nullable: false),
                    endereco_local_atendimento = table.Column<string>(nullable: false),
                    complemento_local_atendimento = table.Column<string>(nullable: true),
                    numero_local_atendimento = table.Column<string>(nullable: false),
                    bairro_local_atendimento = table.Column<string>(nullable: false),
                    uf_local_atendimento = table.Column<string>(nullable: false),
                    municipio_local_atendimento = table.Column<string>(nullable: false),
                    cep_local_atendimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_atendimento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_paciente = table.Column<string>(nullable: false),
                    documento_paciente = table.Column<int>(nullable: false),
                    email_paciente = table.Column<string>(nullable: false),
                    celular_paciente = table.Column<string>(nullable: true),
                    id_acesso_paciente = table.Column<int>(nullable: false),
                    endereco_paciente = table.Column<string>(nullable: true),
                    complemento_endereco_paciente = table.Column<string>(nullable: true),
                    numero_endereco_paciente = table.Column<string>(nullable: true),
                    bairro_endereco_paciente = table.Column<string>(nullable: true),
                    uf_endereco_paciente = table.Column<string>(nullable: true),
                    municipio_endereco_paciente = table.Column<string>(nullable: true),
                    cep_endereco_paciente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clinica",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_clinica = table.Column<string>(nullable: false),
                    contato_clinica_1 = table.Column<int>(nullable: false),
                    cnpj_clinica = table.Column<long>(nullable: false),
                    id_local_atendimento_clinica = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinica", x => x.id);
                    table.ForeignKey(
                        name: "FK_clinica_local_atendimento_id_local_atendimento_clinica",
                        column: x => x.id_local_atendimento_clinica,
                        principalTable: "local_atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_medico = table.Column<string>(nullable: false),
                    crm_medico = table.Column<string>(nullable: false),
                    email_medico = table.Column<string>(nullable: true),
                    possui_agenda_medico = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    numero_contato_medico_1 = table.Column<long>(nullable: false),
                    numero_contato_medico_2 = table.Column<long>(nullable: false),
                    id_local_atendimento_medico = table.Column<int>(nullable: true),
                    id_agenda_medico = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_medico_local_atendimento_id_local_atendimento_medico",
                        column: x => x.id_local_atendimento_medico,
                        principalTable: "local_atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agenda_medico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_medico = table.Column<int>(nullable: false),
                    duracao_compromisso_minutos = table.Column<int>(nullable: false),
                    duracao_intervalo_minutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_agenda_medico_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medico_clinica",
                columns: table => new
                {
                    id_medico = table.Column<int>(nullable: false),
                    id_clinica = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico_clinica", x => new { x.id_medico, x.id_clinica });
                    table.ForeignKey(
                        name: "FK_medico_clinica_clinica_id_clinica",
                        column: x => x.id_clinica,
                        principalTable: "clinica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medico_clinica_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medico_especialidade",
                columns: table => new
                {
                    id_medico = table.Column<int>(nullable: false),
                    id_especialidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico_especialidade", x => new { x.id_medico, x.id_especialidade });
                    table.ForeignKey(
                        name: "FK_medico_especialidade_especialidade_medica_id_especialidade",
                        column: x => x.id_especialidade,
                        principalTable: "especialidade_medica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medico_especialidade_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medico_habilidade",
                columns: table => new
                {
                    id_medico = table.Column<int>(nullable: false),
                    id_habilidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico_habilidade", x => new { x.id_medico, x.id_habilidade });
                    table.ForeignKey(
                        name: "FK_medico_habilidade_habilidade_id_habilidade",
                        column: x => x.id_habilidade,
                        principalTable: "habilidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medico_habilidade_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agendamento_medico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_agenda_medico = table.Column<int>(nullable: false),
                    id_paciente = table.Column<int>(nullable: true),
                    dt_hr_inicio = table.Column<DateTime>(nullable: false),
                    dt_ht_fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamento_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_agendamento_medico_agenda_medico_id_agenda_medico",
                        column: x => x.id_agenda_medico,
                        principalTable: "agenda_medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agendamento_medico_paciente_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "horarios_atendimento_medico",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dia_semana = table.Column<int>(nullable: false),
                    id_agenda_medico = table.Column<int>(nullable: false),
                    id_local_atendimento = table.Column<int>(nullable: false),
                    hr_inicio = table.Column<DateTime>(nullable: false),
                    hr_fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios_atendimento_medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_horarios_atendimento_medico_agenda_medico_id_agenda_medico",
                        column: x => x.id_agenda_medico,
                        principalTable: "agenda_medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_horarios_atendimento_medico_dia_semana_id_dia_semana",
                        column: x => x.id_dia_semana,
                        principalTable: "dia_semana",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_horarios_atendimento_medico_local_atendimento_id_local_atendimento",
                        column: x => x.id_local_atendimento,
                        principalTable: "local_atendimento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dia_semana",
                columns: new[] { "id", "nome_dia" },
                values: new object[,]
                {
                    { 1, "Domingo" },
                    { 2, "Segunda" },
                    { 3, "Terça" },
                    { 4, "Quarta" },
                    { 5, "Quinta" },
                    { 6, "Sexta" },
                    { 7, "Sábado" }
                });

            migrationBuilder.InsertData(
                table: "especialidade_medica",
                columns: new[] { "id", "descricao_especialidade", "nome_especialidade" },
                values: new object[,]
                {
                    { 33, "diagnóstico e terapêutica de diferentes entidades tais como doenças traumáticas, do sistema nervoso central e periférico, orto-traumatológica, cardiorrespiratória.", "Medicina Física e Reabilitação" },
                    { 34, "é o ramo da medicina que se ocupa dos cuidados dos doentes graves ou instáveis, que emprega maior número de recursos tecnológicos e humanos no tratamento de doenças ou complicações de doenças, congregando conhecimento da maioria das especialidades médicas e outras áreas de saúde.", "Medicina Intensiva" },
                    { 36, "é o estudo imaginológico ou terapia pelo uso de radiofármacos.", "Medicina Nuclear" },
                    { 38, "é a parte da medicina que estuda e trata clinicamente as doenças do rim, como insuficiência renal.", "Nefrologia" },
                    { 39, "atua no tratamento de doenças do sistema nervoso central e periférico passíveis de abordagem cirúrgica.", "Neurocirurgia" },
                    { 40, "é a parte da medicina que estuda e trata o sistema nervoso.", "Neurologia" },
                    { 41, "diagnóstico, prevenção e tratamento de doenças do comportamento alimentar.", "Nutrologia" },
                    { 42, "é a área da medicina atrelada à Ginecologia que cuida das mulheres em relação ao processo da gestação (pré, pós-parto, puerpério, gestação e outros).", "Obstetrícia" },
                    { 44, "é a parte da medicina que estuda e trata as doenças do sistema osteomuscular, locomoção, crescimento, deformidades e as fraturas.", "Ortopedia e Traumatologia" },
                    { 47, "No Brasil, de forma geral é uma especialidade médica investigativa e atua como parte do processo diagnóstico das doenças.", "Patologia Clínica/Medicina laboratorial" },
                    { 46, "(também anatomia patológica ou patologia cirúrgica) é a especialidade que se ocupa da análise macroscópica, microscópica e molecular das doenças em autópsias, espécimes cirúrgicos, biópsias e preparados citológicos. Ela faz a ligação entre a ciência básica e a prática clínica.", "Patologia" },
                    { 32, "abordagem do atleta de uma forma global, desde a fisiologia do exercício à prevenção de lesões, passando pelo controle de treino e resolução de problemas de saúde que envolvam o praticante do exercício físico.", "Medicina Esportiva" },
                    { 48, "é a parte da medicina que estuda e trata crianças.", "Pediatria" },
                    { 49, "é a parte da medicina que estuda e trata o sistema respiratório.", "Pneumologia" },
                    { 50, "é a parte da medicina que previne e trata ao transtornos mentais e comportamentais.", "Psiquiatria" },
                    { 52, "tratamento empregado em doenças várias, com o uso de raio X ou outra forma de energia radiante.", "Radioterapia" },
                    { 53, "é a especialidade médica que trata das doenças do tecido conjuntivo, articulações e doenças autoimunes. Diferente do senso comum o reumatologista não trata somente reumatismo.", "Reumatologia" },
                    { 54, "é a parte da medicina que estuda e trata cirurgicamente e clinicamente os problemas do sistema urinário e do sistema reprodutor masculino e feminino.", "Urologia" },
                    { 45, "é a parte da medicina que estuda e trata as doenças da orelha, nariz, seios paranasais, faringe e laringe.", "Otorrinolaringologia" },
                    { 31, "manutenção da saúde no indivíduo que se desloca, qualquer que seja o meio, cuidando das interações deste deslocamento com o indivíduo.", "Medicina do Tráfego" },
                    { 43, "é a parte da medicina que estuda e trata os distúrbios dos olhos.", "Oftalmologia" },
                    { 29, "especialidade que atua no cuidado de pacientes com doenças ou lesões que requerem atenção médica imediata, atuando nas Emergências, pronto-atendimentos e serviços pré-hospitalares.", "Medicina de Emergência" },
                    { 1, "diagnóstico e tratamento das doenças alérgicas e do sistema imunológico.", "Alergia e Imunologia" },
                    { 2, "área da Medicina que envolve o tratamento da dor, a hipnose e o manejo intensivo do paciente sob intervenção cirúrgica ou procedimentos.", "Anestesiologia" },
                    { 3, "é a área da medicina que estuda o tratamento das doenças do aparelho circulatório.", "Angiologia" },
                    { 4, "é a especialidade que trata dos tumores malignos ou câncer.", "Cancerologia (oncologia)" },
                    { 5, "aborda as doenças relacionadas com o coração e sistema vascular.", "Cardiologia" },
                    { 15, "é a área que engloba todas as áreas não cirúrgicas, sendo subdividida em várias outras especialidades.", "Clínica Médica (Medicina interna) " },
                    { 16, "é a parte da medicina que estuda e trata os problemas do intestino grosso (cólon), sigmoide e doenças do reto, canal anal e ânus.", "Coloproctologia" },
                    { 17, "é o estudo da pele anexos (pelos, glândulas), tratamento e prevenção das doenças.", "Dermatologia" },
                    { 30, "trata do processo de trabalho e da relação deste com as doenças. Atua desde a prevenção dos agravos, a minimização dos efeitos destes e do tratamento das doenças do trabalho quando já estabelecidas.", "Medicina do Trabalho" },
                    { 19, "Esta especialidade médica ocupa-se do estudo dos mecanismo fisiopatológicos, diagnóstico e tratamento de enfermidades passíveis de abordagem por procedimentos endoscópicos e minimamente invasivos.", "Endoscopia" },
                    { 18, "é a área da Medicina responsável pelo cuidados aos hormônios, crescimento e glândulas como adrenal, tireoide, hipófise, pâncreas endócrino e outros.", "Endocrinologia e Metabologia" },
                    { 20, "é o estudo, diagnóstico, tratamento e prevenção de doenças relacionadas ao aparelho digestivo, desde erros inatos do metabolismo, doença do trato gastrointestinal, doenças do fígado e cânceres.", "Gastroenterologia" },
                    { 21, "é a área da responsável pelo estudo das doenças genéticas humanas e aconselhamento genético.", "Genética médica" },
                    { 22, "é a subespecialidade médica que cuida dos idosos e articula seu tratamento com outras especialidades.", "Geriatria" },
                    { 23, "é a especialidade médica que aborda de forma integral a mulher. Trata desde as doenças infecciosas sexuais, gestação, alterações hormonais, reprodução.", "Ginecologia e obstetrícia" },
                    { 24, "é o estudo dos elementos figurados do sangue (hemácias, leucócitos, plaquetas) e da produção desses elementos nos órgãos hematopoiéticos (medula óssea, baço, linfonódos), além de tratar das anemias, linfomas, leucemias e outros cânceres, hemofilia e doenças da coagulação", "Hematologia e Hemoterapia" },
                    { 25, "é a prática médica pseudocientífica baseada na Lei dos Semelhantes. Esta é, por sua vez, uma pseudociência em consenso pela comunidade científica, já que apresenta provas científicas da sua não-eficácia.       ", "Homeopatia" },
                    { 26, "prevenção, diagnóstico e tratamentos de infecções causadas por vírus, bactérias, fungos e parasitas (helmintologia, protozoologia, entomologia e artropodologia).", "Infectologia" },
                    { 27, "subespecialidade que trata da mama, suas doenças, alterações benignas e estéticas.", "Mastologia" },
                    { 28, "é a área da medicina que trata do indivíduo em seu ambiente familiar e comunitário, com foco na prevenção e tratamento das doenças mais comuns, sendo o articulador do encaminhamento aos especialistas quando necessária abordagem mais aprofundada das doenças.", "Medicina de Família e Comunidade" }
                });

            migrationBuilder.InsertData(
                table: "habilidade",
                columns: new[] { "id", "descricao_habilidade", "nome_habilidade" },
                values: new object[,]
                {
                    { 1, "Médico consegue se comunicar em Libras", "Comunicação em Libras" },
                    { 2, "Médico disponibiliza materiais (Exemplo: receitas, prontuários) em Braille", "Materiais em Braille" }
                });

            migrationBuilder.InsertData(
                table: "local_atendimento",
                columns: new[] { "id", "bairro_local_atendimento", "cep_local_atendimento", "complemento_local_atendimento", "contato_local_atendimento_1", "contato_local_atendimento_2", "endereco_local_atendimento", "municipio_local_atendimento", "nome_local_atendimento", "numero_local_atendimento", "uf_local_atendimento" },
                values: new object[,]
                {
                    { 6, "Cerqueira César", 5403906, null, 1130617524, 0, "Avenida Doutor Enéas Carvalho de Aguiar", "São Paulo", "Escola de Enfermagem", "419", "SP" },
                    { 7, "Cerqueira César", 5403907, null, 1130617011, 0, "Avenida Doutor Enéas Carvalho de Aguiar", "São Paulo", "Instituto de Medicina Tropical", "470", "SP" },
                    { 5, "Cerqueira César", 5403904, null, 1126615000, 0, "Avenida Doutor Enéas Carvalho de Aguiar", "São Paulo", "Instituto do Coração", "44", "SP" },
                    { 2, "Cerqueira César", 5403901, null, 1126618500, 0, "Avenida Doutor Enéas Carvalho de Aguiar", "São Paulo", "Instituto da Criança", "647", "SP" },
                    { 3, "Cerqueira César", 5403902, null, 1126610000, 0, "Rua Doutor Ovídio Pires de Campos", "São Paulo", "Instituto de Ortopedia e Traumatologia", "333", "SP" },
                    { 1, "Pinheiros", 5403900, null, 1126610000, 0, "Avenida Doutor Enéas Carvalho de Aguiar", "São Paulo", "Hospital das Clínicas", "255", "SP" },
                    { 4, "Cerqueira César", 5403903, null, 1126610000, 0, "Rua Doutor Ovídio Pires de Campos", "São Paulo", "Instituto de Psiquiatria", "s/n", "SP" }
                });

            migrationBuilder.InsertData(
                table: "medico",
                columns: new[] { "id", "crm_medico", "email_medico", "id_agenda_medico", "id_local_atendimento_medico", "nome_medico", "numero_contato_medico_1", "numero_contato_medico_2" },
                values: new object[,]
                {
                    { 18, "383170/SP", "tristique@Aliquamfringilla.com", null, null, "Skyler U. Tillman", 11939297876L, 11968465452L },
                    { 17, "140887/SP", "purus.Duis.elementum@lacusvarius.edu", null, null, "Hammett Y. Craft", 11947701257L, 0L },
                    { 16, "179148/SP", "convallis@dictummi.ca", null, null, "Thomas Y. Pugh", 11989343356L, 0L },
                    { 15, "078833/SP", "pede.blandit@Phasellus.co.uk", null, null, "Ginger U. Merritt", 1195490966L, 0L },
                    { 14, "643205/SP", "commodo.auctor.velit@necmollisvitae.net", null, null, "Quentin Y. Atkins", 11931199344L, 0L },
                    { 13, "187420/SP", "Phasellus.in@mifringillami.co.uk", null, null, "Mira K. Bonner", 11924044637L, 0L },
                    { 12, "631183/SP", "fermentum@tempor.org", null, null, "Kirestin R. Lawson", 11927212735L, 0L },
                    { 11, "274007/SP", "Curabitur.massa@Etiamvestibulum.com", null, null, "Stacy H. Mann", 11906637286L, 0L },
                    { 10, "290338/SP", "neque.In@fringilla.co.uk", null, null, "Casey H. Sandoval", 11927536612L, 0L },
                    { 9, "703417/SP", "non@amagnaLorem.ca", null, null, "Jasmine E. Velasquez", 11976712362L, 0L },
                    { 7, "294301/SP", "Quisque.purus.sapien@etpede.edu", null, null, "Kiara Y. Vincent", 11925917790L, 0L },
                    { 6, "420534/SP", "euismod.mauris@aliquetsemut.edu", null, null, "Brenden G. Mercer", 11907101308L, 0L },
                    { 5, "712719/SP", "dui.semper@indolor.net", null, null, "Jasmine G. Lane", 11964839316L, 0L },
                    { 4, "333157/SP", "dapibus@Integermollis.org", null, null, "Dane V. Patrick", 11950954428L, 0L },
                    { 3, "366710/SP", "mauris.erat.eget@necquam.com", null, null, "Cain D. Pace", 11996322431L, 0L },
                    { 2, "536868/SP", "odio.Nam.interdum@sed.co.uk", null, null, "Ciara U. French", 11959061463L, 0L },
                    { 1, "397068/SP", "Maecenas.libero@nonluctussit.edu", null, null, "Hermione E. Walton", 11937913626L, 11977127427L },
                    { 19, "749873/SP", "purus.sapien.gravida@risusQuisquelibero.edu", null, null, "Leroy U. Hartman", 11975459127L, 11974407415L },
                    { 8, "900552/SP", "Nulla@pedeblandit.ca", null, null, "Vivien Q. Montgomery", 11942813982L, 0L },
                    { 20, "666209/SP", "sagittis.lobortis@tellus.com", null, null, "Alfreda O. Rivas", 11969468105L, 11956837931L }
                });

            migrationBuilder.InsertData(
                table: "agenda_medico",
                columns: new[] { "id", "duracao_compromisso_minutos", "duracao_intervalo_minutos", "id_medico" },
                values: new object[,]
                {
                    { 2, 30, 0, 6 },
                    { 3, 60, 0, 16 },
                    { 4, 30, 0, 9 },
                    { 7, 30, 0, 7 },
                    { 6, 30, 0, 3 },
                    { 5, 30, 0, 2 },
                    { 1, 30, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "clinica",
                columns: new[] { "id", "cnpj_clinica", "contato_clinica_1", "id_local_atendimento_clinica", "nome_clinica" },
                values: new object[,]
                {
                    { 1, 16113226641238L, 1126610000, 1, "Hospital das Clínicas" },
                    { 7, 43290432437169L, 1130617011, 7, "Instituto de Medicina Tropical" },
                    { 6, 40851431805829L, 1130617524, 6, "Escola de Enfermagem" },
                    { 5, 50480326293878L, 1126615000, 5, "Instituto do Coração" },
                    { 2, 81062960693153L, 1126618500, 2, "Instituto da Criança" },
                    { 4, 23796582895229L, 1126610000, 4, "Instituto de Psiquiatria" },
                    { 3, 13960332820863L, 1126610000, 3, "Instituto de Ortopedia" }
                });

            migrationBuilder.InsertData(
                table: "medico_especialidade",
                columns: new[] { "id_medico", "id_especialidade" },
                values: new object[,]
                {
                    { 9, 17 },
                    { 18, 40 },
                    { 17, 27 },
                    { 16, 27 },
                    { 15, 25 },
                    { 14, 24 },
                    { 13, 23 },
                    { 12, 22 },
                    { 11, 19 },
                    { 10, 18 },
                    { 20, 43 },
                    { 1, 1 },
                    { 8, 16 },
                    { 7, 5 },
                    { 19, 42 },
                    { 6, 5 },
                    { 5, 5 },
                    { 4, 4 },
                    { 3, 3 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "medico_habilidade",
                columns: new[] { "id_medico", "id_habilidade" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 16, 1 },
                    { 9, 1 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "horarios_atendimento_medico",
                columns: new[] { "id", "hr_fim", "hr_inicio", "id_agenda_medico", "id_dia_semana", "id_local_atendimento" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 1, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 2, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 3, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 4, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 11, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 1 },
                    { 12, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 13, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 6, 3, 1 },
                    { 5, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 5 },
                    { 6, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 15, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 5 },
                    { 16, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 7, 6, 5 },
                    { 9, new DateTime(2020, 6, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 2 },
                    { 10, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 2 },
                    { 14, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, 6, 1 },
                    { 7, new DateTime(2020, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "medico_clinica",
                columns: new[] { "id_medico", "id_clinica" },
                values: new object[,]
                {
                    { 6, 5 },
                    { 7, 5 },
                    { 5, 5 },
                    { 20, 2 },
                    { 2, 1 },
                    { 3, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 14, 1 },
                    { 16, 1 },
                    { 4, 5 },
                    { 17, 1 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 13, 2 },
                    { 15, 2 },
                    { 18, 2 },
                    { 19, 1 },
                    { 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_agenda_medico_id_medico",
                table: "agenda_medico",
                column: "id_medico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_medico_id_agenda_medico",
                table: "agendamento_medico",
                column: "id_agenda_medico");

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_medico_id_paciente",
                table: "agendamento_medico",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_clinica_id_local_atendimento_clinica",
                table: "clinica",
                column: "id_local_atendimento_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_atendimento_medico_id_agenda_medico",
                table: "horarios_atendimento_medico",
                column: "id_agenda_medico");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_atendimento_medico_id_dia_semana",
                table: "horarios_atendimento_medico",
                column: "id_dia_semana");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_atendimento_medico_id_local_atendimento",
                table: "horarios_atendimento_medico",
                column: "id_local_atendimento");

            migrationBuilder.CreateIndex(
                name: "IX_medico_id_local_atendimento_medico",
                table: "medico",
                column: "id_local_atendimento_medico");

            migrationBuilder.CreateIndex(
                name: "IX_medico_clinica_id_clinica",
                table: "medico_clinica",
                column: "id_clinica");

            migrationBuilder.CreateIndex(
                name: "IX_medico_especialidade_id_especialidade",
                table: "medico_especialidade",
                column: "id_especialidade");

            migrationBuilder.CreateIndex(
                name: "IX_medico_habilidade_id_habilidade",
                table: "medico_habilidade",
                column: "id_habilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamento_medico");

            migrationBuilder.DropTable(
                name: "horarios_atendimento_medico");

            migrationBuilder.DropTable(
                name: "medico_clinica");

            migrationBuilder.DropTable(
                name: "medico_especialidade");

            migrationBuilder.DropTable(
                name: "medico_habilidade");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "agenda_medico");

            migrationBuilder.DropTable(
                name: "dia_semana");

            migrationBuilder.DropTable(
                name: "clinica");

            migrationBuilder.DropTable(
                name: "especialidade_medica");

            migrationBuilder.DropTable(
                name: "habilidade");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "local_atendimento");
        }
    }
}

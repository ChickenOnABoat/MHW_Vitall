using HackatonPWGS.Models.Entity;
using HackatonPWGS.Models.Entity.Relationship;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HackatonPWGS.DatabaseContext
{   
    //No naming creativity, I know....
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options)
            : base(options)
        { }


        public DbSet<clinica> clinica { get; set; }
        public DbSet<especialidade_medica> especialidade_medica { get; set; }
        public DbSet<habilidade> habilidade { get; set; }
        public DbSet<local_atendimento> local_atendimento { get; set; }
        public DbSet<medico> medico { get; set; }
        public DbSet<paciente> paciente { get; set; }
        public DbSet<medico_clinica> medico_clinica { get; set; }
        public DbSet<medico_especialidade> medico_especialidade { get; set; }
        public DbSet<medico_habilidade> medico_habilidade { get; set; }
        public DbSet<agenda_medico> agenda_medico { get; set; }
        public DbSet<agendamento_medico> agendamento_medico { get; set; }
        public DbSet<dia_semana> dia_semana { get; set; }
        public DbSet<horarios_atendimento_medico> horarios_atendimento_medico { get; set; }
        public DbSet<horarios_atendimento_acompanhante> horarios_atendimento_acompanhante { get; set; }
        public DbSet<acompanhante> acompanhante { get; set; }
        public DbSet<agenda_acompanhante> agenda_acompanhante { get; set; }
        public DbSet<agendamento_acompanhante> agendamento_acompanhante { get; set; }
        public DbSet<acompanhante_local_atendimento> acompanhante_local_atendimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<medico>()
                .Property(b => b.possui_agenda_medico)
                .HasDefaultValueSql("0");

            //Relationship many to many Medico - Especialidade
            modelBuilder.Entity<medico_especialidade>()
                .HasKey(me => new { me.id_medico, me.id_especialidade });

            modelBuilder.Entity<medico_especialidade>()
                .HasOne(me => me.medico)
                .WithMany(e => e.especialidade_medico)
                .HasForeignKey(me => me.id_medico);

            modelBuilder.Entity<medico_especialidade>()
                .HasOne(me => me.especialidade)
                .WithMany(e => e.medico_especialidade)
                .HasForeignKey(me => me.id_especialidade);

            //Relationship many to many Medico - Habilidade
            modelBuilder.Entity<medico_habilidade>()
                .HasKey(me => new { me.id_medico, me.id_habilidade });

            modelBuilder.Entity<medico_habilidade>()
                .HasOne(me => me.medico)
                .WithMany(e => e.habilidade_medico)
                .HasForeignKey(me => me.id_medico);

            modelBuilder.Entity<medico_habilidade>()
                .HasOne(me => me.habilidade)
                .WithMany(e => e.medicos_habilidade)
                .HasForeignKey(me => me.id_habilidade);

            //Relationship many to many Medico - Clinica
            modelBuilder.Entity<medico_clinica>()
                .HasKey(me => new { me.id_medico, me.id_clinica });

            modelBuilder.Entity<medico_clinica>()
                .HasOne(me => me.medico)
                .WithMany(e => e.clinica_medico)
                .HasForeignKey(me => me.id_medico);

            modelBuilder.Entity<medico_clinica>()
                .HasOne(me => me.clinica)
                .WithMany(e => e.medicos_clinica)
                .HasForeignKey(me => me.id_clinica);





            modelBuilder.Entity<local_atendimento>().HasData(
                new local_atendimento { id = 1, cep_local_atendimento = 05403900, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Pinheiros", endereco_local_atendimento = "Avenida Doutor Enéas Carvalho de Aguiar", numero_local_atendimento = "255", nome_local_atendimento = "Hospital das Clínicas", contato_local_atendimento_1 = 1126610000 },
                new local_atendimento { id = 2, cep_local_atendimento = 05403901, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Avenida Doutor Enéas Carvalho de Aguiar", numero_local_atendimento = "647", nome_local_atendimento = "Instituto da Criança", contato_local_atendimento_1 = 1126618500 },
                new local_atendimento { id = 3, cep_local_atendimento = 05403902, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Rua Doutor Ovídio Pires de Campos", numero_local_atendimento = "333", nome_local_atendimento = "Instituto de Ortopedia e Traumatologia", contato_local_atendimento_1 = 1126610000 },
                new local_atendimento { id = 4, cep_local_atendimento = 05403903, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Rua Doutor Ovídio Pires de Campos", numero_local_atendimento = "s/n", nome_local_atendimento = "Instituto de Psiquiatria", contato_local_atendimento_1 = 1126610000 },
                new local_atendimento { id = 5, cep_local_atendimento = 05403904, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Avenida Doutor Enéas Carvalho de Aguiar", numero_local_atendimento = "44", nome_local_atendimento = "Instituto do Coração", contato_local_atendimento_1 = 1126615000 },
                new local_atendimento { id = 6, cep_local_atendimento = 05403906, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Avenida Doutor Enéas Carvalho de Aguiar", numero_local_atendimento = "419", nome_local_atendimento = "Escola de Enfermagem", contato_local_atendimento_1 = 1130617524 },
                new local_atendimento { id = 7, cep_local_atendimento = 05403907, municipio_local_atendimento = "São Paulo", uf_local_atendimento = "SP", bairro_local_atendimento = "Cerqueira César", endereco_local_atendimento = "Avenida Doutor Enéas Carvalho de Aguiar", numero_local_atendimento = "470", nome_local_atendimento = "Instituto de Medicina Tropical", contato_local_atendimento_1 = 1130617011 }
            );

            modelBuilder.Entity<especialidade_medica>().HasData(
                new especialidade_medica { id = 1, nome_especialidade = "Alergia e Imunologia", descricao_especialidade = "diagnóstico e tratamento das doenças alérgicas e do sistema imunológico." },
                new especialidade_medica { id = 2, nome_especialidade = "Anestesiologia", descricao_especialidade = "área da Medicina que envolve o tratamento da dor, a hipnose e o manejo intensivo do paciente sob intervenção cirúrgica ou procedimentos." },
                new especialidade_medica { id = 3, nome_especialidade = "Angiologia", descricao_especialidade = "é a área da medicina que estuda o tratamento das doenças do aparelho circulatório." },
                new especialidade_medica { id = 4, nome_especialidade = "Cancerologia (oncologia)", descricao_especialidade = "é a especialidade que trata dos tumores malignos ou câncer." },
                new especialidade_medica { id = 5, nome_especialidade = "Cardiologia", descricao_especialidade = "aborda as doenças relacionadas com o coração e sistema vascular." },
                new especialidade_medica { id = 15, nome_especialidade = "Clínica Médica (Medicina interna) ", descricao_especialidade = "é a área que engloba todas as áreas não cirúrgicas, sendo subdividida em várias outras especialidades." },
                new especialidade_medica { id = 16, nome_especialidade = "Coloproctologia", descricao_especialidade = "é a parte da medicina que estuda e trata os problemas do intestino grosso (cólon), sigmoide e doenças do reto, canal anal e ânus." },
                new especialidade_medica { id = 17, nome_especialidade = "Dermatologia", descricao_especialidade = "é o estudo da pele anexos (pelos, glândulas), tratamento e prevenção das doenças." },
                new especialidade_medica { id = 18, nome_especialidade = "Endocrinologia e Metabologia", descricao_especialidade = "é a área da Medicina responsável pelo cuidados aos hormônios, crescimento e glândulas como adrenal, tireoide, hipófise, pâncreas endócrino e outros." },
                new especialidade_medica { id = 19, nome_especialidade = "Endoscopia", descricao_especialidade = "Esta especialidade médica ocupa-se do estudo dos mecanismo fisiopatológicos, diagnóstico e tratamento de enfermidades passíveis de abordagem por procedimentos endoscópicos e minimamente invasivos." },
                new especialidade_medica { id = 20, nome_especialidade = "Gastroenterologia", descricao_especialidade = "é o estudo, diagnóstico, tratamento e prevenção de doenças relacionadas ao aparelho digestivo, desde erros inatos do metabolismo, doença do trato gastrointestinal, doenças do fígado e cânceres." },
                new especialidade_medica { id = 21, nome_especialidade = "Genética médica", descricao_especialidade = "é a área da responsável pelo estudo das doenças genéticas humanas e aconselhamento genético." },
                new especialidade_medica { id = 22, nome_especialidade = "Geriatria", descricao_especialidade = "é a subespecialidade médica que cuida dos idosos e articula seu tratamento com outras especialidades." },
                new especialidade_medica { id = 23, nome_especialidade = "Ginecologia e obstetrícia", descricao_especialidade = "é a especialidade médica que aborda de forma integral a mulher. Trata desde as doenças infecciosas sexuais, gestação, alterações hormonais, reprodução." },
                new especialidade_medica { id = 24, nome_especialidade = "Hematologia e Hemoterapia", descricao_especialidade = "é o estudo dos elementos figurados do sangue (hemácias, leucócitos, plaquetas) e da produção desses elementos nos órgãos hematopoiéticos (medula óssea, baço, linfonódos), além de tratar das anemias, linfomas, leucemias e outros cânceres, hemofilia e doenças da coagulação" },
                new especialidade_medica { id = 25, nome_especialidade = "Homeopatia", descricao_especialidade = "é a prática médica pseudocientífica baseada na Lei dos Semelhantes. Esta é, por sua vez, uma pseudociência em consenso pela comunidade científica, já que apresenta provas científicas da sua não-eficácia.       " },
                new especialidade_medica { id = 26, nome_especialidade = "Infectologia", descricao_especialidade = "prevenção, diagnóstico e tratamentos de infecções causadas por vírus, bactérias, fungos e parasitas (helmintologia, protozoologia, entomologia e artropodologia)." },
                new especialidade_medica { id = 27, nome_especialidade = "Mastologia", descricao_especialidade = "subespecialidade que trata da mama, suas doenças, alterações benignas e estéticas." },
                new especialidade_medica { id = 28, nome_especialidade = "Medicina de Família e Comunidade", descricao_especialidade = "é a área da medicina que trata do indivíduo em seu ambiente familiar e comunitário, com foco na prevenção e tratamento das doenças mais comuns, sendo o articulador do encaminhamento aos especialistas quando necessária abordagem mais aprofundada das doenças." },
                new especialidade_medica { id = 29, nome_especialidade = "Medicina de Emergência", descricao_especialidade = "especialidade que atua no cuidado de pacientes com doenças ou lesões que requerem atenção médica imediata, atuando nas Emergências, pronto-atendimentos e serviços pré-hospitalares." },
                new especialidade_medica { id = 30, nome_especialidade = "Medicina do Trabalho", descricao_especialidade = "trata do processo de trabalho e da relação deste com as doenças. Atua desde a prevenção dos agravos, a minimização dos efeitos destes e do tratamento das doenças do trabalho quando já estabelecidas." },
                new especialidade_medica { id = 31, nome_especialidade = "Medicina do Tráfego", descricao_especialidade = "manutenção da saúde no indivíduo que se desloca, qualquer que seja o meio, cuidando das interações deste deslocamento com o indivíduo." },
                new especialidade_medica { id = 32, nome_especialidade = "Medicina Esportiva", descricao_especialidade = "abordagem do atleta de uma forma global, desde a fisiologia do exercício à prevenção de lesões, passando pelo controle de treino e resolução de problemas de saúde que envolvam o praticante do exercício físico." },
                new especialidade_medica { id = 33, nome_especialidade = "Medicina Física e Reabilitação", descricao_especialidade = "diagnóstico e terapêutica de diferentes entidades tais como doenças traumáticas, do sistema nervoso central e periférico, orto-traumatológica, cardiorrespiratória." },
                new especialidade_medica { id = 34, nome_especialidade = "Medicina Intensiva", descricao_especialidade = "é o ramo da medicina que se ocupa dos cuidados dos doentes graves ou instáveis, que emprega maior número de recursos tecnológicos e humanos no tratamento de doenças ou complicações de doenças, congregando conhecimento da maioria das especialidades médicas e outras áreas de saúde." },
                new especialidade_medica { id = 36, nome_especialidade = "Medicina Nuclear", descricao_especialidade = "é o estudo imaginológico ou terapia pelo uso de radiofármacos." },
                new especialidade_medica { id = 38, nome_especialidade = "Nefrologia", descricao_especialidade = "é a parte da medicina que estuda e trata clinicamente as doenças do rim, como insuficiência renal." },
                new especialidade_medica { id = 39, nome_especialidade = "Neurocirurgia", descricao_especialidade = "atua no tratamento de doenças do sistema nervoso central e periférico passíveis de abordagem cirúrgica." },
                new especialidade_medica { id = 40, nome_especialidade = "Neurologia", descricao_especialidade = "é a parte da medicina que estuda e trata o sistema nervoso." },
                new especialidade_medica { id = 41, nome_especialidade = "Nutrologia", descricao_especialidade = "diagnóstico, prevenção e tratamento de doenças do comportamento alimentar." },
                new especialidade_medica { id = 42, nome_especialidade = "Obstetrícia", descricao_especialidade = "é a área da medicina atrelada à Ginecologia que cuida das mulheres em relação ao processo da gestação (pré, pós-parto, puerpério, gestação e outros)." },
                new especialidade_medica { id = 43, nome_especialidade = "Oftalmologia", descricao_especialidade = "é a parte da medicina que estuda e trata os distúrbios dos olhos." },
                new especialidade_medica { id = 44, nome_especialidade = "Ortopedia e Traumatologia", descricao_especialidade = "é a parte da medicina que estuda e trata as doenças do sistema osteomuscular, locomoção, crescimento, deformidades e as fraturas." },
                new especialidade_medica { id = 45, nome_especialidade = "Otorrinolaringologia", descricao_especialidade = "é a parte da medicina que estuda e trata as doenças da orelha, nariz, seios paranasais, faringe e laringe." },
                new especialidade_medica { id = 46, nome_especialidade = "Patologia", descricao_especialidade = "(também anatomia patológica ou patologia cirúrgica) é a especialidade que se ocupa da análise macroscópica, microscópica e molecular das doenças em autópsias, espécimes cirúrgicos, biópsias e preparados citológicos. Ela faz a ligação entre a ciência básica e a prática clínica." },
                new especialidade_medica { id = 47, nome_especialidade = "Patologia Clínica/Medicina laboratorial", descricao_especialidade = "No Brasil, de forma geral é uma especialidade médica investigativa e atua como parte do processo diagnóstico das doenças." },
                new especialidade_medica { id = 48, nome_especialidade = "Pediatria", descricao_especialidade = "é a parte da medicina que estuda e trata crianças." },
                new especialidade_medica { id = 49, nome_especialidade = "Pneumologia", descricao_especialidade = "é a parte da medicina que estuda e trata o sistema respiratório." },
                new especialidade_medica { id = 50, nome_especialidade = "Psiquiatria", descricao_especialidade = "é a parte da medicina que previne e trata ao transtornos mentais e comportamentais." },
                new especialidade_medica { id = 52, nome_especialidade = "Radioterapia", descricao_especialidade = "tratamento empregado em doenças várias, com o uso de raio X ou outra forma de energia radiante." },
                new especialidade_medica { id = 53, nome_especialidade = "Reumatologia", descricao_especialidade = "é a especialidade médica que trata das doenças do tecido conjuntivo, articulações e doenças autoimunes. Diferente do senso comum o reumatologista não trata somente reumatismo." },
                new especialidade_medica { id = 54, nome_especialidade = "Urologia", descricao_especialidade = "é a parte da medicina que estuda e trata cirurgicamente e clinicamente os problemas do sistema urinário e do sistema reprodutor masculino e feminino." }
            );

            modelBuilder.Entity<habilidade>().HasData(
                new habilidade { id = 1, nome_habilidade = "Comunicação em Libras", descricao_habilidade = "Médico consegue se comunicar em Libras" },
                new habilidade { id = 2, nome_habilidade = "Materiais em Braille", descricao_habilidade = "Médico disponibiliza materiais (Exemplo: receitas, prontuários) em Braille" }
            );


            modelBuilder.Entity<clinica>().HasData(
                new clinica { id = 1, nome_clinica = "Hospital das Clínicas", contato_clinica_1 = 1126610000, cnpj_clinica = 16113226641238, id_local_atendimento_clinica = 1 },
                new clinica { id = 2, nome_clinica = "Instituto da Criança", contato_clinica_1 = 1126618500, cnpj_clinica = 81062960693153, id_local_atendimento_clinica = 2 },
                new clinica { id = 3, nome_clinica = "Instituto de Ortopedia", contato_clinica_1 = 1126610000, cnpj_clinica = 13960332820863, id_local_atendimento_clinica = 3 },
                new clinica { id = 4, nome_clinica = "Instituto de Psiquiatria", contato_clinica_1 = 1126610000, cnpj_clinica = 23796582895229, id_local_atendimento_clinica = 4 },
                new clinica { id = 5, nome_clinica = "Instituto do Coração", contato_clinica_1 = 1126615000, cnpj_clinica = 50480326293878, id_local_atendimento_clinica = 5 },
                new clinica { id = 6, nome_clinica = "Escola de Enfermagem", contato_clinica_1 = 1130617524, cnpj_clinica = 40851431805829, id_local_atendimento_clinica = 6 },
                new clinica { id = 7, nome_clinica = "Instituto de Medicina Tropical", contato_clinica_1 = 1130617011, cnpj_clinica = 43290432437169, id_local_atendimento_clinica = 7 }
            );



            modelBuilder.Entity<medico>().HasData(

                new medico { id = 1, nome_medico = "Hermione E. Walton", crm_medico = "397068/SP", email_medico = "Maecenas.libero@nonluctussit.edu", possui_agenda_medico = 0, numero_contato_medico_1 = 11937913626, numero_contato_medico_2 = 11977127427, id_local_atendimento_medico = null },
                new medico { id = 2, nome_medico = "Ciara U. French", crm_medico = "536868/SP", email_medico = "odio.Nam.interdum@sed.co.uk", possui_agenda_medico = 0, numero_contato_medico_1 = 11959061463, id_local_atendimento_medico = null },
                new medico { id = 3, nome_medico = "Cain D. Pace", crm_medico = "366710/SP", email_medico = "mauris.erat.eget@necquam.com", possui_agenda_medico = 0, numero_contato_medico_1 = 11996322431, id_local_atendimento_medico = null },
                new medico { id = 4, nome_medico = "Dane V. Patrick", crm_medico = "333157/SP", email_medico = "dapibus@Integermollis.org", possui_agenda_medico = 0, numero_contato_medico_1 = 11950954428, id_local_atendimento_medico = null },
                new medico { id = 5, nome_medico = "Jasmine G. Lane", crm_medico = "712719/SP", email_medico = "dui.semper@indolor.net", possui_agenda_medico = 0, numero_contato_medico_1 = 11964839316, id_local_atendimento_medico = null },
                new medico { id = 6, nome_medico = "Brenden G. Mercer", crm_medico = "420534/SP", email_medico = "euismod.mauris@aliquetsemut.edu", possui_agenda_medico = 0, numero_contato_medico_1 = 11907101308, id_local_atendimento_medico = null },
                new medico { id = 7, nome_medico = "Kiara Y. Vincent", crm_medico = "294301/SP", email_medico = "Quisque.purus.sapien@etpede.edu", possui_agenda_medico = 0, numero_contato_medico_1 = 11925917790, id_local_atendimento_medico = null },
                new medico { id = 8, nome_medico = "Vivien Q. Montgomery", crm_medico = "900552/SP", email_medico = "Nulla@pedeblandit.ca", possui_agenda_medico = 0, numero_contato_medico_1 = 11942813982, id_local_atendimento_medico = null },
                new medico { id = 9, nome_medico = "Jasmine E. Velasquez", crm_medico = "703417/SP", email_medico = "non@amagnaLorem.ca", possui_agenda_medico = 0, numero_contato_medico_1 = 11976712362, id_local_atendimento_medico = null },
                new medico { id = 10, nome_medico = "Casey H. Sandoval", crm_medico = "290338/SP", email_medico = "neque.In@fringilla.co.uk", possui_agenda_medico = 0, numero_contato_medico_1 = 11927536612, id_local_atendimento_medico = null },
                new medico { id = 11, nome_medico = "Stacy H. Mann", crm_medico = "274007/SP", email_medico = "Curabitur.massa@Etiamvestibulum.com", possui_agenda_medico = 0, numero_contato_medico_1 = 11906637286, id_local_atendimento_medico = null },
                new medico { id = 12, nome_medico = "Kirestin R. Lawson", crm_medico = "631183/SP", email_medico = "fermentum@tempor.org", possui_agenda_medico = 0, numero_contato_medico_1 = 11927212735, id_local_atendimento_medico = null },
                new medico { id = 13, nome_medico = "Mira K. Bonner", crm_medico = "187420/SP", email_medico = "Phasellus.in@mifringillami.co.uk", possui_agenda_medico = 0, numero_contato_medico_1 = 11924044637, id_local_atendimento_medico = null },
                new medico { id = 14, nome_medico = "Quentin Y. Atkins", crm_medico = "643205/SP", email_medico = "commodo.auctor.velit@necmollisvitae.net", possui_agenda_medico = 0, numero_contato_medico_1 = 11931199344, id_local_atendimento_medico = null },
                new medico { id = 15, nome_medico = "Ginger U. Merritt", crm_medico = "078833/SP", email_medico = "pede.blandit@Phasellus.co.uk", possui_agenda_medico = 0, numero_contato_medico_1 = 1195490966, id_local_atendimento_medico = null },
                new medico { id = 16, nome_medico = "Thomas Y. Pugh", crm_medico = "179148/SP", email_medico = "convallis@dictummi.ca", possui_agenda_medico = 0, numero_contato_medico_1 = 11989343356, id_local_atendimento_medico = null },
                new medico { id = 17, nome_medico = "Hammett Y. Craft", crm_medico = "140887/SP", email_medico = "purus.Duis.elementum@lacusvarius.edu", possui_agenda_medico = 0, numero_contato_medico_1 = 11947701257, id_local_atendimento_medico = null },
                new medico { id = 18, nome_medico = "Skyler U. Tillman", crm_medico = "383170/SP", email_medico = "tristique@Aliquamfringilla.com", possui_agenda_medico = 0, numero_contato_medico_1 = 11939297876, numero_contato_medico_2 = 11968465452, id_local_atendimento_medico = null },
                new medico { id = 19, nome_medico = "Leroy U. Hartman", crm_medico = "749873/SP", email_medico = "purus.sapien.gravida@risusQuisquelibero.edu", possui_agenda_medico = 0, numero_contato_medico_1 = 11975459127, numero_contato_medico_2 = 11974407415, id_local_atendimento_medico = null },
                new medico { id = 20, nome_medico = "Alfreda O. Rivas", crm_medico = "666209/SP", email_medico = "sagittis.lobortis@tellus.com", possui_agenda_medico = 0, numero_contato_medico_1 = 11969468105, numero_contato_medico_2 = 11956837931, id_local_atendimento_medico = null }
            );

            /*modelBuilder.Entity<medico_especialidade>().HasData(
                new medico_especialidade { }
                );*/


            modelBuilder.Entity<agenda_medico>()
            .HasMany(c => c.horarios_atendimento)
            .WithOne(e => e.agenda);

            modelBuilder.Entity<medico>()
                .HasOne(a => a.agenda_medico)
                .WithOne(b => b.medico)
                .HasForeignKey<agenda_medico>(b => b.id_medico);


            modelBuilder.Entity<agenda_medico>()
            .HasMany(c => c.agendamentos)
            .WithOne(e => e.agenda_medico);



            modelBuilder.Entity<paciente>()
            .HasMany(c => c.agendamentos)
            .WithOne(e => e.paciente);

            

            modelBuilder.Entity<medico_especialidade>().HasData(
                new medico_especialidade {  id_medico = 1, id_especialidade = 1 },
                new medico_especialidade {  id_medico = 2, id_especialidade = 2 },
                new medico_especialidade {  id_medico = 3, id_especialidade = 3 },
                new medico_especialidade {  id_medico = 4, id_especialidade = 4 },
                new medico_especialidade {  id_medico = 5, id_especialidade = 5 },
                new medico_especialidade {  id_medico = 6, id_especialidade = 5 },
                new medico_especialidade {  id_medico = 7, id_especialidade = 5 },
                new medico_especialidade {  id_medico = 8, id_especialidade = 16 },
                new medico_especialidade {  id_medico = 9, id_especialidade = 17 },
                new medico_especialidade {  id_medico = 10, id_especialidade = 18 },
                new medico_especialidade {  id_medico = 11, id_especialidade = 19 },
                new medico_especialidade {  id_medico = 12, id_especialidade = 22 },
                new medico_especialidade {  id_medico = 13, id_especialidade = 23 },
                new medico_especialidade {  id_medico = 14, id_especialidade = 24 },
                new medico_especialidade {  id_medico = 15, id_especialidade = 25 },
                new medico_especialidade {  id_medico = 16, id_especialidade = 27 },
                new medico_especialidade {  id_medico = 17, id_especialidade = 27 },
                new medico_especialidade {  id_medico = 18, id_especialidade = 40 },
                new medico_especialidade {  id_medico = 19, id_especialidade = 42 },
                new medico_especialidade {  id_medico = 20, id_especialidade = 43 }

            );

            modelBuilder.Entity<medico_habilidade>().HasData(
                new medico_habilidade {   id_medico = 1, id_habilidade = 1},
                new medico_habilidade {   id_medico = 6, id_habilidade = 1},
                new medico_habilidade {   id_medico = 16, id_habilidade = 1},
                new medico_habilidade {   id_medico = 9, id_habilidade = 1}
            );


            modelBuilder.Entity<agenda_medico>().HasData(
            
                new agenda_medico { id = 1, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 1},    
                new agenda_medico { id = 2, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 6},    
                new agenda_medico { id = 3, duracao_compromisso_minutos = 60, duracao_intervalo_minutos = 0, id_medico = 16},    
                new agenda_medico { id = 4, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 9},    
                new agenda_medico { id = 5, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 2},    
                new agenda_medico { id = 6, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 3},    
                new agenda_medico { id = 7, duracao_compromisso_minutos = 30, duracao_intervalo_minutos = 0, id_medico = 7}    
            );

            modelBuilder.Entity<dia_semana>().HasData(
                new dia_semana { id = 1, nome_dia = "Domingo"},
                new dia_semana { id = 2, nome_dia = "Segunda"},
                new dia_semana { id = 3, nome_dia = "Terça"},
                new dia_semana { id = 4, nome_dia = "Quarta"},
                new dia_semana { id = 5, nome_dia = "Quinta"},
                new dia_semana { id = 6, nome_dia = "Sexta"},
                new dia_semana { id = 7, nome_dia = "Sábado"}
            );

            modelBuilder.Entity<medico_clinica>().HasData(
                new medico_clinica {  id_medico = 1, id_clinica = 1},
                new medico_clinica {  id_medico = 2, id_clinica = 1},
                new medico_clinica {  id_medico = 3, id_clinica = 1},
                new medico_clinica {  id_medico = 4, id_clinica = 5},
                new medico_clinica {  id_medico = 5, id_clinica = 5},
                new medico_clinica {  id_medico = 6, id_clinica = 5},
                new medico_clinica {  id_medico = 7, id_clinica = 5},
                new medico_clinica {  id_medico = 8, id_clinica = 2},
                new medico_clinica {  id_medico = 9, id_clinica = 2},
                new medico_clinica {  id_medico = 10, id_clinica = 2},
                new medico_clinica {  id_medico = 11, id_clinica = 1},
                new medico_clinica {  id_medico = 12, id_clinica = 1},
                new medico_clinica {  id_medico = 13, id_clinica = 2},
                new medico_clinica {  id_medico = 14, id_clinica = 1},
                new medico_clinica {  id_medico = 15, id_clinica = 2},
                new medico_clinica {  id_medico = 16, id_clinica = 1},
                new medico_clinica {  id_medico = 17, id_clinica = 1},
                new medico_clinica {  id_medico = 18, id_clinica = 2},
                new medico_clinica {  id_medico = 19, id_clinica = 1},
                new medico_clinica {  id_medico = 20, id_clinica = 2}
            );

            modelBuilder.Entity<horarios_atendimento_medico>().HasData(
                //
                new horarios_atendimento_medico { id = 1, id_agenda_medico = 1, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 2, id_agenda_medico = 1, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 3, id_agenda_medico = 1, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 4, id_agenda_medico = 1, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                //
                new horarios_atendimento_medico { id = 5, id_agenda_medico = 2, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 5 },
                new horarios_atendimento_medico { id = 6, id_agenda_medico = 2, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 5 },
                //
                new horarios_atendimento_medico { id = 7, id_agenda_medico = 3, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 8, id_agenda_medico = 3, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                //
                new horarios_atendimento_medico { id = 9, id_agenda_medico = 4, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 2 },
                new horarios_atendimento_medico { id = 10, id_agenda_medico = 4, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 2 },
                //
                new horarios_atendimento_medico { id = 11, id_agenda_medico = 5, id_dia_semana = 3, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 12, id_agenda_medico = 5, id_dia_semana = 6, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                //
                new horarios_atendimento_medico { id = 13, id_agenda_medico = 6, id_dia_semana = 3, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                new horarios_atendimento_medico { id = 14, id_agenda_medico = 6, id_dia_semana = 6, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 1 },
                //
                new horarios_atendimento_medico { id = 15, id_agenda_medico = 7, id_dia_semana = 3, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 5 },
                new horarios_atendimento_medico { id = 16, id_agenda_medico = 7, id_dia_semana = 6, hr_inicio = DateTime.ParseExact("20200609 14:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 17:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), id_local_atendimento = 5 }
            );

            modelBuilder.Entity<paciente>().HasData(
                new paciente { id = 1, email_paciente="paciente@gmail.com", documento_paciente=12454125477,id_acesso_paciente = 1, nome_paciente= "Paciente Hacka", celular_paciente ="11984571122", cep_endereco_paciente = 05403900, municipio_endereco_paciente = "São Paulo", uf_endereco_paciente = "SP", bairro_endereco_paciente = "Pinheiros", endereco_paciente = "Avenida Doutor Enéas Carvalho de Aguiar", numero_endereco_paciente = "300" }
                );

            modelBuilder.Entity<agenda_acompanhante>()
            .HasMany(c => c.horarios_atendimento)
            .WithOne(e => e.agenda);

            modelBuilder.Entity<acompanhante>()
                .HasOne(a => a.agenda_acompanhante)
                .WithOne(b => b.acompanhante)
                .HasForeignKey<agenda_acompanhante>(b => b.id_acompanhante);


            modelBuilder.Entity<agenda_acompanhante>()
            .HasMany(c => c.agendamentos)
            .WithOne(e => e.agenda_acompanhante);

            modelBuilder.Entity<paciente>()
            .HasMany(c => c.agendamentos_acompanhantes)
            .WithOne(e => e.paciente);


            modelBuilder.Entity<acompanhante>().HasData(
                new acompanhante { id = 1, descricao_acompanhante="Meu objetivo é garantir uma boa experiência e comunicação em seu compromisso. Me comunico em Libras e Português", email_acompanhante="acom1@gmail.com", nome_acompanhante="Junior Silva", numero_contato_acompanhante=11984574122},
                new acompanhante { id = 2, descricao_acompanhante="Me comunico em Libras e Português, e estou disposta a ajudar", email_acompanhante="acom2@gmail.com", nome_acompanhante="Maria Azevedo", numero_contato_acompanhante=11984574232}
                );

            modelBuilder.Entity<agenda_acompanhante>().HasData(

               new agenda_acompanhante { id = 1, id_acompanhante = 1 },
               new agenda_acompanhante { id = 2,  id_acompanhante = 2 }
              
           );

            modelBuilder.Entity<acompanhante_local_atendimento>().HasData(
                new acompanhante_local_atendimento {id = 1, id_acompanhante=1, id_local_atendimento= 1, },
                new acompanhante_local_atendimento { id = 2, id_acompanhante =1, id_local_atendimento= 2, },
                new acompanhante_local_atendimento { id = 3, id_acompanhante =1, id_local_atendimento= 3, },
                new acompanhante_local_atendimento { id = 4, id_acompanhante =1, id_local_atendimento= 4, },
                new acompanhante_local_atendimento { id = 5, id_acompanhante =1, id_local_atendimento= 5, },
                new acompanhante_local_atendimento { id = 6, id_acompanhante =1, id_local_atendimento= 6, },
                new acompanhante_local_atendimento { id = 7, id_acompanhante =1, id_local_atendimento= 7, },
                new acompanhante_local_atendimento { id = 8, id_acompanhante = 2, id_local_atendimento = 1, },
                new acompanhante_local_atendimento { id = 9, id_acompanhante = 2, id_local_atendimento = 2, },
                new acompanhante_local_atendimento { id = 10, id_acompanhante = 2, id_local_atendimento = 3, },
                new acompanhante_local_atendimento { id = 11, id_acompanhante = 2, id_local_atendimento = 4, },
                new acompanhante_local_atendimento { id = 12, id_acompanhante = 2, id_local_atendimento = 5, },
                new acompanhante_local_atendimento { id = 13, id_acompanhante = 2, id_local_atendimento = 6, },
                new acompanhante_local_atendimento { id = 14, id_acompanhante = 2, id_local_atendimento = 7, }


                );

            modelBuilder.Entity<horarios_atendimento_acompanhante>().HasData(
    //
                new horarios_atendimento_acompanhante { id = 1, id_agenda_acompanhante = 1, id_dia_semana = 1, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 2, id_agenda_acompanhante = 1, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 3, id_agenda_acompanhante = 1, id_dia_semana = 3, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 4, id_agenda_acompanhante = 1, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 5, id_agenda_acompanhante = 1, id_dia_semana = 5, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 6, id_agenda_acompanhante = 1, id_dia_semana = 6, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 12:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                //
                new horarios_atendimento_acompanhante { id = 7, id_agenda_acompanhante = 2, id_dia_semana = 2, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 8, id_agenda_acompanhante = 2, id_dia_semana = 3, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 9, id_agenda_acompanhante = 2, id_dia_semana = 4, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 10, id_agenda_acompanhante = 2, id_dia_semana = 5, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 11, id_agenda_acompanhante = 2, id_dia_semana = 6, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) },
                new horarios_atendimento_acompanhante { id = 12, id_agenda_acompanhante = 2, id_dia_semana = 1, hr_inicio = DateTime.ParseExact("20200609 08:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture), hr_fim = DateTime.ParseExact("20200609 18:00", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture) }


            );

            

            base.OnModelCreating(modelBuilder);
        }

    }
}

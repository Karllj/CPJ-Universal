using System;
using System.IO;

namespace CPJ_Universal.classes
{
    public class Ini
    {
        public void CriarArquivoCPJ3CIni(string caminhoDestino, string baseSelecionada)
        {
            // Verifica se o caminho de destino existe, caso contrário cria
            if (!Directory.Exists(caminhoDestino))
            {
                Directory.CreateDirectory(caminhoDestino);
            }

            // Remove a extensão .sql do nome da base selecionada
            string baseSemExtensao = Path.GetFileNameWithoutExtension(baseSelecionada);

            // Define o caminho completo para o novo arquivo INI
            string caminhoArquivoIni = Path.Combine(caminhoDestino, "cpj3cserver.ini");

            // Conteúdo do arquivo INI
            string conteudoIni = $@"
[APICRM]
codigo_cliente=0
chave=
url=
[TCP]
TimeOut=5
Porta=8002
PortaHTTP=
Validos=
Bloqueados=
Monitor=N
AtivarSSL=N
AtivarSSLHTTP=N
RootCert=
FileCert=
KeyCert=
PasswordCert=
[DB]
HostName=localhost
Protocol=mysql-4.0
User=root
Password=cm9vdA==
Database={baseSemExtensao}
Owner=
OemTranslate=Nao
NConFisicas=25
Homologacao=1
[MAX]
Relatorios=5
Workflow=5
Paginas=0
RowsRelatorios=0
Rows=50
Downloads=50
[GREL]
GRelExterno=0
[PWD]
TamMinSenha=4
MaxTentativas=3
ExpiraDias=180
[SRVAD]
ServerAD=
PortaAD=
AuthAD=0
AuthADSSL=0
ParametrosAD=
AtributoNomeAD=
AtributoValorAD=
[Workflow]
AtivoWF=0
ServerWF=
SenhaWF=
UsuarioWF=
TimeOutWF=0
[E-Mail]
Porta=25
HostName=
User=
EnviaEmailUser=S
Tamanho=5
[AUTORIZACAO]
AUTORIZACAO=
[ENVIOEMAIL]
Ativo=0
Verificacoes=0
Ignorar=0
Hora=00:00:00
Dias=9
Preposto=0
RPreposto=
Notificacao=
Retorno=
Cabecalho=Agenda automática do CPJ-3C
[SERVICOS]
Lista=[{{""ativo"":1,""descricao"":""Aviso"",""id_servico"":8,""tipo"":3}},{{""ativo"":1,""descricao"":""Gerador de e-mail"",""id_servico"":7,""tipo"":5}},{{""ativo"":1,""descricao"":""Gerador de relatórios"",""id_servico"":1,""tipo"":1}},{{""ativo"":0,""descricao"":""Integração - Cadastro de Pessoa"",""id_servico"":3,""tipo"":3}},{{""ativo"":0,""descricao"":""Integração - Contas a Pagar/Receber"",""id_servico"":4,""tipo"":3}},{{""ativo"":0,""descricao"":""Integração - Cobrança"",""id_servico"":5,""tipo"":3}},{{""ativo"":0,""descricao"":""Integração - API Preâmbulo"",""id_servico"":14,""tempo_sincronizacao"":5,""tipo"":7}},{{""ativo"":0,""descricao"":""Notificações e-mail"",""id_servico"":10,""tipo"":3}},{{""ativo"":0,""descricao"":""WebService - Monitoramento de processos"",""id_servico"":12,""senha"":"""",""tipo"":6,""usuario"":""""}},{{""abre_fluxo"":0,""acesso"":""pilws"",""ativo"":0,""converter"":0,""descricao"":""WebService - Publicação 1"",""id_servico"":11,""retiraenter"":0,""senha"":"""",""tipo"":4,""url"":"""",""usuario"":""""}},{{""abre_fluxo"":0,""acesso"":"""",""ativo"":0,""converter"":0,""descricao"":""WebService - Publicação 2"",""id_servico"":13,""retiraenter"":0,""senha"":"""",""tipo"":4,""url"":"""",""usuario"":""""}},{{""abre_fluxo"":0,""acesso"":""PILWS3"",""ativo"":0,""converter"":0,""descricao"":""WebService - Publicação por transação"",""id_servico"":15,""retiraenter"":0,""senha"":"""",""tipo"":4,""url"":"""",""usuario"":""""}},{{""ativo"":0,""descricao"":""WorkFlow"",""id_servico"":2,""tipo"":2}},{{""ativo"":0,""descricao"":""Preâmbulo Bank"",""id_servico"":16,""tipo"":3}}]
";

            // Escreve o conteúdo no arquivo
            try
            {
                File.WriteAllText(caminhoArquivoIni, conteudoIni);
                Console.WriteLine($"Arquivo INI criado com sucesso em: {caminhoArquivoIni}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o arquivo INI: {ex.Message}");
            }
        }
        public void CriarArquivoARQ3CIni(string caminhoDestino, string baseSelecionada, string versaoDetalhada)
        {
            // Verifica se o caminho de destino existe, caso contrário cria
            if (!Directory.Exists(caminhoDestino))
            {
                Directory.CreateDirectory(caminhoDestino);
            }

            // Remove a extensão .sql do nome da base selecionada
            string baseSemExtensao = Path.GetFileNameWithoutExtension(baseSelecionada);

            // Define o caminho completo para o novo arquivo INI
            string caminhoArquivoIni = Path.Combine(caminhoDestino, "arq3cserver.ini");

            // Define o diretório correto para os documentos dentro da pasta da versão detalhada do ARQ3C
            string diretorioDocs = Path.Combine(caminhoDestino, "docs");

            // Conteúdo do arquivo INI
            string conteudoIni = $@"
[TCP]
Porta=8003
IP=127.0.0.1
PortaMonitoramento=0
[DB 1]
RetPDF=0
Diretorio={diretorioDocs}\
RG=262
Sistema=CPJS
DiretorioCongelado=
DiretorioCache=
DiretorioMigracao=
DiretorioMigracaoCongelado=
VolumeEspelho=
NuvemEspelho=
EspelhoAtivo=N
HostName=localhost
Protocol=mysql-4.0
OEM=
User=root
Password=cm9vdA==
Database={baseSemExtensao}
Owner=
Tamanho=0
Tipos=

[BS 1]
S3AccessKey=
S3SecretKey=
S3Region=
S3Bucket=
S3BaseDir=
S3StaticDir=
GSBucket=
GSBaseDir=
GSStaticDir=
GSProject=
AZaccountName=
AZaccountKey=
AZscheme=
AZcontainer=
AZBaseDir=
AZStaticDir=
";

            // Escreve o conteúdo no arquivo
            try
            {
                File.WriteAllText(caminhoArquivoIni, conteudoIni);
                Console.WriteLine($"Arquivo INI do ARQ3C criado com sucesso em: {caminhoArquivoIni}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o arquivo INI do ARQ3C: {ex.Message}");
            }
        }
    }
}

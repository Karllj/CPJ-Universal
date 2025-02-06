using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace CPJ_Universal.Classes
{
    public class CriarBat
    {
        private const string MyIniPath = "C:\\PREAMBULO\\MARIADB\\data\\my.ini";
        private const string MyOldIniPath = "C:\\PREAMBULO\\MARIADB\\data\\myold.ini";
        private const string BatFilePath = "C:\\PREAMBULO\\PIL\\criar_banco.bat";

        public void CriarArquivoBat(string baseSelecionada, string caminhoSQL)
        {
            try
            {
                // Remove a extensão do nome da base
                string baseSemExtensao = Path.GetFileNameWithoutExtension(baseSelecionada);

                bool myIniModified = false;

                // Verifica se deseja criar ou modificar o arquivo my.ini
                var result = MessageBox.Show("Deseja criar ou modificar o arquivo 'my.ini'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Verifica e renomeia o my.ini, se necessário
                    if (File.Exists(MyOldIniPath))
                    {
                        Console.WriteLine("Backup do arquivo 'my.ini' já existe, removendo arquivo existente...");
                        File.Delete(MyIniPath);
                        myIniModified = true; // Indica que houve modificação
                    }
                    else if (File.Exists(MyIniPath))
                    {
                        Console.WriteLine("Renomeando arquivo 'my.ini' para 'myold.ini'...");
                        File.Move(MyIniPath, MyOldIniPath);
                        myIniModified = true; // Indica que houve modificação
                    }

                    // Cria o novo arquivo my.ini
                    using (StreamWriter writer = new StreamWriter(MyIniPath, false))
                    {
                        writer.WriteLine("[mysqld]");
                        writer.WriteLine("datadir=C:/PREAMBULO/MARIADB/data");
                        writer.WriteLine("port=3306");
                        writer.WriteLine("log-bin");
                        writer.WriteLine("expire_logs_days=30");
                        writer.WriteLine("secure-auth=OFF");
                        writer.WriteLine("max_allowed_packet=1073741824");
                        writer.WriteLine("innodb_buffer_pool_size=2032M");
                        writer.WriteLine("[client]");
                        writer.WriteLine("port=3306");
                        writer.WriteLine("plugin-dir=C:/PREAMBULO/MARIADB/lib/plugin");
                        writer.WriteLine("secure-auth=OFF");
                    }

                    Console.WriteLine("Arquivo 'my.ini' recriado com sucesso.");
                }
                // Verifica se o arquivo my.ini foi modificado e reinicia o serviço se necessário
                if (myIniModified)
                {
                    var restartResult = MessageBox.Show("Deseja reiniciar o serviço MySQLMDB?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (restartResult == DialogResult.Yes)
                    {
                        ReiniciarServicoMySQL();
                    }
                }

                // Cria o conteúdo do arquivo BAT
                string conteudoBat = $@"@echo off

                REM Configurar as variáveis de ambiente
                set MYSQL_HOME=C:\PREAMBULO\MARIADB\data
                set PATH=C:\PREAMBULO\MARIADB\bin;%PATH%

                echo Setting environment for MariaDB 10.3 (x64)

                REM Criar banco de dados
                echo Criando banco de dados: {baseSemExtensao}

                mysql -uroot -proot -e ""CREATE DATABASE IF NOT EXISTS `{baseSemExtensao}`;"" 2>> C:\PREAMBULO\PIL\CreateBaseErro.log
                if errorlevel 1 (
                    echo Erro ao criar o banco de dados. Veja CreateBaseErro.log para mais detalhes.
                    pause
                    exit /b 1
                )

                REM Importar o arquivo SQL
                echo Importando dados para o banco: {baseSemExtensao}
                mysql -uroot -proot {baseSemExtensao} < ""C:\PREAMBULO\PIL\{baseSemExtensao}.sql"" 2>> C:\PREAMBULO\PIL\ImportBaseErro.log
                if errorlevel 1 (
                    echo Erro ao importar o arquivo SQL. Veja ImportBaseErro.log para mais detalhes.
                    pause
                    exit /b 1
                )

                echo Operação concluída com sucesso.
                pause
                ";

                // Verifica se o diretório existe, caso contrário, cria
                string diretorioBat = Path.GetDirectoryName(BatFilePath);
                if (!Directory.Exists(diretorioBat))
                {
                    Directory.CreateDirectory(diretorioBat);
                }

                // Escreve o conteúdo no arquivo BAT
                File.WriteAllText(BatFilePath, conteudoBat);
                Console.WriteLine($"Arquivo BAT criado com sucesso em: {BatFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o arquivo BAT: {ex.Message}");
            }
        }

        private void ReiniciarServicoMySQL()
        {
            try
            {
                // Caminho temporário para o script BAT que reinicia o serviço
                string restartBatPath = Path.Combine(Path.GetTempPath(), "RestartMySQLService.bat");

                // Cria o conteúdo do script BAT para reiniciar o serviço
                string restartBatContent = @"
                @echo off
                echo Reiniciando o serviço MySQLMDB...
                net stop MySQLMDB
                net start MySQLMDB
                if errorlevel 1 (
                    echo Erro ao reiniciar o serviço MySQLMDB.
                    pause
                    exit /b 1
                )
                echo Serviço MySQLMDB reiniciado com sucesso.
                pause
                ";

                // Escreve o script BAT no diretório temporário
                File.WriteAllText(restartBatPath, restartBatContent);

                // Configura o processo para executar o script BAT como administrador
                var processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{restartBatPath}\"",
                    Verb = "runas", // Necessário para solicitar elevação de privilégios
                    UseShellExecute = true,
                    CreateNoWindow = true
                };

                // Executa o processo
                var process = Process.Start(processInfo);
                process.WaitForExit();

                // Verifica o código de saída
                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Serviço MySQLMDB reiniciado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Erro ao reiniciar o serviço. Código de saída: {process.ExitCode}");
                }

                // Remove o arquivo BAT temporário após a execução
                File.Delete(restartBatPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reiniciar o serviço MySQLMDB: {ex.Message}");
            }
        }
    }
}

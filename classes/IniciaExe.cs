using System;
using System.Diagnostics;
using System.IO;

namespace CPJ_Universal.Classes
{
    public class IniciaExe
    {
        public void IniciarBancoDeDados(string caminhoBancoSelecionado, string baseDeDados = null)
        {
            // Verifica se o arquivo do banco de dados existe
            if (string.IsNullOrEmpty(caminhoBancoSelecionado) || !File.Exists(caminhoBancoSelecionado))
            {
                Console.WriteLine($"Arquivo do banco de dados não encontrado: {caminhoBancoSelecionado}");
                return;
            }

            try
            {
                // Configura o processo para executar o instalador
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = caminhoBancoSelecionado,
                    Arguments = baseDeDados != null ? $"/base:{baseDeDados}" : string.Empty, // Passa a base de dados, se fornecida
                    UseShellExecute = true
                };

                // Inicia o processo
                using (Process processo = Process.Start(startInfo))
                {
                    Console.WriteLine($"Processo iniciado para: {caminhoBancoSelecionado}");

                    // Aguarda o processo finalizar
                    processo.WaitForExit();

                    Console.WriteLine($"Processo finalizado com código: {processo.ExitCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar o processo para o banco de dados: {ex.Message}");
            }
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;

namespace CPJ_Universal.classes
{
    internal class Admin
    {
        public void ValidarSelecoes(string modelo, string versao, string admin)
        {
            if (string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(versao) || string.IsNullOrEmpty(admin))
            {
                throw new ArgumentException("Por favor, selecione o Modelo CPJ, a Versão Instalada e o ADMIN.");
            }
        }

        public string ObterCaminhoAdmin(string repoPathBase, string adminFileName)
        {
            if (string.IsNullOrEmpty(repoPathBase) || string.IsNullOrEmpty(adminFileName))
            {
                throw new ArgumentException("Os parâmetros fornecidos são inválidos.");
            }

            var arquivos = Directory.GetFiles(repoPathBase, "*.*", SearchOption.AllDirectories);
            foreach (var arquivo in arquivos)
            {
                if (Path.GetFileName(arquivo).Equals(adminFileName, StringComparison.OrdinalIgnoreCase))
                {
                    return arquivo;
                }
            }

            return null;
        }

        public void CopiarAdmin(string adminFilePathOrigem, string versaoPath)
        {
            string adminFilePathDestino = Path.Combine(versaoPath, Path.GetFileName(adminFilePathOrigem));

            if (!File.Exists(adminFilePathDestino))
            {
                File.Copy(adminFilePathOrigem, adminFilePathDestino, true);
                Console.WriteLine($"Arquivo {Path.GetFileName(adminFilePathOrigem)} copiado para {versaoPath}.");
            }
        }

        public void ExecutarAdmin(string adminFilePathDestino)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = adminFilePathDestino,
                    UseShellExecute = true,
                    Verb = "runas" // Executa como administrador
                };

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar o arquivo {adminFilePathDestino}: {ex.Message}");
                throw;
            }
        }

    }
}

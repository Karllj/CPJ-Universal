using System;
using System.IO;

namespace CPJ_Universal.classes
{
    internal static class saveconfigs
    {
        private static string ObterCaminhoConfig(string nomeArquivo)
        {
            string pastaConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CPJ-Universal");

            if (!Directory.Exists(pastaConfig))
                Directory.CreateDirectory(pastaConfig); // Cria a pasta se não existir

            return Path.Combine(pastaConfig, nomeArquivo + ".config");
        }

        // 🔹 Salvar um único valor (Exemplo: Instalacao.config)
        public static void SalvarConfiguracao(string nomeArquivo, string conteudo)
        {
            string caminhoConfig = ObterCaminhoConfig(nomeArquivo);
            File.WriteAllText(caminhoConfig, conteudo);
        }

        // 🔹 Carregar um único valor (Exemplo: Instalacao.config)
        public static string CarregarConfiguracao(string nomeArquivo)
        {
            string caminhoConfig = ObterCaminhoConfig(nomeArquivo);

            if (File.Exists(caminhoConfig))
                return File.ReadAllText(caminhoConfig);

            return null; // Retorna null se o arquivo não existir
        }

        // 🔹 Salvar múltiplos valores (Exemplo: Inicia.config)
        public static void SalvarMultiplasConfiguracoes(string nomeArquivo, string[] conteudo)
        {
            string caminhoConfig = ObterCaminhoConfig(nomeArquivo);
            File.WriteAllLines(caminhoConfig, conteudo);
        }

        // 🔹 Carregar múltiplos valores (Exemplo: Inicia.config)
        public static string[] CarregarMultiplasConfiguracoes(string nomeArquivo)
        {
            string caminhoConfig = ObterCaminhoConfig(nomeArquivo);

            if (File.Exists(caminhoConfig))
                return File.ReadAllLines(caminhoConfig);

            return new string[0]; // Retorna um array vazio se o arquivo não existir
        }
    }
}

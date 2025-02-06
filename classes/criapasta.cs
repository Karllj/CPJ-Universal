using System;
using System.IO;

namespace CPJ_Universal.Classes
{
    public class Criapasta
    {
        private string BaseDirectory = "C:\\PREAMBULO";

        public string CaminhoARQ3C { get; private set; }
        public string CaminhoCPJ3C { get; private set; }
        public string CaminhoMARIADB { get; private set; }
        public string CaminhoPIL { get; private set; }

        public void ValidarEstruturaDePastas(string versaoCPJ, string versaoCPJDetalhada, string versaoARQ3CDetalhada)
        {
            VerificarOuCriarPasta(BaseDirectory);

            CaminhoARQ3C = Path.Combine(BaseDirectory, "ARQ3C");
            CaminhoCPJ3C = Path.Combine(BaseDirectory, "CPJ3C");
            CaminhoMARIADB = Path.Combine(BaseDirectory, "MARIADB");
            CaminhoPIL = Path.Combine(BaseDirectory, "PIL");

            string[] subPastasBase = { CaminhoARQ3C, CaminhoCPJ3C, CaminhoMARIADB, CaminhoPIL };

            foreach (string subPasta in subPastasBase)
            {
                VerificarOuCriarPasta(subPasta);
            }

            if (!string.IsNullOrEmpty(versaoCPJ))
            {
                string caminhoCPJ3CVersion = Path.Combine(CaminhoCPJ3C, versaoCPJ);
                VerificarOuCriarPasta(caminhoCPJ3CVersion);

                if (!string.IsNullOrEmpty(versaoCPJDetalhada))
                {
                    string nomePasta = versaoCPJDetalhada.Replace(".", "-").Replace("-zip", "");
                    string caminhoVersaoDetalhada = Path.Combine(caminhoCPJ3CVersion, nomePasta);
                    VerificarOuCriarPasta(caminhoVersaoDetalhada);
                }
            }

            if (!string.IsNullOrEmpty(versaoARQ3CDetalhada))
            {
                string nomePastaARQ3C = versaoARQ3CDetalhada.Replace(".", "-").Replace("-zip", "");
                string caminhoARQ3CDetalhado = Path.Combine(CaminhoARQ3C, nomePastaARQ3C);
                VerificarOuCriarPasta(caminhoARQ3CDetalhado);
            }
        }

        private void VerificarOuCriarPasta(string caminho)
        {
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
                Console.WriteLine($"Pasta criada: {caminho}");
            }
            else
            {
                Console.WriteLine($"Pasta já existe: {caminho}");
            }
        }

        public void IntegrarComExtrair(Extrair extrair, string arquivoCPJ3C, string versaoCPJ, string versaoDetalhada, string arquivoARQ3C, string arquivoDocs)
        {
            // Extrair arquivos de CPJ3C
            if (!string.IsNullOrEmpty(arquivoCPJ3C) && !string.IsNullOrEmpty(versaoCPJ) && !string.IsNullOrEmpty(versaoDetalhada))
            {
                extrair.ExtrairCPJ3C(arquivoCPJ3C, CaminhoCPJ3C, versaoCPJ, versaoDetalhada, CaminhoARQ3C);
            }

            // Extrair arquivos de ARQ3C
            if (!string.IsNullOrEmpty(arquivoARQ3C))
            {
                string versaoARQ3CDetalhada = Path.GetFileNameWithoutExtension(arquivoARQ3C);
                extrair.ExtrairARQ3C(arquivoARQ3C, CaminhoARQ3C, versaoARQ3CDetalhada);
            }

            // Extrair documentos adicionais (arquivoDocs)
            if (!string.IsNullOrEmpty(arquivoDocs))
            {
                string versaoDocsDetalhada = Path.GetFileNameWithoutExtension(arquivoDocs);
                extrair.ExtrairARQ3C(arquivoDocs, CaminhoARQ3C, versaoDocsDetalhada);
            }
        }

    }
}

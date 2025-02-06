using System;
using System.IO;
using System.IO.Compression;

namespace CPJ_Universal.Classes
{
    public class Extrair
    {
        public void ExtrairArquivos(string caminhoOrigem, string caminhoDestino)
        {
            // Verifica se o arquivo existe
            if (!File.Exists(caminhoOrigem))
            {
                Console.WriteLine($"Arquivo não encontrado: {caminhoOrigem}");
                return;
            }

            try
            {
                // Cria o diretório se não existir
                if (!Directory.Exists(caminhoDestino))
                {
                    Directory.CreateDirectory(caminhoDestino);
                }

                // Extrai o conteúdo do arquivo ZIP
                using (ZipArchive archive = ZipFile.OpenRead(caminhoOrigem))
                {
                    foreach (var entry in archive.Entries)
                    {
                        string destinoArquivo = Path.Combine(caminhoDestino, entry.FullName);

                        // Verifica se a entrada é uma pasta ou arquivo
                        if (string.IsNullOrEmpty(entry.Name)) // É uma pasta
                        {
                            if (!Directory.Exists(destinoArquivo))
                            {
                                Directory.CreateDirectory(destinoArquivo);
                            }
                        }
                        else // É um arquivo
                        {
                            string diretorio = Path.GetDirectoryName(destinoArquivo);
                            if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }

                            entry.ExtractToFile(destinoArquivo, true); // Sobrescreve arquivos existentes
                        }
                    }
                }

                Console.WriteLine($"Arquivo extraído com sucesso: {caminhoOrigem} para {caminhoDestino}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao extrair o arquivo {caminhoOrigem}: {ex.Message}");
            }
        }

        public void ExtrairCPJ3C(string arquivo, string caminhoBase, string versaoCPJ, string versaoDetalhada, string caminhoARQ3C)
        {
            if (string.IsNullOrEmpty(arquivo) || string.IsNullOrEmpty(versaoCPJ) || string.IsNullOrEmpty(versaoDetalhada))
            {
                Console.WriteLine("Parâmetros inválidos para a extração do CPJ3C.");
                return;
            }

            // Formata o nome da pasta para a versão detalhada
            string nomePastaVersaoDetalhada = versaoDetalhada.Replace(".", "-").Replace("-zip", "");

            // Define o caminho completo para a extração
            string caminhoDestino = Path.Combine(caminhoBase, versaoCPJ, nomePastaVersaoDetalhada);

            // Realiza a extração
            ExtrairArquivos(arquivo, caminhoDestino);

            // Verifica e extrai o diversos.zip
            string caminhoDiversos = Path.Combine(caminhoDestino, "diversos.zip");
            if (File.Exists(caminhoDiversos))
            {
                ExtrairEOrganizarDiversos(caminhoDiversos, caminhoDestino);
            }
            else
            {
                // Caso não encontre o diversos.zip no diretório extraído, busca o arquivo comum
                string caminhoDiversosComum = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Comum\\diversos.zip";
                if (File.Exists(caminhoDiversosComum))
                {
                    ExtrairEOrganizarDiversos(caminhoDiversosComum, caminhoDestino);
                }
            }

            // Cria a pasta CEF4 e extrai o conteúdo de cef4.zip
            string caminhoCEF4 = Path.Combine(caminhoDestino, "CEF4");
            string caminhoCEF4Zip = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Comum\\cef4.zip";

            if (!Directory.Exists(caminhoCEF4))
            {
                Directory.CreateDirectory(caminhoCEF4);
            }

            if (File.Exists(caminhoCEF4Zip))
            {
                ExtrairArquivos(caminhoCEF4Zip, caminhoCEF4);
            }

            // Extrai o dll.maria.zip para a pasta detalhada do CPJ3C
            string arquivoDllMaria = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Comum\\dll.maria.zip";
            if (File.Exists(arquivoDllMaria))
            {
                ExtrairArquivos(arquivoDllMaria, caminhoDestino);
            }

            // Organiza arquivos da pasta "diversos", caso exista
            string pastaDiversos = Path.Combine(caminhoDestino, "diversos");
            if (Directory.Exists(pastaDiversos))
            {
                foreach (var file in Directory.GetFiles(pastaDiversos))
                {
                    string novoCaminho = Path.Combine(caminhoDestino, Path.GetFileName(file));
                    File.Move(file, novoCaminho);
                }

                foreach (var dir in Directory.GetDirectories(pastaDiversos))
                {
                    string novoCaminho = Path.Combine(caminhoDestino, Path.GetFileName(dir));
                    Directory.Move(dir, novoCaminho);
                }

                // Remove a pasta "diversos"
                Directory.Delete(pastaDiversos, true);
                Console.WriteLine("Conteúdo da pasta 'diversos' movido e pasta removida.");
            }

            Console.WriteLine("Extração do CPJ3C concluída.");
        }
        
        public void ExtrairARQ3C(string arquivo, string caminhoBase, string versaoDetalhada)
        {
            if (string.IsNullOrEmpty(arquivo) || string.IsNullOrEmpty(versaoDetalhada))
            {
                Console.WriteLine("Parâmetros inválidos para a extração do ARQ3C.");
                return;
            }

            string nomePastaVersaoDetalhada = versaoDetalhada.Replace(".", "-").Replace("-zip", "");
            string caminhoDestino = Path.Combine(caminhoBase, nomePastaVersaoDetalhada);

            try
            {
                if (!Directory.Exists(caminhoDestino))
                {
                    Directory.CreateDirectory(caminhoDestino);
                }

                using (ZipArchive archive = ZipFile.OpenRead(arquivo))
                {
                    foreach (var entry in archive.Entries)
                    {
                        string destinoArquivo = Path.Combine(caminhoDestino, entry.FullName);

                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            if (!Directory.Exists(destinoArquivo))
                            {
                                Directory.CreateDirectory(destinoArquivo);
                            }
                        }
                        else
                        {
                            string diretorio = Path.GetDirectoryName(destinoArquivo);
                            if (!string.IsNullOrEmpty(diretorio) && !Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }

                            entry.ExtractToFile(destinoArquivo, true);
                        }
                    }
                }

                Console.WriteLine($"ARQ3C extraído com sucesso: {arquivo} para {caminhoDestino}");


                // Extrai o dll.maria.zip diretamente para a versão detalhada do ARQ3C
                string arquivoDllMaria = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Comum\\dll.maria.zip";
                if (File.Exists(arquivoDllMaria))
                {
                    ExtrairArquivos(arquivoDllMaria, caminhoDestino);
                }

                // Extrai docs_fenalaw.zip diretamente para a versão detalhada
                string arquivoDocsFenalaw = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Bancos de Dados\\Fenalaw\\docs_fenalaw.zip";
                if (File.Exists(arquivoDocsFenalaw))
                {
                    ExtrairArquivos(arquivoDocsFenalaw, caminhoDestino);
                }

                string chilkatDll = Path.Combine(caminhoBase, "ChilkatDelphi32.dll");
                if (File.Exists(chilkatDll))
                {
                    string destinoChilkat = Path.Combine(caminhoDestino, "ChilkatDelphi32.dll");
                    File.Move(chilkatDll, destinoChilkat);
                    Console.WriteLine("ChilkatDelphi32.dll movido para a pasta da versão detalhada.");
                }

                string docsFenalawPath = Path.Combine(caminhoBase, "docs_fenalaw");
                if (Directory.Exists(docsFenalawPath))
                {
                    foreach (var file in Directory.GetFiles(docsFenalawPath))
                    {
                        string destinoFile = Path.Combine(caminhoDestino, Path.GetFileName(file));
                        File.Move(file, destinoFile);
                    }

                    Directory.Delete(docsFenalawPath, true);
                    Console.WriteLine("Pasta docs_fenalaw removida após mover os arquivos para a versão detalhada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao extrair o ARQ3C {arquivo}: {ex.Message}");
            }
        }
       
        private void ExtrairEOrganizarDiversos(string caminhoOrigem, string caminhoDestino)
        {
            string tempFolder = Path.Combine(caminhoDestino, "temp_diversos");

            // Extrai o arquivo para uma pasta temporária
            ExtrairArquivos(caminhoOrigem, tempFolder);

            // Move o conteúdo da pasta temporária para o destino
            foreach (var file in Directory.GetFiles(tempFolder))
            {
                string novoCaminho = Path.Combine(caminhoDestino, Path.GetFileName(file));

                // Substitui arquivos existentes
                File.Copy(file, novoCaminho, true);
            }

            foreach (var dir in Directory.GetDirectories(tempFolder))
            {
                string novoCaminho = Path.Combine(caminhoDestino, Path.GetFileName(dir));

                // Remove o diretório de destino, caso já exista
                if (Directory.Exists(novoCaminho))
                {
                    Directory.Delete(novoCaminho, true);
                }

                Directory.Move(dir, novoCaminho);
            }

            // Remove a pasta temporária
            Directory.Delete(tempFolder, true);

            // Verifica se ChilkatDelphi32.dll está presente e copia para ARQ3C
            string chilkatDll = Path.Combine(caminhoDestino, "ChilkatDelphi32.dll");
            string caminhoARQ3C = Path.Combine("C:\\PREAMBULO\\ARQ3C", "ChilkatDelphi32.dll");

            if (File.Exists(chilkatDll) && !File.Exists(caminhoARQ3C))
            {
                File.Copy(chilkatDll, caminhoARQ3C);
                Console.WriteLine("ChilkatDelphi32.dll copiado para ARQ3C.");
            }

            // Apaga o diversos.zip após a extração
            try
            {
                File.Delete(caminhoOrigem);
                Console.WriteLine($"Arquivo {caminhoOrigem} deletado após extração.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o arquivo {caminhoOrigem}: {ex.Message}");
            }
        }
    }
}

using CPJ_Universal.classes;
using CPJ_Universal.classes.CPJ_Universal.classes;
using CPJ_Universal.Classes;
using CPJ_Universal.janelas;
using System;
using System.IO;
using System.Windows.Forms;

namespace CPJ_Universal
{
    public partial class instalacao : Form
    {
        private readonly CarregadorOpcoes _carregadorOpcoes;

        public instalacao()
        {
            InitializeComponent();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;
            CarregarConfiguracao();


            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _carregadorOpcoes = new CarregadorOpcoes();


            // Use os métodos da classe CarregadorOpcoes
            _carregadorOpcoes.LoadARQ3COptions(selectBoxARQ3C);
            _carregadorOpcoes.LoadBancoDeDadosOptions(selectBoxBanco);
            _carregadorOpcoes.LoadAdminOptions(cbAdmin);
            _carregadorOpcoes.LoadModelosCPJOptions(cbModeloCPJ);
            lbCaminho.Text = Configuracoes.EnderecoGlobal;

            // Eventos
            selectBoxCPJ3C.LostFocus += SelectBoxCPJ3C_LostFocus;
            selectBoxVersaoCPJ3C.TextUpdate += selectBoxVersaoCPJ3C_TextUpdate;
            selectBoxARQ3C.TextUpdate += selectBoxARQ3C_TextUpdate;
            cbAdmin.TextUpdate += cbAdmin_TextUpdate;
            cbModeloCPJ.LostFocus += CbModeloCPJ_SelectedIndexChanged;
        }

        //Seleciona o Modelo do CPJ e quando perde o foco ele atualiza a lista das versões
        private void SelectBoxCPJ3C_LostFocus(object sender, EventArgs e)
        {
            _carregadorOpcoes.AtualizarVersoesCPJ3C(selectBoxCPJ3C, selectBoxVersaoCPJ3C);
        }

        private void selectBoxVersaoCPJ3C_TextUpdate(object sender, EventArgs e)
        {
            string filtro = selectBoxVersaoCPJ3C.Text;
            _carregadorOpcoes.FiltrarVersoesCPJ3C(selectBoxVersaoCPJ3C, filtro);
        }

        private void selectBoxARQ3C_TextUpdate(object sender, EventArgs e)
        {
            string filtro = selectBoxARQ3C.Text;
            _carregadorOpcoes.FiltrarARQ3C(selectBoxARQ3C, filtro);
        }

        private void cbAdmin_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                string filtro = cbAdmin.Text;
                cbAdmin.TextUpdate -= cbAdmin_TextUpdate; // Remove o evento temporariamente
                _carregadorOpcoes.FiltrarAdmins(cbAdmin, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar os itens: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cbAdmin.TextUpdate += cbAdmin_TextUpdate; // Reanexa o evento
            }
        }

        private string GetBaseSelecionada()
        {
            string cpj3cSelecionado = selectBoxCPJ3C.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(cpj3cSelecionado)) 
                return null;

            // Caminho onde estão armazenadas as bases
            string path = Path.Combine(Configuracoes.EnderecoGlobal,
                "Preambulo - Geral - Help Desk - Help Desk\\CPJ-Universal\\bancodedados\\bases");

            // Busca o arquivo SQL correspondente
            string baseFileName = $"fenalaw_{cpj3cSelecionado}.sql";
            string[] arquivos = Directory.GetFiles(path, "*.sql", SearchOption.TopDirectoryOnly);

            foreach (var arquivo in arquivos)
            {
                if (Path.GetFileName(arquivo).Equals(baseFileName, StringComparison.OrdinalIgnoreCase))
                {
                    return arquivo; // Retorna o caminho completo do arquivo
                }
            }

            return null; // Caso não encontre o arquivo
        }

        private void ButtonIniciar_Click(object sender, EventArgs e)
        {
            // Captura os valores selecionados
            string bancoSelecionado = selectBoxBanco.SelectedItem?.ToString();
            string cpj3cSelecionado = selectBoxCPJ3C.SelectedItem?.ToString();
            string versaoSelecionada = selectBoxVersaoCPJ3C.SelectedItem?.ToString();
            string arq3cSelecionado = selectBoxARQ3C.SelectedItem?.ToString();
            string baseSelecionada = GetBaseSelecionada();

            // Determina a versão detalhada do ARQ3C
            string versaoARQ3CDetalhada = null;
            if (!string.IsNullOrEmpty(arq3cSelecionado))
            {
                versaoARQ3CDetalhada = Path.GetFileNameWithoutExtension(arq3cSelecionado);
            }

            // Validações opcionais
            if (!string.IsNullOrEmpty(cpj3cSelecionado) && string.IsNullOrEmpty(versaoSelecionada))
            {
                MessageBox.Show("Selecione uma versão CPJ3C válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(versaoSelecionada) && string.IsNullOrEmpty(cpj3cSelecionado))
            {
                MessageBox.Show("Selecione um CPJ3C válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Localiza arquivos ARQ3C em subpastas
            string arq3cPath = null;
            if (!string.IsNullOrEmpty(arq3cSelecionado))
            {
                arq3cPath = _carregadorOpcoes.LocalizarArquivoOuPastaEmSubpastas(
                    $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção\\ARQ-3C",
                    arq3cSelecionado
                );

                if (arq3cPath == null)
                {
                    MessageBox.Show($"O arquivo '{arq3cSelecionado}' não foi encontrado nas subpastas de ARQ3C.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Localiza arquivos CPJ3C em subpastas
            string versaoPath = null;
            if (!string.IsNullOrEmpty(cpj3cSelecionado) && !string.IsNullOrEmpty(versaoSelecionada))
            {
                versaoPath = _carregadorOpcoes.LocalizarArquivoOuPastaEmSubpastas(
                    $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção\\{cpj3cSelecionado}",
                    versaoSelecionada
                );

                if (versaoPath == null)
                {
                    MessageBox.Show($"O arquivo '{versaoSelecionada}' não foi encontrado nas subpastas de CPJ3C.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Valida e organiza a estrutura de pastas
            var criapasta = new Criapasta();
            var extrair = new Extrair();
            criapasta.ValidarEstruturaDePastas(cpj3cSelecionado, versaoSelecionada, versaoARQ3CDetalhada);

            criapasta.IntegrarComExtrair(
                extrair,
                versaoPath,                      // arquivoCPJ3C
                cpj3cSelecionado,                // versaoCPJ
                versaoSelecionada,               // versaoDetalhada
                arq3cPath,                       // arquivoARQ3C
                $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Bancos de Dados\\Fenalaw\\docs_fenalaw.zip" // arquivoDocs
            );

            // Inicia o executável para o banco de dados selecionado
            if (!string.IsNullOrEmpty(bancoSelecionado))
            {
                string caminhoBanco = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Help Desk - Help Desk\\CPJ-Universal\\bancodedados\\versao\\{bancoSelecionado}";
                var iniciaExe = new IniciaExe();
                iniciaExe.IniciarBancoDeDados(caminhoBanco);
            }

            // Gera o arquivo INI do CPJ3C
            if (!string.IsNullOrEmpty(cpj3cSelecionado) && !string.IsNullOrEmpty(versaoSelecionada))
            {
                var ini = new Ini();

                // Monta o caminho completo da versão detalhada
                string caminhoDestinoCPJ3C = Path.Combine(
                    criapasta.CaminhoCPJ3C,
                    cpj3cSelecionado,
                    versaoSelecionada.Replace(".", "-").Replace("-zip", "")
                );

                ini.CriarArquivoCPJ3CIni(caminhoDestinoCPJ3C, baseSelecionada);
            }

            // Gera o arquivo INI do ARQ3C
            if (!string.IsNullOrEmpty(arq3cSelecionado))
            {
                var iniARQ3C = new Ini();

                // Monta o caminho completo da versão detalhada do ARQ3C
                string caminhoDestinoARQ3C = Path.Combine(
                    criapasta.CaminhoARQ3C,
                    versaoARQ3CDetalhada.Replace(".", "-").Replace("-zip", "")
                );

                // Chama o método com o terceiro argumento, versaoARQ3CDetalhada
                iniARQ3C.CriarArquivoARQ3CIni(caminhoDestinoARQ3C, baseSelecionada, versaoARQ3CDetalhada);
            }

            // Exibe a mensagem final
            MessageBox.Show("Processo concluído!\nPara instalações limpas, deve apertar em 'Subir base'.",
                            "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Executa o carregador de opções após o fechamento da MessageBox
            _carregadorOpcoes.LoadModelosCPJOptions(cbModeloCPJ);
        }

        private void btnMariaInstalado_Click(object sender, EventArgs e)
        {
            // Verifica se o checkbox está marcado
            if (!cbSubirBase.Checked)
            {
                MessageBox.Show("A opção 'Subir Base' precisa estar marcada para executar este processo.",
                                "Ação Necessária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método
            }

            string baseSelecionada = GetBaseSelecionada();
            string caminhoSQLOrigem = Path.Combine(
                $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Help Desk - Help Desk\\CPJ-Universal\\bancodedados\\bases",
                baseSelecionada
            );
            string caminhoSQLDestino = Path.Combine("C:\\PREAMBULO\\PIL", Path.GetFileName(baseSelecionada));
            string batFilePath = "C:\\PREAMBULO\\PIL\\criar_banco.bat";

            try
            {
                // Cria o diretório C:\PREAMBULO\PIL se não existir
                if (!Directory.Exists("C:\\PREAMBULO\\PIL"))
                {
                    Directory.CreateDirectory("C:\\PREAMBULO\\PIL");
                }

                // Copia o arquivo SQL para C:\PREAMBULO\PIL
                File.Copy(caminhoSQLOrigem, caminhoSQLDestino, true);
                MessageBox.Show($"Arquivo SQL copiado para {caminhoSQLDestino}.\nO nome do banco de dados será: {Path.GetFileNameWithoutExtension(baseSelecionada)}",
                                            "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao copiar o arquivo SQL: {ex.Message}");
                return;
            }

            try
            {
                // Instancia a classe CriarBat e cria o arquivo BAT
                var criarBat = new CriarBat();
                criarBat.CriarArquivoBat(baseSelecionada, caminhoSQLDestino);

                // Executa o arquivo BAT
                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = batFilePath,
                        Arguments = Path.GetFileNameWithoutExtension(baseSelecionada), // Passa o nome da base sem extensão
                        UseShellExecute = true,
                        CreateNoWindow = false
                    }
                };
                process.Start();
                process.WaitForExit();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar ou executar o arquivo BAT: {ex.Message}");
            }
        }
       
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            string modeloSelecionado = cbModeloCPJ.SelectedItem?.ToString();
            string versaoSelecionada = cbVersaoInstalada.SelectedItem?.ToString();
            string adminSelecionado = cbAdmin.Text?.ToString();
            string versaoPath = Path.Combine("C:\\PREAMBULO\\CPJ3C", modeloSelecionado, versaoSelecionada);
            string repoPathBase = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção\\CPJ-Admin";

            Admin admin = new Admin();

            try
            {
                // Valida as seleções do usuário
                admin.ValidarSelecoes(modeloSelecionado, versaoSelecionada, adminSelecionado);

                // Obtém o caminho do arquivo ADMIN
                string adminPathOrigem = admin.ObterCaminhoAdmin(repoPathBase, adminSelecionado);
                if (string.IsNullOrEmpty(adminPathOrigem))
                {
                    MessageBox.Show($"O arquivo '{adminSelecionado}' não foi encontrado nas subpastas de {repoPathBase}.",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Copia o arquivo ADMIN para o destino
                admin.CopiarAdmin(adminPathOrigem, versaoPath);

                // Executa o arquivo ADMIN
                string adminFilePathDestino = Path.Combine(versaoPath, Path.GetFileName(adminPathOrigem));
                admin.ExecutarAdmin(adminFilePathDestino);               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar o ADMIN: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbModeloCPJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            _carregadorOpcoes.AtualizarModelosCPJ(cbModeloCPJ, cbVersaoInstalada);
        }

        private void btnIniciarCPJ_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário local
            local localForm = new local();

            // Exibe o formulário local
            localForm.Show();

            // Fecha o formulário de instalação (instalacao)
            this.Close();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide(); // Esconde a janela atual (instalacao)
            menu menuForm = new menu(); // Instancia a janela do menu principal
            menuForm.Show(); // Exibe a janela do menu
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chama o comportamento do botão Voltar
                menu menuForm = new menu();
                menuForm.Show();
                this.Hide();

                e.Cancel = true; // Cancela o fechamento da janela para evitar que o aplicativo encerre
            }
            else
            {
                base.OnFormClosing(e); // Permite o fechamento em outros casos
            }
        }


        private void msOpcoes_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Selecione o diretório desejado:";
                folderBrowser.ShowNewFolderButton = true;

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    Configuracoes.EnderecoGlobal = folderBrowser.SelectedPath;
                    lbCaminho.Text = Configuracoes.EnderecoGlobal;

                    // 🔹 Agora usamos SalvarConfiguracao() para salvar apenas UMA string
                    saveconfigs.SalvarConfiguracao("Instalacao", Configuracoes.EnderecoGlobal);

                    // Recarrega as opções
                    _carregadorOpcoes.LoadARQ3COptions(selectBoxARQ3C);
                    _carregadorOpcoes.LoadBancoDeDadosOptions(selectBoxBanco);
                    _carregadorOpcoes.LoadAdminOptions(cbAdmin);
                }
            }
        }

        private void CarregarConfiguracao()
        {
            string configSalva = saveconfigs.CarregarConfiguracao("Instalacao");

            if (!string.IsNullOrEmpty(configSalva))
            {
                Configuracoes.EnderecoGlobal = configSalva;
                lbCaminho.Text = Configuracoes.EnderecoGlobal;
            }
        }

        private void btnIniciarCPJLeviatan_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta o menu

            leviatan leviatanForm = new leviatan();
            if (leviatanForm.DialogResult != DialogResult.Cancel)
            {
                leviatanForm.ShowDialog(); // Exibe a janela Leviatan como modal
            }
            else
            {
            }

            this.Show(); // Reexibe o menu após fechar Leviatan ou cancelar o login
        }
    }
}
using CPJ_Universal.classes;
using CPJ_Universal.classes.CPJ_Universal.classes;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CPJ_Universal.janelas
{
    public partial class local : Form
    {
        private CarregadorOpcoes _carregadorOpcoes;

        public local()
        {
            InitializeComponent();
            CarregarConfiguracaoInicia();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            _carregadorOpcoes = new CarregadorOpcoes();

            // Carregar os modelos de CPJ3C
            _carregadorOpcoes.LoadModelosCPJOptions(comboBoxCPJ3C);

            // Carregar as versões de ARQ3C
            _carregadorOpcoes.LoadARQ3CDirectories(comboBoxARQ3C);

            // Adicionar o evento para quando o modelo do CPJ3C for selecionado
            comboBoxCPJ3C.SelectedIndexChanged += ComboBoxCPJ3C_SelectedIndexChanged;
        }   

        // Evento para quando o modelo do CPJ3C for selecionado
        private void ComboBoxCPJ3C_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Atualiza as versões do CPJ3C com base no modelo selecionado
            _carregadorOpcoes.AtualizarModelosCPJ(comboBoxCPJ3C, comboBoxVersaoCPJ3C);
        }

        // Método para inicializar a instalação ou outra ação desejada
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Coleta os valores selecionados nas ComboBoxes
            string modeloCPJ3C = comboBoxCPJ3C.SelectedItem?.ToString() ?? "";
            string versaoCPJ3C = comboBoxVersaoCPJ3C.SelectedItem?.ToString() ?? "";
            string arq3c = comboBoxARQ3C.SelectedItem?.ToString() ?? "";

            // Salvar as opções selecionadas
            saveconfigs.SalvarMultiplasConfiguracoes("Inicia", new string[] { modeloCPJ3C, versaoCPJ3C, arq3c });

            // Verifica se pelo menos uma das opções foi selecionada
            if (string.IsNullOrEmpty(versaoCPJ3C) && string.IsNullOrEmpty(arq3c))
            {
                MessageBox.Show("Por favor, selecione pelo menos uma opção: Versão CPJ3C ou ARQ3C.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Constrói os caminhos dos arquivos executáveis
            string caminhoCPJ3CServer = null;
            string caminhoCPJ3CClient = null;
            string caminhoARQ3C = null;

            if (!string.IsNullOrEmpty(versaoCPJ3C))
            {
                string caminhoCPJ3C = Path.Combine(@"C:\PREAMBULO\CPJ3C", modeloCPJ3C, versaoCPJ3C);
                caminhoCPJ3CServer = Path.Combine(caminhoCPJ3C, "cpj3cserver.exe");
                caminhoCPJ3CClient = Path.Combine(caminhoCPJ3C, "cpj3cclient.exe");
            }

            if (!string.IsNullOrEmpty(arq3c))
            {
                caminhoARQ3C = Path.Combine(@"C:\PREAMBULO\ARQ3C", arq3c, "arq3cserver.exe");
            }

            // Verifica se os arquivos existem antes de tentar executá-los
            if (!string.IsNullOrEmpty(caminhoCPJ3CServer) && !File.Exists(caminhoCPJ3CServer))
            {
                MessageBox.Show($"Não foi encontrado o arquivo: {caminhoCPJ3CServer}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(caminhoCPJ3CClient) && !File.Exists(caminhoCPJ3CClient))
            {
                MessageBox.Show($"Não foi encontrado o arquivo: {caminhoCPJ3CClient}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(caminhoARQ3C) && !File.Exists(caminhoARQ3C))
            {
                MessageBox.Show($"Não foi encontrado o arquivo: {caminhoARQ3C}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Fecha os processos anteriores, caso estejam em execução
                var processosCPJ3C = System.Diagnostics.Process.GetProcessesByName("cpj3cserver");
                foreach (var processo in processosCPJ3C)
                {
                    processo.Kill();
                }

                var processosARQ3C = System.Diagnostics.Process.GetProcessesByName("arq3cserver");
                foreach (var processo in processosARQ3C)
                {
                    processo.Kill();
                }

                // Inicia os processos conforme as opções selecionadas
                if (!string.IsNullOrEmpty(caminhoARQ3C))
                {
                    System.Diagnostics.Process.Start(caminhoARQ3C);
                }

                if (!string.IsNullOrEmpty(caminhoCPJ3CServer))
                {
                    System.Diagnostics.Process.Start(caminhoCPJ3CServer);
                }

                // Adiciona a contagem regressiva antes de abrir o Client
                if (!string.IsNullOrEmpty(caminhoCPJ3CClient))
                {
                    ExibirMensagemContagemRegressiva(5, () =>
                    {
                        System.Diagnostics.Process.Start(caminhoCPJ3CClient);
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar os serviços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarConfiguracaoInicia()
        {
            string[] configuracoes = saveconfigs.CarregarMultiplasConfiguracoes("Inicia");

            if (configuracoes.Length >= 3)
            {
                string modeloCPJ3C = configuracoes[0];
                string versaoCPJ3C = configuracoes[1];
                string arq3c = configuracoes[2];

                // 🔹 Espera os ComboBoxes carregarem antes de definir os valores
                this.Load += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(modeloCPJ3C) && comboBoxCPJ3C.Items.Contains(modeloCPJ3C))
                        comboBoxCPJ3C.SelectedItem = modeloCPJ3C;

                    if (!string.IsNullOrEmpty(versaoCPJ3C) && comboBoxVersaoCPJ3C.Items.Contains(versaoCPJ3C))
                        comboBoxVersaoCPJ3C.SelectedItem = versaoCPJ3C;

                    if (!string.IsNullOrEmpty(arq3c) && comboBoxARQ3C.Items.Contains(arq3c))
                        comboBoxARQ3C.SelectedItem = arq3c;
                };
            }
        }

        private void ExibirMensagemContagemRegressiva(int segundos, Action callback)
        {
            Form formContagem = new Form()
            {
                Size = new System.Drawing.Size(350, 150),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = false,
                Text = "Aguarde...",
                BackColor = System.Drawing.Color.FromArgb(30, 30, 30),
                ForeColor = System.Drawing.Color.White
            };

            Label lblContagem = new Label()
            {
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                ForeColor = System.Drawing.Color.White
            };

            formContagem.Controls.Add(lblContagem);

            Timer timer = new Timer();
            timer.Interval = 1000;
            int tempoRestante = segundos;

            timer.Tick += (s, e) =>
            {
                lblContagem.Text = $"Aguarde o CPJ Server iniciar...\nCliente abrirá em {tempoRestante} segundos...";
                tempoRestante--;

                if (tempoRestante < 0)
                {
                    timer.Stop();
                    formContagem.Close();
                    callback?.Invoke(); // Executa a ação após a contagem regressiva
                }
            };

            timer.Start();
            formContagem.ShowDialog();
        }

        // Método para voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Exibe a janela "menu" e esconde a janela "local"
            menu menuForm = new menu();
            menuForm.Show();
            this.Hide();
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


        // Método para instalar
        private void btnInstalar_Click(object sender, EventArgs e)
        {
            // Cria uma instância do formulário de instalação
            instalacao instalacaoForm = new instalacao();

            // Exibe o formulário de instalação
            instalacaoForm.Show();

            // Esconde a janela atual (local)
            this.Hide();
        }

        private void btnFecharCPJ_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtém todos os processos em execução com o nome "cpj3cserver"
                var processosCPJ3C = System.Diagnostics.Process.GetProcessesByName("cpj3cserver");
                foreach (var processo in processosCPJ3C)
                {
                    processo.Kill();  // Fecha o processo
                }

                // Obtém todos os processos em execução com o nome "arq3cserver"
                var processosARQ3C = System.Diagnostics.Process.GetProcessesByName("arq3cserver");
                foreach (var processo in processosARQ3C)
                {
                    processo.Kill();  // Fecha o processo
                }

                // Mensagem de sucesso
                MessageBox.Show("Processos CPJ3C e ARQ3C fechados com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar fechar os processos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciaClient_Click(object sender, EventArgs e)
        {
            // Coleta os valores selecionados na ComboBox de versão do CPJ3C
            string modeloCPJ3C = comboBoxCPJ3C.SelectedItem?.ToString();
            string versaoCPJ3C = comboBoxVersaoCPJ3C.SelectedItem?.ToString();

            // Verifica se a versão foi selecionada
            if (string.IsNullOrEmpty(modeloCPJ3C) || string.IsNullOrEmpty(versaoCPJ3C))
            {
                MessageBox.Show("Por favor, selecione um modelo e uma versão do CPJ3C.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Constrói o caminho do cpj3cclient.exe
            string caminhoCPJ3C = Path.Combine(@"C:\PREAMBULO\CPJ3C", modeloCPJ3C, versaoCPJ3C);
            string caminhoCPJ3CClient = Path.Combine(caminhoCPJ3C, "cpj3cclient.exe");

            // Verifica se o arquivo existe antes de tentar executá-lo
            if (!File.Exists(caminhoCPJ3CClient))
            {
                MessageBox.Show($"Não foi encontrado o arquivo: {caminhoCPJ3CClient}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Inicia o CPJ3C Client
                System.Diagnostics.Process.Start(caminhoCPJ3CClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar o CPJ3C Client: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

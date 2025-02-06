using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using CPJ_Universal.classes;
using MySql.Data.MySqlClient;


namespace CPJ_Universal.janelas
{
    public partial class leviatan : Form
    {
        private List<ListItem> allItems = new List<ListItem>();

        private conexaodb db;

        private Timer timer; // Adiciona um timer para verificar a conexão

        public leviatan()
        {
            // Realiza a validação de login antes de inicializar os componentes
            if (!ValidarLogin())
            {
                this.DialogResult = DialogResult.Cancel; // Define o resultado como "Cancel"
                return; // Sai do construtor antes de inicializar os componentes
            }

            // Inicializa os componentes apenas após o login bem-sucedido
            InitializeComponent();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            db = new conexaodb();

            // Configura o timer
            timer = new Timer();
            timer.Interval = 2000; // Intervalo em milissegundos (2000ms = 2 segundos)
            timer.Tick += Timer_Tick; // Define o método a ser executado
            timer.Start(); // Inicia o timer
        }

        private bool ValidarLogin()
        {
            // Verifica a conexão com o banco de dados antes de iniciar o login
            try
            {
                using (var conexao = new conexaodb())
                {
                    conexao.AbrirConexao();

                    // Verifica se a conexão está aberta
                    if (conexao.Connection.State != System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Não foi possível estabelecer conexão com o banco de dados.",
                                        "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Conexão falhou
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar a conexão com o banco de dados: {ex.Message}",
                                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Conexão falhou
            }

            // Instancia a janela de login e realiza o processo de autenticação
            loginLeviatan loginForm = new loginLeviatan();
            DialogResult resultado = loginForm.ShowDialog();

            // Verifica se o login foi bem-sucedido
            return resultado == DialogResult.OK && loginLeviatanClass.SuperUsuario >= 0;
        }

        private void leviatan_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true; // Impede edição

            // Atualiza o status do banco ao carregar a janela
            db.AtualizarStatusBanco(StatusBancolb);

            // Carrega os dados do banco no DataGridView
            Task.Run(() => CarregarDadosDoBanco());

            // Define o texto do lbLogin como o nome do usuário logado
            lbLogin.Text = $"Logado como: {loginLeviatanClass.Login}";

            // Verifica se o usuário logado é super e habilita ou desabilita o menu "Usuários"
            usuariosToolStripMenuItem.Enabled = loginLeviatanClass.SuperUsuario == 1;
        }

        private void CarregarDadosDoBanco()
        {
            try
            {
                linkacesso linkAcesso = new linkacesso();
                DataTable dados = linkAcesso.ObterLinksAcesso();

                // Atualiza o DataGridView
                Invoke((MethodInvoker)delegate
                {
                    dataGridView1.DataSource = dados;

                    // Configura as colunas do DataGridView
                    if (dataGridView1.Columns["codigo_cliente"] != null)
                        dataGridView1.Columns["codigo_cliente"].HeaderText = "Código";
                    if (dataGridView1.Columns["nome_cliente"] != null)
                        dataGridView1.Columns["nome_cliente"].HeaderText = "Nome";
                    if (dataGridView1.Columns["link_cliente"] != null)
                        dataGridView1.Columns["link_cliente"].HeaderText = "Link";

                    // Configura o DataGridView para ser somente leitura
                    dataGridView1.ReadOnly = true;

                    // Configura para selecionar a linha inteira ao clicar
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Ajusta automaticamente o tamanho das colunas
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados do banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                db.AbrirConexao();

                // Verifica se a conexão está aberta
                if (db.Connection.State == System.Data.ConnectionState.Open)
                {
                    // Atualiza o status do banco como conectado
                    db.AtualizarStatusBanco(StatusBancolb);
                }
                else
                {
                    throw new Exception("A conexão com o banco foi perdida.");
                }
            }
            catch (Exception)
            {
                // Para o timer para evitar múltiplas mensagens
                timer.Stop();

                // Exibe uma mensagem informando que o banco caiu
                DialogResult result = MessageBox.Show(
                    "A conexão com o banco foi perdida.\nDeseja tentar novamente?",
                    "Erro de Conexão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Yes)
                {
                    // Tenta reconectar
                    timer.Start(); // Reinicia o timer
                }
                else
                {
                    // Fecha o formulário e volta ao menu principal
                    voltar_Click(sender, e);
                }
            }
            finally
            {
                db.FecharConexao();
            }
        }


        private async void acessarCpjb_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string codigo = selectedRow.Cells[0].Value.ToString();
                string nome = selectedRow.Cells[1].Value.ToString();
                string link = selectedRow.Cells[2].Value.ToString().Replace("\r", "").Replace("\n", "").Trim();
                string folderName = $"{codigo}_{nome}";
                string path = Path.Combine("C:\\CPJ3C_Client", folderName);

                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string exePath = Path.Combine(path, "cpj3cclient.exe");

                    if (File.Exists(exePath))
                    {
                        Clipboard.SetText(path);
                        Process.Start(exePath);
                    }
                    else
                    {
                        string exeUrl = $"{link}/cpj3cclient_inst.exe";
                        exePath = Path.Combine(path, "cpj3cclient_inst.exe");

                        // Cria uma instância da barra de progresso
                        var progressBarHandler = new progressleviatanbar(progressBar, labelProgress, labelSpeed, labelDownloaded);

                        using (var client = new WebClient())
                        {
                            client.DownloadProgressChanged += (s, ev) =>
                            {
                                progressBarHandler.UpdateProgress(ev.ProgressPercentage);

                                // Calcula a velocidade em bytes por segundo de forma segura
                                long bytesPerSecond = ev.ProgressPercentage > 0
                                    ? ev.BytesReceived / ev.ProgressPercentage
                                    : ev.BytesReceived; // Assume todo o recebido se o progresso for 0%

                                progressBarHandler.UpdateSpeed(bytesPerSecond);
                                progressBarHandler.UpdateDownloaded(ev.BytesReceived);
                            };

                            client.DownloadFileCompleted += (s, ev) =>
                            {
                                if (ev.Error != null)
                                {
                                    MessageBox.Show($"Erro ao baixar o arquivo: {ev.Error.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Download concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                progressBarHandler.Reset();
                            };

                            await client.DownloadFileTaskAsync(new Uri(exeUrl), exePath);
                            Clipboard.SetText(path);
                            Process.Start(exePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao criar a pasta, baixar ou executar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma linha para acessar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void acessarConfigb_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string link = selectedRow.Cells[2].Value.ToString();
                string configLink = link.Replace("server", "cpj-config");
                Process.Start(configLink);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para acessar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void acessarConnectb_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string link = selectedRow.Cells[2].Value.ToString();
                string connectLink = link.Replace("server", "cpj-connect");
                Process.Start(connectLink);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para acessar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();

            // Define a consulta SQL com base no texto de pesquisa
            string query = $"SELECT codigo_cliente, nome_cliente, link_cliente FROM links_acesso WHERE nome_cliente LIKE '%{searchText}%'";

            // Usa a classe conexaodb para executar a consulta
            try
            {
                using (var conexao = new conexaodb())
                {
                    MySqlDataReader reader = conexao.ExecutarConsulta(query);

                    // Cria um DataTable para armazenar os resultados
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Atualiza o DataGridView com os dados filtrados
                    dataGridView1.DataSource = dataTable;

                    // Configura os cabeçalhos das colunas, se necessário
                    dataGridView1.Columns["codigo_cliente"].HeaderText = "Código";
                    dataGridView1.Columns["nome_cliente"].HeaderText = "Nome";
                    dataGridView1.Columns["link_cliente"].HeaderText = "Link";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar no banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atualizarb_Click(object sender, EventArgs e)
        {
            CarregarDadosDoBanco();
        }

        private void voltar_Click(object sender, EventArgs e)
        {
            // Para o timer se estiver em execução
            if (timer != null && timer.Enabled)
            {
                timer.Stop();
                timer.Dispose();
            }

            // Fecha o formulário Leviatan
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário "usuarios"
            usuarios formUsuarios = new usuarios();

            // Exibe o formulário como uma janela modal (bloqueia a interação com o formulário pai)
            formUsuarios.ShowDialog();
        }

    }
}

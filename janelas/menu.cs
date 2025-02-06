using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CPJ_Universal.janelas
{
    public partial class menu : Form
    {
        private static NotifyIcon notifyIcon; // Torna o NotifyIcon estático
        private static ContextMenuStrip contextMenu;

        public menu()
        {
            InitializeComponent();

            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configura o NotifyIcon apenas na primeira vez
            if (notifyIcon == null)
            {
                notifyIcon = new NotifyIcon();

                // Define o caminho para o ícone
                string iconPath = Path.Combine(Application.StartupPath, "icon\\LOGOHD.ico");

                // Configura o NotifyIcon com o ícone
                notifyIcon.Icon = new System.Drawing.Icon(iconPath);
                notifyIcon.Text = "CPJ Universal"; // Texto ao passar o mouse sobre o ícone
                notifyIcon.Visible = true;

                // Configuração do menu de contexto com as mesmas opções dos botões
                contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("1. Local", null, AbrirLocal);
                contextMenu.Items.Add("2. Leviatan", null, AbrirLeviatan);
                contextMenu.Items.Add("3. Instalação", null, AbrirInstalacao);
                contextMenu.Items.Add("4. Desinstalação", null, AbrirDesinstalacao);
                contextMenu.Items.Add(new ToolStripSeparator()); // Adiciona um separador
                contextMenu.Items.Add("Sair", null, SairAplicacao);

                notifyIcon.ContextMenuStrip = contextMenu;


                // Evento ao clicar duas vezes no ícone
                notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            FecharTodasJanelas(); // Fecha todas as janelas abertas antes de reabrir o menu

            if (!this.Visible) // Apenas exibe o menu se ele estiver oculto
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }


        // Método para abrir a janela Local
        private void AbrirLocal(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            local localForm = new local();
            localForm.Show();
        }

        private void AbrirLeviatan(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            leviatan leviatanForm = new leviatan();
            leviatanForm.ShowDialog();
        }

        private void AbrirInstalacao(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            instalacao instalacaoForm = new instalacao();
            instalacaoForm.Show();
        }

        private void AbrirDesinstalacao(object sender, EventArgs e)
        {
            FecharTodasJanelas();
            desinstalacao desinstalacaoForm = new desinstalacao();
            desinstalacaoForm.Show();
        }

        // Método para sair da aplicação
        private static void SairAplicacao(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void FecharTodasJanelas()
        {
            // Criar uma lista de formulários para evitar erro de modificação da coleção
            List<Form> formsAbertos = Application.OpenForms.Cast<Form>().ToList();

            // Apenas oculta todas as janelas abertas, sem fechar
            foreach (Form form in formsAbertos)
            {
                if (form != this && !form.IsDisposed) // Garante que o próprio menu continue funcionando
                {
                    form.Hide(); // Apenas oculta em vez de fechar
                }
            }

            // Oculta o menu se ele estiver visível
            if (this.Visible)
            {
                this.Hide();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancela o fechamento do formulário
                this.Hide();     // Oculta a janela principal
                notifyIcon.ShowBalloonTip(1000, "CPJ Universal", "O aplicativo continua ativo na barra de tarefas.", ToolTipIcon.Info);
            }
            else
            {
                base.OnFormClosing(e); // Permite que o aplicativo feche completamente em outros casos
            }
        }

        // Evento para o botão "1.Local"
        private void btnLocal_Click(object sender, EventArgs e)
        {
            local localForm = new local();  // Instancia a janela local
            localForm.Show();               // Exibe a janela local
            this.Hide();                    // Esconde a janela atual (menu)
        }

        // Evento para o botão "2.Leviatan"
        private void btnLeviatan_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta o menu

            leviatan leviatanForm = new leviatan();
            if (leviatanForm.DialogResult != DialogResult.Cancel)
            {
                leviatanForm.ShowDialog(); // Exibe a janela Leviatan como modal
            }

            this.Show(); // Reexibe o menu após fechar Leviatan ou cancelar o login
        }

        // Evento para o botão "3.Instalação"
        private void btnInstalacao_Click(object sender, EventArgs e)
        {
            instalacao instalacaoForm = new instalacao();  // Corrigido para usar a classe correta 'Inicial'
            instalacaoForm.Show();                   // Exibe a janela 'Inicial'
            this.Hide();                             // Esconde a janela atual (menu)
        }

        // Evento para o botão "4.Desinstalação"
        private void btnDesinstalacao_Click(object sender, EventArgs e)
        {
            desinstalacao desinstalacaoForm = new desinstalacao();  // Instancia a janela desinstalacao
            desinstalacaoForm.Show();                               // Exibe a janela desinstalacao
            this.Hide();                                            // Esconde a janela atual (menu)
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sobre janelaSobre = new sobre();
            janelaSobre.ShowDialog(); // Exibe como uma janela modal
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

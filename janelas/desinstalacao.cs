using CPJ_Universal.classes.CPJ_Universal.classes;
using System;
using System.IO;
using System.Windows.Forms;

namespace CPJ_Universal.janelas
{
    public partial class desinstalacao : Form
    {
        private CarregadorOpcoes _carregadorOpcoes;
        public desinstalacao()
        {
            InitializeComponent();
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
        private void btnDesinstalar_Click(object sender, EventArgs e)
        {
            // Coleta os valores selecionados nas ComboBoxes
            string modeloCPJ3C = comboBoxCPJ3C.SelectedItem?.ToString();
            string versaoCPJ3C = comboBoxVersaoCPJ3C.SelectedItem?.ToString();
            string arq3c = comboBoxARQ3C.SelectedItem?.ToString();

            // Verifica se todos os campos foram selecionados
            if (string.IsNullOrEmpty(modeloCPJ3C) || string.IsNullOrEmpty(versaoCPJ3C) || string.IsNullOrEmpty(arq3c))
            {
                MessageBox.Show("Por favor, selecione todos os itens antes de iniciar a desinstalação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Se algum valor não foi selecionado, exibe erro e retorna
            }

            // Constrói os caminhos das pastas para CPJ3C e ARQ3C
            string caminhoCPJ3C = Path.Combine(@"C:\PREAMBULO\CPJ3C", modeloCPJ3C, versaoCPJ3C);
            string caminhoARQ3C = Path.Combine(@"C:\PREAMBULO\ARQ3C", arq3c);

            // Confirmação de desinstalação
            var resultado = MessageBox.Show($"Tem certeza que deseja desinstalar o CPJ3C '{modeloCPJ3C} - {versaoCPJ3C}' e o ARQ3C '{arq3c}'? Esta ação não pode ser desfeita.", "Confirmar Desinstalação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.No)
            {
                return; // Se o usuário não confirmar, a desinstalação é cancelada
            }

            try
            {
                // Fecha os processos "cpj3cserver" e "arq3cserver", caso estejam em execução
                var processosCPJ3C = System.Diagnostics.Process.GetProcessesByName("cpj3cserver");
                foreach (var processo in processosCPJ3C)
                {
                    processo.Kill();  // Fecha o processo
                }

                var processosARQ3C = System.Diagnostics.Process.GetProcessesByName("arq3cserver");
                foreach (var processo in processosARQ3C)
                {
                    processo.Kill();  // Fecha o processo
                }

                // Exclui a pasta ARQ3C
                if (Directory.Exists(caminhoARQ3C))
                {
                    Directory.Delete(caminhoARQ3C, true);  // Deleta a pasta ARQ3C e seu conteúdo
                    MessageBox.Show($"Pasta ARQ3C '{arq3c}' excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"A pasta ARQ3C '{arq3c}' não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Exclui a pasta CPJ3C
                if (Directory.Exists(caminhoCPJ3C))
                {
                    Directory.Delete(caminhoCPJ3C, true);  // Deleta a pasta CPJ3C e seu conteúdo
                    MessageBox.Show($"Pasta CPJ3C '{modeloCPJ3C} - {versaoCPJ3C}' excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"A pasta CPJ3C '{modeloCPJ3C} - {versaoCPJ3C}' não foi encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar desinstalar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
    }

}

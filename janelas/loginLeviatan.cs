using System;
using System.Windows.Forms;
using CPJ_Universal.classes;

namespace CPJ_Universal.janelas
{
    public partial class loginLeviatan : Form
    {
        private conexaodb conexao;

        public loginLeviatan()
        {
            InitializeComponent();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            conexao = new conexaodb();
            // Configura o evento KeyDown para o formulário
            this.KeyPreview = true;
            this.KeyDown += LoginLeviatan_KeyDown;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Por favor, insira o login e a senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarLogin(login, senha))
            {
                this.DialogResult = DialogResult.OK; // Define que o login foi bem-sucedido
                this.Close(); // Fecha o formulário
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarLogin(string login, string senhaFornecida)
        {
            try
            {
                string query = "SELECT senha, super, first_login FROM usuarios WHERE login = @login";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conexao.Connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    conexao.AbrirConexao();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string senhaArmazenada = reader.GetString(0);
                            int superUsuario = reader.GetInt32(1);
                            int firstLogin = reader.GetInt32(2);

                            if (criptografia.VerificarSenha(senhaFornecida, senhaArmazenada) || senhaFornecida == senhaArmazenada)
                            {
                                // Se for o primeiro login, exibe a tela para redefinir a senha
                                if (firstLogin == 1)
                                {
                                    using (var formNovaSenha = new novasenha(login))
                                    {
                                        var resultado = formNovaSenha.ShowDialog();
                                        if (resultado == DialogResult.OK)
                                        {
                                            loginLeviatanClass.DefinirSuperUsuario(superUsuario);
                                            loginLeviatanClass.DefinirLogin(login);
                                            return true; // Faz o login após a troca de senha
                                        }
                                        else
                                        {
                                            return false; // Usuário cancelou a troca da senha
                                        }
                                    }
                                }
                                else
                                {
                                    // Login normal
                                    loginLeviatanClass.DefinirSuperUsuario(superUsuario);
                                    loginLeviatanClass.DefinirLogin(login);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar login: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.FecharConexao();
            }

            return false;
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Define que o login foi cancelado
            this.Close(); // Fecha o formulário
        }

        private void LoginLeviatan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}

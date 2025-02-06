using System;
using System.Windows.Forms;
using CPJ_Universal.classes;

namespace CPJ_Universal.janelas
{
    public partial class novasenha : Form
    {
        private string _login;
        private conexaodb conexao; // Criar uma instância da conexão

        public novasenha(string login)
        {
            InitializeComponent();
            _login = login;
            conexao = new conexaodb(); // Inicializa a conexão com o banco
        }

        private void btnSalvarNovaSenha_Click(object sender, EventArgs e)
        {
            string novaSenha = txtNovasenha.Text.Trim();
            string confirmarSenha = txtConfirmeNovasenha.Text.Trim();

            if (string.IsNullOrEmpty(novaSenha) || novaSenha.Length < 4)
            {
                MessageBox.Show("A senha deve ter pelo menos 4 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas digitadas não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Verifica se a nova senha é igual à senha atual
                string querySenhaAtual = "SELECT senha FROM usuarios WHERE login = @login";
                string senhaAtual = null;

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(querySenhaAtual, conexao.Connection))
                {
                    cmd.Parameters.AddWithValue("@login", _login);
                    conexao.AbrirConexao();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            senhaAtual = reader.GetString(0);
                        }
                    }
                }

                // Se a senha nova for igual à senha antiga, não permitir a troca
                if (criptografia.VerificarSenha(novaSenha, senhaAtual))
                {
                    MessageBox.Show("A nova senha não pode ser igual à senha atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Atualiza a senha e define `first_login` como 0
                string senhaHash = criptografia.GerarHash(novaSenha);
                string queryAtualizar = "UPDATE usuarios SET senha = @senha, first_login = 0 WHERE login = @login";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(queryAtualizar, conexao.Connection))
                {
                    cmd.Parameters.AddWithValue("@senha", senhaHash);
                    cmd.Parameters.AddWithValue("@login", _login);
                    conexao.AbrirConexao();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indica sucesso
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar senha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.FecharConexao();
            }
        }

        private void btnCancelarNovaSenha_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indica que a senha não foi alterada
            this.Close();
        }
    }
}

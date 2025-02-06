using System;
using System.Data;
using System.Windows.Forms;
using CPJ_Universal.classes;

namespace CPJ_Universal.janelas
{
    public partial class usuarios : Form
    {
        private conexaodb conexao;

        public usuarios()
        {
            InitializeComponent();
            // Centralizar no monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Impedir maximização
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            conexao = new conexaodb();
            dgUsuarios.AllowUserToAddRows = false; // Desativa a linha em branco padrão
            // Adiciona o evento para formatar a coluna de senha
            dgUsuarios.CellFormatting += DgUsuarios_CellFormatting;
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            try
            {
                string query = "SELECT id, login, senha, super FROM usuarios";
                DataTable usuarios = new DataTable();

                using (var reader = conexao.ExecutarConsulta(query))
                {
                    usuarios.Load(reader);
                }

                dgUsuarios.DataSource = usuarios;

                dgUsuarios.Columns["id"].HeaderText = "ID";
                dgUsuarios.Columns["id"].ReadOnly = true; // ID é somente leitura
                dgUsuarios.Columns["login"].HeaderText = "Login";
                dgUsuarios.Columns["senha"].HeaderText = "Senha";
                dgUsuarios.Columns["super"].HeaderText = "Super Usuário";
                dgUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dgUsuarios.DataSource;

            if (dataTable != null)
            {
                DataRow novaLinha = dataTable.NewRow();
                novaLinha["login"] = "";
                novaLinha["senha"] = "";
                novaLinha["super"] = "0"; // Valor padrão
                dataTable.Rows.Add(novaLinha);

                int novaLinhaIndex = dgUsuarios.Rows.Count - 1;
                dgUsuarios.CurrentCell = dgUsuarios.Rows[novaLinhaIndex].Cells["login"]; // Foco na nova linha
                dgUsuarios.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("Nenhuma fonte de dados está vinculada ao DataGridView.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            SalvarAlteracoes();
        }

        private void SalvarAlteracoes()
        {
            DataTable dataTable = (DataTable)dgUsuarios.DataSource;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    InserirUsuario(row);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    AtualizarUsuario(row);
                }
            }

            // Aceita todas as alterações realizadas no DataTable
            dataTable.AcceptChanges();
            MessageBox.Show("Alterações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InserirUsuario(DataRow row)
        {
            try
            {
                string login = row["login"].ToString();
                string senha = row["senha"].ToString();
                string super = row["super"].ToString();

                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
                {
                    throw new Exception("Os campos 'Login' e 'Senha' são obrigatórios.");
                }

                // Gera o hash da senha
                string senhaHash = criptografia.GerarHash(senha);

                // Monta a consulta para inserção, definindo first_login como 1
                string query = $"INSERT INTO usuarios (login, senha, super, first_login) VALUES ('{login}', '{senhaHash}', '{super}', 1)";
                conexao.ExecutarComando(query);

                // Atualiza o ID do novo registro
                string idQuery = "SELECT MAX(id) FROM usuarios";
                using (var reader = conexao.ExecutarConsulta(idQuery))
                {
                    if (reader.Read())
                    {
                        row["id"] = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarUsuario(DataRow row)
        {
            try
            {
                int id = Convert.ToInt32(row["id"]);
                string login = row["login"].ToString();
                string senha = row["senha"].ToString();
                string super = row["super"].ToString();

                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
                {
                    throw new Exception("Os campos 'Login' e 'Senha' são obrigatórios.");
                }

                // Gera o hash da senha
                string senhaHash = criptografia.GerarHash(senha);

                // Monta a consulta para atualização, incluindo o reset do first_login para 1
                string query = $"UPDATE usuarios SET login = '{login}', senha = '{senhaHash}', super = '{super}', first_login = 1 WHERE id = {id}";
                conexao.ExecutarComando(query);

                MessageBox.Show("Usuário atualizado com sucesso! O próximo login exigirá troca de senha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                // Exibe mensagem de confirmação
                DialogResult confirmacao = MessageBox.Show(
                    "Tem certeza que deseja excluir o(s) usuário(s) selecionado(s)?\nEsta ação é irreversível.",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Verifica se o usuário clicou em "Sim"
                if (confirmacao == DialogResult.Yes)
                {
                    foreach (DataGridViewRow selectedRow in dgUsuarios.SelectedRows)
                    {
                        if (selectedRow.Cells["id"].Value != DBNull.Value)
                        {
                            int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                            ExcluirUsuario(id); // Chama o método para excluir do banco de dados
                        }

                        dgUsuarios.Rows.Remove(selectedRow); // Remove da tabela
                    }

                    MessageBox.Show("Usuário(s) excluído(s) com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada para exclusão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcluirUsuario(int id)
        {
            try
            {
                string query = $"DELETE FROM usuarios WHERE id = {id}";
                conexao.ExecutarComando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula pertence à coluna "senha"
            if (dgUsuarios.Columns[e.ColumnIndex].Name == "senha" && e.Value != null)
            {
                // Exibe 4 asteriscos ou bolinhas
                e.Value = "****";
                e.FormattingApplied = true; // Indica que a formatação foi aplicada
            }
        }
    }
}

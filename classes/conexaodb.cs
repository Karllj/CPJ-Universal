using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CPJ_Universal.classes
{
    internal class conexaodb : IDisposable
    {
        private MySqlConnection connection;

        // Propriedade para expor a conexão
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        // Construtor que inicializa a string de conexão
        public conexaodb()
        {
            string server = "192.168.11.46";
            string database = "acesso_leviatan";
            string user = "acesso_leviatan";
            string password = "1cpj_universal!leviatan1";
            string port = "3306";

            string connectionString = $"Server={server};Database={database};User ID={user};Password={password};Port={port};";

            connection = new MySqlConnection(connectionString);
        }

        // Método para verificar conexão e atualizar a Label
        public void AtualizarStatusBanco(Label statusLabel)
        {
            try
            {
                AbrirConexao();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    statusLabel.Text = "Banco Conectado";
                    statusLabel.ForeColor = System.Drawing.Color.Green; // Cor verde
                }
            }
            catch (MySqlException)
            {
                statusLabel.Text = "Banco Não Conectado";
                statusLabel.ForeColor = System.Drawing.Color.Red; // Cor vermelha
            }
            finally
            {
                FecharConexao();
            }
        }

        // Método para abrir a conexão
        public void AbrirConexao()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Conexão aberta com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao abrir conexão: {ex.Message}");
            }
        }

        // Método para fechar a conexão
        public void FecharConexao()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Conexão fechada com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao fechar conexão: {ex.Message}");
            }
        }

        // Implementação da interface IDisposable
        public void Dispose()
        {
            FecharConexao();
            connection?.Dispose();
        }

        // Método para executar comandos INSERT, UPDATE ou DELETE
        public void ExecutarComando(string query)
        {
            try
            {
                AbrirConexao();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int linhasAfetadas = cmd.ExecuteNonQuery();
                Console.WriteLine($"Comando executado com sucesso! Linhas afetadas: {linhasAfetadas}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao executar comando: {ex.Message}");
            }
            finally
            {
                FecharConexao();
            }
        }

        // Método para executar comandos SELECT e retornar dados
        public MySqlDataReader ExecutarConsulta(string query)
        {
            try
            {
                AbrirConexao();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                return cmd.ExecuteReader(); // Retorna o DataReader para leitura
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao executar consulta: {ex.Message}");
                throw;
            }
        }
    }
}

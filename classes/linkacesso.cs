using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CPJ_Universal.classes
{
    internal class linkacesso
    {
        private conexaodb db;

        public linkacesso()
        {
            db = new conexaodb();
        }

        // Método para carregar dados da tabela links_acesso
        public DataTable ObterLinksAcesso()
        {
            DataTable tabela = new DataTable();

            try
            {
                string query = "SELECT codigo_cliente, nome_cliente, link_cliente FROM links_acesso";

                using (var reader = db.ExecutarConsulta(query))
                {
                    tabela.Load(reader); // Carrega os dados diretamente no DataTable
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar dados de links_acesso: {ex.Message}");
            }

            return tabela;
        }
    }
}

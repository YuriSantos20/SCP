using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ConsultarProduto : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ConsultarProduto()
        {
            InitializeComponent();
            CarregarDados();
        }

        // Método para Conectar ao Banco de Dados
        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();  // Tentar abrir a conexão
                return connection;  // Retorna a conexão se estiver aberta
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;  // Retorna null se falhar ao abrir
            }
        }

        // Método para Carregar Dados no DataGridView
        private void CarregarDados()
        {
            string query = "SELECT id_produto, nome, quantidade_estoque, preco, unidade, sigla_classificacaoproduto FROM produto";

            using (MySqlConnection connection = GetConnection())
            {
                // Verificar se a conexão é válida
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            adapter.Fill(dataTable);  // Preencher o DataTable com dados
                            dataGridViewProdutos.DataSource = dataTable;  // Configurar DataSource do DataGridView
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

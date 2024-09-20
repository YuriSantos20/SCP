using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ConsultarClassificacao : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ConsultarClassificacao()
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
            string query = "SELECT id_classificacaoProduto, sigla_classificacaoProduto, nome_classificacaoProduto FROM classificacaoproduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            adapter.Fill(dataTable);  // Preencher o DataTable com dados
                            dataGridViewClassificacoes.DataSource = dataTable;  // Configurar DataSource do DataGridView
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

        private void dataGridViewClassificacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento de clique na célula do DataGridView, se necessário
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

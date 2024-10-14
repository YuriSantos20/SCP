using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ConsultarFornecedores : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ConsultarFornecedores()
        {
            InitializeComponent();
            CarregarDadosFornecedores();
        }

        // Método para Conectar ao Banco de Dados
        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
                return null;
            }
        }

        // Método para carregar os dados dos fornecedores do banco de dados
        private void CarregarDadosFornecedores()
        {
            string query = "SELECT id_fornecedor, nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email FROM Fornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Exibe os dados no DataGridView ou outro controle
                        dataGridViewFornecedores.DataSource = dataTable;  // DataGridView chamado dataGridViewFornecedores
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao carregar dados dos fornecedores: " + ex.Message);
                    }
                }
            }
        }

        private void ConsultarFornecedores_Load(object sender, EventArgs e)
        {
            // Qualquer lógica adicional de carregamento pode ser colocada aqui
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Você pode adicionar lógica aqui se necessário
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IncluirFornecedor cadastroFornecedor = new IncluirFornecedor();
            cadastroFornecedor.FormClosed += (s, args) => CarregarDadosFornecedores();  // Recarregar dados ao fechar o formulário
            cadastroFornecedor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlterarFornecedores alterarFornecedor = new AlterarFornecedores();
            alterarFornecedor.FormClosed += (s, args) => CarregarDadosFornecedores();  // Recarregar dados ao fechar o formulário
            alterarFornecedor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirFornecedores excluirFornecedor = new ExcluirFornecedores();
            excluirFornecedor.FormClosed += (s, args) => CarregarDadosFornecedores();  // Recarregar dados ao fechar o formulário
            excluirFornecedor.Show();
        }
    }
}

using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ConsultarClientes : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ConsultarClientes()
        {
            InitializeComponent();
            CarregarDadosClientes();
        }

        // Método para Conectar ao Banco de Dados
        private MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MessageBox.Show("Conexão bem-sucedida!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
            }

            return connection;
        }

        // Método para carregar os dados dos clientes do banco de dados
        private void CarregarDadosClientes()
        {
            string query = "SELECT id_cliente, nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email FROM cliente";

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
                        dataGridViewClientes.DataSource = dataTable;  // DataGridView chamado dataGridViewClientes
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao carregar dados dos clientes: " + ex.Message);
                    }
                }
            }
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {
            // Qualquer lógica adicional de carregamento pode ser colocada aqui
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IncluirClientes incluirClientes = new IncluirClientes();
            incluirClientes.FormClosed += (s, args) => CarregarDadosClientes();  // Atualizar os dados ao fechar o formulário
            incluirClientes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlterarClientes alterarClientes = new AlterarClientes();
            alterarClientes.FormClosed += (s, args) => CarregarDadosClientes();  // Atualizar os dados ao fechar o formulário
            alterarClientes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirCliente excluirCliente = new ExcluirCliente();
            excluirCliente.FormClosed += (s, args) => CarregarDadosClientes();  // Atualizar os dados ao fechar o formulário
            excluirCliente.Show();
        }
    }
}
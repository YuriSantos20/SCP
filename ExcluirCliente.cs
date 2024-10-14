using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MeuProjeto
{
    public partial class ExcluirCliente : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ExcluirCliente()
        {
            InitializeComponent();
            CarregarClientes();
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

        // Método para Carregar Clientes no DataGridView
        private void CarregarClientes()
        {
            string query = "SELECT id_cliente, nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email FROM Cliente";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewClientes.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento de Seleção do DataGridView
        
        

        // Método para Excluir Cliente no Banco de Dados
        private void ExcluirClienteDoBanco(int idCliente)
        {
            string query = "DELETE FROM Cliente WHERE id_cliente = @idCliente";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Cliente excluído com sucesso!");
                                CarregarClientes(); // Recarregar a lista após a exclusão
                                txtIdCliente.Clear(); // Limpar o campo após a exclusão
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído. Verifique o ID do cliente.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Excluir Cliente
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ExcluirCliente_Load(object sender, EventArgs e)
        {
            // Carregar os clientes ao carregar o formulário
            CarregarClientes();
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewClientes.Rows[e.RowIndex];
                    txtIdCliente.Text = row.Cells["id_cliente"].Value.ToString();
                    txtNome.Text = row.Cells["nome"].Value.ToString();
                    txtCpfCnpj.Text = row.Cells["cpf_cnpj"].Value.ToString();
                    // Preencher outros campos conforme necessário
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdCliente.Text))
                    {
                        MessageBox.Show("Por favor, insira o ID do cliente para exclusão.");
                        return;
                    }

                    int idCliente = Convert.ToInt32(txtIdCliente.Text);
                    ExcluirClienteDoBanco(idCliente);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Erro de formato no ID do cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

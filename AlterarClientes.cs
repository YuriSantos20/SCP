using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MeuProjeto
{
    public partial class AlterarClientes : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarClientes()
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
            // Seleciona todos os campos que você precisa
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

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewClientes.Rows[e.RowIndex];

                    // Preencher os campos com todos os atributos do cliente
                    txtIdCliente.Text = row.Cells["id_cliente"].Value.ToString();
                    txtNome.Text = row.Cells["nome"].Value.ToString();
                    txtCpfCnpj.Text = row.Cells["cpf_cnpj"].Value.ToString();
                    txtLogradouro.Text = row.Cells["logradouro"].Value.ToString();
                    txtNumero.Text = row.Cells["numero"].Value.ToString();
                    txtComplemento.Text = row.Cells["complemento"].Value.ToString();
                    txtBairro.Text = row.Cells["bairro"].Value.ToString();
                    txtCidade.Text = row.Cells["cidade"].Value.ToString();
                    txtEstado.Text = row.Cells["estado"].Value.ToString();
                    txtCep.Text = row.Cells["cep"].Value.ToString();
                    txtTelefone.Text = row.Cells["telefone"].Value.ToString();
                    txtEmail.Text = row.Cells["email"].Value.ToString();
                }
            }

        }

        // Método para Atualizar Cliente no Banco de Dados
        private void AtualizarCliente(int idCliente, string nome, string cpfCnpj, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string cep, string telefone, string email)
        {
            string query = "UPDATE Cliente SET nome = @nome, cpf_cnpj = @cpfCnpj, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, telefone = @telefone, email = @email WHERE id_cliente = @idCliente";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                        cmd.Parameters.AddWithValue("@logradouro", logradouro);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@complemento", complemento);
                        cmd.Parameters.AddWithValue("@bairro", bairro);
                        cmd.Parameters.AddWithValue("@cidade", cidade);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@cep", cep);
                        cmd.Parameters.AddWithValue("@telefone", telefone);
                        cmd.Parameters.AddWithValue("@email", email);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Cliente atualizado com sucesso!");
                                CarregarClientes(); // Recarregar a lista após a atualização
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do cliente.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar cliente: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Atualizar Cliente
        
        

        

        private void AlterarClientes_Load(object sender, EventArgs e)
        {
            // Carregar os clientes ao carregar o formulário
            CarregarClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdCliente.Text) ||
                        string.IsNullOrEmpty(txtNome.Text) ||
                        string.IsNullOrEmpty(txtCpfCnpj.Text))
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    int idCliente = Convert.ToInt32(txtIdCliente.Text);
                    string nome = txtNome.Text;
                    string cpfCnpj = txtCpfCnpj.Text;
                    // Capturar outros campos conforme necessário

                    AtualizarCliente(idCliente, nome, cpfCnpj, txtLogradouro.Text, txtNumero.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, txtEstado.Text, txtCep.Text, txtTelefone.Text, txtEmail.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Erro de formato nos dados: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

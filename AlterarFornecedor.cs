using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MeuProjeto
{
    public partial class AlterarFornecedores : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarFornecedores()
        {
            InitializeComponent();
            CarregarFornecedores();
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

        // Método para Carregar Fornecedores no DataGridView
        private void CarregarFornecedores()
        {
            // Seleciona todos os campos que você precisa
            string query = "SELECT id_fornecedor, nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email FROM fornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewFornecedores.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento de Seleção do DataGridView
       
        

        // Método para Atualizar Fornecedor no Banco de Dados
        private void AtualizarFornecedor(int idFornecedor, string nome, string cpfCnpj, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string cep, string telefone, string email)
        {
            string query = "UPDATE fornecedor SET nome = @nome, cpf_cnpj = @cpfCnpj, logradouro = @logradouro, numero = @numero, complemento = @complemento, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep, telefone = @telefone, email = @email WHERE id_fornecedor = @idFornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idFornecedor", idFornecedor);
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
                                MessageBox.Show("Fornecedor atualizado com sucesso!");
                                CarregarFornecedores(); // Recarregar a lista após a atualização
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do fornecedor.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar fornecedor: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Atualizar Fornecedor
       
        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdFornecedor.Text) ||
                        string.IsNullOrEmpty(txtNome.Text) ||
                        string.IsNullOrEmpty(txtCpfCnpj.Text))
                    {
                        MessageBox.Show("Por favor, preencha todos os campos.");
                        return;
                    }

                    int idFornecedor = Convert.ToInt32(txtIdFornecedor.Text);
                    string nome = txtNome.Text;
                    string cpfCnpj = txtCpfCnpj.Text;

                    // Chama o método para atualizar o fornecedor
                    AtualizarFornecedor(idFornecedor, nome, cpfCnpj, txtLogradouro.Text, txtNumero.Text, txtComplemento.Text, txtBairro.Text, txtCidade.Text, txtEstado.Text, txtCep.Text, txtTelefone.Text, txtEmail.Text);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewFornecedores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewFornecedores.Rows[e.RowIndex];

                    // Preencher os campos com todos os atributos do fornecedor
                    txtIdFornecedor.Text = row.Cells["id_fornecedor"].Value.ToString();
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
    }
}

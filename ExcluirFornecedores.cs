using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MeuProjeto
{
    public partial class ExcluirFornecedores : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ExcluirFornecedores()
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
            string query = "SELECT id_fornecedor, nome, cpf_cnpj, logradouro, numero, complemento, bairro, cidade, estado, cep, telefone, email FROM Fornecedor";

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

        // Método para Excluir Fornecedor no Banco de Dados
        private void ExcluirFornecedorDoBanco(int idFornecedor)
        {
            string query = "DELETE FROM Fornecedor WHERE id_fornecedor = @idFornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idFornecedor", idFornecedor);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Fornecedor excluído com sucesso!");
                                CarregarFornecedores(); // Recarregar a lista após a exclusão
                                txtIdFornecedor.Clear(); // Limpar o campo após a exclusão
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído. Verifique o ID do fornecedor.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir fornecedor: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void ExcluirFornecedores_Load(object sender, EventArgs e)
        {
            // Carregar os fornecedores ao carregar o formulário
            CarregarFornecedores();
        }

       
        

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewFornecedores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewFornecedores.Rows[e.RowIndex];
                    txtIdFornecedor.Text = row.Cells["id_fornecedor"].Value.ToString();
                    txtNome.Text = row.Cells["nome"].Value.ToString();
                    txtCpfCnpj.Text = row.Cells["cpf_cnpj"].Value.ToString();
                    // Preencher outros campos conforme necessário
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdFornecedor.Text))
                    {
                        MessageBox.Show("Por favor, insira o ID do fornecedor para exclusão.");
                        return;
                    }

                    int idFornecedor = Convert.ToInt32(txtIdFornecedor.Text);
                    ExcluirFornecedorDoBanco(idFornecedor);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Erro de formato no ID do fornecedor: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }
    }
}

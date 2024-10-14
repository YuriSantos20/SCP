using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace MeuProjeto
{
    public partial class ExcluirProduto : Form
    {
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ExcluirProduto()
        {
            InitializeComponent();
        }

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

        // Método para Excluir Produto no Banco de Dados
        private void ExcluirProdutodoBanco(int idProduto)
        {
            string query = "DELETE FROM produto WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Produto excluído com sucesso!");
                                txtIdProduto.Clear();
                                CarregarProdutos(); // Atualizar DataGridView após exclusão
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído. Verifique o ID do produto.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void CarregarProdutos()
        {
            // Consulta SQL modificada para incluir o nome do fornecedor
            string query = @"
        SELECT p.id_produto, p.nome, p.quantidade_estoque, p.preco, p.unidade, 
               p.sigla_classificacaoproduto, f.nome AS nome_fornecedor
        FROM produto p
        JOIN fornecedor f ON p.id_fornecedor = f.id_fornecedor"; // Faz o join para trazer o nome do fornecedor

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Atribuir os dados ao DataGridView
                            dataGridView1.DataSource = dataTable;

                            // Configurar cabeçalhos das colunas, se necessário
                            dataGridView1.Columns["id_produto"].HeaderText = "ID Produto";
                            dataGridView1.Columns["nome"].HeaderText = "Nome";
                            dataGridView1.Columns["quantidade_estoque"].HeaderText = "Quantidade em Estoque";
                            dataGridView1.Columns["preco"].HeaderText = "Preço";
                            dataGridView1.Columns["unidade"].HeaderText = "Unidade";
                            dataGridView1.Columns["sigla_classificacaoproduto"].HeaderText = "Classificação";
                            dataGridView1.Columns["nome_fornecedor"].HeaderText = "Fornecedor"; // Coluna nova com nome do fornecedor
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void ExcluirProduto_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }


        // Evento do Botão para Excluir Produto
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProduto.Text))
                {
                    MessageBox.Show("Por favor, insira o ID do produto para exclusão.");
                    return;
                }

                int idProduto = Convert.ToInt32(txtIdProduto.Text);
                ExcluirProdutodoBanco(idProduto);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro de formato no ID do produto: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtIdProduto.Text = row.Cells["id_produto"].Value.ToString();
                }
            }
        }
    }
}

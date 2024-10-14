using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace MeuProjeto
{
    public partial class AlterarProdutos : Form
    {
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarProdutos()
        {
            InitializeComponent();
            PreencherComboBoxClassificacoes();
            PreencherComboBoxFornecedores();
            CarregarProdutos(); // Carregar produtos ao inicializar o formulário
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
        private void CarregarProdutos()
        {
            string query = @"
    SELECT p.id_produto, p.nome, p.quantidade_estoque, p.preco, p.unidade, f.nome AS nome_fornecedor, p.id_fornecedor
    FROM produto p
    JOIN fornecedor f ON p.id_fornecedor = f.id_fornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        // Ajustar os títulos das colunas, se necessário
                        dataGridView1.Columns["id_produto"].HeaderText = "ID Produto";
                        dataGridView1.Columns["nome"].HeaderText = "Nome";
                        dataGridView1.Columns["quantidade_estoque"].HeaderText = "Estoque";
                        dataGridView1.Columns["preco"].HeaderText = "Preço";
                        dataGridView1.Columns["unidade"].HeaderText = "Unidade";
                        dataGridView1.Columns["nome_fornecedor"].HeaderText = "Fornecedor"; // Define o título da coluna do fornecedor
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }


        // Método para Buscar Dados do Produto com base no ID
        private void PreencherCamposProduto(int idProduto)
        {
            string query = "SELECT nome, quantidade_estoque, preco, unidade FROM produto WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);

                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtNome1.Text = reader["nome"].ToString();
                                    txtQuantidadeEstoque1.Text = reader["quantidade_estoque"].ToString();
                                    txtPreco1.Text = reader["preco"].ToString();
                                    txtUnidade1.Text = reader["unidade"].ToString();
                                }
                                else
                                {
                                    LimparCampos();
                                    MessageBox.Show("Produto não encontrado.");
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao buscar dados do produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void LimparCampos()
        {
            txtNome1.Clear();
            txtQuantidadeEstoque1.Clear();
            txtPreco1.Clear();
            txtUnidade1.Clear();
        }

        // Evento do TextBox txtIdProduto para Autocomplete
        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProduto.Text, out int idProduto))
            {
                PreencherCamposProduto(idProduto);
            }
            else
            {
                // Limpar os campos se o ID não for um número válido
                txtNome1.Clear();
                txtQuantidadeEstoque1.Clear();
                txtPreco1.Clear();
                txtUnidade1.Clear();
            }
        }

        // Método para Atualizar Produto no Banco de Dados
        private void AtualizarProduto(int idProduto, string nome, int quantidadeEstoque, double preco, string unidade, string sigla_classificacaoproduto, int id_fornecedor)
        {
            string query = "UPDATE produto SET nome = @nome, quantidade_estoque = @quantidadeEstoque, preco = @preco, unidade = @unidade, sigla_classificacaoproduto = @sigla_classificacaoproduto, id_fornecedor = @id_fornecedor " +
                           "WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@unidade", unidade);
                        cmd.Parameters.AddWithValue("@sigla_classificacaoproduto", sigla_classificacaoproduto);
                        cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Produto atualizado com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do produto.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        // Evento do Botão para Atualizar Produto
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdProduto1.Text) ||
                    string.IsNullOrEmpty(txtNome1.Text) ||
                    string.IsNullOrEmpty(txtQuantidadeEstoque1.Text) ||
                    string.IsNullOrEmpty(txtPreco1.Text) ||
                    string.IsNullOrEmpty(txtUnidade1.Text) ||
                    comboBoxClassificacao.SelectedItem == null ||
                    comboBoxFornecedor.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }

                int idProduto = Convert.ToInt32(txtIdProduto1.Text);
                string nome = txtNome1.Text;
                int quantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque1.Text);
                double preco = Convert.ToDouble(txtPreco1.Text);
                string unidade = txtUnidade1.Text;
                string sigla_classificacaoproduto = comboBoxClassificacao.SelectedItem.ToString();
                int id_fornecedor = Convert.ToInt32(comboBoxFornecedor.SelectedValue);

                AtualizarProduto(idProduto, nome, quantidadeEstoque, preco, unidade, sigla_classificacaoproduto, id_fornecedor);
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

        private void txtIdProduto1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Método para Atualizar Produto no Banco de Dados
        private void AtualizarProduto(int idProduto, string nome, int quantidadeEstoque, double preco, string unidade, string sigla_classificacaoproduto)
        {
            string query = "UPDATE produto SET nome = @nome, quantidade_estoque = @quantidadeEstoque, preco = @preco, unidade = @unidade, sigla_classificacaoproduto = @sigla_classificacaoproduto " +
                           "WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@unidade", unidade);
                        cmd.Parameters.AddWithValue("@sigla_classificacaoproduto", sigla_classificacaoproduto);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Produto atualizado com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do produto.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void PreencherComboBoxFornecedores()
        {
            string query = "SELECT id_fornecedor, nome FROM fornecedor";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                comboBoxFornecedor.DisplayMember = "nome"; // Exibe apenas o nome do fornecedor
                                comboBoxFornecedor.ValueMember = "id_fornecedor"; // Valor associado será o id
                                comboBoxFornecedor.DataSource = dt; // Atribui os dados à ComboBox
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar fornecedores: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void PreencherComboBoxClassificacoes()
        {
            string query = "SELECT sigla_classificacaoProduto FROM classificacaoproduto";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    comboBoxClassificacao.Items.Add(reader["sigla_classificacaoProduto"].ToString());
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar classificações: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlterarProdutos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int idProduto = Convert.ToInt32(row.Cells["id_produto"].Value);
                txtIdProduto1.Text = idProduto.ToString(); // Preencher o ID do produto
                PreencherCamposProduto(idProduto); // Carregar os dados do produto

                // Preencher o fornecedor na ComboBox
                if (row.Cells["id_fornecedor"].Value != null)
                {
                    int idFornecedor = Convert.ToInt32(row.Cells["id_fornecedor"].Value);
                    comboBoxFornecedor.SelectedValue = idFornecedor; // Atribuir o ID do fornecedor
                }
            }
        }
    }
}

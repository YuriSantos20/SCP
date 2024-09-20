using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class AlterarProdutos : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public AlterarProdutos()
        {
            InitializeComponent();
            PreencherComboBoxClassificacoes();
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

        // Método para Buscar Dados do Produto com base no ID
        private void PreencherCamposProduto(int idProduto)
        {
            string query = "SELECT nome, quantidade_estoque, preco, unidade FROM produto WHERE id_produto = @idProduto";

            using (MySqlConnection connection = GetConnection())
            {
                // Verificar se a conexão é válida
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Definir o parâmetro
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);

                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Preencher os TextBoxes com os dados retornados
                                    txtNome1.Text = reader["nome"].ToString();
                                    txtQuantidadeEstoque1.Text = reader["quantidade_estoque"].ToString();
                                    txtPreco1.Text = reader["preco"].ToString();
                                    txtUnidade1.Text = reader["unidade"].ToString();
                                }
                                else
                                {
                                    // Limpar os campos se nenhum dado for encontrado
                                    txtNome1.Clear();
                                    txtQuantidadeEstoque1.Clear();
                                    txtPreco1.Clear();
                                    txtUnidade1.Clear();
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
        private void AtualizarProduto(int idProduto, string nome, int quantidadeEstoque, double preco, string unidade)
        {
            string query = "UPDATE produto SET nome = @nome, quantidade_estoque = @quantidadeEstoque, preco = @preco, unidade = @unidade, sigla_classificacaoproduto = @sigla_classificacaoproduto " +
               "WHERE id_produto = @idProduto";


            using (MySqlConnection connection = GetConnection())
            {
                // Verificar se a conexão é válida
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Definir os parâmetros
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@unidade", unidade);
                        cmd.Parameters.AddWithValue("@sigla_classificacaoproduto", comboBoxClassificacao.SelectedItem.ToString());


                        try
                        {
                            int result = cmd.ExecuteNonQuery();  // Executar a atualização
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
                // Verificar se todos os campos foram preenchidos, exceto o ID
                if (string.IsNullOrEmpty(txtIdProduto1.Text) ||
                    string.IsNullOrEmpty(txtNome1.Text) ||
                    string.IsNullOrEmpty(txtQuantidadeEstoque1.Text) ||
                    string.IsNullOrEmpty(txtPreco1.Text) ||
                    string.IsNullOrEmpty(txtUnidade1.Text) ||
                    comboBoxClassificacao.SelectedItem == null)

                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }

                // Capturar os valores dos TextBoxes
                int idProduto = Convert.ToInt32(txtIdProduto1.Text);
                string nome = txtNome1.Text;
                int quantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque1.Text);
                double preco = Convert.ToDouble(txtPreco1.Text);
                string unidade = txtUnidade1.Text;
                string sigla_classificacaoproduto = comboBoxClassificacao.SelectedItem.ToString();

                // Chamar o método para atualizar no banco de dados
                AtualizarProduto(idProduto, nome, quantidadeEstoque, preco, unidade, sigla_classificacaoproduto);
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
                                    // Adicionar as siglas ao ComboBox
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
    }
}

using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class incluirProdutos : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public incluirProdutos()
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
                connection.Open();
                MessageBox.Show("Conexão bem-sucedida!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
            }

            return connection;
        }

        // Método para Inserir Produto no Banco de Dados
        private void InserirProduto(int idProduto, string nome, int quantidadeEstoque, double preco, string unidade, string sigla_classificacaoproduto)
        {
            string query = "INSERT INTO produto (id_produto, nome, quantidade_estoque, preco, unidade, sigla_classificacaoproduto) " +
                           "VALUES (@idProduto, @nome, @quantidadeEstoque, @preco, @unidade, @sigla_classificacaoproduto)";

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Passando os parâmetros
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@unidade", unidade);
                    cmd.Parameters.AddWithValue("@sigla_Classificacaoproduto", sigla_classificacaoproduto);

                    try
                    {
                        // Executa o comando
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produto cadastrado com sucesso!");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erro ao inserir produto: " + ex.Message);
                    }
                }
            }
        }

        // Evento do Botão para Cadastrar Produto
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            
        }

        private void cadastroProdutos_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            // Captura os valores dos TextBoxes
            int idProduto = Convert.ToInt32(txtIdProduto.Text);
            string nome = txtNome.Text;
            int quantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
            double preco = Convert.ToDouble(txtPreco.Text);
            string unidade = txtUnidade.Text;
            string sigla_classificacaoproduto = comboBoxClassificacao.SelectedItem.ToString();


            // Chama o método para inserir no banco de dados
            InserirProduto(idProduto, nome, quantidadeEstoque, preco, unidade, sigla_classificacaoproduto);
        }
        // Método para preencher o ComboBox com as classificações (siglas)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

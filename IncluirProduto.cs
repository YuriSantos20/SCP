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
            PreencherComboBoxFornecedores();
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
        private void InserirProduto(string nome, int quantidadeEstoque, double preco, string unidade, string sigla_classificacaoproduto, int id_fornecedor)
        {
            string query = "INSERT INTO produto (nome, quantidade_estoque, preco, unidade, sigla_classificacaoproduto, id_fornecedor) " +
                           "VALUES (@nome, @quantidadeEstoque, @preco, @unidade, @sigla_classificacaoproduto, @id_fornecedor)";

            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Passando os parâmetros
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@unidade", unidade);
                    cmd.Parameters.AddWithValue("@sigla_classificacaoproduto", sigla_classificacaoproduto);
                    cmd.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);

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
            string nome = txtNome.Text;
            int quantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
            double preco = Convert.ToDouble(txtPreco.Text);
            string unidade = txtUnidade.Text;
            string sigla_classificacaoProduto = comboBoxClassificacao.SelectedItem.ToString();

            // Obtenha o fornecedor selecionado como DataRowView
            var fornecedorSelecionado = (DataRowView)comboBoxFornecedor.SelectedItem;
            int id_fornecedor = (int)fornecedorSelecionado["id_fornecedor"];  // Acesse o id do fornecedor

            // Chama o método para inserir no banco de dados
            InserirProduto(nome, quantidadeEstoque, preco, unidade, sigla_classificacaoProduto, id_fornecedor);
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
        private void PreencherComboBoxFornecedores()
        {
            string query = "SELECT id_fornecedor, nome FROM fornecedor"; // Ajuste conforme o nome correto da coluna

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

                                // Defina as propriedades DisplayMember e ValueMember
                                comboBoxFornecedor.DisplayMember = "nome";  // Nome da coluna que você quer mostrar
                                comboBoxFornecedor.ValueMember = "id_fornecedor";  // Coluna que será usada internamente

                                // Atribui o DataTable como fonte de dados
                                comboBoxFornecedor.DataSource = dt;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

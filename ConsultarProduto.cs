using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MeuProjeto
{
    public partial class ConsultarProduto : Form
    {
        // String de Conexão (Substitua pelos seus detalhes)
        string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";

        public ConsultarProduto()
        {
            InitializeComponent();
            CarregarDados();
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

        // Método para Carregar Dados no DataGridView
        private void CarregarDados()
        {
            // Consulta SQL modificada para incluir o nome do fornecedor
            string query = @"
        SELECT p.id_produto, p.nome, p.quantidade_estoque, p.preco, p.unidade, 
               p.sigla_classificacaoproduto, f.nome AS nome_fornecedor
        FROM produto p
        JOIN fornecedor f ON p.id_fornecedor = f.id_fornecedor"; // Faz o join para trazer o nome do fornecedor

            using (MySqlConnection connection = GetConnection())
            {
                // Verificar se a conexão é válida
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            adapter.Fill(dataTable);  // Preencher o DataTable com dados
                            dataGridViewProdutos.DataSource = dataTable;  // Configurar DataSource do DataGridView

                            // Configurar cabeçalhos das colunas, se necessário
                            dataGridViewProdutos.Columns["id_produto"].HeaderText = "ID Produto";
                            dataGridViewProdutos.Columns["nome"].HeaderText = "Nome";
                            dataGridViewProdutos.Columns["quantidade_estoque"].HeaderText = "Quantidade em Estoque";
                            dataGridViewProdutos.Columns["preco"].HeaderText = "Preço";
                            dataGridViewProdutos.Columns["unidade"].HeaderText = "Unidade";
                            dataGridViewProdutos.Columns["sigla_classificacaoproduto"].HeaderText = "Classificação";
                            dataGridViewProdutos.Columns["nome_fornecedor"].HeaderText = "Fornecedor"; // Coluna nova com nome do fornecedor
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarProduto_Load(object sender, EventArgs e)
        {

        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            incluirProdutos formIncluir = new incluirProdutos();
            formIncluir.FormClosed += (s, args) => CarregarDados();  // Recarregar os dados quando a janela for fechada
            formIncluir.Show();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            AlterarProdutos formAlterar = new AlterarProdutos();
            formAlterar.FormClosed += (s, args) => CarregarDados();  // Recarregar os dados quando a janela for fechada
            formAlterar.Show();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            ExcluirProduto formExcluir = new ExcluirProduto();
            formExcluir.FormClosed += (s, args) => CarregarDados();  // Recarregar os dados quando a janela for fechada
            formExcluir.Show();
        }
    }
}

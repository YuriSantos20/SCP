using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaComercio1
{
    public partial class ControleVendas : Form
    {
        private string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;"; // Agora está no escopo correto
        public ControleVendas()
        {
            InitializeComponent();
            PreencherComboBoxClientes();
            CarregarProdutos();
            ConfigurarDataGridViewVendas();
        }
        private void ConfigurarDataGridViewVendas()
        {
            // Define as colunas do DataGridView de vendas
            dataGridViewVendas.Columns.Add("Nome", "Nome");
            dataGridViewVendas.Columns.Add("Preço", "Preço");
            dataGridViewVendas.Columns.Add("Quantidade", "Quantidade");
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
        private void PreencherComboBoxClientes()
        {
            string query = "SELECT id_cliente, nome FROM cliente";

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

                                // Configura a ComboBox
                                comboBoxClientes.DisplayMember = "nome";  // Nome do cliente que será mostrado
                                comboBoxClientes.ValueMember = "id_cliente";  // ID do cliente que será usado internamente
                                comboBoxClientes.DataSource = dt;  // Atribui a tabela como fonte de dados
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
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
            // Ajuste a consulta para buscar todos os campos, exceto o id_produto
            string query = @"
        SELECT 
            p.nome, 
            p.quantidade_estoque, 
            p.preco, 
            p.unidade, 
            p.sigla_classificacaoproduto, 
            f.nome AS nome_fornecedor 
        FROM produto p 
        JOIN fornecedor f ON p.id_fornecedor = f.id_fornecedor"; // Faz o join para trazer o nome do fornecedor

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Exibe os dados no DataGridView
                            dataGridViewProdutos.DataSource = dataTable;

                            // Configuração dos cabeçalhos das colunas
                            dataGridViewProdutos.Columns["nome"].HeaderText = "Nome";
                            dataGridViewProdutos.Columns["quantidade_estoque"].HeaderText = "Quantidade em Estoque";
                            dataGridViewProdutos.Columns["preco"].HeaderText = "Preço";
                            dataGridViewProdutos.Columns["unidade"].HeaderText = "Unidade";
                            dataGridViewProdutos.Columns["sigla_classificacaoproduto"].HeaderText = "Classificação";
                            dataGridViewProdutos.Columns["nome_fornecedor"].HeaderText = "Fornecedor";

                            // Opcional: Ocultar a coluna de ID do produto se estiver incluída no DataTable
                            if (dataGridViewProdutos.Columns.Contains("id_produto"))
                            {
                                dataGridViewProdutos.Columns["id_produto"].Visible = false; // Para garantir que não seja mostrada
                            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Certifique-se de que há um produto selecionado
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text) || string.IsNullOrWhiteSpace(txtValorProduto.Text))
            {
                MessageBox.Show("Por favor, selecione um produto antes de adicionar.");
                return;
            }

            // Obtem a quantidade desejada
            int quantidade;
            if (int.TryParse(txtQuantidade.Text, out quantidade) && quantidade > 0)
            {
                // Obtem a quantidade em estoque do produto selecionado
                int quantidadeEstoque = Convert.ToInt32(dataGridViewProdutos.CurrentRow.Cells["quantidade_estoque"].Value);

                // Verifica se a quantidade desejada é menor ou igual à quantidade em estoque
                if (quantidade <= quantidadeEstoque)
                {
                    // Adiciona uma nova linha ao DataGridView de vendas
                    int rowIndex = dataGridViewVendas.Rows.Add();
                    DataGridViewRow newRow = dataGridViewVendas.Rows[rowIndex];

                    newRow.Cells["Nome"].Value = txtNomeProduto.Text;
                    newRow.Cells["Preço"].Value = txtValorProduto.Text;
                    newRow.Cells["Quantidade"].Value = quantidade;

                    // Atualiza o total da compra
                    CalcularTotal();

                    // Opcional: você pode atualizar a quantidade em estoque, se necessário
                    // quantidadeEstoque -= quantidade; // Atualiza a quantidade em estoque
                    // dataGridViewProdutos.CurrentRow.Cells["quantidade_estoque"].Value = quantidadeEstoque; // Atualiza o DataGridView de produtos
                }
                else
                {
                    MessageBox.Show("A quantidade desejada excede a quantidade em estoque.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira uma quantidade válida.");
            }
        }
        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewVendas.Rows)
            {
                // Certifique-se de que a linha não é uma linha em branco
                if (row.Cells["Preço"].Value != null && row.Cells["Quantidade"].Value != null)
                {
                    decimal preco = Convert.ToDecimal(row.Cells["Preço"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    // Adiciona o total da linha ao total geral
                    total += preco * quantidade;
                }
            }

            // Exibe o total na TextBox
            txtTotal.Text = total.ToString("C2"); // Formata como moeda
        }

        private void dataGridViewProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha e coluna selecionada são válidas
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obter a linha atual selecionada
                DataGridViewRow row = dataGridViewProdutos.Rows[e.RowIndex];

                // Atribuir os valores das colunas para os TextBoxes
                txtNomeProduto.Text = row.Cells["nome"].Value.ToString();
                txtValorProduto.Text = row.Cells["preco"].Value.ToString();
            }
        }

        private void buttonFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (dataGridViewVendas.Rows.Count > 0)
            {
                using (MySqlConnection connection = GetConnection())
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Inserir a venda na tabela de vendas
                                int idCliente = (int)comboBoxClientes.SelectedValue; // Pega o ID do cliente selecionado
                                decimal valorTotal = CalcularTotalDecimal(); // Calcula o total da venda
                                string queryVenda = "INSERT INTO venda (data, id_cliente, total_venda, situacao_venda) VALUES (@data, @id_cliente, @total_venda, @situacao_venda)";

                                int idVenda = 0; // Para armazenar o ID da venda inserida

                                using (MySqlCommand cmdVenda = new MySqlCommand(queryVenda, connection, transaction))
                                {
                                    cmdVenda.Parameters.AddWithValue("@data", DateTime.Now);
                                    cmdVenda.Parameters.AddWithValue("@id_cliente", idCliente);
                                    cmdVenda.Parameters.AddWithValue("@total_venda", valorTotal);
                                    cmdVenda.Parameters.AddWithValue("@situacao_venda", "Finalizada");

                                    cmdVenda.ExecuteNonQuery();
                                    // Obter o ID da venda recém-inserida
                                    idVenda = (int)cmdVenda.LastInsertedId;
                                }

                                // Adicionar itens na tabela itemvenda
                                string queryItemVenda = "INSERT INTO itemvenda (id_venda, numeroItem, idProduto, quantidade, valor_unitario, total_item) VALUES (@id_venda, @numeroItem, @idProduto, @quantidade, @valor_unitario, @total_item)";

                                using (MySqlCommand cmdItemVenda = new MySqlCommand(queryItemVenda, connection, transaction))
                                {
                                    foreach (DataGridViewRow row in dataGridViewVendas.Rows)
                                    {
                                        if (row.Cells["Nome"].Value != null)
                                        {
                                            // Aqui você deve obter o ID do produto
                                            string nomeProduto = row.Cells["Nome"].Value.ToString();
                                            int quantidadeVendida = Convert.ToInt32(row.Cells["Quantidade"].Value);
                                            decimal valorUnitario = Convert.ToDecimal(row.Cells["Preço"].Value);
                                            decimal totalItem = quantidadeVendida * valorUnitario; // Total para o item

                                            // Obter o ID do produto com base no nome (ou pode ser feito com um método diferente)
                                            int idProduto = ObterIdProduto(nomeProduto, connection, transaction);

                                            // Preencher os parâmetros do comando
                                            cmdItemVenda.Parameters.Clear();
                                            cmdItemVenda.Parameters.AddWithValue("@id_venda", idVenda);
                                            cmdItemVenda.Parameters.AddWithValue("@numeroItem", row.Index + 1); // O número do item pode ser a posição na lista
                                            cmdItemVenda.Parameters.AddWithValue("@idProduto", idProduto);
                                            cmdItemVenda.Parameters.AddWithValue("@quantidade", quantidadeVendida);
                                            cmdItemVenda.Parameters.AddWithValue("@valor_unitario", valorUnitario);
                                            cmdItemVenda.Parameters.AddWithValue("@total_item", totalItem);

                                            // Executa o comando para inserir o item na tabela
                                            cmdItemVenda.ExecuteNonQuery();
                                        }
                                    }
                                }

                                // Atualiza o estoque
                                string queryAtualizaEstoque = "UPDATE produto SET quantidade_estoque = quantidade_estoque - @quantidade WHERE id_produto = @id_produto";
                                using (MySqlCommand cmdAtualizaEstoque = new MySqlCommand(queryAtualizaEstoque, connection, transaction))
                                {
                                    foreach (DataGridViewRow row in dataGridViewVendas.Rows)
                                    {
                                        if (row.Cells["Nome"].Value != null)
                                        {
                                            string nomeProduto = row.Cells["Nome"].Value.ToString();
                                            int quantidadeVendida = Convert.ToInt32(row.Cells["Quantidade"].Value);
                                            int idProduto = ObterIdProduto(nomeProduto, connection, transaction); // Obter ID do produto

                                            cmdAtualizaEstoque.Parameters.Clear();
                                            cmdAtualizaEstoque.Parameters.AddWithValue("@quantidade", quantidadeVendida);
                                            cmdAtualizaEstoque.Parameters.AddWithValue("@id_produto", idProduto);

                                            cmdAtualizaEstoque.ExecuteNonQuery();
                                        }
                                    }
                                }

                                // Aqui você deve chamar a função GerarContasAReceber
                                int numeroParcelas = string.IsNullOrWhiteSpace(txtParcelas.Text) ? 1 : int.Parse(txtParcelas.Text); // Define o número de parcelas
                                DateTime dataLancamento = DateTime.Now; // Define a data de lançamento
                                GerarContasAReceber(idCliente, valorTotal, numeroParcelas, dataLancamento);

                                // Confirma a transação
                                transaction.Commit();
                                MessageBox.Show("Venda realizada com sucesso!");
                                LimparCampos();
                                CarregarProdutos();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Erro ao realizar venda: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falha ao conectar ao banco de dados.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há produtos na venda.");
            }
        }

        private int ObterIdProduto(string nomeProduto, MySqlConnection connection, MySqlTransaction transaction)
        {
            // Método para obter o ID do produto pelo nome
            string query = "SELECT id_produto FROM produto WHERE nome = @nome";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@nome", nomeProduto);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0; // Retorna 0 se não encontrar
            }
        }
        private void LimparCampos()
        {
            // Limpar campos de texto
            txtNomeProduto.Text = "";
            txtValorProduto.Text = "";
            txtQuantidade.Text = "";
            txtTotal.Text = "";

            // Limpar o DataGridView de vendas
            dataGridViewVendas.Rows.Clear();

            // Opcional: Reiniciar a ComboBox de clientes
            comboBoxClientes.SelectedIndex = -1; // Desseleciona qualquer item

            // Limpar parcelas se necessário
            txtParcelas.Text = "";
            txtParcelas.Enabled = false; // Desabilita o campo de parcelas
        }
        private decimal CalcularTotalDecimal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewVendas.Rows)
            {
                // Certifique-se de que a linha não é uma linha em branco
                if (row.Cells["Preço"].Value != null && row.Cells["Quantidade"].Value != null)
                {
                    decimal preco = Convert.ToDecimal(row.Cells["Preço"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    // Adiciona o total da linha ao total geral
                    total += preco * quantidade;
                }
            }

            return total; // Retorna o total como decimal
        }
        private void GerarContasAReceber(int idCliente, decimal valorTotal, int numeroParcelas, DateTime dataLancamento)
        {
            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Cálculo do valor de cada parcela
                            decimal valorParcela = valorTotal / numeroParcelas;

                            for (int i = 1; i <= numeroParcelas; i++)
                            {
                                // Definir a data de vencimento de cada parcela
                                DateTime dataVencimento = dataLancamento.AddMonths(i);

                                // Comando SQL para inserir a conta a receber
                                string query = @"
                            INSERT INTO conta_receber (descricao, id_cliente, data_lancamento, data_vencimento, valor, recebido)
                            VALUES (@descricao, @idCliente, @dataLancamento, @dataVencimento, @valor, @recebido)";

                                using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
                                {
                                    // Parâmetros da consulta
                                    cmd.Parameters.AddWithValue("@descricao", $"Parcela {i} de {numeroParcelas}");
                                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                                    cmd.Parameters.AddWithValue("@dataLancamento", dataLancamento);
                                    cmd.Parameters.AddWithValue("@dataVencimento", dataVencimento);
                                    cmd.Parameters.AddWithValue("@valor", valorParcela);
                                    cmd.Parameters.AddWithValue("@recebido", false); // Inicialmente, não foi recebido

                                    // Executa o comando para inserir a conta a receber
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Confirma a transação
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Erro ao gerar contas a receber: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void cbPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se o valor selecionado é "Cartão de Credito"
            if (cbPagamento.SelectedItem != null && cbPagamento.SelectedItem.ToString() == "Cartao de Credito")
            {
                txtParcelas.Enabled = true; // Habilita o campo de parcelas
            }
            else
            {
                txtParcelas.Enabled = false; // Desabilita o campo de parcelas
                txtParcelas.Text = ""; // Limpa o campo quando não for cartão de crédito
            }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

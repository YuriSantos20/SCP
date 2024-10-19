using MeuProjeto;
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
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;database=conexao_SCP;uid=root;pwd=1234;";
        public Form1()
        {
            InitializeComponent();
            CarregarVendas();
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
        private void CarregarVendas()
        {
            string query = @"
                SELECT 
                    v.id_venda, 
                    v.data, 
                    c.nome AS cliente, 
                    v.total_venda, 
                    v.situacao_venda
                FROM venda v
                JOIN cliente c ON v.id_cliente = c.id_cliente";

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
                            dataGridViewVendas.DataSource = dataTable;

                            // Configuração dos cabeçalhos das colunas
                            dataGridViewVendas.Columns["id_venda"].HeaderText = "ID Venda";
                            dataGridViewVendas.Columns["data"].HeaderText = "Data";
                            dataGridViewVendas.Columns["cliente"].HeaderText = "Cliente";
                            dataGridViewVendas.Columns["total_venda"].HeaderText = "Total da Venda";
                            dataGridViewVendas.Columns["situacao_venda"].HeaderText = "Situação da Venda";
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao carregar vendas: " + ex.Message);
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
            ControleCadastro form2 = new ControleCadastro();
            form2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ControleVendas cadastroClassificacao = new ControleVendas();
            cadastroClassificacao.FormClosed += (s, args) => CarregarVendas(); // Atualiza as vendas ao fechar ControleVendas
            cadastroClassificacao.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ContaReceber cadastroclassificacao = new ContaReceber();
            cadastroclassificacao.Show();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            // Verifica se uma linha está selecionada
            if (dataGridViewVendas.SelectedRows.Count > 0)
            {
                // Obtém o ID da venda selecionada
                int idVenda = Convert.ToInt32(dataGridViewVendas.SelectedRows[0].Cells["id_venda"].Value);

                // Confirmar a ação de cancelamento
                DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar a venda?", "Cancelar Venda", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Chamadas para cancelar a venda e devolver os itens ao estoque
                    CancelarVenda(idVenda);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma venda para cancelar.");
            }
        }
        private void CancelarVenda(int idVenda)
        {
            // Devolver itens ao estoque
            DevolverItensAoEstoque(idVenda);

            // Excluir a venda da tabela
            string query = "DELETE FROM venda WHERE id_venda = @id_venda";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_venda", idVenda);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Venda cancelada com sucesso!");
                            CarregarVendas(); // Atualiza o DataGridView
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao cancelar a venda: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }
        private void DevolverItensAoEstoque(int idVenda)
        {
            string query = @"
        SELECT iv.idProduto, iv.quantidade
        FROM itemvenda iv  
        WHERE iv.id_venda = @id_venda";

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_venda", idVenda);
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int idProduto = reader.GetInt32("idProduto");
                                    int quantidade = reader.GetInt32("quantidade");

                                    MessageBox.Show($"Devolvendo produto ID: {idProduto}, Quantidade: {quantidade}");
                                    // Atualiza a quantidade do produto no estoque
                                    AtualizarProduto(idProduto, quantidade);
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao devolver itens ao estoque: " + ex.Message);
                        }
                    }

                    // Exclui os itens da venda
                    string deleteQuery = "DELETE FROM itemvenda WHERE id_venda = @id_venda";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, connection))
                    {
                        cmdDelete.Parameters.AddWithValue("@id_venda", idVenda);
                        try
                        {
                            cmdDelete.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erro ao excluir itens da venda: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao conectar ao banco de dados.");
                }
            }
        }

        private void AtualizarProduto(int idProduto, int quantidade)
        {
            string query = @"
    UPDATE produto
    SET quantidade_estoque = quantidade_estoque + @quantidade
    WHERE id_produto = @idProduto";  // Use o nome correto da coluna

            using (MySqlConnection connection = GetConnection())
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            MessageBox.Show($"Produto ID: {idProduto} atualizado, Linhas Afetadas: {rowsAffected}");
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
    }
}       



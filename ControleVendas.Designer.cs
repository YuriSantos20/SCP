namespace SistemaComercio1
{
    partial class ControleVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProdutos = new System.Windows.Forms.DataGridView();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtValorProduto = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtParcelas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPagamento = new System.Windows.Forms.ComboBox();
            this.buttonFinalizarVenda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Carrinho = new System.Windows.Forms.Label();
            this.dataGridViewVendas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(97, 28);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // dataGridViewProdutos
            // 
            this.dataGridViewProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdutos.Location = new System.Drawing.Point(24, 66);
            this.dataGridViewProdutos.Name = "dataGridViewProdutos";
            this.dataGridViewProdutos.ReadOnly = true;
            this.dataGridViewProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProdutos.Size = new System.Drawing.Size(351, 150);
            this.dataGridViewProdutos.TabIndex = 2;
            this.dataGridViewProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProdutos_CellContentClick);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(24, 359);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(124, 31);
            this.buttonAdicionar.TabIndex = 3;
            this.buttonAdicionar.Text = "Adicionar no carrinho";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            this.buttonAdicionar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(97, 236);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(100, 20);
            this.txtNomeProduto.TabIndex = 4;
            this.txtNomeProduto.TextChanged += new System.EventHandler(this.txtNomeProduto_TextChanged);
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.Location = new System.Drawing.Point(97, 262);
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.Size = new System.Drawing.Size(100, 20);
            this.txtValorProduto.TabIndex = 5;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(97, 288);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(100, 20);
            this.txtQuantidade.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Produto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor Unitario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Quantidade:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtParcelas);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbPagamento);
            this.panel1.Controls.Add(this.buttonFinalizarVenda);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.Carrinho);
            this.panel1.Controls.Add(this.dataGridViewVendas);
            this.panel1.Location = new System.Drawing.Point(393, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 408);
            this.panel1.TabIndex = 10;
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(139, 292);
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(115, 20);
            this.txtParcelas.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Parcelas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Forma de Pagamento:";
            // 
            // cbPagamento
            // 
            this.cbPagamento.FormattingEnabled = true;
            this.cbPagamento.Items.AddRange(new object[] {
            "Especie",
            "Cartao de Debito",
            "Cartao de Credito",
            "Pix"});
            this.cbPagamento.Location = new System.Drawing.Point(139, 259);
            this.cbPagamento.Name = "cbPagamento";
            this.cbPagamento.Size = new System.Drawing.Size(115, 21);
            this.cbPagamento.TabIndex = 5;
            this.cbPagamento.SelectedIndexChanged += new System.EventHandler(this.cbPagamento_SelectedIndexChanged);
            // 
            // buttonFinalizarVenda
            // 
            this.buttonFinalizarVenda.Location = new System.Drawing.Point(25, 360);
            this.buttonFinalizarVenda.Name = "buttonFinalizarVenda";
            this.buttonFinalizarVenda.Size = new System.Drawing.Size(91, 23);
            this.buttonFinalizarVenda.TabIndex = 4;
            this.buttonFinalizarVenda.Text = "Finalizar Venda";
            this.buttonFinalizarVenda.UseVisualStyleBackColor = true;
            this.buttonFinalizarVenda.Click += new System.EventHandler(this.buttonFinalizarVenda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(139, 233);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(115, 20);
            this.txtTotal.TabIndex = 2;
            // 
            // Carrinho
            // 
            this.Carrinho.AutoSize = true;
            this.Carrinho.Location = new System.Drawing.Point(158, 26);
            this.Carrinho.Name = "Carrinho";
            this.Carrinho.Size = new System.Drawing.Size(46, 13);
            this.Carrinho.TabIndex = 1;
            this.Carrinho.Text = "Carrinho";
            // 
            // dataGridViewVendas
            // 
            this.dataGridViewVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVendas.Location = new System.Drawing.Point(25, 64);
            this.dataGridViewVendas.Name = "dataGridViewVendas";
            this.dataGridViewVendas.Size = new System.Drawing.Size(322, 150);
            this.dataGridViewVendas.TabIndex = 0;
            // 
            // ControleVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtValorProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.dataGridViewProdutos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxClientes);
            this.Name = "ControleVendas";
            this.Text = "ControleVendas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdutos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProdutos;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtValorProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Carrinho;
        private System.Windows.Forms.DataGridView dataGridViewVendas;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button buttonFinalizarVenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPagamento;
        private System.Windows.Forms.TextBox txtParcelas;
        private System.Windows.Forms.Label label7;
    }
}
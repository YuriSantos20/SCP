namespace MeuProjeto
{
    partial class AlterarClassificacao
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
            this.dataGridViewClassificacoes1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdClassificacaoProduto1 = new System.Windows.Forms.TextBox();
            this.txtSiglaClassificacaoProduto1 = new System.Windows.Forms.TextBox();
            this.txtNomeClassificacaoProduto1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificacoes1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClassificacoes1
            // 
            this.dataGridViewClassificacoes1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassificacoes1.Location = new System.Drawing.Point(285, 12);
            this.dataGridViewClassificacoes1.Name = "dataGridViewClassificacoes1";
            this.dataGridViewClassificacoes1.Size = new System.Drawing.Size(290, 203);
            this.dataGridViewClassificacoes1.TabIndex = 0;
            this.dataGridViewClassificacoes1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassificacoes1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(364, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 26);
            this.button3.TabIndex = 1;
            this.button3.Text = "Alterar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(465, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Excluir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sigla:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nome:";
            // 
            // txtIdClassificacaoProduto1
            // 
            this.txtIdClassificacaoProduto1.Location = new System.Drawing.Point(109, 72);
            this.txtIdClassificacaoProduto1.Name = "txtIdClassificacaoProduto1";
            this.txtIdClassificacaoProduto1.Size = new System.Drawing.Size(100, 20);
            this.txtIdClassificacaoProduto1.TabIndex = 6;
            // 
            // txtSiglaClassificacaoProduto1
            // 
            this.txtSiglaClassificacaoProduto1.Location = new System.Drawing.Point(109, 106);
            this.txtSiglaClassificacaoProduto1.Name = "txtSiglaClassificacaoProduto1";
            this.txtSiglaClassificacaoProduto1.Size = new System.Drawing.Size(100, 20);
            this.txtSiglaClassificacaoProduto1.TabIndex = 7;
            // 
            // txtNomeClassificacaoProduto1
            // 
            this.txtNomeClassificacaoProduto1.Location = new System.Drawing.Point(109, 139);
            this.txtNomeClassificacaoProduto1.Name = "txtNomeClassificacaoProduto1";
            this.txtNomeClassificacaoProduto1.Size = new System.Drawing.Size(100, 20);
            this.txtNomeClassificacaoProduto1.TabIndex = 8;
            // 
            // AlterarClassificacao
            // 
            this.ClientSize = new System.Drawing.Size(609, 281);
            this.Controls.Add(this.txtNomeClassificacaoProduto1);
            this.Controls.Add(this.txtSiglaClassificacaoProduto1);
            this.Controls.Add(this.txtIdClassificacaoProduto1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridViewClassificacoes1);
            this.Name = "AlterarClassificacao";
            this.Text = "Alterar Classificacao";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificacoes1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdClassificacaoProduto;
        private System.Windows.Forms.TextBox txtSiglaClassificacaoProduto;
        private System.Windows.Forms.TextBox txtNomeClassificacaoProduto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewClassificacoes;
        private System.Windows.Forms.DataGridView dataGridViewClassificacoes1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdClassificacaoProduto1;
        private System.Windows.Forms.TextBox txtSiglaClassificacaoProduto1;
        private System.Windows.Forms.TextBox txtNomeClassificacaoProduto1;
    }
}
namespace MeuProjeto
{
    partial class IncluirClassificacao
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
            this.btnIncluirClassificacao = new System.Windows.Forms.Button();
            this.txtIdClassificacaoProduto = new System.Windows.Forms.TextBox();
            this.txtSiglaClassificacaoProduto = new System.Windows.Forms.TextBox();
            this.txtNomeClassificacaoProduto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIncluirClassificacao
            // 
            this.btnIncluirClassificacao.Location = new System.Drawing.Point(265, 194);
            this.btnIncluirClassificacao.Name = "btnIncluirClassificacao";
            this.btnIncluirClassificacao.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirClassificacao.TabIndex = 0;
            this.btnIncluirClassificacao.Text = "Incluir";
            this.btnIncluirClassificacao.UseVisualStyleBackColor = true;
            this.btnIncluirClassificacao.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtIdClassificacaoProduto
            // 
            this.txtIdClassificacaoProduto.Location = new System.Drawing.Point(89, 61);
            this.txtIdClassificacaoProduto.Name = "txtIdClassificacaoProduto";
            this.txtIdClassificacaoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtIdClassificacaoProduto.TabIndex = 1;
            this.txtIdClassificacaoProduto.TextChanged += new System.EventHandler(this.txtIdClassificacaoProduto_TextChanged);
            // 
            // txtSiglaClassificacaoProduto
            // 
            this.txtSiglaClassificacaoProduto.Location = new System.Drawing.Point(89, 99);
            this.txtSiglaClassificacaoProduto.Name = "txtSiglaClassificacaoProduto";
            this.txtSiglaClassificacaoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtSiglaClassificacaoProduto.TabIndex = 2;
            // 
            // txtNomeClassificacaoProduto
            // 
            this.txtNomeClassificacaoProduto.Location = new System.Drawing.Point(89, 140);
            this.txtNomeClassificacaoProduto.Name = "txtNomeClassificacaoProduto";
            this.txtNomeClassificacaoProduto.Size = new System.Drawing.Size(100, 20);
            this.txtNomeClassificacaoProduto.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sigla:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nome:";
            // 
            // IncluirClassificacao
            // 
            this.ClientSize = new System.Drawing.Size(474, 249);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtNomeClassificacaoProduto);
            this.Controls.Add(this.txtSiglaClassificacaoProduto);
            this.Controls.Add(this.txtIdClassificacaoProduto);
            this.Controls.Add(this.btnIncluirClassificacao);
            this.Name = "IncluirClassificacao";
            this.Text = "Incluir Classificação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIncluirClassificacao;
        private System.Windows.Forms.TextBox txtIdClassificacaoProduto;
        private System.Windows.Forms.TextBox txtSiglaClassificacaoProduto;
        private System.Windows.Forms.TextBox txtNomeClassificacaoProduto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
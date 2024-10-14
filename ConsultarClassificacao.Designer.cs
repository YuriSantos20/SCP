namespace MeuProjeto
{
    partial class ConsultarClassificacao
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
            this.dataGridViewClassificacoes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btIncluir = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClassificacoes
            // 
            this.dataGridViewClassificacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassificacoes.Location = new System.Drawing.Point(12, 61);
            this.dataGridViewClassificacoes.Name = "dataGridViewClassificacoes";
            this.dataGridViewClassificacoes.Size = new System.Drawing.Size(539, 234);
            this.dataGridViewClassificacoes.TabIndex = 0;
            this.dataGridViewClassificacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassificacoes_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btIncluir
            // 
            this.btIncluir.Location = new System.Drawing.Point(12, 12);
            this.btIncluir.Name = "btIncluir";
            this.btIncluir.Size = new System.Drawing.Size(75, 23);
            this.btIncluir.TabIndex = 3;
            this.btIncluir.Text = "Incluir";
            this.btIncluir.UseVisualStyleBackColor = true;
            this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Location = new System.Drawing.Point(103, 12);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(75, 23);
            this.btAlterar.TabIndex = 4;
            this.btAlterar.Text = "Alterar";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Location = new System.Drawing.Point(199, 12);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(75, 23);
            this.btExcluir.TabIndex = 5;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // ConsultarClassificacao
            // 
            this.ClientSize = new System.Drawing.Size(563, 336);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btAlterar);
            this.Controls.Add(this.btIncluir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewClassificacoes);
            this.Name = "ConsultarClassificacao";
            this.Text = "Consultar Classificação";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificacoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClassificacoes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btIncluir;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btExcluir;
    }
}
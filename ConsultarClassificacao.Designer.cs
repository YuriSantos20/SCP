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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassificacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClassificacoes
            // 
            this.dataGridViewClassificacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassificacoes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewClassificacoes.Name = "dataGridViewClassificacoes";
            this.dataGridViewClassificacoes.Size = new System.Drawing.Size(539, 247);
            this.dataGridViewClassificacoes.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConsultarClassificacao
            // 
            this.ClientSize = new System.Drawing.Size(563, 309);
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
    }
}
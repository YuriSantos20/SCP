namespace SistemaComercio1
{
    partial class ContaReceber
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
            this.dataGridViewContasReceber = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContasReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewContasReceber
            // 
            this.dataGridViewContasReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContasReceber.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewContasReceber.Name = "dataGridViewContasReceber";
            this.dataGridViewContasReceber.Size = new System.Drawing.Size(696, 217);
            this.dataGridViewContasReceber.TabIndex = 0;
            this.dataGridViewContasReceber.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ContaReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewContasReceber);
            this.Name = "ContaReceber";
            this.Text = "ContaReceber";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContasReceber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContasReceber;
        private System.Windows.Forms.Button button1;
    }
}
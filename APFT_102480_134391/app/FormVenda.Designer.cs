namespace Barbearia
{
    partial class FormVenda
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
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProdutos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numQtd = new System.Windows.Forms.NumericUpDown();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.dgvVenda = new System.Windows.Forms.DataGridView();
            this.lblTotalGeral = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(327, 48);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(121, 24);
            this.cbClientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // cbProdutos
            // 
            this.cbProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProdutos.FormattingEnabled = true;
            this.cbProdutos.Location = new System.Drawing.Point(327, 93);
            this.cbProdutos.Name = "cbProdutos";
            this.cbProdutos.Size = new System.Drawing.Size(121, 24);
            this.cbProdutos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Produto/Qtd";
            // 
            // numQtd
            // 
            this.numQtd.Location = new System.Drawing.Point(480, 93);
            this.numQtd.Name = "numQtd";
            this.numQtd.Size = new System.Drawing.Size(120, 22);
            this.numQtd.TabIndex = 4;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(214, 184);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(327, 184);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(93, 23);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Location = new System.Drawing.Point(452, 184);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(136, 23);
            this.btnFinalizarVenda.TabIndex = 7;
            this.btnFinalizarVenda.Text = "Finalizar venda";
            this.btnFinalizarVenda.UseVisualStyleBackColor = true;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // dgvVenda
            // 
            this.dgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenda.Location = new System.Drawing.Point(63, 265);
            this.dgvVenda.Name = "dgvVenda";
            this.dgvVenda.ReadOnly = true;
            this.dgvVenda.RowHeadersWidth = 51;
            this.dgvVenda.RowTemplate.Height = 24;
            this.dgvVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVenda.Size = new System.Drawing.Size(678, 102);
            this.dgvVenda.TabIndex = 8;
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.AutoSize = true;
            this.lblTotalGeral.Location = new System.Drawing.Point(368, 402);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(68, 16);
            this.lblTotalGeral.TabIndex = 9;
            this.lblTotalGeral.Text = "Total: 0.00";
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.dgvVenda);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.numQtd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbProdutos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClientes);
            this.Name = "FormVenda";
            this.Text = "FormVenda";
            this.Load += new System.EventHandler(this.FormVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQtd;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.DataGridView dgvVenda;
        private System.Windows.Forms.Label lblTotalGeral;
    }
}
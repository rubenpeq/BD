namespace Barbearia
{
    partial class FormStock
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
            this.dgvStockConsumo = new System.Windows.Forms.DataGridView();
            this.dgvStockVenda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFornecedores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbProdutos = new System.Windows.Forms.ComboBox();
            this.cbTipoStock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGravarFornecimento = new System.Windows.Forms.Button();
            this.txtPrecoUnidade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockConsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStockConsumo
            // 
            this.dgvStockConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockConsumo.Location = new System.Drawing.Point(0, 231);
            this.dgvStockConsumo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStockConsumo.Name = "dgvStockConsumo";
            this.dgvStockConsumo.ReadOnly = true;
            this.dgvStockConsumo.RowHeadersWidth = 51;
            this.dgvStockConsumo.RowTemplate.Height = 24;
            this.dgvStockConsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockConsumo.Size = new System.Drawing.Size(296, 136);
            this.dgvStockConsumo.TabIndex = 0;
            // 
            // dgvStockVenda
            // 
            this.dgvStockVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockVenda.Location = new System.Drawing.Point(301, 231);
            this.dgvStockVenda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStockVenda.Name = "dgvStockVenda";
            this.dgvStockVenda.ReadOnly = true;
            this.dgvStockVenda.RowHeadersWidth = 51;
            this.dgvStockVenda.RowTemplate.Height = 24;
            this.dgvStockVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockVenda.Size = new System.Drawing.Size(299, 136);
            this.dgvStockVenda.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estoque para consumo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estoque para vendas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Atualizar Estoques";
            // 
            // cbFornecedores
            // 
            this.cbFornecedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFornecedores.FormattingEnabled = true;
            this.cbFornecedores.Location = new System.Drawing.Point(162, 37);
            this.cbFornecedores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFornecedores.Name = "cbFornecedores";
            this.cbFornecedores.Size = new System.Drawing.Size(92, 21);
            this.cbFornecedores.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fornecedor";
            // 
            // cbProdutos
            // 
            this.cbProdutos.FormattingEnabled = true;
            this.cbProdutos.Location = new System.Drawing.Point(162, 89);
            this.cbProdutos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbProdutos.Name = "cbProdutos";
            this.cbProdutos.Size = new System.Drawing.Size(92, 21);
            this.cbProdutos.TabIndex = 7;
            // 
            // cbTipoStock
            // 
            this.cbTipoStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoStock.FormattingEnabled = true;
            this.cbTipoStock.Items.AddRange(new object[] {
            "Consumo",
            "Venda"});
            this.cbTipoStock.Location = new System.Drawing.Point(162, 141);
            this.cbTipoStock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTipoStock.Name = "cbTipoStock";
            this.cbTipoStock.Size = new System.Drawing.Size(92, 21);
            this.cbTipoStock.TabIndex = 8;
            this.cbTipoStock.SelectedIndexChanged += new System.EventHandler(this.cbTipoStock_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tipo";
            // 
            // numQuantidade
            // 
            this.numQuantidade.Location = new System.Drawing.Point(477, 37);
            this.numQuantidade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(90, 20);
            this.numQuantidade.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unidade(s)";
            // 
            // btnGravarFornecimento
            // 
            this.btnGravarFornecimento.Location = new System.Drawing.Point(259, 189);
            this.btnGravarFornecimento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGravarFornecimento.Name = "btnGravarFornecimento";
            this.btnGravarFornecimento.Size = new System.Drawing.Size(56, 19);
            this.btnGravarFornecimento.TabIndex = 13;
            this.btnGravarFornecimento.Text = "Gravar";
            this.btnGravarFornecimento.UseVisualStyleBackColor = true;
            this.btnGravarFornecimento.Click += new System.EventHandler(this.btnGravarFornecimento_Click);
            // 
            // txtPrecoUnidade
            // 
            this.txtPrecoUnidade.Location = new System.Drawing.Point(477, 87);
            this.txtPrecoUnidade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecoUnidade.Name = "txtPrecoUnidade";
            this.txtPrecoUnidade.Size = new System.Drawing.Size(91, 20);
            this.txtPrecoUnidade.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Preço de compra por unidade (€)";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Location = new System.Drawing.Point(477, 139);
            this.txtPrecoVenda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(91, 20);
            this.txtPrecoVenda.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 141);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Preço de venda por unidade (€)";
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrecoUnidade);
            this.Controls.Add(this.btnGravarFornecimento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoStock);
            this.Controls.Add(this.cbProdutos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFornecedores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStockVenda);
            this.Controls.Add(this.dgvStockConsumo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormStock";
            this.Text = "FormStock";
            this.Load += new System.EventHandler(this.FormStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockConsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStockConsumo;
        private System.Windows.Forms.DataGridView dgvStockVenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFornecedores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProdutos;
        private System.Windows.Forms.ComboBox cbTipoStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGravarFornecimento;
        private System.Windows.Forms.TextBox txtPrecoUnidade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label label9;
    }
}
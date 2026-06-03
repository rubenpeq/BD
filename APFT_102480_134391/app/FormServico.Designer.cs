namespace Barbearia
{
    partial class FormServico
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
            this.listBoxServicos = new System.Windows.Forms.ListBox();
            this.txtNomeServico = new System.Windows.Forms.TextBox();
            this.txtPrecoBase = new System.Windows.Forms.TextBox();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdicionarServico = new System.Windows.Forms.Button();
            this.btnGravarServico = new System.Windows.Forms.Button();
            this.btnEliminarServico = new System.Windows.Forms.Button();
            this.cbProdutosConsumo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantidadeConsumidas = new System.Windows.Forms.NumericUpDown();
            this.dgvConsumosTemporarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeConsumidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumosTemporarios)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxServicos
            // 
            this.listBoxServicos.FormattingEnabled = true;
            this.listBoxServicos.Location = new System.Drawing.Point(-1, 2);
            this.listBoxServicos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxServicos.Name = "listBoxServicos";
            this.listBoxServicos.Size = new System.Drawing.Size(204, 368);
            this.listBoxServicos.TabIndex = 0;
            this.listBoxServicos.SelectedIndexChanged += new System.EventHandler(this.listBoxServicos_SelectedIndexChanged_1);
            // 
            // txtNomeServico
            // 
            this.txtNomeServico.Location = new System.Drawing.Point(394, 35);
            this.txtNomeServico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNomeServico.Name = "txtNomeServico";
            this.txtNomeServico.Size = new System.Drawing.Size(168, 20);
            this.txtNomeServico.TabIndex = 1;
            // 
            // txtPrecoBase
            // 
            this.txtPrecoBase.Location = new System.Drawing.Point(394, 77);
            this.txtPrecoBase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecoBase.Name = "txtPrecoBase";
            this.txtPrecoBase.Size = new System.Drawing.Size(168, 20);
            this.txtPrecoBase.TabIndex = 2;
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(394, 126);
            this.txtUnidades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(168, 20);
            this.txtUnidades.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Serviço";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preço (€)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "tempo (min)";
            // 
            // btnAdicionarServico
            // 
            this.btnAdicionarServico.Location = new System.Drawing.Point(250, 209);
            this.btnAdicionarServico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdicionarServico.Name = "btnAdicionarServico";
            this.btnAdicionarServico.Size = new System.Drawing.Size(111, 28);
            this.btnAdicionarServico.TabIndex = 8;
            this.btnAdicionarServico.Text = "Adicionar Produto";
            this.btnAdicionarServico.UseVisualStyleBackColor = true;
            this.btnAdicionarServico.Click += new System.EventHandler(this.btnAdicionarServico_Click);
            // 
            // btnGravarServico
            // 
            this.btnGravarServico.Location = new System.Drawing.Point(484, 209);
            this.btnGravarServico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGravarServico.Name = "btnGravarServico";
            this.btnGravarServico.Size = new System.Drawing.Size(56, 28);
            this.btnGravarServico.TabIndex = 9;
            this.btnGravarServico.Text = "Gravar";
            this.btnGravarServico.UseVisualStyleBackColor = true;
            this.btnGravarServico.Click += new System.EventHandler(this.btnGravarServico_Click);
            // 
            // btnEliminarServico
            // 
            this.btnEliminarServico.Location = new System.Drawing.Point(394, 209);
            this.btnEliminarServico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarServico.Name = "btnEliminarServico";
            this.btnEliminarServico.Size = new System.Drawing.Size(56, 28);
            this.btnEliminarServico.TabIndex = 10;
            this.btnEliminarServico.Text = "Excluir";
            this.btnEliminarServico.UseVisualStyleBackColor = true;
            this.btnEliminarServico.Click += new System.EventHandler(this.btnEliminarServico_Click);
            // 
            // cbProdutosConsumo
            // 
            this.cbProdutosConsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProdutosConsumo.FormattingEnabled = true;
            this.cbProdutosConsumo.Location = new System.Drawing.Point(394, 171);
            this.cbProdutosConsumo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbProdutosConsumo.Name = "cbProdutosConsumo";
            this.cbProdutosConsumo.Size = new System.Drawing.Size(92, 21);
            this.cbProdutosConsumo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Produto consumido (Tipo/unidades)";
            // 
            // txtQuantidadeConsumidas
            // 
            this.txtQuantidadeConsumidas.Location = new System.Drawing.Point(494, 172);
            this.txtQuantidadeConsumidas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuantidadeConsumidas.Name = "txtQuantidadeConsumidas";
            this.txtQuantidadeConsumidas.Size = new System.Drawing.Size(90, 20);
            this.txtQuantidadeConsumidas.TabIndex = 13;
            // 
            // dgvConsumosTemporarios
            // 
            this.dgvConsumosTemporarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumosTemporarios.Location = new System.Drawing.Point(237, 242);
            this.dgvConsumosTemporarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvConsumosTemporarios.Name = "dgvConsumosTemporarios";
            this.dgvConsumosTemporarios.ReadOnly = true;
            this.dgvConsumosTemporarios.RowHeadersWidth = 51;
            this.dgvConsumosTemporarios.RowTemplate.Height = 24;
            this.dgvConsumosTemporarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumosTemporarios.Size = new System.Drawing.Size(338, 114);
            this.dgvConsumosTemporarios.TabIndex = 14;
            // 
            // FormServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dgvConsumosTemporarios);
            this.Controls.Add(this.txtQuantidadeConsumidas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbProdutosConsumo);
            this.Controls.Add(this.btnEliminarServico);
            this.Controls.Add(this.btnGravarServico);
            this.Controls.Add(this.btnAdicionarServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.txtPrecoBase);
            this.Controls.Add(this.txtNomeServico);
            this.Controls.Add(this.listBoxServicos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormServico";
            this.Text = "FormServico";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidadeConsumidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumosTemporarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxServicos;
        private System.Windows.Forms.TextBox txtNomeServico;
        private System.Windows.Forms.TextBox txtPrecoBase;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdicionarServico;
        private System.Windows.Forms.Button btnGravarServico;
        private System.Windows.Forms.Button btnEliminarServico;
        private System.Windows.Forms.ComboBox cbProdutosConsumo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtQuantidadeConsumidas;
        private System.Windows.Forms.DataGridView dgvConsumosTemporarios;
    }
}
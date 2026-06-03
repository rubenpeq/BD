namespace Barbearia
{
    partial class FormMovimentacao
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
            this.dgvMovimentacoes = new System.Windows.Forms.DataGridView();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboSubtipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFiltrar2 = new System.Windows.Forms.Button();
            this.lblSaldoExibicao = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovimentacoes
            // 
            this.dgvMovimentacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimentacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentacoes.Location = new System.Drawing.Point(0, 150);
            this.dgvMovimentacoes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvMovimentacoes.Name = "dgvMovimentacoes";
            this.dgvMovimentacoes.ReadOnly = true;
            this.dgvMovimentacoes.RowHeadersWidth = 51;
            this.dgvMovimentacoes.RowTemplate.Height = 24;
            this.dgvMovimentacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimentacoes.Size = new System.Drawing.Size(602, 215);
            this.dgvMovimentacoes.TabIndex = 0;
            this.dgvMovimentacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimentacoes_CellContentClick);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(467, 45);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(83, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(467, 86);
            this.dtpFim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(83, 20);
            this.dtpFim.TabIndex = 2;
            // 
            // btnFiltrar1
            // 
            this.btnFiltrar1.Location = new System.Drawing.Point(467, 123);
            this.btnFiltrar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar1.Name = "btnFiltrar1";
            this.btnFiltrar1.Size = new System.Drawing.Size(56, 19);
            this.btnFiltrar1.TabIndex = 3;
            this.btnFiltrar1.Text = "Filtrar";
            this.btnFiltrar1.UseVisualStyleBackColor = true;
            this.btnFiltrar1.Click += new System.EventHandler(this.btnFiltrar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filtrar por data";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Receita",
            "Despesa"});
            this.cboTipo.Location = new System.Drawing.Point(95, 45);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(104, 21);
            this.cboTipo.TabIndex = 7;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // cboSubtipo
            // 
            this.cboSubtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubtipo.FormattingEnabled = true;
            this.cboSubtipo.Location = new System.Drawing.Point(95, 88);
            this.cboSubtipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboSubtipo.Name = "cboSubtipo";
            this.cboSubtipo.Size = new System.Drawing.Size(104, 21);
            this.cboSubtipo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nome";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Filtrar por categoria";
            // 
            // btnFiltrar2
            // 
            this.btnFiltrar2.Location = new System.Drawing.Point(84, 124);
            this.btnFiltrar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFiltrar2.Name = "btnFiltrar2";
            this.btnFiltrar2.Size = new System.Drawing.Size(56, 19);
            this.btnFiltrar2.TabIndex = 12;
            this.btnFiltrar2.Text = "Filtrar";
            this.btnFiltrar2.UseVisualStyleBackColor = true;
            this.btnFiltrar2.Click += new System.EventHandler(this.btnFiltrar2_Click);
            // 
            // lblSaldoExibicao
            // 
            this.lblSaldoExibicao.AutoSize = true;
            this.lblSaldoExibicao.Location = new System.Drawing.Point(224, 67);
            this.lblSaldoExibicao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldoExibicao.Name = "lblSaldoExibicao";
            this.lblSaldoExibicao.Size = new System.Drawing.Size(49, 13);
            this.lblSaldoExibicao.TabIndex = 13;
            this.lblSaldoExibicao.Text = "Saldo (€)";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(284, 65);
            this.txtSaldo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(76, 20);
            this.txtSaldo.TabIndex = 14;
            // 
            // FormMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.lblSaldoExibicao);
            this.Controls.Add(this.btnFiltrar2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboSubtipo);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFiltrar1);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.dgvMovimentacoes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMovimentacao";
            this.Text = "FormMovimentacao";
            this.Load += new System.EventHandler(this.FormMovimentacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimentacoes;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Button btnFiltrar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboSubtipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFiltrar2;
        private System.Windows.Forms.Label lblSaldoExibicao;
        private System.Windows.Forms.TextBox txtSaldo;
    }
}
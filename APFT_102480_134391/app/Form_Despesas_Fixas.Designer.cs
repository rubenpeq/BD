namespace BarbeariaSistema
{
    partial class Form_Despesas_Fixas
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
            this.txtNomeDespesa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numValorDespesa = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.dgvDespesas = new System.Windows.Forms.DataGridView();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numValorDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespesas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeDespesa
            // 
            this.txtNomeDespesa.Location = new System.Drawing.Point(389, 24);
            this.txtNomeDespesa.Name = "txtNomeDespesa";
            this.txtNomeDespesa.Size = new System.Drawing.Size(120, 22);
            this.txtNomeDespesa.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome da despesa";
            // 
            // numValorDespesa
            // 
            this.numValorDespesa.DecimalPlaces = 2;
            this.numValorDespesa.Location = new System.Drawing.Point(389, 95);
            this.numValorDespesa.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numValorDespesa.Name = "numValorDespesa";
            this.numValorDespesa.Size = new System.Drawing.Size(120, 22);
            this.numValorDespesa.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor (€)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data de pagamento";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(492, 223);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 33);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(354, 223);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 33);
            this.btnLimpar.TabIndex = 7;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(228, 223);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 33);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // dgvDespesas
            // 
            this.dgvDespesas.AllowUserToAddRows = false;
            this.dgvDespesas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDespesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDespesas.Location = new System.Drawing.Point(-1, 275);
            this.dgvDespesas.Name = "dgvDespesas";
            this.dgvDespesas.ReadOnly = true;
            this.dgvDespesas.RowHeadersWidth = 51;
            this.dgvDespesas.RowTemplate.Height = 24;
            this.dgvDespesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDespesas.Size = new System.Drawing.Size(801, 175);
            this.dgvDespesas.TabIndex = 9;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(389, 157);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(200, 22);
            this.dtpData.TabIndex = 10;
            // 
            // Form_Despesas_Fixas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.dgvDespesas);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numValorDespesa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeDespesa);
            this.Name = "Form_Despesas_Fixas";
            this.Text = "Form_Despesas_Fixas";
            this.Load += new System.EventHandler(this.Form_Despesas_Fixas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numValorDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeDespesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numValorDespesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridView dgvDespesas;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}
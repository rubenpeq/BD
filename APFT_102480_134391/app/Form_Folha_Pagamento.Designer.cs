namespace BarbeariaSistema
{
    partial class Form_Folha_Pagamento
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
            this.cmbBarbeiro = new System.Windows.Forms.ComboBox();
            this.dtpMesAno = new System.Windows.Forms.DateTimePicker();
            this.numSalario = new System.Windows.Forms.NumericUpDown();
            this.btnGravar = new System.Windows.Forms.Button();
            this.dgvFolha = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSalario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolha)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBarbeiro
            // 
            this.cmbBarbeiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarbeiro.FormattingEnabled = true;
            this.cmbBarbeiro.Location = new System.Drawing.Point(429, 26);
            this.cmbBarbeiro.Name = "cmbBarbeiro";
            this.cmbBarbeiro.Size = new System.Drawing.Size(121, 24);
            this.cmbBarbeiro.TabIndex = 0;
            // 
            // dtpMesAno
            // 
            this.dtpMesAno.CustomFormat = "MM/yyyy";
            this.dtpMesAno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMesAno.Location = new System.Drawing.Point(429, 84);
            this.dtpMesAno.Name = "dtpMesAno";
            this.dtpMesAno.Size = new System.Drawing.Size(121, 22);
            this.dtpMesAno.TabIndex = 1;
            // 
            // numSalario
            // 
            this.numSalario.DecimalPlaces = 2;
            this.numSalario.Location = new System.Drawing.Point(429, 143);
            this.numSalario.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSalario.Name = "numSalario";
            this.numSalario.Size = new System.Drawing.Size(120, 22);
            this.numSalario.TabIndex = 2;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(369, 201);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 3;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // dgvFolha
            // 
            this.dgvFolha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFolha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolha.Location = new System.Drawing.Point(0, 260);
            this.dgvFolha.Name = "dgvFolha";
            this.dgvFolha.ReadOnly = true;
            this.dgvFolha.RowHeadersWidth = 51;
            this.dgvFolha.RowTemplate.Height = 24;
            this.dgvFolha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolha.Size = new System.Drawing.Size(800, 189);
            this.dgvFolha.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Barbeiro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mês/Ano";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vencimento";
            // 
            // Form_Folha_Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFolha);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.numSalario);
            this.Controls.Add(this.dtpMesAno);
            this.Controls.Add(this.cmbBarbeiro);
            this.Name = "Form_Folha_Pagamento";
            this.Text = "Form_Folha_Pagamento";
            this.Load += new System.EventHandler(this.Form_Folha_Pagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSalario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBarbeiro;
        private System.Windows.Forms.DateTimePicker dtpMesAno;
        private System.Windows.Forms.NumericUpDown numSalario;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.DataGridView dgvFolha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
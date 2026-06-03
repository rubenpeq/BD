namespace Barbearia
{
    partial class FormAgendamento
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
            this.comboBoxClientes = new System.Windows.Forms.ComboBox();
            this.dtpDia = new System.Windows.Forms.DateTimePicker();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxServicos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxBarbeiros = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecoPraticado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdicionarLinha = new System.Windows.Forms.Button();
            this.dgvServicosAgendados = new System.Windows.Forms.DataGridView();
            this.btnGravarAgendamento = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicosAgendados)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxClientes
            // 
            this.comboBoxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClientes.FormattingEnabled = true;
            this.comboBoxClientes.Location = new System.Drawing.Point(225, 44);
            this.comboBoxClientes.Name = "comboBoxClientes";
            this.comboBoxClientes.Size = new System.Drawing.Size(121, 24);
            this.comboBoxClientes.TabIndex = 0;
            // 
            // dtpDia
            // 
            this.dtpDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDia.Location = new System.Drawing.Point(169, 126);
            this.dtpDia.Name = "dtpDia";
            this.dtpDia.Size = new System.Drawing.Size(115, 22);
            this.dtpDia.TabIndex = 1;
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(318, 126);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(88, 22);
            this.dtpHora.TabIndex = 2;
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Pendente",
            "Concluído",
            "Cancelado"});
            this.comboBoxEstado.Location = new System.Drawing.Point(225, 198);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEstado.TabIndex = 3;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(225, 264);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(121, 22);
            this.txtObservacoes.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Estado do agendamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Observações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data/Hora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cliente";
            // 
            // comboBoxServicos
            // 
            this.comboBoxServicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServicos.FormattingEnabled = true;
            this.comboBoxServicos.Location = new System.Drawing.Point(658, 44);
            this.comboBoxServicos.Name = "comboBoxServicos";
            this.comboBoxServicos.Size = new System.Drawing.Size(121, 24);
            this.comboBoxServicos.TabIndex = 9;
            this.comboBoxServicos.SelectedIndexChanged += new System.EventHandler(this.comboBoxServicos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Serviço";
            // 
            // comboBoxBarbeiros
            // 
            this.comboBoxBarbeiros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBarbeiros.FormattingEnabled = true;
            this.comboBoxBarbeiros.Location = new System.Drawing.Point(658, 126);
            this.comboBoxBarbeiros.Name = "comboBoxBarbeiros";
            this.comboBoxBarbeiros.Size = new System.Drawing.Size(121, 24);
            this.comboBoxBarbeiros.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Barbeiro";
            // 
            // txtPrecoPraticado
            // 
            this.txtPrecoPraticado.Location = new System.Drawing.Point(658, 203);
            this.txtPrecoPraticado.Name = "txtPrecoPraticado";
            this.txtPrecoPraticado.Size = new System.Drawing.Size(121, 22);
            this.txtPrecoPraticado.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(528, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Preço praticado";
            // 
            // btnAdicionarLinha
            // 
            this.btnAdicionarLinha.Location = new System.Drawing.Point(491, 263);
            this.btnAdicionarLinha.Name = "btnAdicionarLinha";
            this.btnAdicionarLinha.Size = new System.Drawing.Size(281, 31);
            this.btnAdicionarLinha.TabIndex = 15;
            this.btnAdicionarLinha.Text = "Adicionar Serviço ao Agendamento";
            this.btnAdicionarLinha.UseVisualStyleBackColor = true;
            this.btnAdicionarLinha.Click += new System.EventHandler(this.btnAdicionarLinha_Click);
            // 
            // dgvServicosAgendados
            // 
            this.dgvServicosAgendados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicosAgendados.Location = new System.Drawing.Point(307, 319);
            this.dgvServicosAgendados.Name = "dgvServicosAgendados";
            this.dgvServicosAgendados.RowHeadersWidth = 51;
            this.dgvServicosAgendados.RowTemplate.Height = 24;
            this.dgvServicosAgendados.Size = new System.Drawing.Size(540, 184);
            this.dgvServicosAgendados.TabIndex = 16;
            // 
            // btnGravarAgendamento
            // 
            this.btnGravarAgendamento.Location = new System.Drawing.Point(59, 337);
            this.btnGravarAgendamento.Name = "btnGravarAgendamento";
            this.btnGravarAgendamento.Size = new System.Drawing.Size(182, 63);
            this.btnGravarAgendamento.TabIndex = 17;
            this.btnGravarAgendamento.Text = "Gravar Agendamento";
            this.btnGravarAgendamento.UseVisualStyleBackColor = true;
            this.btnGravarAgendamento.Click += new System.EventHandler(this.btnGravarAgendamento_Click);
            // 
            // FormAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 524);
            this.Controls.Add(this.btnGravarAgendamento);
            this.Controls.Add(this.dgvServicosAgendados);
            this.Controls.Add(this.btnAdicionarLinha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrecoPraticado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxBarbeiros);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxServicos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.dtpDia);
            this.Controls.Add(this.comboBoxClientes);
            this.Name = "FormAgendamento";
            this.Text = "FormAgendamento";
            this.Load += new System.EventHandler(this.FormAgendamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicosAgendados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.DateTimePicker dtpDia;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxServicos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxBarbeiros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecoPraticado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdicionarLinha;
        private System.Windows.Forms.DataGridView dgvServicosAgendados;
        private System.Windows.Forms.Button btnGravarAgendamento;
    }
}
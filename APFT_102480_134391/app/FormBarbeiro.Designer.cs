namespace Barbearia
{
    partial class FormBarbeiro
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeBarbeiro = new System.Windows.Forms.TextBox();
            this.txtApelidoBarbeiro = new System.Windows.Forms.TextBox();
            this.txtNIFBarbeiro = new System.Windows.Forms.TextBox();
            this.txtTelefoneBarbeiro = new System.Windows.Forms.TextBox();
            this.txtEspecialidadeBarbeiro = new System.Windows.Forms.TextBox();
            this.btnAdicionarBarbeiro = new System.Windows.Forms.Button();
            this.btnGravarBarbeiro = new System.Windows.Forms.Button();
            this.btnEliminarBarbeiro = new System.Windows.Forms.Button();
            this.clbDiasSemana = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFim = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvBarbeiros = new System.Windows.Forms.DataGridView();
            this.dgvEscala = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarbeiros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscala)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apelido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "NIF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Especialidade";
            // 
            // txtNomeBarbeiro
            // 
            this.txtNomeBarbeiro.Location = new System.Drawing.Point(104, 10);
            this.txtNomeBarbeiro.Name = "txtNomeBarbeiro";
            this.txtNomeBarbeiro.Size = new System.Drawing.Size(181, 22);
            this.txtNomeBarbeiro.TabIndex = 7;
            // 
            // txtApelidoBarbeiro
            // 
            this.txtApelidoBarbeiro.Location = new System.Drawing.Point(104, 54);
            this.txtApelidoBarbeiro.Name = "txtApelidoBarbeiro";
            this.txtApelidoBarbeiro.Size = new System.Drawing.Size(181, 22);
            this.txtApelidoBarbeiro.TabIndex = 8;
            // 
            // txtNIFBarbeiro
            // 
            this.txtNIFBarbeiro.Location = new System.Drawing.Point(104, 102);
            this.txtNIFBarbeiro.Name = "txtNIFBarbeiro";
            this.txtNIFBarbeiro.Size = new System.Drawing.Size(181, 22);
            this.txtNIFBarbeiro.TabIndex = 9;
            // 
            // txtTelefoneBarbeiro
            // 
            this.txtTelefoneBarbeiro.Location = new System.Drawing.Point(537, 10);
            this.txtTelefoneBarbeiro.Name = "txtTelefoneBarbeiro";
            this.txtTelefoneBarbeiro.Size = new System.Drawing.Size(181, 22);
            this.txtTelefoneBarbeiro.TabIndex = 10;
            // 
            // txtEspecialidadeBarbeiro
            // 
            this.txtEspecialidadeBarbeiro.Location = new System.Drawing.Point(537, 56);
            this.txtEspecialidadeBarbeiro.Name = "txtEspecialidadeBarbeiro";
            this.txtEspecialidadeBarbeiro.Size = new System.Drawing.Size(181, 22);
            this.txtEspecialidadeBarbeiro.TabIndex = 11;
            // 
            // btnAdicionarBarbeiro
            // 
            this.btnAdicionarBarbeiro.Location = new System.Drawing.Point(36, 159);
            this.btnAdicionarBarbeiro.Name = "btnAdicionarBarbeiro";
            this.btnAdicionarBarbeiro.Size = new System.Drawing.Size(90, 45);
            this.btnAdicionarBarbeiro.TabIndex = 13;
            this.btnAdicionarBarbeiro.Text = "Limpar";
            this.btnAdicionarBarbeiro.UseVisualStyleBackColor = true;
            this.btnAdicionarBarbeiro.Click += new System.EventHandler(this.btnAdicionarBarbeiro_Click);
            // 
            // btnGravarBarbeiro
            // 
            this.btnGravarBarbeiro.Location = new System.Drawing.Point(330, 159);
            this.btnGravarBarbeiro.Name = "btnGravarBarbeiro";
            this.btnGravarBarbeiro.Size = new System.Drawing.Size(75, 45);
            this.btnGravarBarbeiro.TabIndex = 14;
            this.btnGravarBarbeiro.Text = "Gravar";
            this.btnGravarBarbeiro.UseVisualStyleBackColor = true;
            this.btnGravarBarbeiro.Click += new System.EventHandler(this.btnGravarBarbeiro_Click);
            // 
            // btnEliminarBarbeiro
            // 
            this.btnEliminarBarbeiro.Location = new System.Drawing.Point(191, 159);
            this.btnEliminarBarbeiro.Name = "btnEliminarBarbeiro";
            this.btnEliminarBarbeiro.Size = new System.Drawing.Size(75, 45);
            this.btnEliminarBarbeiro.TabIndex = 15;
            this.btnEliminarBarbeiro.Text = "Excluir";
            this.btnEliminarBarbeiro.UseVisualStyleBackColor = true;
            this.btnEliminarBarbeiro.Click += new System.EventHandler(this.btnEliminarBarbeiro_Click);
            // 
            // clbDiasSemana
            // 
            this.clbDiasSemana.FormattingEnabled = true;
            this.clbDiasSemana.Items.AddRange(new object[] {
            "Segunda-feira",
            "Terça-feira",
            "Quarta-feira",
            "Quinta-feira",
            "Sexta-feira",
            "Sábado",
            "Domingo"});
            this.clbDiasSemana.Location = new System.Drawing.Point(568, 102);
            this.clbDiasSemana.Name = "clbDiasSemana";
            this.clbDiasSemana.Size = new System.Drawing.Size(181, 89);
            this.clbDiasSemana.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Escala";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(458, 111);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(104, 22);
            this.dtpHoraInicio.TabIndex = 18;
            // 
            // dtpHoraFim
            // 
            this.dtpHoraFim.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFim.Location = new System.Drawing.Point(458, 159);
            this.dtpHoraFim.Name = "dtpHoraFim";
            this.dtpHoraFim.ShowUpDown = true;
            this.dtpHoraFim.Size = new System.Drawing.Size(104, 22);
            this.dtpHoraFim.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Início";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Fim";
            // 
            // dgvBarbeiros
            // 
            this.dgvBarbeiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarbeiros.Location = new System.Drawing.Point(0, 250);
            this.dgvBarbeiros.Name = "dgvBarbeiros";
            this.dgvBarbeiros.ReadOnly = true;
            this.dgvBarbeiros.RowHeadersWidth = 51;
            this.dgvBarbeiros.RowTemplate.Height = 24;
            this.dgvBarbeiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarbeiros.Size = new System.Drawing.Size(384, 200);
            this.dgvBarbeiros.TabIndex = 22;
            this.dgvBarbeiros.SelectionChanged += new System.EventHandler(this.dgvBarbeiros_SelectionChanged);
            // 
            // dgvEscala
            // 
            this.dgvEscala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEscala.Location = new System.Drawing.Point(390, 250);
            this.dgvEscala.Name = "dgvEscala";
            this.dgvEscala.ReadOnly = true;
            this.dgvEscala.RowHeadersWidth = 51;
            this.dgvEscala.RowTemplate.Height = 24;
            this.dgvEscala.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEscala.Size = new System.Drawing.Size(410, 200);
            this.dgvEscala.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Barbeiro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(565, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Escala";
            // 
            // FormBarbeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvEscala);
            this.Controls.Add(this.dgvBarbeiros);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpHoraFim);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clbDiasSemana);
            this.Controls.Add(this.btnEliminarBarbeiro);
            this.Controls.Add(this.btnGravarBarbeiro);
            this.Controls.Add(this.btnAdicionarBarbeiro);
            this.Controls.Add(this.txtEspecialidadeBarbeiro);
            this.Controls.Add(this.txtTelefoneBarbeiro);
            this.Controls.Add(this.txtNIFBarbeiro);
            this.Controls.Add(this.txtApelidoBarbeiro);
            this.Controls.Add(this.txtNomeBarbeiro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBarbeiro";
            this.Text = " ";
            this.Load += new System.EventHandler(this.btnAdicionarBarbeiro_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarbeiros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeBarbeiro;
        private System.Windows.Forms.TextBox txtApelidoBarbeiro;
        private System.Windows.Forms.TextBox txtNIFBarbeiro;
        private System.Windows.Forms.TextBox txtTelefoneBarbeiro;
        private System.Windows.Forms.TextBox txtEspecialidadeBarbeiro;
        private System.Windows.Forms.Button btnAdicionarBarbeiro;
        private System.Windows.Forms.Button btnGravarBarbeiro;
        private System.Windows.Forms.Button btnEliminarBarbeiro;
        private System.Windows.Forms.CheckedListBox clbDiasSemana;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvBarbeiros;
        private System.Windows.Forms.DataGridView dgvEscala;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}
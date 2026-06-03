namespace Barbearia
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(-1, -2);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(204, 368);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(297, 37);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Nome";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(297, 75);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Apelido";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(297, 110);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(24, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "NIF";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(297, 153);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Telefone";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(388, 32);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(151, 20);
            this.txtNome.TabIndex = 6;
            // 
            // txtApelido
            // 
            this.txtApelido.Location = new System.Drawing.Point(388, 70);
            this.txtApelido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(150, 20);
            this.txtApelido.TabIndex = 7;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(388, 106);
            this.txtNIF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(151, 20);
            this.txtNIF.TabIndex = 8;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(388, 148);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(151, 20);
            this.txtTelefone.TabIndex = 9;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(297, 195);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(72, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "DataCadastro";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(275, 265);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(62, 27);
            this.btnAdicionar.TabIndex = 13;
            this.btnAdicionar.Text = "Limpar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(472, 265);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(56, 27);
            this.btnGravar.TabIndex = 14;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // dtpDataCadastro
            // 
            this.dtpDataCadastro.Location = new System.Drawing.Point(388, 195);
            this.dtpDataCadastro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(151, 20);
            this.dtpDataCadastro.TabIndex = 15;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Location = new System.Drawing.Point(376, 265);
            this.btnEliminarCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(56, 27);
            this.btnEliminarCliente.TabIndex = 16;
            this.btnEliminarCliente.Text = "Excluir";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnEliminarCliente);
            this.Controls.Add(this.dtpDataCadastro);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNIF);
            this.Controls.Add(this.txtApelido);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtApelido;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        private System.Windows.Forms.Button btnEliminarCliente;
    }
}


namespace Barbearia
{
    partial class FormFornecedor
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
            this.txtNomeFornecedor = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvFornecedores = new System.Windows.Forms.DataGridView();
            this.btnGravarFornecedor = new System.Windows.Forms.Button();
            this.btnEliminarFornecedor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeFornecedor
            // 
            this.txtNomeFornecedor.Location = new System.Drawing.Point(438, 37);
            this.txtNomeFornecedor.Name = "txtNomeFornecedor";
            this.txtNomeFornecedor.Size = new System.Drawing.Size(100, 22);
            this.txtNomeFornecedor.TabIndex = 0;
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(438, 83);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(100, 22);
            this.txtContacto.TabIndex = 1;
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(438, 126);
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(100, 22);
            this.txtNif.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome do fornecedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telefone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "NIF";
            // 
            // dgvFornecedores
            // 
            this.dgvFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFornecedores.Location = new System.Drawing.Point(102, 301);
            this.dgvFornecedores.Name = "dgvFornecedores";
            this.dgvFornecedores.ReadOnly = true;
            this.dgvFornecedores.RowHeadersWidth = 51;
            this.dgvFornecedores.RowTemplate.Height = 24;
            this.dgvFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFornecedores.Size = new System.Drawing.Size(599, 137);
            this.dgvFornecedores.TabIndex = 6;
            // 
            // btnGravarFornecedor
            // 
            this.btnGravarFornecedor.Location = new System.Drawing.Point(451, 237);
            this.btnGravarFornecedor.Name = "btnGravarFornecedor";
            this.btnGravarFornecedor.Size = new System.Drawing.Size(75, 23);
            this.btnGravarFornecedor.TabIndex = 7;
            this.btnGravarFornecedor.Text = "Gravar";
            this.btnGravarFornecedor.UseVisualStyleBackColor = true;
            this.btnGravarFornecedor.Click += new System.EventHandler(this.btnGravarFornecedor_Click);
            // 
            // btnEliminarFornecedor
            // 
            this.btnEliminarFornecedor.Location = new System.Drawing.Point(302, 237);
            this.btnEliminarFornecedor.Name = "btnEliminarFornecedor";
            this.btnEliminarFornecedor.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarFornecedor.TabIndex = 8;
            this.btnEliminarFornecedor.Text = "Excluir";
            this.btnEliminarFornecedor.UseVisualStyleBackColor = true;
            this.btnEliminarFornecedor.Click += new System.EventHandler(this.btnEliminarFornecedor_Click);
            // 
            // FormFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminarFornecedor);
            this.Controls.Add(this.btnGravarFornecedor);
            this.Controls.Add(this.dgvFornecedores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNif);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtNomeFornecedor);
            this.Name = "FormFornecedor";
            this.Text = "FormFornecedor";
            this.Load += new System.EventHandler(this.FormFornecedor_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeFornecedor;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvFornecedores;
        private System.Windows.Forms.Button btnGravarFornecedor;
        private System.Windows.Forms.Button btnEliminarFornecedor;
    }
}
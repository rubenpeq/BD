namespace Barbearia
{
    partial class FormMenu
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
            this.btnGerirClientes = new System.Windows.Forms.Button();
            this.btnGerirBarbeiros = new System.Windows.Forms.Button();
            this.btnGerirServiços = new System.Windows.Forms.Button();
            this.btnGerirAgendamentos = new System.Windows.Forms.Button();
            this.dgvDashboardAgendamentos = new System.Windows.Forms.DataGridView();
            this.btnConcluirAgendamento = new System.Windows.Forms.Button();
            this.btnCancelarAgendamento = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnGerirFornecedores = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnDespesasFixas = new System.Windows.Forms.Button();
            this.btnVencimento = new System.Windows.Forms.Button();
            this.btnCaixa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboardAgendamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGerirClientes
            // 
            this.btnGerirClientes.Location = new System.Drawing.Point(577, 26);
            this.btnGerirClientes.Name = "btnGerirClientes";
            this.btnGerirClientes.Size = new System.Drawing.Size(156, 23);
            this.btnGerirClientes.TabIndex = 0;
            this.btnGerirClientes.Text = "Clientes";
            this.btnGerirClientes.UseVisualStyleBackColor = true;
            this.btnGerirClientes.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerirBarbeiros
            // 
            this.btnGerirBarbeiros.Location = new System.Drawing.Point(577, 73);
            this.btnGerirBarbeiros.Name = "btnGerirBarbeiros";
            this.btnGerirBarbeiros.Size = new System.Drawing.Size(156, 23);
            this.btnGerirBarbeiros.TabIndex = 1;
            this.btnGerirBarbeiros.Text = "Barbeiros";
            this.btnGerirBarbeiros.UseVisualStyleBackColor = false;
            this.btnGerirBarbeiros.Click += new System.EventHandler(this.btnGerirBarbeiros_Click);
            // 
            // btnGerirServiços
            // 
            this.btnGerirServiços.Location = new System.Drawing.Point(577, 121);
            this.btnGerirServiços.Name = "btnGerirServiços";
            this.btnGerirServiços.Size = new System.Drawing.Size(156, 23);
            this.btnGerirServiços.TabIndex = 2;
            this.btnGerirServiços.Text = "Serviços";
            this.btnGerirServiços.UseVisualStyleBackColor = true;
            this.btnGerirServiços.Click += new System.EventHandler(this.btnGerirServiços_Click);
            // 
            // btnGerirAgendamentos
            // 
            this.btnGerirAgendamentos.Location = new System.Drawing.Point(506, 169);
            this.btnGerirAgendamentos.Name = "btnGerirAgendamentos";
            this.btnGerirAgendamentos.Size = new System.Drawing.Size(184, 64);
            this.btnGerirAgendamentos.TabIndex = 3;
            this.btnGerirAgendamentos.Text = "Novo Agendamento";
            this.btnGerirAgendamentos.UseVisualStyleBackColor = true;
            this.btnGerirAgendamentos.Click += new System.EventHandler(this.btnGerirAgendamentos_Click);
            // 
            // dgvDashboardAgendamentos
            // 
            this.dgvDashboardAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDashboardAgendamentos.Location = new System.Drawing.Point(1, 250);
            this.dgvDashboardAgendamentos.Name = "dgvDashboardAgendamentos";
            this.dgvDashboardAgendamentos.ReadOnly = true;
            this.dgvDashboardAgendamentos.RowHeadersWidth = 51;
            this.dgvDashboardAgendamentos.RowTemplate.Height = 24;
            this.dgvDashboardAgendamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDashboardAgendamentos.Size = new System.Drawing.Size(798, 201);
            this.dgvDashboardAgendamentos.TabIndex = 4;
            // 
            // btnConcluirAgendamento
            // 
            this.btnConcluirAgendamento.Location = new System.Drawing.Point(12, 210);
            this.btnConcluirAgendamento.Name = "btnConcluirAgendamento";
            this.btnConcluirAgendamento.Size = new System.Drawing.Size(191, 34);
            this.btnConcluirAgendamento.TabIndex = 5;
            this.btnConcluirAgendamento.Text = "Concluir Agendamento";
            this.btnConcluirAgendamento.UseVisualStyleBackColor = true;
            this.btnConcluirAgendamento.Click += new System.EventHandler(this.btnConcluirAgendamento_Click);
            // 
            // btnCancelarAgendamento
            // 
            this.btnCancelarAgendamento.Location = new System.Drawing.Point(226, 210);
            this.btnCancelarAgendamento.Name = "btnCancelarAgendamento";
            this.btnCancelarAgendamento.Size = new System.Drawing.Size(191, 34);
            this.btnCancelarAgendamento.TabIndex = 6;
            this.btnCancelarAgendamento.Text = "Cancelar Agendamento";
            this.btnCancelarAgendamento.UseVisualStyleBackColor = true;
            this.btnCancelarAgendamento.Click += new System.EventHandler(this.btnCancelarAgendamento_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(391, 26);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(156, 28);
            this.btnStock.TabIndex = 7;
            this.btnStock.Text = "Estoque de produtos";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnGerirFornecedores
            // 
            this.btnGerirFornecedores.Location = new System.Drawing.Point(391, 73);
            this.btnGerirFornecedores.Name = "btnGerirFornecedores";
            this.btnGerirFornecedores.Size = new System.Drawing.Size(156, 23);
            this.btnGerirFornecedores.TabIndex = 8;
            this.btnGerirFornecedores.Text = "Fornecedores";
            this.btnGerirFornecedores.UseVisualStyleBackColor = true;
            this.btnGerirFornecedores.Click += new System.EventHandler(this.btnGerirFornecedores_Click);
            // 
            // btnVenda
            // 
            this.btnVenda.Location = new System.Drawing.Point(391, 120);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(156, 23);
            this.btnVenda.TabIndex = 9;
            this.btnVenda.Text = "Vendas";
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            // 
            // btnDespesasFixas
            // 
            this.btnDespesasFixas.Location = new System.Drawing.Point(209, 26);
            this.btnDespesasFixas.Name = "btnDespesasFixas";
            this.btnDespesasFixas.Size = new System.Drawing.Size(156, 28);
            this.btnDespesasFixas.TabIndex = 10;
            this.btnDespesasFixas.Text = "Despesas fixas";
            this.btnDespesasFixas.UseVisualStyleBackColor = true;
            this.btnDespesasFixas.Click += new System.EventHandler(this.btnDespesasFixas_Click);
            // 
            // btnVencimento
            // 
            this.btnVencimento.Location = new System.Drawing.Point(209, 72);
            this.btnVencimento.Name = "btnVencimento";
            this.btnVencimento.Size = new System.Drawing.Size(156, 23);
            this.btnVencimento.TabIndex = 11;
            this.btnVencimento.Text = "Vencimentos";
            this.btnVencimento.UseVisualStyleBackColor = true;
            this.btnVencimento.Click += new System.EventHandler(this.btnVencimento_Click);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Location = new System.Drawing.Point(22, 26);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(155, 70);
            this.btnCaixa.TabIndex = 12;
            this.btnCaixa.Text = "CAIXA";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCaixa);
            this.Controls.Add(this.btnVencimento);
            this.Controls.Add(this.btnDespesasFixas);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.btnGerirFornecedores);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnCancelarAgendamento);
            this.Controls.Add(this.btnConcluirAgendamento);
            this.Controls.Add(this.dgvDashboardAgendamentos);
            this.Controls.Add(this.btnGerirAgendamentos);
            this.Controls.Add(this.btnGerirServiços);
            this.Controls.Add(this.btnGerirBarbeiros);
            this.Controls.Add(this.btnGerirClientes);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboardAgendamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGerirClientes;
        private System.Windows.Forms.Button btnGerirBarbeiros;
        private System.Windows.Forms.Button btnGerirServiços;
        private System.Windows.Forms.Button btnGerirAgendamentos;
        private System.Windows.Forms.DataGridView dgvDashboardAgendamentos;
        private System.Windows.Forms.Button btnConcluirAgendamento;
        private System.Windows.Forms.Button btnCancelarAgendamento;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnGerirFornecedores;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnDespesasFixas;
        private System.Windows.Forms.Button btnVencimento;
        private System.Windows.Forms.Button btnCaixa;
    } 
}
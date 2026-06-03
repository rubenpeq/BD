using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BarbeariaSistema;

namespace Barbearia
{
    public partial class FormMenu : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        public FormMenu()
        {
            InitializeComponent();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null) cn = new SqlConnection(connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn.State == ConnectionState.Open;
        }

        // --- 1. CARREGAR O DASHBOARD ASSIM QUE O MENU ABRE ---
        private void FormMenu_Load(object sender, EventArgs e)
        {
            AtualizarDashboard();
        }

        public void AtualizarDashboard()
        {
            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Dashboard_GetAgendamentos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDashboardAgendamentos.DataSource = dt;
                    if (dgvDashboardAgendamentos.Columns["ID_Agendamento"] != null)
                        dgvDashboardAgendamentos.Columns["ID_Agendamento"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dashboard: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        // --- 2. BOTÕES DE ALTERAÇÃO DE ESTADO ---
        private void btnConcluirAgendamento_Click(object sender, EventArgs e)
        {
            MudarEstadoAgendamento("Concluído");
        }

        private void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {
            MudarEstadoAgendamento("Cancelado");
        }

        private void MudarEstadoAgendamento(string novoEstado)
        {
            if (dgvDashboardAgendamentos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecione um agendamento na tabela primeiro.");
                return;
            }

            int idAgendamento = Convert.ToInt32(dgvDashboardAgendamentos.CurrentRow.Cells["ID_Agendamento"].Value);
            string estadoAtual = dgvDashboardAgendamentos.CurrentRow.Cells["Estado"].Value.ToString();

            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Agendamento_UpdateEstado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Agendamento", idAgendamento);
                    cmd.Parameters.AddWithValue("@NovoEstado", novoEstado);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Agendamento atualizado para '{novoEstado}' com sucesso!");
                AtualizarDashboard();
            }
            catch (SqlException ex)
            {
                // A excepção pode vir do RAISERROR ou de outro erro SQL
                MessageBox.Show("Erro ao processar conclusão: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        // --- 3. ATALHOS PARA OS OUTROS ECRÃS DO SISTEMA ---
        private void btnGerirAgendamentos_Click(object sender, EventArgs e)
        {
            FormAgendamento frm = new FormAgendamento();
            frm.ShowDialog();
            AtualizarDashboard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Atalho antigo dos Clientes (redirecionado para manter compatibilidade)
            btnGerirClientes_Click(sender, e);
        }

        private void btnGerirClientes_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void btnGerirBarbeiros_Click(object sender, EventArgs e)
        {
            FormBarbeiro frm = new FormBarbeiro();
            frm.ShowDialog();
        }

        private void btnGerirServiços_Click(object sender, EventArgs e)
        {
            FormServico frm = new FormServico();
            frm.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            FormStock ecraStock = new FormStock();

            // Abre o ecrã como uma janela modal (bloqueia o menu até que feches o stock)
            ecraStock.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormFornecedor ecraFornecedor = new FormFornecedor();

            // 2. Abre o ecrã como uma janela modal (bloqueia o menu principal enquanto estiver aberto)
            ecraFornecedor.ShowDialog();
        }

        private void btnGerirFornecedores_Click(object sender, EventArgs e)
        {
            FormFornecedor ecraFornecedor = new FormFornecedor();

            // Abre como ShowDialog. Ao fechar esta janela, o foco volta ao menu
            ecraFornecedor.ShowDialog();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            FormVenda frm = new FormVenda();
            frm.ShowDialog();
        }

        private void btnDespesasFixas_Click(object sender, EventArgs e)
        {
            Form_Despesas_Fixas formDespesas = new Form_Despesas_Fixas();

            
            formDespesas.ShowDialog();
        }

        private void btnVencimento_Click(object sender, EventArgs e)
        {
            Form_Folha_Pagamento formFolha = new Form_Folha_Pagamento();

            
            formFolha.ShowDialog();
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            FormMovimentacao frm = new FormMovimentacao();
            frm.ShowDialog();
        }
    }
}
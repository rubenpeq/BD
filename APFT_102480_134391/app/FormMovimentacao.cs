using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormMovimentacao : Form
    {
        private SqlConnection cn;
        private string connStr = "data source=192.168.182.10;initial catalog=p3g1;user id=p3g1;password=BDRE2026.;TrustServerCertificate=True;";

        public FormMovimentacao()
        {
            InitializeComponent();
            cn = new SqlConnection(connStr);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-PT");
        }

        private bool verifySGBDConnection()
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            return cn.State == ConnectionState.Open;
        }

        private void FormMovimentacao_Load(object sender, EventArgs e)
        {
            try
            {
                dgvMovimentacoes.AutoGenerateColumns = true;
                AtualizarSaldo();
                FiltrarMovimentacoes(DateTime.Today.AddDays(-30), DateTime.Today, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados da movimentação: " + ex.Message,
                                "Erro de Inicialização",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            dgvMovimentacoes.ReadOnly = true;
        }

        private void AtualizarSaldo()
        {
            try
            {
                if (!verifySGBDConnection()) return;
                using (SqlCommand cmd = new SqlCommand("sp_Movimentacao_GetSaldo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    decimal saldo = Convert.ToDecimal(cmd.ExecuteScalar());
                    txtSaldo.Text = saldo.ToString("C2");
                    txtSaldo.ForeColor = (saldo >= 0) ? Color.Green : Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter saldo: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        private void btnFiltrar1_Click(object sender, EventArgs e)
        {
            FiltrarMovimentacoes(dtpInicio.Value.Date, dtpFim.Value.Date, null, null);
        }

        private void btnFiltrar2_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.SelectedItem?.ToString();
            string subtipo = cboSubtipo.SelectedItem?.ToString();
            FiltrarMovimentacoes(dtpInicio.Value.Date, dtpFim.Value.Date, tipo, subtipo);
        }

        private void FiltrarMovimentacoes(DateTime inicio, DateTime fim, string tipo, string subtipo)
        {
            try
            {
                if (!verifySGBDConnection()) return;
                using (SqlCommand cmd = new SqlCommand("sp_Movimentacao_GetFiltered", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DataInicio", inicio);
                    cmd.Parameters.AddWithValue("@DataFim", fim.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@Tipo", string.IsNullOrEmpty(tipo) ? DBNull.Value : (object)tipo);
                    cmd.Parameters.AddWithValue("@Subtipo", string.IsNullOrEmpty(subtipo) ? DBNull.Value : (object)subtipo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMovimentacoes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSubtipo.Items.Clear();
            if (cboTipo.SelectedItem == null) return;
            string categoria = cboTipo.SelectedItem.ToString();
            if (categoria == "Despesa")
            {
                cboSubtipo.Items.AddRange(new string[] { "Despesa fixa", "Pagamento de salário - Barbeiro", "Compra de produto" });
            }
            else if (categoria == "Receita")
            {
                cboSubtipo.Items.AddRange(new string[] { "Agendamento", "Venda" });
            }
        }

        private void dgvMovimentacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
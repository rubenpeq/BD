using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BarbeariaSistema
{
    public partial class Form_Despesas_Fixas : Form
    {
        SqlConnection cn = new SqlConnection("data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.");

        public Form_Despesas_Fixas()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        private void Form_Despesas_Fixas_Load(object sender, EventArgs e)
        {
            CarregarDespesas();
        }

        private void CarregarDespesas()
        {
            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DespesasFixas_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDespesas.DataSource = dt;
                    dgvDespesas.Columns["ID_Despesa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeDespesa.Text))
            {
                MessageBox.Show("Preencha o nome da despesa.");
                return;
            }

            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DespesasFixas_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NomeDespesa", txtNomeDespesa.Text);
                    cmd.Parameters.AddWithValue("@Valor", numValorDespesa.Value);
                    cmd.Parameters.AddWithValue("@DiaVencimento", dtpData.Value.Date);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Gravado com sucesso!");
                btnLimpar_Click(sender, e);
                CarregarDespesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeDespesa.Clear();
            numValorDespesa.Value = 0;
            
            dtpData.Value = DateTime.Now;
            txtNomeDespesa.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvDespesas.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvDespesas.SelectedRows[0].Cells["ID_Despesa"].Value);

            try
            {
                if (cn.State == ConnectionState.Closed) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DespesasFixas_Delete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Despesa", id);
                    cmd.ExecuteNonQuery();
                }

                CarregarDespesas();
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro: Esta despesa já possui movimentações vinculadas e não pode ser excluída.");
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
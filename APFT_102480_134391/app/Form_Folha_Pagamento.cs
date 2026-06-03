using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BarbeariaSistema
{
    public partial class Form_Folha_Pagamento : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        public Form_Folha_Pagamento()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            cn = new SqlConnection(connectionString);
        }

        private void Form_Folha_Pagamento_Load(object sender, EventArgs e)
        {
            CarregarBarbeiros();
            CarregarGrid();
        }

        private void CarregarBarbeiros()
        {
            try
            {
                if (cn.State != ConnectionState.Open) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_Barbeiros_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbBarbeiro.DataSource = dt;
                    cmbBarbeiro.DisplayMember = "Nome";
                    cmbBarbeiro.ValueMember = "ID_Barbeiro";
                    cmbBarbeiro.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar barbeiros: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void CarregarGrid()
        {
            try
            {
                if (cn.State != ConnectionState.Open) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_FolhaPagamento_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFolha.DataSource = dt;

                    if (dgvFolha.Columns["Mes_Ano"] != null)
                        dgvFolha.Columns["Mes_Ano"].DefaultCellStyle.Format = "MM/yyyy";
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar grid: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (cmbBarbeiro.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um barbeiro!");
                return;
            }

            try
            {
                if (cn.State != ConnectionState.Open) cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_FolhaPagamento_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Barbeiro", cmbBarbeiro.SelectedValue);
                    cmd.Parameters.AddWithValue("@Mes_Ano", dtpMesAno.Value.Date);
                    cmd.Parameters.AddWithValue("@Salario", numSalario.Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Folha gravada com sucesso!");
                CarregarGrid();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            finally { cn.Close(); }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormFornecedor : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        // Variável auxiliar para sabermos qual fornecedor está selecionado na Grid
        private int idFornecedorSelecionado = -1;

        public FormFornecedor()
        {
            InitializeComponent();
            CarregarFornecedoresAtivos();
        }

        private void FormFornecedor_Load(object sender, EventArgs e)
        {
            CarregarFornecedoresAtivos();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null) cn = new SqlConnection(connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn.State == ConnectionState.Open;
        }

        // 1. CARREGAR FORNECEDORES ACTIVOS (usando stored procedure)
        private void CarregarFornecedoresAtivos()
        {
            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Fornecedores_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvFornecedores.DataSource = null;
                    dgvFornecedores.DataSource = dt;

                    if (dgvFornecedores.Columns.Contains("ID_Fornecedor"))
                        dgvFornecedores.Columns["ID_Fornecedor"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar fornecedores: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        // 2. EVENTO CLIQUE DA GRID: PREENCHE OS CAMPOS
        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFornecedores.Rows[e.RowIndex];

                idFornecedorSelecionado = Convert.ToInt32(row.Cells["ID_Fornecedor"].Value);
                txtNomeFornecedor.Text = row.Cells["Nome"].Value.ToString();
                txtNif.Text = row.Cells["NIF"].Value.ToString();
                txtContacto.Text = row.Cells["Telefone"].Value.ToString();
            }
        }

        // 3. BOTÃO GRAVAR (inserir novo fornecedor)
        private void btnGravarFornecedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeFornecedor.Text) || string.IsNullOrEmpty(txtNif.Text))
            {
                MessageBox.Show("O Nome e o NIF do fornecedor são obrigatórios!");
                return;
            }

            if (txtNif.Text.Trim().Length != 9)
            {
                MessageBox.Show("O NIF deve conter exatamente 9 dígitos!");
                return;
            }

            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Fornecedor_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", txtNomeFornecedor.Text.Trim());
                    cmd.Parameters.AddWithValue("@NIF", txtNif.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefone", txtContacto.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Fornecedor registado com sucesso!");
                LimparCampos();
                CarregarFornecedoresAtivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar fornecedor: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        // 4. BOTÃO EXCLUIR (soft delete)
        private void btnEliminarFornecedor_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione uma linha completa na tabela.");
                return;
            }

            int idSelecionado = Convert.ToInt32(dgvFornecedores.SelectedRows[0].Cells["ID_Fornecedor"].Value);

            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que deseja eliminar o fornecedor selecionado?",
                "Confirmar Eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta == DialogResult.Yes)
            {
                if (!verifySGBDConnection()) return;

                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Fornecedor_SoftDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Fornecedor", idSelecionado);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Fornecedor eliminado com sucesso!");
                    LimparCampos();
                    CarregarFornecedoresAtivos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao eliminar fornecedor: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        private void LimparCampos()
        {
            txtNomeFornecedor.Clear();
            txtNif.Clear();
            txtContacto.Clear();
            idFornecedorSelecionado = -1;
        }

        private void FormFornecedor_Activated(object sender, EventArgs e)
        {
            // Mantido vazio conforme original
        }
    }
}
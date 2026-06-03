using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormBarbeiro : Form
    {
        private SqlConnection cn;
        private string connStr = "data source=192.168.182.10;initial catalog=p3g1;user id=p3g1;password=BDRE2026.;TrustServerCertificate=True;";
        private bool modoEdicao = false;
        public FormBarbeiro()
        {
            InitializeComponent();
            cn = new SqlConnection(connStr);
            AtualizarListaDeBarbeiros();
            

        }

        private bool verifySGBDConnection()
        {
            if (cn.State != ConnectionState.Open) { try { cn.Open(); } catch { return false; } }
            return true;
        }

        public void AtualizarListaDeBarbeiros()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Barbeiros_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBarbeiros.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar barbeiros: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void dgvBarbeiros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBarbeiros.SelectedRows.Count > 0)
            {
                modoEdicao = true;
                DataGridViewRow row = dgvBarbeiros.SelectedRows[0];

                txtNomeBarbeiro.Text = row.Cells["Nome"].Value?.ToString();
                txtApelidoBarbeiro.Text = row.Cells["Apelido"].Value?.ToString();
                txtNIFBarbeiro.Text = row.Cells["NIF"].Value?.ToString();
                txtTelefoneBarbeiro.Text = row.Cells["Telefone"].Value?.ToString();
                txtEspecialidadeBarbeiro.Text = row.Cells["Especialidade"].Value?.ToString();

                if (int.TryParse(row.Cells["ID_Barbeiro"].Value?.ToString(), out int idBarbeiro))
                {
                    CarregarEscalaDoBarbeiro(idBarbeiro);
                }
            }
        }
        private void CarregarEscalaDoBarbeiro(int idBarbeiro)
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Escala_GetByBarbeiro", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Barbeiro", idBarbeiro);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvEscala.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar escala: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void btnGravarBarbeiro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeBarbeiro.Text))
            {
                MessageBox.Show("Nome obrigatório.");
                return;
            }

            if (!verifySGBDConnection()) return;

            SqlTransaction transacao = cn.BeginTransaction();
            try
            {
                if (modoEdicao)
                {
                    int id = Convert.ToInt32(dgvBarbeiros.SelectedRows[0].Cells["ID_Barbeiro"].Value);
                    using (SqlCommand cmd = new SqlCommand("sp_Barbeiro_Update", cn, transacao))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Barbeiro", id);
                        cmd.Parameters.AddWithValue("@Nome", txtNomeBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Apelido", txtApelidoBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@NIF", string.IsNullOrEmpty(txtNIFBarbeiro.Text) ? DBNull.Value : (object)txtNIFBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Telefone", string.IsNullOrEmpty(txtTelefoneBarbeiro.Text) ? DBNull.Value : (object)txtTelefoneBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Especialidade", string.IsNullOrEmpty(txtEspecialidadeBarbeiro.Text) ? DBNull.Value : (object)txtEspecialidadeBarbeiro.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Barbeiro atualizado com sucesso!");
                }
                else
                {
                    int novoId;
                    using (SqlCommand cmd = new SqlCommand("sp_Barbeiro_Insert", cn, transacao))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nome", txtNomeBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Apelido", txtApelidoBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@NIF", string.IsNullOrEmpty(txtNIFBarbeiro.Text) ? DBNull.Value : (object)txtNIFBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Telefone", string.IsNullOrEmpty(txtTelefoneBarbeiro.Text) ? DBNull.Value : (object)txtTelefoneBarbeiro.Text);
                        cmd.Parameters.AddWithValue("@Especialidade", string.IsNullOrEmpty(txtEspecialidadeBarbeiro.Text) ? DBNull.Value : (object)txtEspecialidadeBarbeiro.Text);
                        SqlParameter outParam = new SqlParameter("@NovoID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(outParam);
                        cmd.ExecuteNonQuery();
                        novoId = (int)outParam.Value;
                    }

                    // Inserir escala para os dias seleccionados
                    TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
                    TimeSpan horaFim = dtpHoraFim.Value.TimeOfDay;
                    foreach (object item in clbDiasSemana.CheckedItems)
                    {
                        string dia = item.ToString();
                        using (SqlCommand cmd = new SqlCommand("sp_Escala_Insert", cn, transacao))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Barbeiro", novoId);
                            cmd.Parameters.AddWithValue("@DiaSemana", dia);
                            cmd.Parameters.AddWithValue("@HoraInicio", horaInicio);
                            cmd.Parameters.AddWithValue("@HoraFim", horaFim);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Barbeiro e escala padrão criados!");
                }

                transacao.Commit();
                LimparCampos();
                AtualizarListaDeBarbeiros();
                modoEdicao = false;
                dgvBarbeiros.ClearSelection();
                dgvEscala.DataSource = null;
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnEliminarBarbeiro_Click(object sender, EventArgs e)
        {
            if (dgvBarbeiros.CurrentRow == null)
            {
                MessageBox.Show("Selecione um barbeiro na tabela para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvBarbeiros.CurrentRow.Cells["ID_Barbeiro"].Value);
            string nome = dgvBarbeiros.CurrentRow.Cells["Nome"].Value.ToString();

            if (MessageBox.Show($"Eliminar {nome}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Barbeiro_SoftDelete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Barbeiro", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Barbeiro eliminado!");
                LimparCampos();
                AtualizarListaDeBarbeiros();
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void LimparCampos()
        {
            txtNomeBarbeiro.Clear();
            txtApelidoBarbeiro.Clear();
            txtNIFBarbeiro.Clear();
            txtTelefoneBarbeiro.Clear();
            txtEspecialidadeBarbeiro.Clear();
        }

        private void btnAdicionarBarbeiro_Click(object sender, EventArgs e) 
        {
            LimparCampos();
            dgvBarbeiros.ClearSelection(); // Remove o destaque visual
            dgvEscala.DataSource = null;   // Limpa a grade de escala
            modoEdicao = false;            // Força o modo de inserção
            txtNomeBarbeiro.Focus();
        }

        
    }
}
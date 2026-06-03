using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    
    

    
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private string connectionString = "data source=192.168.182.10;initial catalog=p3g1;user id=p3g1;password=BDRE2026.;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(connectionString);

            
            AtualizarListaDeClientes();
        }

        private bool verifySGBDConnection()
        {
            if (cn.State != ConnectionState.Open)
            {
                try { cn.Open(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão: " + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public void AtualizarListaDeClientes()
        {
            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Clientes_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        Cliente c = new Cliente();
                        c.ID_Cliente = Convert.ToInt32(reader["ID_Cliente"]);
                        c.Nome = reader["Nome"].ToString();
                        c.Apelido = reader["Apelido"].ToString();
                        c.NIF = reader["NIF"] != DBNull.Value ? reader["NIF"].ToString() : "";
                        c.Telefone = reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : "";
                        c.DataCadastro = Convert.ToDateTime(reader["Data_Cadastro"]);
                        listBox1.Items.Add(c);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Cliente selecionado)
            {
                txtNome.Text = selecionado.Nome;
                txtApelido.Text = selecionado.Apelido;
                txtNIF.Text = selecionado.NIF;
                txtTelefone.Text = selecionado.Telefone;
                dtpDataCadastro.Value = selecionado.DataCadastro;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtApelido.Text))
            {
                MessageBox.Show("O Nome e o Apelido são obrigatórios!");
                return;
            }

            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Cliente_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@Apelido", txtApelido.Text);
                    cmd.Parameters.AddWithValue("@NIF", string.IsNullOrEmpty(txtNIF.Text) ? DBNull.Value : (object)txtNIF.Text);
                    cmd.Parameters.AddWithValue("@Telefone", string.IsNullOrEmpty(txtTelefone.Text) ? DBNull.Value : (object)txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@DataCadastro", dtpDataCadastro.Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente guardado!");
                LimparCampos();
                AtualizarListaDeClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao guardar: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Cliente selec)
            {
                if (MessageBox.Show("Confirmar eliminação?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!verifySGBDConnection()) return;

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_Cliente_SoftDelete", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Cliente", selec.ID_Cliente);
                            cmd.ExecuteNonQuery();
                        }

                        LimparCampos();
                        AtualizarListaDeClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao eliminar: " + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtApelido.Clear();
            txtNIF.Clear();
            txtTelefone.Clear();
            dtpDataCadastro.Value = DateTime.Now;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();

            
            txtNome.Focus();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormStock : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        public FormStock()
        {
            InitializeComponent();
            CarregarStocks();
            CarregarFornecedores();
            CarregarTodosProdutos();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null) cn = new SqlConnection(connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn.State == ConnectionState.Open;
        }

        private void CarregarStocks()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                // Stock consumo
                using (SqlCommand cmd = new SqlCommand("sp_Stock_GetConsumo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStockConsumo.DataSource = dt;
                }

                // Stock venda
                using (SqlCommand cmd = new SqlCommand("sp_Stock_GetVenda", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStockVenda.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar stocks: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void CarregarFornecedores()
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
                    cbFornecedores.DataSource = dt;
                    cbFornecedores.DisplayMember = "Nome";
                    cbFornecedores.ValueMember = "ID_Fornecedor";
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar fornecedores: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void CarregarTodosProdutos()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Produtos_GetAll", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbProdutos.DataSource = dt;
                    cbProdutos.DisplayMember = "Nome";
                    cbProdutos.ValueMember = "ID_Produto";
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar produtos: " + ex.Message); }
            finally { cn.Close(); }
        }

        private int CriarNovoProduto(string nomeProduto)
        {
            if (!verifySGBDConnection()) return 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Produto_Insert", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", nomeProduto);
                    SqlParameter outId = new SqlParameter("@ID_Produto", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outId);
                    cmd.ExecuteNonQuery();
                    int novoId = (int)outId.Value;
                    CarregarTodosProdutos();
                    return novoId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar produto: " + ex.Message);
                return 0;
            }
        }

        private void btnGravarFornecimento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbProdutos.Text))
            {
                MessageBox.Show("Nome do produto inválido.");
                return;
            }

            // Determinar ID do produto (existente ou novo)
            int idProdutoSelecionado = 0;
            if (cbProdutos.SelectedValue != null && cbProdutos.Text == cbProdutos.GetItemText(cbProdutos.SelectedItem))
            {
                idProdutoSelecionado = (int)cbProdutos.SelectedValue;
            }
            else
            {
                idProdutoSelecionado = CriarNovoProduto(cbProdutos.Text);
            }

            if (idProdutoSelecionado == 0) return;

            if (cbFornecedores.SelectedValue == null)
            {
                MessageBox.Show("Selecione um fornecedor válido.");
                return;
            }

            if (cbTipoStock.SelectedItem == null)
            {
                MessageBox.Show("Selecione se o stock é para Venda ou Consumo.");
                return;
            }

            string tipo = cbTipoStock.SelectedItem.ToString();
            decimal precoVenda = 0;
            if (tipo == "Venda")
            {
                if (!decimal.TryParse(txtPrecoVenda.Text, System.Globalization.NumberStyles.Any,
                                      System.Globalization.CultureInfo.InvariantCulture, out precoVenda))
                {
                    MessageBox.Show("Preço de venda inválido.");
                    return;
                }
            }

            if (!decimal.TryParse(txtPrecoUnidade.Text, System.Globalization.NumberStyles.Any,
                                  System.Globalization.CultureInfo.InvariantCulture, out decimal precoUnidade))
            {
                MessageBox.Show("Preço de compra inválido.");
                return;
            }

            btnGravarFornecimento.Enabled = false;
            if (!verifySGBDConnection()) { btnGravarFornecimento.Enabled = true; return; }

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Fornecimento_Registrar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Fornecedor", cbFornecedores.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID_Produto", idProdutoSelecionado);
                    cmd.Parameters.AddWithValue("@NomeProduto", (object)cbProdutos.Text ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Quantidade", (int)numQuantidade.Value);
                    cmd.Parameters.AddWithValue("@PrecoUnidade", precoUnidade);
                    cmd.Parameters.AddWithValue("@TipoStock", tipo);
                    cmd.Parameters.AddWithValue("@PrecoVenda", tipo == "Venda" ? (object)precoVenda : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Operação de {tipo} concluída com sucesso!");
                CarregarStocks();  // Actualiza as grelhas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message);
            }
            finally
            {
                btnGravarFornecimento.Enabled = true;
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        private void cbTipoStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoStock.SelectedItem != null)
            {
                string tipo = cbTipoStock.SelectedItem.ToString();
                if (tipo == "Consumo")
                {
                    txtPrecoVenda.Enabled = false;
                    txtPrecoVenda.Text = "0";
                    numQuantidade.Focus();
                }
                else
                {
                    txtPrecoVenda.Enabled = true;
                    txtPrecoVenda.Clear();
                }
            }
        }

        private void FormStock_Load(object sender, EventArgs e) { }
    }
}
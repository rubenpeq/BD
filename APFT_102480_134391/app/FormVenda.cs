using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormVenda : Form
    {
        string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        BindingList<ItemVenda> listaVenda = new BindingList<ItemVenda>();

        public FormVenda()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-PT");
            dgvVenda.DataSource = listaVenda;
            dgvVenda.AllowUserToAddRows = false;
        }

        private void FormVenda_Load(object sender, EventArgs e)
        {
            CarregarClientes();
            CarregarProdutos();
            dgvVenda.Columns["Preco"].DefaultCellStyle.Format = "C2";
            dgvVenda.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void CarregarClientes()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_Clientes_GetActiveForVenda", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbClientes.DataSource = dt;
                cbClientes.DisplayMember = "NomeCompleto";
                cbClientes.ValueMember = "ID_Cliente";
            }
        }

        private void CarregarProdutos()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ProdutosVenda_GetWithStock", cn))
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cbProdutos.SelectedValue == null) return;

            int qtdDesejada = (int)numQtd.Value;
            int idProduto = (int)cbProdutos.SelectedValue;
            decimal precoUnitario = 0;

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ProdutoVenda_GetStockAndPrice", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Produto", idProduto);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int stockAtual = Convert.ToInt32(reader["Stock"]);
                        precoUnitario = Convert.ToDecimal(reader["Preco_unidade"]);

                        if (qtdDesejada > stockAtual)
                        {
                            MessageBox.Show($"Estoque insuficiente! Temos apenas {stockAtual} unidades.");
                            return;
                        }
                    }
                }
            }

            var item = new ItemVenda
            {
                ID_Produto = idProduto,
                Nome = cbProdutos.Text,
                Quantidade = qtdDesejada,
                Preco = precoUnitario,
                Subtotal = qtdDesejada * precoUnitario
            };

            listaVenda.Add(item);
            AtualizarTotais();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (listaVenda.Count == 0)
            {
                MessageBox.Show("Adicione produtos à venda primeiro!");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlTransaction transacao = cn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in listaVenda)
                            {
                                using (SqlCommand cmd = new SqlCommand("sp_Venda_InsertItem", cn, transacao))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@ID_Cliente", cbClientes.SelectedValue);
                                    cmd.Parameters.AddWithValue("@ID_Produto_Venda", item.ID_Produto);
                                    cmd.Parameters.AddWithValue("@Unidades", item.Quantidade);
                                    cmd.Parameters.AddWithValue("@Preco_Unidade_Momento", item.Preco);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            transacao.Commit();
                            MessageBox.Show("Venda processada com sucesso!");
                            listaVenda.Clear();
                            AtualizarTotais();
                        }
                        catch
                        {
                            transacao.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar venda: " + ex.Message);
            }
        }

        private void AtualizarTotais()
        {
            decimal total = 0;
            foreach (var item in listaVenda) total += item.Subtotal;
            lblTotalGeral.Text = "Total a Pagar: " + total.ToString("C2");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVenda.CurrentRow != null)
            {
                listaVenda.RemoveAt(dgvVenda.CurrentRow.Index);
                AtualizarTotais();
            }
        }
    }

    public class ItemVenda
    {
        public int ID_Produto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Subtotal { get; set; }
    }
}
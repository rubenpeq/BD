using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormServico : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        private BindingList<LinhaConsumoServico> listaConsumos = new BindingList<LinhaConsumoServico>();

        public FormServico()
        {
            InitializeComponent();
            dgvConsumosTemporarios.DataSource = listaConsumos;
            AtualizarListaDeServicos();
            CarregarProdutosConsumo();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null) cn = new SqlConnection(connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn.State == ConnectionState.Open;
        }

        public void AtualizarListaDeServicos()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Servicos_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBoxServicos.Items.Clear();
                    while (reader.Read())
                    {
                        Servico s = new Servico();
                        s.ID_Servico = Convert.ToInt32(reader["ID_Servico"]);
                        s.Nome_Servico = reader["Nome_Servico"].ToString();
                        s.Preco_base = Convert.ToDecimal(reader["Preco_base"]);
                        s.Unidades = reader["Unidades"] != DBNull.Value ? Convert.ToInt32(reader["Unidades"]) : (int?)null;
                        listBoxServicos.Items.Add(s);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar serviços: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void CarregarProdutosConsumo()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Produtos_GetConsumo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    cbProdutosConsumo.Items.Clear();
                    while (reader.Read())
                    {
                        cbProdutosConsumo.Items.Add(new
                        {
                            Text = reader["Nome"].ToString(),
                            Value = Convert.ToInt32(reader["ID_Produto"])
                        });
                    }
                    cbProdutosConsumo.DisplayMember = "Text";
                    cbProdutosConsumo.ValueMember = "Value";
                    reader.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro ao carregar produtos: " + ex.Message); }
            finally { cn.Close(); }
        }

        private void btnAdicionarServico_Click(object sender, EventArgs e)
        {
            if (cbProdutosConsumo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um produto!");
                return;
            }

            dynamic prod = cbProdutosConsumo.SelectedItem;
            int unidadesConsumidas = (int)txtQuantidadeConsumidas.Value;

            if (unidadesConsumidas <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!");
                return;
            }

            bool jaExiste = false;
            foreach (var linha in listaConsumos)
            {
                if (linha.ID_Produto == prod.Value)
                {
                    linha.Unidades += unidadesConsumidas;
                    jaExiste = true;
                    break;
                }
            }

            if (!jaExiste)
            {
                listaConsumos.Add(new LinhaConsumoServico
                {
                    ID_Produto = prod.Value,
                    Nome_Produto = prod.Text,
                    Unidades = unidadesConsumidas
                });
            }

            dgvConsumosTemporarios.Refresh();
        }

        private void btnGravarServico_Click(object sender, EventArgs e)
        {
            // Validação do nome
            if (string.IsNullOrWhiteSpace(txtNomeServico.Text))
            {
                MessageBox.Show("O Nome do Serviço é obrigatório!");
                return;
            }

            // Validação e conversão do Preço Base
            if (!decimal.TryParse(txtPrecoBase.Text, System.Globalization.NumberStyles.Any,
                                  System.Globalization.CultureInfo.InvariantCulture, out decimal precoBase))
            {
                MessageBox.Show("Preço Base inválido. Use um formato numérico (ex: 10.50)");
                return;
            }

            // Validação e conversão das Unidades (campo opcional)
            int? unidades = null;
            if (!string.IsNullOrWhiteSpace(txtUnidades.Text))
            {
                if (int.TryParse(txtUnidades.Text, out int unid))
                    unidades = unid;
                else
                {
                    MessageBox.Show("Unidades deve ser um número inteiro válido (ex: 30)");
                    return;
                }
            }

            // Validação do carrinho
            if (listaConsumos.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto consumido ao serviço!");
                return;
            }

            if (!verifySGBDConnection()) return;

            SqlTransaction transacao = cn.BeginTransaction();
            try
            {
                int novoServicoId;

                // Inserir serviço
                using (SqlCommand cmd = new SqlCommand("sp_Servico_Insert", cn, transacao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome_Servico", txtNomeServico.Text.Trim());
                    cmd.Parameters.AddWithValue("@Preco_base", precoBase);
                    cmd.Parameters.AddWithValue("@Unidades", unidades.HasValue ? (object)unidades.Value : DBNull.Value);
                    SqlParameter outId = new SqlParameter("@ID_Servico", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(outId);
                    cmd.ExecuteNonQuery();
                    novoServicoId = (int)outId.Value;
                }

                // Inserir consumos
                foreach (var item in listaConsumos)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Servico_Consumo_Insert", cn, transacao))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Servico", novoServicoId);
                        cmd.Parameters.AddWithValue("@ID_Produto", item.ID_Produto);
                        cmd.Parameters.AddWithValue("@Unidades", item.Unidades);
                        cmd.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                MessageBox.Show("Serviço e produtos consumidos gravados com sucesso!");

                listaConsumos.Clear();
                LimparCampos();
                AtualizarListaDeServicos();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                MessageBox.Show("Erro ao gravar: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        private void btnEliminarServico_Click(object sender, EventArgs e)
        {
            if (listBoxServicos.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um serviço na lista para desativar.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que deseja desativar este serviço?",
                "Confirmar Desativação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                if (!verifySGBDConnection()) return;
                Servico selecionado = (Servico)listBoxServicos.SelectedItem;
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Servico_SoftDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Servico", selecionado.ID_Servico);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Serviço desativado com sucesso!");
                    LimparCampos();
                    AtualizarListaDeServicos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao desativar: " + ex.Message);
                }
                finally { cn.Close(); }
            }
        }

        private void listBoxServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxServicos.SelectedIndex >= 0)
            {
                Servico selecionado = (Servico)listBoxServicos.SelectedItem;
                txtNomeServico.Text = selecionado.Nome_Servico;
                txtPrecoBase.Text = selecionado.Preco_base.ToString();
                txtUnidades.Text = selecionado.Unidades.HasValue ? selecionado.Unidades.Value.ToString() : "";
                listaConsumos.Clear();  // Opcional: carregar consumos reais se necessário
            }
        }

        private void LimparCampos()
        {
            txtNomeServico.Clear();
            txtPrecoBase.Clear();
            txtUnidades.Clear();
            listaConsumos.Clear();
        }

        private void listBoxServicos_SelectedIndexChanged_1(object sender, EventArgs e) { } // mantido vazio
    }

    public class LinhaConsumoServico
    {
        public int ID_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public int Unidades { get; set; }
    }
}
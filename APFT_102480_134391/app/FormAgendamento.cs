using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barbearia
{
    public partial class FormAgendamento : Form
    {
        private string connectionString = "data source=192.168.182.10;Initial Catalog=p3g1;User ID=p3g1;Password=BDRE2026.";
        private SqlConnection cn;

        
        private BindingList<LinhaAgendamento> listaServicosNoCarrinho = new BindingList<LinhaAgendamento>();

        public FormAgendamento()
        {
            InitializeComponent();
            dgvServicosAgendados.DataSource = listaServicosNoCarrinho;
        }

        // --- 1. AO CARREGAR O FORMULÁRIO ---
        private void FormAgendamento_Load(object sender, EventArgs e)
        {
            CarregarClientes();
            CarregarServicos();
            comboBoxEstado.SelectedIndex = 0;
            dtpDia.ValueChanged += dtpDia_ValueChanged;
            AtualizarBarbeirosPorEscalaEDisponibilidade();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null) cn = new SqlConnection(connectionString);
            if (cn.State != ConnectionState.Open) cn.Open();
            return cn.State == ConnectionState.Open;
        }

        
        private void dtpDia_ValueChanged(object sender, EventArgs e)
        {
            AtualizarBarbeirosPorEscalaEDisponibilidade();
        }

        // --- 2. PREENCHER AS COMBOBOXES ---
        private void CarregarClientes()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Clientes_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBoxClientes.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxClientes.Items.Add(new { Text = reader["Nome"].ToString(), Value = reader["ID_Cliente"] });
                    }
                    comboBoxClientes.DisplayMember = "Text";
                    comboBoxClientes.ValueMember = "Value";
                    reader.Close();
                }
            }
            finally { cn.Close(); }
        }


        private void AtualizarBarbeirosPorEscalaEDisponibilidade()
        {
            if (!verifySGBDConnection()) return;
            string diaSemana = dtpDia.Value.ToString("dddd", new System.Globalization.CultureInfo("pt-PT"));
            diaSemana = char.ToUpper(diaSemana[0]) + diaSemana.Substring(1);
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Barbeiros_GetByDiaSemana", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiaSemana", diaSemana);
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBoxBarbeiros.Items.Clear();
                    comboBoxBarbeiros.Text = "";
                    while (reader.Read())
                    {
                        comboBoxBarbeiros.Items.Add(new { Text = reader["Nome"].ToString(), Value = reader["ID_Barbeiro"] });
                    }
                    comboBoxBarbeiros.DisplayMember = "Text";
                    comboBoxBarbeiros.ValueMember = "Value";
                    reader.Close();
                }
                if (comboBoxBarbeiros.Items.Count == 0)
                    MessageBox.Show($"Aviso: Não existem barbeiros ativos escalados para {diaSemana}.", "Escala Vazia");
            }
            finally { cn.Close(); }
        }

        private void CarregarServicos()
        {
            if (!verifySGBDConnection()) return;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Servicos_GetActive", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBoxServicos.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxServicos.Items.Add(new
                        {
                            Text = reader["Nome_Servico"].ToString(),
                            Value = reader["ID_Servico"],
                            Preco = reader["Preco_base"]
                        });
                    }
                    comboBoxServicos.DisplayMember = "Text";
                    comboBoxServicos.ValueMember = "Value";
                    reader.Close();
                }
            }
            finally { cn.Close(); }
        }

        // --- 3. AO SELECIONAR UM SERVIÇO, MOSTRAR O PREÇO ---
        private void comboBoxServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServicos.SelectedItem != null)
            {
                dynamic servico = comboBoxServicos.SelectedItem;
                txtPrecoPraticado.Text = servico.Preco.ToString();
            }
        }


        // --- 4. ADICIONAR SERVIÇO À LISTA TEMPORÁRIA (DATAGRID) COM VALIDAÇÃO DE HORÁRIO ---
        private void btnAdicionarLinha_Click(object sender, EventArgs e)
        {
            if (comboBoxServicos.SelectedItem == null || comboBoxBarbeiros.SelectedItem == null)
            {
                MessageBox.Show("Selecione um serviço e um barbeiro disponível!");
                return;
            }

            dynamic serv = comboBoxServicos.SelectedItem;
            dynamic barb = comboBoxBarbeiros.SelectedItem;
            int idBarbeiro = barb.Value;
            TimeSpan horaSelecionada = dtpHora.Value.TimeOfDay;
            string diaSemana = dtpDia.Value.ToString("dddd", new System.Globalization.CultureInfo("pt-PT"));
            diaSemana = char.ToUpper(diaSemana[0]) + diaSemana.Substring(1);

            if (!verifySGBDConnection()) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Escala_GetHorario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Barbeiro", idBarbeiro);
                    cmd.Parameters.AddWithValue("@DiaSemana", diaSemana);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TimeSpan inicioTurno = (TimeSpan)reader["Hora_Inicio"];
                        TimeSpan fimTurno = (TimeSpan)reader["Hora_Fim"];
                        if (horaSelecionada < inicioTurno || horaSelecionada > fimTurno)
                        {
                            MessageBox.Show($"O barbeiro {barb.Text} não está disponível a esta hora!\nHorário: {inicioTurno:hh\\:mm} às {fimTurno:hh\\:mm}.",
                                            "Horário Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            reader.Close();
                            return;
                        }
                    }
                    reader.Close();
                }

                LinhaAgendamento linha = new LinhaAgendamento
                {
                    ID_Servico = serv.Value,
                    Nome_Servico = serv.Text,
                    ID_Barbeiro = idBarbeiro,
                    Nome_Barbeiro = barb.Text,
                    Preco_Praticado = Convert.ToDecimal(txtPrecoPraticado.Text)
                };
                listaServicosNoCarrinho.Add(linha);
            }
            catch (Exception ex) { MessageBox.Show("Erro ao validar horário: " + ex.Message); }
            finally { cn.Close(); }
        }

        // --- 5. O GRANDE FINAL: GRAVAR NAS DUAS TABELAS ---
        private void btnGravarAgendamento_Click(object sender, EventArgs e)
        {
            if (comboBoxClientes.SelectedItem == null || listaServicosNoCarrinho.Count == 0)
            {
                MessageBox.Show("Selecione um cliente e pelo menos um serviço!");
                return;
            }

            if (!verifySGBDConnection()) return;

            SqlTransaction transacao = cn.BeginTransaction();
            try
            {
                int novoIDAgendamento;

                // 1. Inserir cabeçalho e obter o ID
                using (SqlCommand cmd = new SqlCommand("sp_Agendamento_InsertCabecalho", cn, transacao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Cliente", ((dynamic)comboBoxClientes.SelectedItem).Value);
                    cmd.Parameters.AddWithValue("@Dia", dtpDia.Value.Date);
                    cmd.Parameters.AddWithValue("@Hora", dtpHora.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Estado", comboBoxEstado.Text);
                    cmd.Parameters.AddWithValue("@Observacoes", txtObservacoes.Text);

                    SqlParameter outputId = new SqlParameter("@ID_Agendamento", SqlDbType.Int);
                    outputId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputId);

                    cmd.ExecuteNonQuery();
                    novoIDAgendamento = (int)outputId.Value;
                }

                // 2. Inserir cada serviço
                foreach (var item in listaServicosNoCarrinho)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Agendamento_InsertServico", cn, transacao))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Agendamento", novoIDAgendamento);
                        cmd.Parameters.AddWithValue("@ID_Servico", item.ID_Servico);
                        cmd.Parameters.AddWithValue("@ID_Barbeiro", item.ID_Barbeiro);
                        cmd.Parameters.AddWithValue("@Preco_Praticado", item.Preco_Praticado);
                        cmd.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                MessageBox.Show("Agendamento realizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                MessageBox.Show("Erro ao agendar: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
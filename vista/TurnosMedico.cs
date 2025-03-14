using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class TurnosMedico : Form
    {
        private Usuario usuario;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private PanelPrincipal panelPrincipal;
        private ConsultaMedico consultaMedico;
        private Turno turnoSeleccionado = new Turno();
        public TurnosMedico(PanelPrincipal panelPrincipal, Usuario usuario)
        {
            InitializeComponent();
            this.panelPrincipal = panelPrincipal;
            this.usuario = usuario;
        }

        public TurnosMedico(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void TurnosMedico_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dataGridViewTurnosPendientes.Rows.Count < 1) btnAusente.Enabled = false;
            lblFechaActual.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal = new PanelPrincipal(usuario);
            panelPrincipal.Show();
            Hide();
        }

        private void LoadData()
        {
            string query = "EXECUTE spTurnos_del_dia @fecha, @id_medico";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@id_medico", IdMedico(usuario.Username));
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewTurnosPendientes.DataSource = dataTable;
                dataGridViewTurnosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void dataGridViewTurnosPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Turno turno = new Turno();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTurnosPendientes.Rows[e.RowIndex];
                turno.Id = Convert.ToInt32(row.Cells["id"].Value);
                turno.IdPaciente = IdPaciente(row.Cells["DNI"].Value.ToString());
                turno.FechaTurno = Convert.ToDateTime(row.Cells["Fecha de Turno"].Value);
                turno.IdHoraTurno = IdHorario(row.Cells["Horario de Turno"].Value.ToString());
                consultaMedico = new ConsultaMedico(usuario, turno);
                consultaMedico.Show();
                Hide();
                return;
            }

        }

        private int IdMedico(string dni)
        {
            string query = "SELECT id FROM medico WHERE dni = @dni;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private int IdPaciente(string dniPaciente)
        {
            string query = "SELECT id FROM paciente WHERE dni = @dniPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniPaciente", dniPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private int IdHorario(string horario)
        {
            string query = "SELECT id FROM horario_clinica WHERE horario = @horario;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@horario", horario);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private void dataGridViewTurnosPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTurnosPendientes.Rows[e.RowIndex];
                turnoSeleccionado.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                turnoSeleccionado.IdPaciente = IdPaciente(row.Cells["DNI"].Value.ToString());
                turnoSeleccionado.FechaTurno = Convert.ToDateTime(row.Cells["Fecha de Turno"].Value);
                turnoSeleccionado.IdHoraTurno = IdHorario(row.Cells["Horario de Turno"].Value.ToString());
            }
        }

        private void btnAusente_Click(object sender, EventArgs e)
        {
            string query = "UPDATE turno SET ausente = 'SI' WHERE id = @idTurno;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTurno", turnoSeleccionado.Id);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Turno marcado como ausente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadData();
        }

    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class HorariosMedicoAdmin : Form
    {

        private int idHorario;
        private string dia;
        private string dniMedico;
        private ModificarMedico modificarMedico;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public HorariosMedicoAdmin(ModificarMedico modificarMedico, string dniMedico)
        {
            InitializeComponent();
            this.dniMedico = dniMedico;
            this.modificarMedico = modificarMedico;
        }
        private void HorariosMedicoAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CargarHorarios()
        {
            cbHorarios.Items.Clear();
            string query = "SELECT id, horario FROM horario_clinica WHERE id NOT IN " +
                "(SELECT id_horario FROM horario_medico WHERE id_medico = @idMedico AND dia = @dia);";

            using (SqlConnection connection = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idMedico", IdMedico(dniMedico));
                cmd.Parameters.AddWithValue("@dia", cbDias.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TimeSpan horario = reader.GetTimeSpan(1);
                    cbHorarios.Items.Add(horario.ToString());
                }
            }
        }


        private int AgregarHorario()
        {
            string query = "INSERT INTO horario_medico (id_medico, dia, id_horario) VALUES (@id_medico, @dia, @id_horario);";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_medico", IdMedico(dniMedico));
                cmd.Parameters.AddWithValue("@dia", cbDias.Text);
                cmd.Parameters.AddWithValue("@id_horario", IdHorario(cbHorarios.Text));
                return cmd.ExecuteNonQuery();
            }
        }
         
        private int IdMedico(string dniMedico)
        {
            string query = "SELECT id FROM medico WHERE dni = @dni";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dniMedico);
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
            string query = "SELECT id FROM horario_clinica WHERE horario = @horario";
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            modificarMedico.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbDias.Text == "" && cbHorarios.Text == "")
            {
                MessageBox.Show("Seleccione un dia y un horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AgregarHorario();
            LoadData();
            CargarHorarios();
        }


        private void LoadData()
        {
            string query = "SELECT hm.dia, hc.horario, m.nombre, m.apellido FROM horario_medico hm " +
                "INNER JOIN horario_clinica hc ON hm.id_horario = hc.id INNER JOIN medico m ON hm.id_medico = m.id WHERE m.id = 0;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);

                dataAdapter.SelectCommand.Parameters.AddWithValue("@id_medico", IdMedico(dniMedico));
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewHorariosMedico.DataSource = dataTable;
                dataGridViewHorariosMedico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewHorariosMedico.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EliminarHorario();
            LoadData();
            CargarHorarios();
        }

        private int EliminarHorario()
        {
            string query = "DELETE FROM horario_medico WHERE id_medico = @id_medico AND dia = @dia AND id_horario = @id_horario;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_medico", IdMedico(dniMedico));
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@id_horario", idHorario);
                return cmd.ExecuteNonQuery();
            }
        }

        private void dataGridViewHorariosMedico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewHorariosMedico.Rows[e.RowIndex];
                dia = row.Cells["dia"].Value.ToString();
                idHorario = IdHorario(row.Cells["horario"].Value.ToString());
                return;
            }
        }

        private void cbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHorarios.Items.Clear();
            CargarHorarios();
        }

    }
}

using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class ReagendarTurno : Form
    {

        private int idPaciente;
        private List<int> idTurnos = new List<int>();
        private int turnoSeleccionado;
        public ReagendarTurno(int idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (cbTurnos.Text == "")
            {
                MessageBox.Show("Seleccione un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbHorario.Text == "")
            {
                MessageBox.Show("Seleccione un horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Turno turno = new Turno(turnoSeleccionado, pFecha.Value.Date, IdHorario(cbHorario.Text, IdMedico(turnoSeleccionado)));

            if (Reagendar(turno) > 0)
            {
                MessageBox.Show("Turno reagendado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }

        private void ReagendarTurno_Load(object sender, EventArgs e)
        {
            pFecha.Value = DateTime.Now;
            CargarHorariosDisponibles(pFecha.Value, IdMedico(turnoSeleccionado));
            Turnos(idPaciente);
        }

        private void Turnos(int idPaciente)
        {
            string query = "SELECT t.id, CONCAT('Dr. ', m.apellido, ', ', m.nombre) " +
                        "AS medico, e.nombre AS especialidad, t.fecha_turno AS fecha FROM turno t " +
                        "INNER JOIN paciente p ON t.id_paciente = p.id " +
                        "INNER JOIN medico m ON t.id_medico = m.id " +
                        "INNER JOIN especialidad e ON m.id_especialidad = e.id " +
                        "WHERE t.id_paciente = @idPaciente AND t.cancelado = 'NO' AND t.atendido = 'NO' AND t.ausente = 'NO';";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                cbTurnos.Items.Clear();
                while (reader.Read())
                {
                    idTurnos.Add(reader.GetInt32(0));
                    cbTurnos.Items.Add(reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetDateTime(3).ToString("dd/MM/yyyy"));
                }
            }
        }


        private int Reagendar(Turno turno)
        {
            string query = "UPDATE turno SET fecha_turno = @fechaTurno, id_horario = @horaTurno WHERE id = @idTurno;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fechaTurno", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@horaTurno", turno.IdHoraTurno);
                cmd.Parameters.AddWithValue("@idTurno", turno.Id);
                return cmd.ExecuteNonQuery();
            }
        }


        private void CargarHorariosDisponibles(DateTime fecha, int idMedico)
        {
            string dia = ObtenerDiaSemana(pFecha.Value);

            string query = "SELECT hc.horario FROM horario_medico hm " +
                "JOIN horario_clinica hc ON hm.id_horario = hc.id " +
                "LEFT JOIN turno t ON hm.id = t.id_horario AND t.id_medico = hm.id_medico " +
                "AND t.fecha_turno = @fecha AND t.cancelado = 'NO' WHERE hm.id_medico = @idMedico " +
                "AND hm.dia = @dia AND t.id IS NULL ORDER BY hc.horario;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                cmd.Parameters.AddWithValue("@idMedico", idMedico);
                cmd.Parameters.AddWithValue("@dia", dia);
                SqlDataReader reader = cmd.ExecuteReader();
                cbHorario.Items.Clear();
                while (reader.Read())
                {
                    TimeSpan horario = reader.GetTimeSpan(0);
                    cbHorario.Items.Add(horario.ToString(@"hh\:mm"));
                }
            }
        }


        private void pFecha_ValueChanged(object sender, EventArgs e)
        {
            cbHorario.SelectedIndex = -1;
            if (pFecha.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("No se pueden agendar turnos en domingo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Compare(pFecha.Value.Date, DateTime.Now.Date) < 0)
            {
                MessageBox.Show("No se pueden reagendar turnos anteriores a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarHorariosDisponibles(pFecha.Value, IdMedico(turnoSeleccionado));
        }

        private void cbTurnos_TextChanged(object sender, EventArgs e)
        {
            CargarHorariosDisponibles(pFecha.Value, IdMedico(turnoSeleccionado));
        }

        private int IdHorario(string horario, int idMedico)
        {
            string query = "SELECT hm.id FROM horario_medico hm " +
                "JOIN horario_clinica hc ON hm.id_horario = hc.id "
                + "WHERE hc.horario = @horario AND hm.id_medico = @idMedico;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@horario", horario);
                cmd.Parameters.AddWithValue("@idMedico", idMedico);
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

        private void cbTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            turnoSeleccionado = idTurnos[cbTurnos.SelectedIndex];
            CargarHorariosDisponibles(pFecha.Value, IdMedico(turnoSeleccionado));
        }

        string ObtenerDiaSemana(DateTime fecha)
        {
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Sunday: return "DOMINGO";
                case DayOfWeek.Monday: return "LUNES";
                case DayOfWeek.Tuesday: return "MARTES";
                case DayOfWeek.Wednesday: return "MIERCOLES";
                case DayOfWeek.Thursday: return "JUEVES";
                case DayOfWeek.Friday: return "VIERNES";
                case DayOfWeek.Saturday: return "SABADO";
                default: return "";
            }
        }

        private int IdMedico(int idTurno)
        {
            string query = "SELECT id_medico FROM turno WHERE id = @idTurno;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTurno", idTurno);
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
    }
}
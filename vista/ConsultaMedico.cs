using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class ConsultaMedico : Form
    {
        private Usuario usuario;
        private Turno turno;
        private TurnosMedico turnosMedico;
        public ConsultaMedico(Usuario usuario, Turno turno)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.turno = turno;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(AgregarAHistoriaClinica() > 0)
            {
                MessageBox.Show("Historia clinica ingresada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                turnosMedico = new TurnosMedico(usuario);
                turnosMedico.Show();
                Hide();
            }
        }
        private void ConsultaMedico_Load(object sender, EventArgs e)
        {
            txtDni.Text = DniPaciente(turno.IdPaciente);
            txtPaciente.Text = Paciente(turno.IdPaciente);
            txtObraSocial.Text = ObraSocial(turno.IdPaciente);
        }

        private string ObtenerDiaSemana(DateTime fecha)
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

        private int IdPaciente(string dniPaciente)
        {
            string query = "SELECT id FROM paciente WHERE dni = @dniPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniPaciente", dniPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int IdMedico(string dniMedico)
        {
            string query = "SELECT id FROM medico WHERE dni = @dniMedico;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniMedico", dniMedico);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int AgregarAHistoriaClinica()
        {
            string query = "INSERT INTO historia_clinica (id_paciente, id_medico, id_turno, diagnostico)" +
                " VALUES (@idPaciente, @idMedico, @idTurno, @diagnostico);" +
                "UPDATE turno SET atendido = 'SI' WHERE id = @idTurno;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", IdPaciente(txtDni.Text));
                cmd.Parameters.AddWithValue("@idMedico", IdMedico(usuario.Username));
                cmd.Parameters.AddWithValue("@idTurno", turno.Id);
                cmd.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
                return cmd.ExecuteNonQuery();
            }
        }


        private string DniPaciente(int idPaciente)
        {
            string query = "SELECT dni FROM paciente WHERE id = @idPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                return "";
            }
        }

        private string Paciente(int idPaciente)
        {
            string query = "SELECT CONCAT(apellido, ', ', nombre) FROM paciente WHERE id = @idPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                return "";
            }
        }

        private string ObraSocial(int idPaciente)
        {
            string query = "SELECT os.nombre FROM paciente p INNER JOIN obra_social os " +
                "ON p.id_obra_social = os.id WHERE p.id = @idPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                return "";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            turnosMedico = new TurnosMedico(usuario);
            turnosMedico.Show();
            Hide();
        }
    }
}

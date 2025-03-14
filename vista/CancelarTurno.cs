using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class CancelarTurno : Form
    {
        private int idPaciente;
        private List<Int32> idTurnos = new List<Int32>();
        private int turnoSeleccionado;
        public CancelarTurno(int idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
        }

        private void Turnos(int idPaciente)
        {
            string query = "SELECT t.id, CONCAT(m.apellido, ', ', m.nombre) " +
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
                while (reader.Read())
                {
                    idTurnos.Add(reader.GetInt32(0));
                    cbTurnos.Items.Add(reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetDateTime(3).ToString("dd/MM/yyyy"));
                }
            }
        }

        private int Cancelar(int idTurno)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "UPDATE turno SET cancelado = 'SI' WHERE id = @id_turno";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_turno", idTurno);
                return cmd.ExecuteNonQuery();
            }
        }

        private void CancelarTurno_Load(object sender, EventArgs e)
        {
            Turnos(idPaciente);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cbTurnos.Text == "")
            {
                MessageBox.Show("Seleccione un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Cancelar(turnoSeleccionado) > 0)
            {
                MessageBox.Show("Turno cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cbTurnos_SelectedIndexChanged(object sender, EventArgs e)
        { 
            turnoSeleccionado = idTurnos[cbTurnos.SelectedIndex];
        }
    }
}

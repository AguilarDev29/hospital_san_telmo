using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using Final_TallerdeProgramacion_Aguilar_Juarez.vista;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    public partial class PanelPrincipal : Form
    {
        private PacienteUser ingresoPaciente;
        private TurnoUser turnoUser;
        private TurnosMedico turnosMedico;
        private HistoriaClinica historiaClinica;
        private IngresoMedicoAdmin ingresoMedicoAdmin;
        private Finanzas finanzas;
        private Planillas planillas;
        private Usuario usuario;




        public PanelPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        public PanelPrincipal()
        {
            InitializeComponent();
        }

        private void IngresoPaciente_Load(object sender, EventArgs e)
        {
            if (usuario.Rol == "USUARIO")
            {
                btnTurnos.Show();
                btnPacientes.Show();
                btnTurnosMedico.Hide();
                btnHistoriaClinica.Hide();
                btnCargarMedicos.Hide();
                btnFinanzas.Hide();
                btnPlanillas.Hide();
                lblNombreMedico.Hide();
            }

            if (usuario.Rol == "ADMIN")
            {
                btnCargarMedicos.Show();
                btnFinanzas.Show();
                btnPlanillas.Show();
                btnTurnosMedico.Hide();
                btnHistoriaClinica.Hide();
                btnTurnos.Hide();
                btnPacientes.Hide();
                lblNombreMedico.Hide();
            }

            if (usuario.Rol == "MEDICO")
            {
                btnTurnosMedico.Show();
                btnHistoriaClinica.Show();
                btnTurnos.Hide();
                btnPacientes.Hide();
                btnCargarMedicos.Hide();
                btnFinanzas.Hide();
                btnPlanillas.Hide();
                lblNombreMedico.Show();
                NombreMedico();
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.ExitThread();
                Dispose();
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            ingresoPaciente = new PacienteUser(this);
            ingresoPaciente.Show();
            Hide();
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            turnoUser = new TurnoUser(this);
            turnoUser.Show();
            Hide();
        }

        private void btnTurnosMedico_Click(object sender, EventArgs e)
        {
            turnosMedico = new TurnosMedico(this, usuario);
            turnosMedico.Show();
            Hide();
        }

        private void btnHistoriaClinica_Click(object sender, EventArgs e)
        {
            historiaClinica = new HistoriaClinica(this, usuario);
            historiaClinica.Show();
            Hide();
        }

        private void btnCargarMedicos_Click(object sender, EventArgs e)
        {
            ingresoMedicoAdmin = new IngresoMedicoAdmin(this);
            ingresoMedicoAdmin.Show();
            Hide();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            finanzas = new Finanzas(this);
            finanzas.Show();
            Hide();
        }

        private void btnPlanillas_Click(object sender, EventArgs e)
        {
            planillas = new Planillas(this);
            planillas.Show();
            Hide();
        }

        private void NombreMedico()
        {
            string query = "SELECT CONCAT('Dr. ', apellido, ', ', nombre) AS NombreCompleto FROM medico WHERE dni = @dni";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", usuario.Username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblNombreMedico.Text = reader.GetString(0);
                }
            }
        }

    }
}

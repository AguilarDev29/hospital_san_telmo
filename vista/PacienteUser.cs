using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class PacienteUser : Form
    {
        private PanelPrincipal panelPrincipal;
        private ModificarPaciente modificarPaciente;
        public PacienteUser(PanelPrincipal panelPrincipal)
        {
            InitializeComponent();
            CargarObraSocial();
            this.panelPrincipal = panelPrincipal;
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal.Show();
            Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            cbSexo.SelectedIndex = -1;
            txtDireccion.Clear();
            cbProvincia.SelectedIndex = -1;
            cbLocalidad.SelectedIndex = -1;
            txtTelefono.Clear();
            txtEmail.Clear();
            cbObraSocial.SelectedIndex = -1;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente(txtApellido.Text, txtNombre.Text, txtDni.Text,
                cbSexo.Text, txtDireccion.Text, IdProvincia(cbProvincia.Text), IdLocalidad(cbLocalidad.Text),
                pFechaNac.Value, txtTelefono.Text, txtEmail.Text, IdObraSocial(cbObraSocial.Text));

            if (ValidarDni(paciente.Dni) > 0)
            {
                MessageBox.Show("El DNI ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IngresarPaciente(paciente) > 0) MessageBox.Show("Paciente ingresado con exito",
                                                "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLimpiar_Click(sender, e);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarPaciente = new ModificarPaciente(this);
            modificarPaciente.Show();
            Hide();
        }
        private void PacienteUser_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarLocalidades();
        }

        private void CargarObraSocial()
        {
            string query = "SELECT id, nombre FROM obra_social";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbObraSocial.Items.Add(reader.GetString(1));
                }
            }
        }

        private int IdObraSocial(string obraSocial)
        {
            string query = "SELECT id FROM obra_social WHERE nombre = @obraSocial;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@obraSocial", obraSocial);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) return reader.GetInt32(0);
                else return -1;
            }
        }
        private int IngresarPaciente(Paciente paciente)
        {
            string query = "INSERT INTO paciente (apellido, nombre, dni, sexo, direccion, id_provincia, id_localidad," +
                " fecha_nac, telefono, email, id_obra_social) " +
                "VALUES (@apellido, @nombre, @dni, @sexo, @direccion," +
                " @provincia, @localidad, @fechaNac," +
                " @telefono, @email, @obraSocial)";
            try
            {
                using (SqlConnection conn = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@dni", paciente.Dni);
                    cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                    cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@provincia", paciente.IdProvincia);
                    cmd.Parameters.AddWithValue("@localidad", paciente.IdLocalidad);
                    cmd.Parameters.AddWithValue("@fechaNac", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@email", paciente.Email);
                    cmd.Parameters.AddWithValue("@obraSocial", paciente.IdObraSocial);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Los campos no pueden estar vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }

        private int ValidarDni(string dni)
        {
            string query = "SELECT COUNT(*) FROM paciente WHERE dni = @dni;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void CargarProvincias()
        {
            string query = "SELECT nombre FROM provincia;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbProvincia.Items.Add(reader.GetString(0));
                }
            }
        }

        private void FiltrarLocalidades()
        {
            string query = "SELECT l.nombre FROM localidad l INNER JOIN provincia p ON p.id = l.id_provincia WHERE p.nombre = @nombre;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", cbProvincia.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                cbLocalidad.Items.Clear();

                while (reader.Read())
                {
                    cbLocalidad.Items.Add(reader.GetString(0));
                }

            }
        }

        private int IdProvincia(string nombre)
        {
            string query = "SELECT id FROM provincia WHERE nombre = @nombre";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
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

        private int IdLocalidad(string nombre)
        {
            string query = "SELECT id FROM localidad WHERE nombre = @nombre";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
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

        private void txtApellido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtApellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El apellido debe ser unicamente compuesto por letras",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Clear();
                txtApellido.Focus();
            }
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtNombre.Text.All(char.IsLetter))
            {
                MessageBox.Show("El nombre debe ser unicamente compuesto por letras",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
            }
        }

        private void txtDni_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtDni.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe ser unicamente compuesto por numeros",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
            }
        }

        private void txtTelefono_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!ValidarTelefonoOpcional(txtTelefono.Text))
            {
                e.Cancel = true; // Cancela el evento de validación
                MessageBox.Show("Número de telefono no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidarEmailOpcional(txtEmail.Text))
            {
                e.Cancel = true; // Cancela el evento de validación
                MessageBox.Show("Correo electrónico no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }

        public static bool ValidarTelefonoOpcional(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return true;

            try
            {
                string pattern = @"^(?:(?:(?:0?([1-9]\d{0,3}))|([1-9]\d{0,3}))\d{6,8})?$";
                return Regex.IsMatch(telefono, pattern);

            }catch(ArgumentException ex)
            {
                return false;
            }
        }

        public static bool ValidarEmailOpcional(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            try
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

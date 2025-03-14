using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class IngresoMedicoAdmin : Form
    {
        private PanelPrincipal panelPrincipal;
        private ModificarMedico modificarMedico;
        private BajaMedico bajaMedico;
        public IngresoMedicoAdmin(PanelPrincipal panelPrincipal)
        {
            InitializeComponent();
            this.panelPrincipal = panelPrincipal;
        }

        public IngresoMedicoAdmin()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal.Show();
            Hide();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico(txtApellido.Text, txtNombre.Text, txtDni.Text, cbSexo.Text, txtDireccion.Text, IdProvincia(cbProvincia.Text),
                IdLocalidad(cbLocalidad.Text), pFechaNac.Value, txtTelefono.Text, txtEmail.Text, IdEspecialidad(cbEspecialidad.Text), Convert.ToDecimal(txtPlus.Text));

            if (ValidarDni(medico.Dni) > 0)
            {
                MessageBox.Show("El DNI ingresado ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CargarMedico(medico) > 0)
            {
                MessageBox.Show("Medico ingresado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HashearContraseña(medico);
                btnLimpiar_Click(sender, e);
            }

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarMedico = new ModificarMedico(this);
            modificarMedico.Show();
            Hide();
        }

        private void CargarMedico_Load(object sender, EventArgs e)
        {
            CargarEspecialidad();
            CargarProvincias();

        }


        private int CargarMedico(Medico medico)
        {
            string query = "INSERT INTO medico (apellido, nombre, dni, sexo ,direccion, id_provincia, id_localidad, fecha_nac, telefono, email, id_especialidad, plus)" +
                " VALUES (@apellido, @nombre, @dni, @sexo, @direccion, @id_provincia, @id_localidad, @fecha_nac, @telefono, @email, @id_especialidad, @plus);";
            try
            {

                using (SqlConnection conn = Conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@apellido", medico.Apellido);
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombre);
                    cmd.Parameters.AddWithValue("@dni", medico.Dni);
                    cmd.Parameters.AddWithValue("@sexo", medico.Sexo);
                    cmd.Parameters.AddWithValue("@direccion", medico.Direccion);
                    cmd.Parameters.AddWithValue("@id_provincia", medico.IdProvincia);
                    cmd.Parameters.AddWithValue("@id_localidad", medico.IdLocalidad);
                    cmd.Parameters.AddWithValue("@fecha_nac", medico.FechaNac);
                    cmd.Parameters.AddWithValue("@telefono", medico.Telefono);
                    cmd.Parameters.AddWithValue("@email", medico.Email);
                    cmd.Parameters.AddWithValue("@id_especialidad", medico.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@plus", medico.Plus);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Los campos no pueden estar vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void CargarEspecialidad()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT nombre FROM especialidad;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbEspecialidad.Items.Add(reader.GetString(0));
                }
            }
        }
        private int IdEspecialidad(string especialidad)
        {
            string query = "SELECT id FROM especialidad WHERE nombre = @especialidad;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            cbSexo.SelectedIndex = -1;
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            cbProvincia.SelectedIndex = -1;
            cbLocalidad.SelectedIndex = -1;
            cbEspecialidad.SelectedIndex = -1;
            txtPlus.Clear();
        }

        private void HashearContraseña(Medico medico)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "UPDATE usuario SET clave = @clave WHERE usuario = @usuario;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clave", BCrypt.Net.BCrypt.HashPassword(medico.Dni));
                cmd.Parameters.AddWithValue("@usuario", medico.Dni);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            bajaMedico = new BajaMedico();
            bajaMedico.Show();
        }

        private int ValidarDni(string dni)
        {
            string query = "SELECT COUNT(*) FROM medico WHERE dni = @dni;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                return (int)cmd.ExecuteScalar();
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

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarLocalidades();
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

        private void txtApellido_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtApellido.Text.All(char.IsLetter))
            {
                MessageBox.Show("El apellido debe ser unicamente compuesto por letras",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void txtPlus_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtPlus.Text.All(char.IsDigit))
            {

                MessageBox.Show("El campo plus debe ser unicamente compuesto por numeros", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlus.Focus();
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

            }
            catch (ArgumentException ex)
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

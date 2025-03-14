using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    public partial class Login : Form
    {
        private int intentos = 0;
        public Login()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }


        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == "" || txtContrasenia.Text == "")
            {
                MessageBox.Show("Los campos no pueden estar vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarUsuario(txtusuario.Text, txtContrasenia.Text, this))
            {
                intentos++;
                if (intentos == 3)
                {
                    MessageBox.Show("Ha superado el número de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearUsuario(txtusuario.Text);
                    Dispose();
                }
            }
        }

        public static bool ValidarUsuario(string username, string password, Login login)
        {
            Usuario usuario = ObtenerUsuario(username);
            PanelPrincipal panelPrincipal;


            if (usuario != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, usuario.Password))
                {
                    if (usuario.Rol == "USUARIO")
                    {
                        panelPrincipal = new PanelPrincipal(usuario);
                        login.Hide();
                        panelPrincipal.Show();
                    }

                    if (usuario.Rol == "ADMIN")
                    {
                        panelPrincipal = new PanelPrincipal(usuario);
                        login.Hide();
                        panelPrincipal.Show();
                    }

                    if (usuario.Rol == "MEDICO")
                    {
                        panelPrincipal = new PanelPrincipal(usuario);
                        login.Hide();
                        panelPrincipal.Show();


                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private static Usuario ObtenerUsuario(string username)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT usuario, clave, rol, activo FROM usuario WHERE usuario = @username AND activo = 1", conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) return new Usuario(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), true); else return null;
            }
        }

        private void BloquearUsuario(string username)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand("UPDATE usuario SET activo = 0 WHERE usuario = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.controlador
{
    internal class LoginControlador
    {


        public static void ValidarUsuario(string username, string password, Login login)
        {
            Usuario usuario = ObtenerUsuario(username);
            IngresoPaciente ingresoPaciente = new IngresoPaciente();

            if (usuario != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, usuario.Password))
                {
                    login.Hide();
                    ingresoPaciente.Show();
                }
                else MessageBox.Show("Credenciales incorrectas");
            }
            else MessageBox.Show("Usuario no encontrado");
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
    }
}

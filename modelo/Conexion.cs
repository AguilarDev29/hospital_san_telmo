using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    internal class Conexion
    {
        private const string URL = "Server=matias\\SQLEXPRESS;Database=hospital_san_telmo;User Id=root;Password=42664539;TrustServerCertificate=True;";

        public static SqlConnection Conectar()
        {
            SqlConnection conn = new SqlConnection(URL);
            if (conn.State == ConnectionState.Closed) conn.Open();
            return conn;
        }
    }
}

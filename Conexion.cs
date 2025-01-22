using System;
using System.Collections.Generic;
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
        public static void Conectar()
        {
            const string URL = "Server=MATIAS\\SQLEXPRESS;Database=hospital_san_telmo;Trusted_Connection=True;";
            DbConnection conn = new SqlConnection(URL);
            try
            {
                conn.Open();
                
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

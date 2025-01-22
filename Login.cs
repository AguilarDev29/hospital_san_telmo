using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnsalir1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
    }
}

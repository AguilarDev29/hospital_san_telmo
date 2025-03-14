using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class HistoriaClinica : Form
    {
        private Usuario usuario;
        private SqlDataAdapter dataAdapter;
        private System.Data.DataTable dataTable;
        private PanelPrincipal panelPrincipal;
        public HistoriaClinica(PanelPrincipal panelPrincipal, Usuario usuario)
        {
            InitializeComponent();
            this.panelPrincipal = panelPrincipal;
            this.usuario = usuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal = new PanelPrincipal(usuario);
            panelPrincipal.Show();
            Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = "EXECUTE spListar_historia_clinica @dni_paciente;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@dni_paciente", txtDni.Text);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewHistoriaClinica.DataSource = dataTable;
                dataGridViewHistoriaClinica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void txtDni_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtDni.Text.All(char.IsDigit)) MessageBox.Show("El DNI debe ser unicamente compuesto por numeros",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

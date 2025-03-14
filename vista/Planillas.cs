using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class Planillas : Form
    {
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        private PanelPrincipal panelPrincipal;
        public Planillas(PanelPrincipal panelPrincipal)
        {
            InitializeComponent();
            this.panelPrincipal = panelPrincipal;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal.Show();
            Hide();
        }

        private void LoadData(string view, DataGridView dataGridView)
        {
            string query = $"SELECT * FROM {view};";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void Planillas_Load(object sender, EventArgs e)
        {
            LoadData("vista_turnos_pendientes", dataGridViewTurnos);
            LoadData("vista_pacientes", dataGridViewPacientes);
            LoadData("vista_medicos", dataGridViewMedicos);
        }
    }
}

using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class Finanzas : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private PanelPrincipal panelPrincipal;

        public Finanzas(PanelPrincipal panelPrincipal)
        {
            InitializeComponent();
            this.panelPrincipal = panelPrincipal;
        }

        private void Finanzas_Load(object sender, EventArgs e)
        {
            cbMedico.SelectedIndex = 0;
            cbEspecialidad.SelectedIndex = 0;
            CargarMedico();
            CargarEspecialidad();
            FiltrarDatos();
        }

        private void LoadData(DateTime fechaInicio, DateTime fechaFin, string medico = "", string especialidad = "")
        {
            string query = "EXECUTE spFiltrar_pagos @fecha_inicio, @fecha_fin, @medico, @especialidad;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@fecha_inicio", fechaInicio);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@fecha_fin", fechaFin);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@medico", string.IsNullOrEmpty(medico) ? (object)DBNull.Value : medico);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@especialidad", string.IsNullOrEmpty(especialidad) ? (object)DBNull.Value : especialidad);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewFinanzas.DataSource = dataTable;
                dataGridViewFinanzas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void FiltrarDatos()
        {
            DateTime fechaInicio = pFechaDesde.Value;
            DateTime fechaFin = pFechaHasta.Value;
            string medico = cbMedico.Text;
            string especialidad = cbEspecialidad.Text;

            LoadData(fechaInicio, fechaFin, medico, especialidad);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelPrincipal.Show();
            Hide();
        }

        private void pFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void pFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void ExportarAExcel()
        {
            if (dataGridViewFinanzas.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dataGridViewFinanzas.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dataGridViewFinanzas.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";
                saveFileDialog.FileName = $"Reporte_Finanzas_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Datos");
                            wb.SaveAs(filePath);
                        }

                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void CargarMedico()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT CONCAT('Dr. ', apellido, ', ', nombre) FROM medico WHERE activo = 1;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbMedico.Items.Add(reader.GetString(0));
                }
            }
        }
    }
}


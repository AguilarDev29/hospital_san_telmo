namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    partial class TurnosMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dataGridViewTurnosPendientes = new System.Windows.Forms.DataGridView();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.btnAusente = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTurnosPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(793, 382);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(99, 35);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dataGridViewTurnosPendientes
            // 
            this.dataGridViewTurnosPendientes.AllowUserToAddRows = false;
            this.dataGridViewTurnosPendientes.AllowUserToDeleteRows = false;
            this.dataGridViewTurnosPendientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTurnosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTurnosPendientes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTurnosPendientes.Name = "dataGridViewTurnosPendientes";
            this.dataGridViewTurnosPendientes.Size = new System.Drawing.Size(749, 446);
            this.dataGridViewTurnosPendientes.TabIndex = 3;
            this.dataGridViewTurnosPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTurnosPendientes_CellClick);
            this.dataGridViewTurnosPendientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTurnosPendientes_CellDoubleClick);
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.Location = new System.Drawing.Point(786, 24);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(66, 24);
            this.lblFechaActual.TabIndex = 4;
            this.lblFechaActual.Text = "label1";
            // 
            // btnAusente
            // 
            this.btnAusente.AccessibleDescription = "";
            this.btnAusente.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnAusente.Font = new System.Drawing.Font("Georgia", 14.25F);
            this.btnAusente.Location = new System.Drawing.Point(781, 162);
            this.btnAusente.Name = "btnAusente";
            this.btnAusente.Size = new System.Drawing.Size(120, 77);
            this.btnAusente.TabIndex = 5;
            this.btnAusente.Text = "Paciente ausente";
            this.toolTip1.SetToolTip(this.btnAusente, "Marca el turno seleccionado como ausente");
            this.btnAusente.UseVisualStyleBackColor = true;
            this.btnAusente.Click += new System.EventHandler(this.btnAusente_Click);
            // 
            // TurnosMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Dark_Green_and_Cream_Simple_Dark_Real_Estate_Bio_Link_Website__3_;
            this.ClientSize = new System.Drawing.Size(903, 470);
            this.ControlBox = false;
            this.Controls.Add(this.btnAusente);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.dataGridViewTurnosPendientes);
            this.Controls.Add(this.btnVolver);
            this.Name = "TurnosMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital San Telmo";
            this.Load += new System.EventHandler(this.TurnosMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTurnosPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dataGridViewTurnosPendientes;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.Button btnAusente;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
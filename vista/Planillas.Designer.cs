namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    partial class Planillas
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.turnos = new System.Windows.Forms.TabPage();
            this.dataGridViewTurnos = new System.Windows.Forms.DataGridView();
            this.pacientes = new System.Windows.Forms.TabPage();
            this.dataGridViewPacientes = new System.Windows.Forms.DataGridView();
            this.medicos = new System.Windows.Forms.TabPage();
            this.dataGridViewMedicos = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.turnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTurnos)).BeginInit();
            this.pacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacientes)).BeginInit();
            this.medicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.turnos);
            this.tabControl1.Controls.Add(this.pacientes);
            this.tabControl1.Controls.Add(this.medicos);
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // turnos
            // 
            this.turnos.Controls.Add(this.dataGridViewTurnos);
            this.turnos.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnos.Location = new System.Drawing.Point(4, 32);
            this.turnos.Name = "turnos";
            this.turnos.Padding = new System.Windows.Forms.Padding(3);
            this.turnos.Size = new System.Drawing.Size(743, 390);
            this.turnos.TabIndex = 0;
            this.turnos.Text = "Turnos:";
            this.turnos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTurnos
            // 
            this.dataGridViewTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTurnos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTurnos.Name = "dataGridViewTurnos";
            this.dataGridViewTurnos.Size = new System.Drawing.Size(743, 390);
            this.dataGridViewTurnos.TabIndex = 0;
            // 
            // pacientes
            // 
            this.pacientes.Controls.Add(this.dataGridViewPacientes);
            this.pacientes.Location = new System.Drawing.Point(4, 32);
            this.pacientes.Name = "pacientes";
            this.pacientes.Padding = new System.Windows.Forms.Padding(3);
            this.pacientes.Size = new System.Drawing.Size(743, 390);
            this.pacientes.TabIndex = 1;
            this.pacientes.Text = "Pacientes:";
            this.pacientes.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPacientes
            // 
            this.dataGridViewPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacientes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPacientes.Name = "dataGridViewPacientes";
            this.dataGridViewPacientes.Size = new System.Drawing.Size(743, 390);
            this.dataGridViewPacientes.TabIndex = 0;
            // 
            // medicos
            // 
            this.medicos.Controls.Add(this.dataGridViewMedicos);
            this.medicos.Location = new System.Drawing.Point(4, 32);
            this.medicos.Name = "medicos";
            this.medicos.Padding = new System.Windows.Forms.Padding(3);
            this.medicos.Size = new System.Drawing.Size(743, 390);
            this.medicos.TabIndex = 2;
            this.medicos.Text = "Medicos:";
            this.medicos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMedicos
            // 
            this.dataGridViewMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMedicos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMedicos.Name = "dataGridViewMedicos";
            this.dataGridViewMedicos.Size = new System.Drawing.Size(743, 390);
            this.dataGridViewMedicos.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnVolver.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(789, 368);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(83, 37);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Planillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Dark_Green_and_Cream_Simple_Dark_Real_Estate_Bio_Link_Website__3_;
            this.ClientSize = new System.Drawing.Size(882, 443);
            this.ControlBox = false;
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.tabControl1);
            this.Name = "Planillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital San Telmo";
            this.Load += new System.EventHandler(this.Planillas_Load);
            this.tabControl1.ResumeLayout(false);
            this.turnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTurnos)).EndInit();
            this.pacientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacientes)).EndInit();
            this.medicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage turnos;
        private System.Windows.Forms.TabPage pacientes;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TabPage medicos;
        private System.Windows.Forms.DataGridView dataGridViewTurnos;
        private System.Windows.Forms.DataGridView dataGridViewPacientes;
        private System.Windows.Forms.DataGridView dataGridViewMedicos;
    }
}
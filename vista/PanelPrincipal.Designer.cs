namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    partial class PanelPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnTurnosMedico = new System.Windows.Forms.Button();
            this.btnHistoriaClinica = new System.Windows.Forms.Button();
            this.btnFinanzas = new System.Windows.Forms.Button();
            this.btnPlanillas = new System.Windows.Forms.Button();
            this.btnCargarMedicos = new System.Windows.Forms.Button();
            this.lblNombreMedico = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Location = new System.Drawing.Point(793, 513);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 51);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(793, 23);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(111, 59);
            this.btnPacientes.TabIndex = 17;
            this.btnPacientes.Text = "Cargar pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnTurnos
            // 
            this.btnTurnos.Location = new System.Drawing.Point(793, 134);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(111, 65);
            this.btnTurnos.TabIndex = 18;
            this.btnTurnos.Text = "Agendar Turnos";
            this.btnTurnos.UseVisualStyleBackColor = true;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            // 
            // btnTurnosMedico
            // 
            this.btnTurnosMedico.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurnosMedico.Location = new System.Drawing.Point(793, 24);
            this.btnTurnosMedico.Name = "btnTurnosMedico";
            this.btnTurnosMedico.Size = new System.Drawing.Size(111, 59);
            this.btnTurnosMedico.TabIndex = 20;
            this.btnTurnosMedico.Text = "Turnos del dia";
            this.btnTurnosMedico.UseVisualStyleBackColor = true;
            this.btnTurnosMedico.Click += new System.EventHandler(this.btnTurnosMedico_Click);
            // 
            // btnHistoriaClinica
            // 
            this.btnHistoriaClinica.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoriaClinica.Location = new System.Drawing.Point(793, 134);
            this.btnHistoriaClinica.Name = "btnHistoriaClinica";
            this.btnHistoriaClinica.Size = new System.Drawing.Size(111, 65);
            this.btnHistoriaClinica.TabIndex = 19;
            this.btnHistoriaClinica.Text = "Historia Clinica";
            this.btnHistoriaClinica.UseVisualStyleBackColor = true;
            this.btnHistoriaClinica.Click += new System.EventHandler(this.btnHistoriaClinica_Click);
            // 
            // btnFinanzas
            // 
            this.btnFinanzas.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnFinanzas.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanzas.Location = new System.Drawing.Point(793, 134);
            this.btnFinanzas.Name = "btnFinanzas";
            this.btnFinanzas.Size = new System.Drawing.Size(111, 65);
            this.btnFinanzas.TabIndex = 23;
            this.btnFinanzas.Text = "Visualizar Finanzas";
            this.btnFinanzas.UseVisualStyleBackColor = false;
            this.btnFinanzas.Click += new System.EventHandler(this.btnFinanzas_Click);
            // 
            // btnPlanillas
            // 
            this.btnPlanillas.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnPlanillas.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanillas.Location = new System.Drawing.Point(793, 250);
            this.btnPlanillas.Name = "btnPlanillas";
            this.btnPlanillas.Size = new System.Drawing.Size(111, 63);
            this.btnPlanillas.TabIndex = 22;
            this.btnPlanillas.Text = "Visualizar Planillas";
            this.btnPlanillas.UseVisualStyleBackColor = false;
            this.btnPlanillas.Click += new System.EventHandler(this.btnPlanillas_Click);
            // 
            // btnCargarMedicos
            // 
            this.btnCargarMedicos.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCargarMedicos.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMedicos.Location = new System.Drawing.Point(793, 25);
            this.btnCargarMedicos.Name = "btnCargarMedicos";
            this.btnCargarMedicos.Size = new System.Drawing.Size(111, 58);
            this.btnCargarMedicos.TabIndex = 21;
            this.btnCargarMedicos.Text = "Cargar Medicos";
            this.btnCargarMedicos.UseVisualStyleBackColor = false;
            this.btnCargarMedicos.Click += new System.EventHandler(this.btnCargarMedicos_Click);
            // 
            // lblNombreMedico
            // 
            this.lblNombreMedico.AutoSize = true;
            this.lblNombreMedico.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreMedico.Font = new System.Drawing.Font("Georgia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMedico.Location = new System.Drawing.Point(155, 363);
            this.lblNombreMedico.Name = "lblNombreMedico";
            this.lblNombreMedico.Size = new System.Drawing.Size(0, 56);
            this.lblNombreMedico.TabIndex = 24;
            // 
            // PanelPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Dark_Green_and_Cream_Simple_Dark_Real_Estate_Bio_Link_Website__1_;
            this.ClientSize = new System.Drawing.Size(916, 593);
            this.ControlBox = false;
            this.Controls.Add(this.lblNombreMedico);
            this.Controls.Add(this.btnFinanzas);
            this.Controls.Add(this.btnPlanillas);
            this.Controls.Add(this.btnCargarMedicos);
            this.Controls.Add(this.btnTurnosMedico);
            this.Controls.Add(this.btnHistoriaClinica);
            this.Controls.Add(this.btnTurnos);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PanelPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital San Telmo";
            this.Load += new System.EventHandler(this.IngresoPaciente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnTurnosMedico;
        private System.Windows.Forms.Button btnHistoriaClinica;
        private System.Windows.Forms.Button btnFinanzas;
        private System.Windows.Forms.Button btnPlanillas;
        private System.Windows.Forms.Button btnCargarMedicos;
        private System.Windows.Forms.Label lblNombreMedico;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    partial class PacienteUser
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbObraSocial = new System.Windows.Forms.ComboBox();
            this.gbdatos = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.pFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbdatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(786, 260);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 51);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnVolver.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(786, 371);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(102, 51);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.toolTip1.SetToolTip(this.btnVolver, "Volver al menú principal");
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(786, 170);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 51);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.toolTip1.SetToolTip(this.btnModificar, "Ir a modificar datos del paciente");
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(786, 73);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 51);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.toolTip1.SetToolTip(this.btnGuardar, "Guardar paciente");
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(35, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNombre.Location = new System.Drawing.Point(124, 123);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(203, 27);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "D.N.I:";
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDni.Location = new System.Drawing.Point(124, 174);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.ShortcutsEnabled = false;
            this.txtDni.Size = new System.Drawing.Size(203, 27);
            this.txtDni.TabIndex = 2;
            this.txtDni.Validating += new System.ComponentModel.CancelEventHandler(this.txtDni_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sexo:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDireccion.Location = new System.Drawing.Point(532, 77);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(163, 27);
            this.txtDireccion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(412, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Direccion:";
            // 
            // cbSexo
            // 
            this.cbSexo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Items.AddRange(new object[] {
            "MASCULINO",
            "FEMENINO"});
            this.cbSexo.Location = new System.Drawing.Point(124, 224);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(203, 28);
            this.cbSexo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(412, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Localidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(412, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Telefono:";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtApellido.Location = new System.Drawing.Point(124, 74);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(203, 27);
            this.txtApellido.TabIndex = 0;
            this.txtApellido.Validating += new System.ComponentModel.CancelEventHandler(this.txtApellido_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(35, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(413, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtEmail.Location = new System.Drawing.Point(533, 272);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(162, 27);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(6, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 61);
            this.label8.TabIndex = 19;
            this.label8.Text = "Fecha de Nacimiento:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(412, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Obra Social:";
            // 
            // cbObraSocial
            // 
            this.cbObraSocial.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObraSocial.FormattingEnabled = true;
            this.cbObraSocial.Location = new System.Drawing.Point(532, 320);
            this.cbObraSocial.Name = "cbObraSocial";
            this.cbObraSocial.Size = new System.Drawing.Size(162, 28);
            this.cbObraSocial.TabIndex = 10;
            // 
            // gbdatos
            // 
            this.gbdatos.BackColor = System.Drawing.Color.Transparent;
            this.gbdatos.Controls.Add(this.label12);
            this.gbdatos.Controls.Add(this.label11);
            this.gbdatos.Controls.Add(this.cbLocalidad);
            this.gbdatos.Controls.Add(this.pFechaNac);
            this.gbdatos.Controls.Add(this.cbProvincia);
            this.gbdatos.Controls.Add(this.label10);
            this.gbdatos.Controls.Add(this.cbObraSocial);
            this.gbdatos.Controls.Add(this.label9);
            this.gbdatos.Controls.Add(this.label8);
            this.gbdatos.Controls.Add(this.txtEmail);
            this.gbdatos.Controls.Add(this.label1);
            this.gbdatos.Controls.Add(this.label13);
            this.gbdatos.Controls.Add(this.txtApellido);
            this.gbdatos.Controls.Add(this.txtTelefono);
            this.gbdatos.Controls.Add(this.label7);
            this.gbdatos.Controls.Add(this.label6);
            this.gbdatos.Controls.Add(this.cbSexo);
            this.gbdatos.Controls.Add(this.label5);
            this.gbdatos.Controls.Add(this.txtDireccion);
            this.gbdatos.Controls.Add(this.label4);
            this.gbdatos.Controls.Add(this.txtDni);
            this.gbdatos.Controls.Add(this.label3);
            this.gbdatos.Controls.Add(this.txtNombre);
            this.gbdatos.Controls.Add(this.label2);
            this.gbdatos.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.gbdatos.Location = new System.Drawing.Point(12, 25);
            this.gbdatos.Name = "gbdatos";
            this.gbdatos.Size = new System.Drawing.Size(731, 397);
            this.gbdatos.TabIndex = 2;
            this.gbdatos.TabStop = false;
            this.gbdatos.Text = "Datos del Paciente";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(533, 302);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 9);
            this.label12.TabIndex = 26;
            this.label12.Text = "campo opcional";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(533, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 9);
            this.label11.TabIndex = 25;
            this.label11.Text = "campo opcional";
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(533, 175);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(161, 28);
            this.cbLocalidad.TabIndex = 7;
            // 
            // pFechaNac
            // 
            this.pFechaNac.Location = new System.Drawing.Point(127, 290);
            this.pFechaNac.Name = "pFechaNac";
            this.pFechaNac.Size = new System.Drawing.Size(200, 27);
            this.pFechaNac.TabIndex = 4;
            // 
            // cbProvincia
            // 
            this.cbProvincia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(533, 126);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(162, 28);
            this.cbProvincia.TabIndex = 6;
            this.cbProvincia.SelectedIndexChanged += new System.EventHandler(this.cbProvincia_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(413, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Provincia:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTelefono.Location = new System.Drawing.Point(533, 223);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(162, 27);
            this.txtTelefono.TabIndex = 8;
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // PacienteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_TallerdeProgramacion_Aguilar_Juarez.Properties.Resources.Dark_Green_and_Cream_Simple_Dark_Real_Estate_Bio_Link_Website__3_;
            this.ClientSize = new System.Drawing.Size(893, 465);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbdatos);
            this.Name = "PacienteUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital San Telmo";
            this.Load += new System.EventHandler(this.PacienteUser_Load);
            this.gbdatos.ResumeLayout(false);
            this.gbdatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbObraSocial;
        private System.Windows.Forms.GroupBox gbdatos;
        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker pFechaNac;
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}
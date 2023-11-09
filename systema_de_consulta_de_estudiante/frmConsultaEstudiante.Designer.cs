namespace systema_de_consulta_de_estudiante
{
    partial class frmConsultaEstudiante
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSede = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.cbModalidad = new System.Windows.Forms.ComboBox();
            this.cbTanda = new System.Windows.Forms.ComboBox();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbSede);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.cbModalidad);
            this.panel1.Controls.Add(this.cbTanda);
            this.panel1.Controls.Add(this.txtModulo);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtCurso);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtNacionalidad);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCedula);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.txtMatricula);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 352);
            this.panel1.TabIndex = 7;
            // 
            // cbSede
            // 
            this.cbSede.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbSede.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSede.FormattingEnabled = true;
            this.cbSede.Location = new System.Drawing.Point(256, 20);
            this.cbSede.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSede.Name = "cbSede";
            this.cbSede.Size = new System.Drawing.Size(279, 21);
            this.cbSede.TabIndex = 6;
            this.cbSede.Tag = "sede";
            this.cbSede.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSede_KeyDown);
            this.cbSede.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSede_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTelefono.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefono.Location = new System.Drawing.Point(8, 219);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(241, 20);
            this.txtTelefono.TabIndex = 11;
            this.txtTelefono.Tag = "telefono";
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefono_KeyDown);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // cbModalidad
            // 
            this.cbModalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbModalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbModalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbModalidad.FormattingEnabled = true;
            this.cbModalidad.Location = new System.Drawing.Point(256, 99);
            this.cbModalidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbModalidad.Name = "cbModalidad";
            this.cbModalidad.Size = new System.Drawing.Size(279, 21);
            this.cbModalidad.TabIndex = 10;
            this.cbModalidad.Tag = "modalidad";
            this.cbModalidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbModalidad_KeyDown);
            this.cbModalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbModalidad_KeyPress);
            // 
            // cbTanda
            // 
            this.cbTanda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTanda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbTanda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbTanda.FormattingEnabled = true;
            this.cbTanda.Items.AddRange(new object[] {
            "Matutina",
            "Vespertina",
            "Nocturna"});
            this.cbTanda.Location = new System.Drawing.Point(256, 139);
            this.cbTanda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTanda.Name = "cbTanda";
            this.cbTanda.Size = new System.Drawing.Size(279, 21);
            this.cbTanda.TabIndex = 9;
            this.cbTanda.Tag = "tanda";
            this.cbTanda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTanda_KeyDown);
            this.cbTanda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTanda_KeyPress);
            // 
            // txtModulo
            // 
            this.txtModulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtModulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtModulo.Location = new System.Drawing.Point(256, 179);
            this.txtModulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtModulo.MaxLength = 15;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(279, 20);
            this.txtModulo.TabIndex = 8;
            this.txtModulo.Tag = "modulo";
            this.txtModulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtModulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModulo_KeyDown);
            this.txtModulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModulo_KeyPress);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(256, 166);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(279, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "MÓDULO";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurso
            // 
            this.txtCurso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCurso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCurso.Location = new System.Drawing.Point(256, 61);
            this.txtCurso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCurso.MaxLength = 15;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(279, 20);
            this.txtCurso.TabIndex = 7;
            this.txtCurso.Tag = "curso";
            this.txtCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurso_KeyDown);
            this.txtCurso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurso_KeyPress);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(256, 48);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(279, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "CURSO";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(256, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(279, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "SEDE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(8, 245);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(527, 95);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 206);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "TELÉFONO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(256, 87);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(279, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "MODALIDAD";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(256, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "TANDA";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNacionalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNacionalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNacionalidad.Location = new System.Drawing.Point(8, 179);
            this.txtNacionalidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNacionalidad.MaxLength = 15;
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(240, 20);
            this.txtNacionalidad.TabIndex = 5;
            this.txtNacionalidad.Tag = "nacionalidad";
            this.txtNacionalidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNacionalidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNacionalidad_KeyDown);
            this.txtNacionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNacionalidad_KeyPress);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 166);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "NACIONALIDAD";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCedula
            // 
            this.txtCedula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCedula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCedula.Location = new System.Drawing.Point(8, 61);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCedula.MaxLength = 11;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(241, 20);
            this.txtCedula.TabIndex = 2;
            this.txtCedula.Tag = "cedula";
            this.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCedula_KeyDown);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtApellido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtApellido.Location = new System.Drawing.Point(8, 140);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtApellido.MaxLength = 35;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(241, 20);
            this.txtApellido.TabIndex = 4;
            this.txtApellido.Tag = "apellido";
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApellido_KeyDown);
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(8, 101);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.MaxLength = 35;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Tag = "nombre";
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtMatricula
            // 
            this.txtMatricula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMatricula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMatricula.Location = new System.Drawing.Point(8, 22);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMatricula.MaxLength = 5;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(241, 20);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.Tag = "matricula";
            this.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "CÉDULA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "APELLIDO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "NOMBRE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "MATRÍCULA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 70);
            this.panel2.TabIndex = 89;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(413, 1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(73, 66);
            this.btnMinimize.TabIndex = 8;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(2, 18);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(428, 34);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "C O N S U L T A  E S T U D I A N T E                         ";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            this.lblTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseMove);
            this.lblTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(488, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 66);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConsultaEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmConsultaEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estudiante";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstudiante_FormClosing);
            this.Load += new System.EventHandler(this.frmEstudiante_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTanda;
        private System.Windows.Forms.ComboBox cbModalidad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.ComboBox cbSede;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClose;
    }
}
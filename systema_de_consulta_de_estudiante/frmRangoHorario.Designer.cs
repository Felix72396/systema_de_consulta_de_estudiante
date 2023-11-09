namespace systema_de_consulta_de_estudiante
{
    partial class frmRangoHorario
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.btnEliminarRh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rdbPm2 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.rdbAm2 = new System.Windows.Forms.RadioButton();
            this.txtHoraSalida = new System.Windows.Forms.TextBox();
            this.txtMinutoSalida = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CV = new System.Windows.Forms.Label();
            this.rdbPm1 = new System.Windows.Forms.RadioButton();
            this.rdbAm1 = new System.Windows.Forms.RadioButton();
            this.txtHoraEntrada = new System.Windows.Forms.TextBox();
            this.txtMinutoEntrada = new System.Windows.Forms.TextBox();
            this.btnAgregarRh = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cbHorario);
            this.groupBox2.Controls.Add(this.btnEliminarRh);
            this.groupBox2.Location = new System.Drawing.Point(432, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 74);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ELIMINAR RANGO HORARIO";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(6, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(297, 22);
            this.label20.TabIndex = 83;
            this.label20.Text = "RANGO HORARIO";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbHorario
            // 
            this.cbHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHorario.FormattingEnabled = true;
            this.cbHorario.Location = new System.Drawing.Point(6, 42);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(297, 24);
            this.cbHorario.TabIndex = 80;
            // 
            // btnEliminarRh
            // 
            this.btnEliminarRh.BackColor = System.Drawing.Color.Red;
            this.btnEliminarRh.FlatAppearance.BorderSize = 0;
            this.btnEliminarRh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRh.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRh.Location = new System.Drawing.Point(309, 17);
            this.btnEliminarRh.Name = "btnEliminarRh";
            this.btnEliminarRh.Size = new System.Drawing.Size(97, 49);
            this.btnEliminarRh.TabIndex = 81;
            this.btnEliminarRh.Text = "ELIMINAR";
            this.btnEliminarRh.UseVisualStyleBackColor = false;
            this.btnEliminarRh.Click += new System.EventHandler(this.btnEliminarRh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnAgregarRh);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 158);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AGREGAR RANGO HORARIO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.rdbPm2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.rdbAm2);
            this.panel2.Controls.Add(this.txtHoraSalida);
            this.panel2.Controls.Add(this.txtMinutoSalida);
            this.panel2.Location = new System.Drawing.Point(208, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 81);
            this.panel2.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(148, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 22);
            this.label7.TabIndex = 86;
            this.label7.Text = "PM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 22);
            this.label3.TabIndex = 73;
            this.label3.Text = "HORA SALIDA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(99, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 22);
            this.label8.TabIndex = 85;
            this.label8.Text = "AM";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(51, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 22);
            this.label9.TabIndex = 84;
            this.label9.Text = "mm";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbPm2
            // 
            this.rdbPm2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbPm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdbPm2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPm2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbPm2.FlatAppearance.BorderSize = 0;
            this.rdbPm2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbPm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbPm2.Location = new System.Drawing.Point(148, 51);
            this.rdbPm2.Name = "rdbPm2";
            this.rdbPm2.Size = new System.Drawing.Size(47, 27);
            this.rdbPm2.TabIndex = 78;
            this.rdbPm2.Tag = "PM";
            this.rdbPm2.Text = "x";
            this.rdbPm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPm2.UseVisualStyleBackColor = false;
            this.rdbPm2.CheckedChanged += new System.EventHandler(this.rdbPm2_CheckedChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 22);
            this.label10.TabIndex = 83;
            this.label10.Text = "HH";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbAm2
            // 
            this.rdbAm2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbAm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdbAm2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbAm2.Checked = true;
            this.rdbAm2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbAm2.FlatAppearance.BorderSize = 0;
            this.rdbAm2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbAm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAm2.ForeColor = System.Drawing.Color.White;
            this.rdbAm2.Location = new System.Drawing.Point(99, 51);
            this.rdbAm2.Name = "rdbAm2";
            this.rdbAm2.Size = new System.Drawing.Size(47, 27);
            this.rdbAm2.TabIndex = 77;
            this.rdbAm2.TabStop = true;
            this.rdbAm2.Tag = "AM";
            this.rdbAm2.Text = "x";
            this.rdbAm2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbAm2.UseVisualStyleBackColor = false;
            this.rdbAm2.CheckedChanged += new System.EventHandler(this.rdbAm2_CheckedChanged);
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtHoraSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraSalida.Location = new System.Drawing.Point(3, 51);
            this.txtHoraSalida.MaxLength = 2;
            this.txtHoraSalida.Multiline = true;
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(45, 27);
            this.txtHoraSalida.TabIndex = 74;
            this.txtHoraSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraSalida_KeyPress);
            // 
            // txtMinutoSalida
            // 
            this.txtMinutoSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMinutoSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinutoSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutoSalida.Location = new System.Drawing.Point(51, 51);
            this.txtMinutoSalida.MaxLength = 2;
            this.txtMinutoSalida.Multiline = true;
            this.txtMinutoSalida.Name = "txtMinutoSalida";
            this.txtMinutoSalida.Size = new System.Drawing.Size(45, 27);
            this.txtMinutoSalida.TabIndex = 75;
            this.txtMinutoSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutoSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutoSalida_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CV);
            this.panel1.Controls.Add(this.rdbPm1);
            this.panel1.Controls.Add(this.rdbAm1);
            this.panel1.Controls.Add(this.txtHoraEntrada);
            this.panel1.Controls.Add(this.txtMinutoEntrada);
            this.panel1.Location = new System.Drawing.Point(6, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 81);
            this.panel1.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(148, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 22);
            this.label6.TabIndex = 82;
            this.label6.Text = "PM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(99, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 22);
            this.label5.TabIndex = 81;
            this.label5.Text = "AM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(51, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 22);
            this.label4.TabIndex = 80;
            this.label4.Text = "mm";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 79;
            this.label1.Text = "HH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CV
            // 
            this.CV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CV.ForeColor = System.Drawing.Color.White;
            this.CV.Location = new System.Drawing.Point(3, 3);
            this.CV.Name = "CV";
            this.CV.Size = new System.Drawing.Size(192, 22);
            this.CV.TabIndex = 73;
            this.CV.Text = "HORA ENTRADA";
            this.CV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbPm1
            // 
            this.rdbPm1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbPm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdbPm1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPm1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbPm1.FlatAppearance.BorderSize = 0;
            this.rdbPm1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbPm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbPm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbPm1.Location = new System.Drawing.Point(148, 51);
            this.rdbPm1.Name = "rdbPm1";
            this.rdbPm1.Size = new System.Drawing.Size(47, 27);
            this.rdbPm1.TabIndex = 78;
            this.rdbPm1.Tag = "PM";
            this.rdbPm1.Text = "x";
            this.rdbPm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbPm1.UseVisualStyleBackColor = false;
            this.rdbPm1.CheckedChanged += new System.EventHandler(this.rdbPm1_CheckedChanged);
            // 
            // rdbAm1
            // 
            this.rdbAm1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbAm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rdbAm1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbAm1.Checked = true;
            this.rdbAm1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbAm1.FlatAppearance.BorderSize = 0;
            this.rdbAm1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdbAm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAm1.ForeColor = System.Drawing.Color.White;
            this.rdbAm1.Location = new System.Drawing.Point(99, 51);
            this.rdbAm1.Name = "rdbAm1";
            this.rdbAm1.Size = new System.Drawing.Size(47, 27);
            this.rdbAm1.TabIndex = 77;
            this.rdbAm1.TabStop = true;
            this.rdbAm1.Tag = "AM";
            this.rdbAm1.Text = "x";
            this.rdbAm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbAm1.UseVisualStyleBackColor = false;
            this.rdbAm1.CheckedChanged += new System.EventHandler(this.rdbAm1_CheckedChanged);
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtHoraEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraEntrada.Location = new System.Drawing.Point(3, 51);
            this.txtHoraEntrada.MaxLength = 2;
            this.txtHoraEntrada.Multiline = true;
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(45, 27);
            this.txtHoraEntrada.TabIndex = 74;
            this.txtHoraEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoraEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraEntrada_KeyPress);
            // 
            // txtMinutoEntrada
            // 
            this.txtMinutoEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMinutoEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinutoEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutoEntrada.Location = new System.Drawing.Point(51, 51);
            this.txtMinutoEntrada.MaxLength = 2;
            this.txtMinutoEntrada.Multiline = true;
            this.txtMinutoEntrada.Name = "txtMinutoEntrada";
            this.txtMinutoEntrada.Size = new System.Drawing.Size(45, 27);
            this.txtMinutoEntrada.TabIndex = 75;
            this.txtMinutoEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinutoEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinutoEntrada_KeyPress);
            // 
            // btnAgregarRh
            // 
            this.btnAgregarRh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarRh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRh.FlatAppearance.BorderSize = 0;
            this.btnAgregarRh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRh.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRh.Location = new System.Drawing.Point(6, 107);
            this.btnAgregarRh.Name = "btnAgregarRh";
            this.btnAgregarRh.Size = new System.Drawing.Size(400, 43);
            this.btnAgregarRh.TabIndex = 71;
            this.btnAgregarRh.Text = "AGREGAR";
            this.btnAgregarRh.UseVisualStyleBackColor = false;
            this.btnAgregarRh.Click += new System.EventHandler(this.btnAgregarRh_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnMinimize);
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(855, 86);
            this.panel3.TabIndex = 97;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
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
            this.btnMinimize.Location = new System.Drawing.Point(657, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(97, 81);
            this.btnMinimize.TabIndex = 8;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(705, 42);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "A G R E G A R / E L I M I N A R  R A N G O  H O R A R I O             ";
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
            this.btnClose.Location = new System.Drawing.Point(757, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 81);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRangoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(855, 262);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRangoHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rango Horario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRangoHorario_FormClosing);
            this.Load += new System.EventHandler(this.frmRangoHorario_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbHorario;
        private System.Windows.Forms.Button btnEliminarRh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdbPm2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdbAm2;
        private System.Windows.Forms.TextBox txtHoraSalida;
        private System.Windows.Forms.TextBox txtMinutoSalida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CV;
        private System.Windows.Forms.RadioButton rdbPm1;
        private System.Windows.Forms.RadioButton rdbAm1;
        private System.Windows.Forms.TextBox txtHoraEntrada;
        private System.Windows.Forms.TextBox txtMinutoEntrada;
        private System.Windows.Forms.Button btnAgregarRh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClose;
    }
}
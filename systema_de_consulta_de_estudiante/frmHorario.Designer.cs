namespace systema_de_consulta_de_estudiante
{
    partial class frmHorario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHorario1 = new System.Windows.Forms.ComboBox();
            this.btnAgregarRhEnCurso = new System.Windows.Forms.Button();
            this.dtCurso = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHorario2 = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCurso)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSabado);
            this.groupBox3.Controls.Add(this.chkViernes);
            this.groupBox3.Controls.Add(this.chkJueves);
            this.groupBox3.Controls.Add(this.chkMiercoles);
            this.groupBox3.Controls.Add(this.chkMartes);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chkLunes);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbHorario1);
            this.groupBox3.Controls.Add(this.btnAgregarRhEnCurso);
            this.groupBox3.Location = new System.Drawing.Point(9, 406);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(550, 106);
            this.groupBox3.TabIndex = 83;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AGREGAR RANGO HORARIO EN CURSO";
            // 
            // chkSabado
            // 
            this.chkSabado.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSabado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkSabado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSabado.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSabado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSabado.Location = new System.Drawing.Point(457, 34);
            this.chkSabado.Margin = new System.Windows.Forms.Padding(2);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(88, 22);
            this.chkSabado.TabIndex = 93;
            this.chkSabado.Text = "SÁBADO";
            this.chkSabado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSabado.UseVisualStyleBackColor = false;
            // 
            // chkViernes
            // 
            this.chkViernes.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkViernes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkViernes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkViernes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkViernes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkViernes.Location = new System.Drawing.Point(366, 34);
            this.chkViernes.Margin = new System.Windows.Forms.Padding(2);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(88, 22);
            this.chkViernes.TabIndex = 92;
            this.chkViernes.Text = "VIERNES";
            this.chkViernes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkViernes.UseVisualStyleBackColor = false;
            // 
            // chkJueves
            // 
            this.chkJueves.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkJueves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkJueves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkJueves.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkJueves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkJueves.Location = new System.Drawing.Point(275, 34);
            this.chkJueves.Margin = new System.Windows.Forms.Padding(2);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(88, 22);
            this.chkJueves.TabIndex = 91;
            this.chkJueves.Text = "JUEVES";
            this.chkJueves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkJueves.UseVisualStyleBackColor = false;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMiercoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMiercoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMiercoles.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMiercoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMiercoles.Location = new System.Drawing.Point(185, 34);
            this.chkMiercoles.Margin = new System.Windows.Forms.Padding(2);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(88, 22);
            this.chkMiercoles.TabIndex = 90;
            this.chkMiercoles.Text = "MIÉRCOLES";
            this.chkMiercoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMiercoles.UseVisualStyleBackColor = false;
            // 
            // chkMartes
            // 
            this.chkMartes.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMartes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkMartes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkMartes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMartes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMartes.Location = new System.Drawing.Point(95, 34);
            this.chkMartes.Margin = new System.Windows.Forms.Padding(2);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(88, 22);
            this.chkMartes.TabIndex = 89;
            this.chkMartes.Text = "MARTES";
            this.chkMartes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMartes.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(541, 18);
            this.label11.TabIndex = 88;
            this.label11.Text = "DÍAS DE LA SEMANA";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkLunes
            // 
            this.chkLunes.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLunes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkLunes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkLunes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkLunes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLunes.Location = new System.Drawing.Point(4, 34);
            this.chkLunes.Margin = new System.Windows.Forms.Padding(2);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(88, 22);
            this.chkLunes.TabIndex = 87;
            this.chkLunes.Text = "LUNES";
            this.chkLunes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLunes.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 18);
            this.label2.TabIndex = 85;
            this.label2.Text = "TODOS LOS RANGOS HORARIOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbHorario1
            // 
            this.cbHorario1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbHorario1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHorario1.FormattingEnabled = true;
            this.cbHorario1.Location = new System.Drawing.Point(4, 80);
            this.cbHorario1.Margin = new System.Windows.Forms.Padding(2);
            this.cbHorario1.Name = "cbHorario1";
            this.cbHorario1.Size = new System.Drawing.Size(270, 21);
            this.cbHorario1.TabIndex = 84;
            // 
            // btnAgregarRhEnCurso
            // 
            this.btnAgregarRhEnCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregarRhEnCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRhEnCurso.Enabled = false;
            this.btnAgregarRhEnCurso.FlatAppearance.BorderSize = 0;
            this.btnAgregarRhEnCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRhEnCurso.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRhEnCurso.Location = new System.Drawing.Point(275, 60);
            this.btnAgregarRhEnCurso.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarRhEnCurso.Name = "btnAgregarRhEnCurso";
            this.btnAgregarRhEnCurso.Size = new System.Drawing.Size(270, 41);
            this.btnAgregarRhEnCurso.TabIndex = 71;
            this.btnAgregarRhEnCurso.Text = "AGREGAR";
            this.btnAgregarRhEnCurso.UseVisualStyleBackColor = false;
            this.btnAgregarRhEnCurso.Click += new System.EventHandler(this.btnAgregarRhEnCurso_Click);
            // 
            // dtCurso
            // 
            this.dtCurso.AllowUserToAddRows = false;
            this.dtCurso.AllowUserToDeleteRows = false;
            this.dtCurso.AllowUserToResizeColumns = false;
            this.dtCurso.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtCurso.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtCurso.BackgroundColor = System.Drawing.Color.White;
            this.dtCurso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtCurso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtCurso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtCurso.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtCurso.GridColor = System.Drawing.Color.White;
            this.dtCurso.Location = new System.Drawing.Point(9, 80);
            this.dtCurso.MultiSelect = false;
            this.dtCurso.Name = "dtCurso";
            this.dtCurso.ReadOnly = true;
            this.dtCurso.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtCurso.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtCurso.RowHeadersVisible = false;
            this.dtCurso.RowHeadersWidth = 50;
            this.dtCurso.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCurso.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtCurso.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtCurso.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtCurso.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCurso.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dtCurso.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtCurso.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtCurso.RowTemplate.Height = 25;
            this.dtCurso.RowTemplate.ReadOnly = true;
            this.dtCurso.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtCurso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCurso.Size = new System.Drawing.Size(550, 320);
            this.dtCurso.TabIndex = 86;
            this.dtCurso.SelectionChanged += new System.EventHandler(this.dtCurso_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbHorario2);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Location = new System.Drawing.Point(9, 517);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(550, 101);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ELIMINAR RANGO HORARIO EN CURSO";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(541, 18);
            this.label4.TabIndex = 85;
            this.label4.Text = "RANGO(S) HORARIO(S) EN CURSO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbHorario2
            // 
            this.cbHorario2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbHorario2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHorario2.FormattingEnabled = true;
            this.cbHorario2.Location = new System.Drawing.Point(4, 35);
            this.cbHorario2.Margin = new System.Windows.Forms.Padding(2);
            this.cbHorario2.Name = "cbHorario2";
            this.cbHorario2.Size = new System.Drawing.Size(542, 21);
            this.cbHorario2.TabIndex = 84;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(4, 58);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(541, 35);
            this.btnEliminar.TabIndex = 71;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 70);
            this.panel2.TabIndex = 95;
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
            this.btnMinimize.Location = new System.Drawing.Point(419, 1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2);
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
            this.lblTitulo.Location = new System.Drawing.Point(2, 15);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(440, 34);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "A G R E G A R / E L I M I N A R  H O R A R I O  E N  C U R S O      ";
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
            this.btnClose.Location = new System.Drawing.Point(494, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 66);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtCurso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHorario_FormClosing);
            this.Load += new System.EventHandler(this.frmHorario_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtCurso)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAgregarRhEnCurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHorario1;
        private System.Windows.Forms.DataGridView dtCurso;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbHorario2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClose;
    }
}
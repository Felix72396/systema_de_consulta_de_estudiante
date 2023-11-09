namespace systema_de_consulta_de_estudiante
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursoSedeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.móduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.móduloCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangoHorarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horarioCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSede = new System.Windows.Forms.Button();
            this.btnHorario = new System.Windows.Forms.Button();
            this.btnModulo = new System.Windows.Forms.Button();
            this.btnCurso = new System.Windows.Forms.Button();
            this.btnEstudiante = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAgregarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEliminarActualizarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAgregarPermisosDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(650, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursoToolStripMenuItem,
            this.sedeToolStripMenuItem,
            this.cursoToolStripMenuItem1,
            this.móduloToolStripMenuItem,
            this.horarioToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // cursoToolStripMenuItem
            // 
            this.cursoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.agregarToolStripMenuItem});
            this.cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            this.cursoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cursoToolStripMenuItem.Text = "&Estudiante";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.consultarToolStripMenuItem.Text = "Consultar estudiante";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.agregarToolStripMenuItem.Text = "Agregar estudiante";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // sedeToolStripMenuItem
            // 
            this.sedeToolStripMenuItem.Name = "sedeToolStripMenuItem";
            this.sedeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sedeToolStripMenuItem.Text = "&Sede";
            this.sedeToolStripMenuItem.Click += new System.EventHandler(this.sedeToolStripMenuItem_Click);
            // 
            // cursoToolStripMenuItem1
            // 
            this.cursoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informacionCursosToolStripMenuItem,
            this.cursoSedeToolStripMenuItem});
            this.cursoToolStripMenuItem1.Name = "cursoToolStripMenuItem1";
            this.cursoToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.cursoToolStripMenuItem1.Text = "&Curso";
            // 
            // informacionCursosToolStripMenuItem
            // 
            this.informacionCursosToolStripMenuItem.Name = "informacionCursosToolStripMenuItem";
            this.informacionCursosToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.informacionCursosToolStripMenuItem.Text = "Ver/Agregar curso";
            this.informacionCursosToolStripMenuItem.Click += new System.EventHandler(this.informacionCursosToolStripMenuItem_Click);
            // 
            // cursoSedeToolStripMenuItem
            // 
            this.cursoSedeToolStripMenuItem.Name = "cursoSedeToolStripMenuItem";
            this.cursoSedeToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.cursoSedeToolStripMenuItem.Text = "Ver/Agregar curso en sede";
            this.cursoSedeToolStripMenuItem.Click += new System.EventHandler(this.cursoSedeToolStripMenuItem_Click);
            // 
            // móduloToolStripMenuItem
            // 
            this.móduloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónMóduloToolStripMenuItem,
            this.móduloCursoToolStripMenuItem});
            this.móduloToolStripMenuItem.Name = "móduloToolStripMenuItem";
            this.móduloToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.móduloToolStripMenuItem.Text = "&Módulo";
            this.móduloToolStripMenuItem.Click += new System.EventHandler(this.móduloToolStripMenuItem_Click);
            // 
            // informaciónMóduloToolStripMenuItem
            // 
            this.informaciónMóduloToolStripMenuItem.Name = "informaciónMóduloToolStripMenuItem";
            this.informaciónMóduloToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.informaciónMóduloToolStripMenuItem.Text = "Ver/Agregar módulo";
            this.informaciónMóduloToolStripMenuItem.Click += new System.EventHandler(this.informaciónMóduloToolStripMenuItem_Click);
            // 
            // móduloCursoToolStripMenuItem
            // 
            this.móduloCursoToolStripMenuItem.Name = "móduloCursoToolStripMenuItem";
            this.móduloCursoToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.móduloCursoToolStripMenuItem.Text = "Ver/Agregar módulo en curso";
            this.móduloCursoToolStripMenuItem.Click += new System.EventHandler(this.móduloCursoToolStripMenuItem_Click);
            // 
            // horarioToolStripMenuItem
            // 
            this.horarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rangoHorarioToolStripMenuItem,
            this.horarioCursoToolStripMenuItem});
            this.horarioToolStripMenuItem.Name = "horarioToolStripMenuItem";
            this.horarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.horarioToolStripMenuItem.Text = "&Horario";
            this.horarioToolStripMenuItem.Click += new System.EventHandler(this.horarioToolStripMenuItem_Click);
            // 
            // rangoHorarioToolStripMenuItem
            // 
            this.rangoHorarioToolStripMenuItem.Name = "rangoHorarioToolStripMenuItem";
            this.rangoHorarioToolStripMenuItem.Size = new System.Drawing.Size(345, 26);
            this.rangoHorarioToolStripMenuItem.Text = "Ver/Agregar/Eliminar rango horario";
            this.rangoHorarioToolStripMenuItem.Click += new System.EventHandler(this.rangoHorarioToolStripMenuItem_Click);
            // 
            // horarioCursoToolStripMenuItem
            // 
            this.horarioCursoToolStripMenuItem.Name = "horarioCursoToolStripMenuItem";
            this.horarioCursoToolStripMenuItem.Size = new System.Drawing.Size(345, 26);
            this.horarioCursoToolStripMenuItem.Text = "Ver/Agregar/Eliminar horario de curso";
            this.horarioCursoToolStripMenuItem.Click += new System.EventHandler(this.horarioCursoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estudiante";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(435, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Curso";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(325, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Módulo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(112, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Horario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(223, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sede";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSede
            // 
            this.btnSede.BackgroundImage = global::systema_de_consulta_de_estudiante.Properties.Resources.sede;
            this.btnSede.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSede.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSede.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSede.Location = new System.Drawing.Point(223, 127);
            this.btnSede.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSede.Name = "btnSede";
            this.btnSede.Size = new System.Drawing.Size(204, 156);
            this.btnSede.TabIndex = 6;
            this.btnSede.UseVisualStyleBackColor = true;
            this.btnSede.Click += new System.EventHandler(this.btnSede_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.BackgroundImage = global::systema_de_consulta_de_estudiante.Properties.Resources.horario;
            this.btnHorario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorario.Location = new System.Drawing.Point(112, 320);
            this.btnHorario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(204, 156);
            this.btnHorario.TabIndex = 5;
            this.btnHorario.UseVisualStyleBackColor = true;
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // btnModulo
            // 
            this.btnModulo.BackgroundImage = global::systema_de_consulta_de_estudiante.Properties.Resources.modulo;
            this.btnModulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModulo.Location = new System.Drawing.Point(325, 320);
            this.btnModulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModulo.Name = "btnModulo";
            this.btnModulo.Size = new System.Drawing.Size(204, 156);
            this.btnModulo.TabIndex = 4;
            this.btnModulo.UseVisualStyleBackColor = true;
            this.btnModulo.Click += new System.EventHandler(this.btnModulo_Click);
            // 
            // btnCurso
            // 
            this.btnCurso.BackgroundImage = global::systema_de_consulta_de_estudiante.Properties.Resources.curso1;
            this.btnCurso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurso.Location = new System.Drawing.Point(435, 127);
            this.btnCurso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCurso.Name = "btnCurso";
            this.btnCurso.Size = new System.Drawing.Size(204, 156);
            this.btnCurso.TabIndex = 3;
            this.btnCurso.UseVisualStyleBackColor = true;
            this.btnCurso.Click += new System.EventHandler(this.btnCurso_Click);
            // 
            // btnEstudiante
            // 
            this.btnEstudiante.BackgroundImage = global::systema_de_consulta_de_estudiante.Properties.Resources.estudiante;
            this.btnEstudiante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEstudiante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstudiante.Location = new System.Drawing.Point(11, 127);
            this.btnEstudiante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEstudiante.Name = "btnEstudiante";
            this.btnEstudiante.Size = new System.Drawing.Size(204, 156);
            this.btnEstudiante.TabIndex = 2;
            this.btnEstudiante.UseVisualStyleBackColor = true;
            this.btnEstudiante.Click += new System.EventHandler(this.btnEstudiante_Click);
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 86);
            this.panel2.TabIndex = 96;
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
            this.btnMinimize.Location = new System.Drawing.Point(453, 1);
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
            this.lblTitulo.Size = new System.Drawing.Size(494, 42);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "P R I N C I P A L                              ";
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
            this.btnClose.Location = new System.Drawing.Point(553, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 81);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 32);
            this.panel1.TabIndex = 97;
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verAgregarUsuariosToolStripMenuItem,
            this.verEliminarActualizarUsuariosToolStripMenuItem,
            this.verAgregarPermisosDeUsuarioToolStripMenuItem});
            this.usuarioToolStripMenuItem.Enabled = false;
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // verAgregarUsuariosToolStripMenuItem
            // 
            this.verAgregarUsuariosToolStripMenuItem.Name = "verAgregarUsuariosToolStripMenuItem";
            this.verAgregarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.verAgregarUsuariosToolStripMenuItem.Text = "Ver/Agregar usuarios";
            // 
            // verEliminarActualizarUsuariosToolStripMenuItem
            // 
            this.verEliminarActualizarUsuariosToolStripMenuItem.Name = "verEliminarActualizarUsuariosToolStripMenuItem";
            this.verEliminarActualizarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.verEliminarActualizarUsuariosToolStripMenuItem.Text = "Ver/Eliminar/Actualizar usuarios";
            // 
            // verAgregarPermisosDeUsuarioToolStripMenuItem
            // 
            this.verAgregarPermisosDeUsuarioToolStripMenuItem.Name = "verAgregarPermisosDeUsuarioToolStripMenuItem";
            this.verAgregarPermisosDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.verAgregarPermisosDeUsuarioToolStripMenuItem.Text = "Ver/Agregar permisos de usuario";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(651, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSede);
            this.Controls.Add(this.btnHorario);
            this.Controls.Add(this.btnModulo);
            this.Controls.Add(this.btnCurso);
            this.Controls.Add(this.btnEstudiante);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRUPO CHATGPT S.A.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem móduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sedeToolStripMenuItem;
        private System.Windows.Forms.Button btnEstudiante;
        private System.Windows.Forms.Button btnCurso;
        private System.Windows.Forms.Button btnModulo;
        private System.Windows.Forms.Button btnHorario;
        private System.Windows.Forms.Button btnSede;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem cursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacionCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursoSedeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónMóduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem móduloCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangoHorarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horarioCursoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAgregarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEliminarActualizarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAgregarPermisosDeUsuarioToolStripMenuItem;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Text.RegularExpressions;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmDatosEstudiante : Form
    {
        public frmDatosEstudiante()
        {
            InitializeComponent();
        }


        public frmDatosEstudiante(DataTable tabla)
        {
            InitializeComponent();
            this.tabla = tabla;
           
            dtEstudiante.DataSource = tabla;
            configurarTablaEstudiante();
            dtEstudiante.CellFormatting += dtEstudiante_CellFormatting;

            this.idUsuario = Usuario.IdUsuario;
           
            aplicarPermisos();
        }

        public frmDatosEstudiante(int matricula)
        {
            InitializeComponent();
            this.matricula = matricula;

            //lstSede.DrawMode = DrawMode.OwnerDrawFixed;
            //lstSede.DrawItem += lstSede_DrawItem;

            asignarInformacion();

            //dtgHorario.CellPainting += dtgHorario_CellPainting;

            this.idUsuario = Usuario.IdUsuario;
 
            aplicarPermisos();
        }

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        Curso curso = new Curso();
        Modalidad modalidad = new Modalidad();
        Modulo modulo = new Modulo();
        Estudiante estudiante = new Estudiante();
        Horario horario = new Horario();
        
        DataTable tabla;

        int matricula = 0,
        idSede = 0,
        idCurso = 0,
        idModulo = 0;

        string nombreSede,
               nombreCurso,
               nombreModalidad,
               nombreModulo;

        bool grabbed = false;
        int mx, my;


        private void frmDatosEstudiante_Load(object sender, EventArgs e)
        {
            if (matricula == 0)
            {
                panel1.Visible = false;
                lblMatricula.Visible = false;
            }
            else
            {
                bool tieneInscripcion = estudiante.verificarInscripcion(matricula);
                if (!tieneInscripcion)
                {
                    btnInscripcion.Enabled = true;
                    btnInscripcion.Focus();
                    btnVerMas.Enabled = false;
                }
            }


            //lstCurso.SelectedIndexChanged -= lstCurso_SelectedIndexChanged;
            //lstSede.SelectedIndexChanged -= lstSede_SelectedIndexChanged;
            //tbcModulo.SelectedIndexChanged -= tbcModulo_SelectedIndexChanged;
        }

        private void frmDatosEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmConsultaEstudiante frm = new frmConsultaEstudiante();
            frm.Show();
        }

        private void aplicarPermisos()
        {
            List<string> listaPermisos = new List<string>();
        
            listaPermisos = usuario.obtenerPermisosUsuario(idUsuario);

            // count = 2
            //listaPermisos[0] = "EL";
            //listaPermisos[1] = "ED";
         
            if (listaPermisos.Count == 0) 
                return;

           
            for (int i = 0; i < listaPermisos.Count; i++)
            {
                //MessageBox.Show(listaPermisos[0] + " " + btnEditar.Enabled);
                switch (listaPermisos[i])
                {
                    case "TO":
                       btnEditar.Enabled = true;
                        btnEliminar.Enabled = true;
                        break;

                    case "EL":
                        btnEliminar.Enabled=true;
                        break;

                    case "ED":
                  
                        btnEditar.Enabled = true;
                   
                        break;
                }
            }

        }


        private void definirColorFilas()
        {
            dtgHorario.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtgHorario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0,64,64); // Cambia el color de fondo
            dtgHorario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente
          
            //dtgHorario.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;//color de fondo de la cabecera de las columnas
            //dtgHorario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;//color de fondo de las letras de la cabecera de las columnas

            //dtgHorario.RowsDefaultCellStyle.SelectionBackColor = Color.White;//color de seleccion de las filas
            //dtgHorario.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 64, 64);//color de seleccion de las letras de las filas

            //dtgHorario.RowsDefaultCellStyle.BackColor = Color.FromArgb(0, 84, 84);//color por defecto del fondo de las filas
            //dtgHorario.RowsDefaultCellStyle.ForeColor = Color.White; //color por defecto de las letras de las filas
            //dtgHorario.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
            //dtgHorario.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas



        }

        private void configurarTablaEstudiante()
        {
            dtEstudiante.Visible = true;
            DataGridViewColumn matricula = dtEstudiante.Columns["MATRÍCULA"];
            matricula.Width = 200;

            DataGridViewColumn nombreCompleto = dtEstudiante.Columns["NOMBRE COMPLETO"];
            nombreCompleto.Width = 500;

            foreach (DataGridViewColumn columna in dtEstudiante.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtEstudiante.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtEstudiante.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtEstudiante.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

           

            //dtEstudiante.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
            //dtEstudiante.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas


            dtEstudiante.ColumnHeadersDefaultCellStyle.Font = new Font(dtgHorario.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void definirAltoColumnas()
        {

            int ancho = 115;

            dtgHorario.RowsDefaultCellStyle.Font = new Font(dtgHorario.Font.FontFamily, 10, FontStyle.Bold);
   

            //dtgHorario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //dtgHorario.ColumnHeadersHeight = 50;

            DataGridViewColumn lunes = dtgHorario.Columns["LUNES"];
            //lunes.DataPropertyName = "LUNES";
            //lunes.HeaderText = "LUNES";
            lunes.Width = ancho;

            //matricula.Frozen = true;
            //lunes.ValueType = typeof(string);
            //dtgHorario.Columns.Add(lunes);

            DataGridViewColumn martes = dtgHorario.Columns["MARTES"];
            
            //martes.DataPropertyName = "MARTES";
            //martes.HeaderText = "MARTES";
            martes.Width = ancho;
            //matricula.Frozen = true;
            //martes.ValueType = typeof(string);
            //dtgHorario.Columns.Add(martes);


            DataGridViewColumn miercoles = dtgHorario.Columns["MIÉRCOLES"];
    
            //miercoles.DataPropertyName = "MIÉRCOLES";
            //miercoles.HeaderText = "MIÉRCOLES";
            miercoles.Width = ancho;
        
            //miercoles.Frozen = true;
            //miercoles.ValueType = typeof(string);
            //dtgHorario.Columns.Add(miercoles);

            DataGridViewColumn jueves = dtgHorario.Columns["JUEVES"];
            //jueves.DataPropertyName = "JUEVES";
            //jueves.HeaderText = "JUEVES";
            jueves.Width = ancho;
            //matricula.Frozen = true;
            //jueves.ValueType = typeof(string);
            //dtgHorario.Columns.Add(jueves);

            DataGridViewColumn viernes = dtgHorario.Columns["VIERNES"];
            //viernes.DataPropertyName = "VIERNES";
            //viernes.HeaderText = "VIERNES";
            viernes.Width = ancho;
            //matricula.Frozen = true;
            //viernes.ValueType = typeof(string);
            //dtgHorario.Columns.Add(viernes);

            DataGridViewColumn sabado = dtgHorario.Columns["SÁBADO"];
            //sabado.DataPropertyName = "SÁBADO";
            //sabado.HeaderText = "SÁBADO";
            sabado.Width = ancho;
            //matricula.Frozen = true;
            //sabado.ValueType = typeof(string);
            //dtgHorario.Columns.Add(sabado);



            foreach (DataGridViewColumn columna in dtgHorario.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void configurarTabla()
        {     
            definirAltoColumnas();
            definirColorFilas();
        }

        private int obtenerEdad(string fechaNacimiento)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            int diasEnMes = 30;
            int diasEnAno = 365;
            //Regex rg = new Regex(@"\d+");
            MatchCollection digitos = Regex.Matches(fechaActual, @"\d+");
            int[] digitosFechaActual = digitos.Cast<Match>().Select(d => int.Parse(d.Value)).ToArray();
            int diaActual = digitosFechaActual[0],
                mesActual = digitosFechaActual[1],
                anoActual = digitosFechaActual[2];

            digitos = Regex.Matches(fechaNacimiento, @"\d+");
            int[] digitosFechaNacimiento = digitos.Cast<Match>().Select(d => int.Parse(d.Value)).ToArray();
            int diaNacimiento = digitosFechaNacimiento[0],
                mesNacimiento = digitosFechaNacimiento[1],
                anoNacimiento = digitosFechaNacimiento[2];

            int fechaActualADias = diaActual + (mesActual * diasEnMes) + (anoActual * diasEnAno);
            int fechaNacimientoADias = diaNacimiento + (mesNacimiento * diasEnMes) + (anoNacimiento * diasEnAno);

            int diferenciaDias = fechaActualADias - fechaNacimientoADias;
            int edad = diferenciaDias / diasEnAno;
          
            return edad;
        }

        private void asignarInformacion()
        {
            panel1.Visible = true;
           
            tabla = estudiante.obtenerInformacionEstudiante(matricula);

            if (tabla.Rows.Count == 0) return;
            var tupla = tabla.Rows[0];
            lblMatricula.Text = matricula + "";
            lblMatricula.Visible = true;
            

            lblNombre.Text = tupla["nombre"].ToString();
            lblApellido.Text = tupla["apellido"].ToString();
            lblSexo.Text = tupla["sexo"].ToString();
            lblDireccion.Text = tupla["direccion"].ToString();
            lblEmail.Text = tupla["email"].ToString();
            lblCedula.Text = tupla["cedula"].ToString();
            lblNacionalidad.Text = tupla["nacionalidad"].ToString();
            lblFechaNacimiento.Text = tupla["fecha_nacimiento"].ToString();
            lblFechaIngreso.Text = tupla["fecha_ingreso"].ToString();

            //string fechaSalida = tupla["fecha_salida"].ToString();
            //Regex rg = new Regex(@"00/00/0000");
            //MessageBox.Show(fechaSalida.Length+"");
           
            lblFechaSalida.Text = tupla["fecha_salida"].ToString();
            

            int edad = obtenerEdad(lblFechaNacimiento.Text);
            lblEdad.Text = edad + "";


            lblEnfermedad.Text = tupla["enfermedad"].ToString();
            lblOcupacion.Text = tupla["ocupacion"].ToString();
            lblEstadoCivil.Text = tupla["estado_civil"].ToString();
            lblNivelAcademico.Text = tupla["nivel_academico"].ToString();
            lblTipoSangre.Text = tupla["tipo_de_sangre"].ToString();


            if (tupla["status"].ToString() == "Activo")
            {
                lblStatus.Text = "ACTIVO";
                lblStatus.BackColor = Color.Green;

            }
            else
            {
                lblStatus.Text = "INACTIVO";
                lblStatus.BackColor = Color.Red;
            }
           
            //panel1.BackColor = lblStatus.ForeColor;

            tabla = estudiante.obtenerTelefonosEstudiante(matricula);
            //int cantidadTelefono= dt.Rows.Count;
           
            foreach (DataRow fila in tabla.Rows)
            {
                string tipoTelefono= fila[0].ToString();
                string telefono = fila[1].ToString();
                telefono = $"{telefono.Substring(0,3)}-{telefono.Substring(2, 3)}-{telefono.Substring(5, 4)}";
                switch (tipoTelefono) {

                    case "1":
                        lblTelefono1.Text = telefono;
                        break;

                    case "2":
                        lblTelefono2.Text = telefono;
                        break;

                    case "3":
                        lblTelefonoEmg.Text = telefono;
                        break;
                }
            }
            
            //imagenes
            var datosFoto = estudiante.obtenerDatosFoto(matricula);

            if(datosFoto != null)
            {
                pictureBox1.BackgroundImage = Image.FromStream(datosFoto);
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }

            mostrarSedes();
            //MessageBox.Show(lblMatricula.Visible + "");
        }

        private void mostrarSedes()
        {     
            tabla = sede.obtenerSedes(matricula);       
            lstSede.DisplayMember = "descripcion";   
            lstSede.DataSource = tabla;
        }

        private void mostrarCursos()
        {     
            tabla = curso.obtenerCursos(matricula, idSede);
            lstCurso.DataSource = tabla;
            lstCurso.DisplayMember = "descripcion";
        }

        private void mostrarModalidad()
        {
            tabla = modalidad.obtenerModalidad(matricula, idSede, idCurso);
            nombreModalidad = tabla.Rows[0]["modalidad"] + "";
            string acronimo = tabla.Rows[0]["acronimo"] + "";
            lblModalidad.Text = $"{nombreModalidad} ({acronimo})";

            //idModalidad = modalidad.obtenerIdDeNombreModalidad(nombreModalidad);
            mostrarModulos();
        }

    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar a este estudiante?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                bool eliminado = estudiante.eliminarEstudiante(matricula);
                
                if(eliminado)
                {
                    MessageBox.Show("El estudiante fue eliminado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

       

     

        private void dtEstudiante_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Regular);
            dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            if (e.RowIndex % 2 == 0) // Cambiar solo las filas pares
            {
                dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0,54,54); // Establecer el color de fondo para las filas pares
                //dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0,99,89); // Establecer el color de fondo para las filas impares
                //dtEstudiante.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(0, 54, 54);
            }
        }

        private void dtEstudiante_DoubleClick(object sender, EventArgs e)
        {
            matricula = (int)dtEstudiante.SelectedRows[0].Cells[0].Value;
            btnAtras.Visible = true;
            dtEstudiante.Visible = false;
            asignarInformacion();
            bool tieneInscripcion = estudiante.verificarInscripcion(matricula);
         
            btnVerMas.Enabled = true;


            if (!tieneInscripcion)
            {
                btnInscripcion.Enabled = true;
                btnInscripcion.Focus();
                btnVerMas.Enabled = false;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            dtEstudiante.Visible = true;
            panel1.Visible = false;
            btnAtras.Visible = false;

        }

      

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            frmInscripcion frm = new frmInscripcion(matricula);
            frm.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAgregarEditarEstudiante frm = new frmAgregarEditarEstudiante(matricula, idUsuario);
            this.Hide();
            frm.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
        }

  
        private void btnVerMas_Click(object sender, EventArgs e)
        {
            bool estado = !panel2.Visible;
            panel2.Visible = estado;

            if (estado)
                btnVerMas.Text = "VOLVER";
            else btnVerMas.Text = "VER MÁS";
        }

        private void mostrarHorarios()
        {

            tabla = horario.obtenerHorario(matricula, idCurso);

            dtgHorario.DataSource = tabla;

            configurarTabla();


        }

  
      

        private void mostrarModulos()
        {

            //while (tbcModulo.TabCount > 0)
            //{
            //    TabPage tb = tbcModulo.TabPages[0];
            //    tbcModulo.TabPages.Remove(tb);
            //}

            tabla = modulo.obtenerModulos(matricula,idCurso);
            #region R  //MessageBox.Show(idCurso+"");

            //MessageBox.Show($"matricula{matricula} sede{idSede} curso{idCurso} modalidad{idModalidad} modulo{idModulo} {nombreModulo} {tbcModulo.TabCount} {tabla.Columns[0]}");
            //MessageBox.Show("m"+tbcModulo.TabCount);

            //foreach (TabPage item in tbcModulo.Controls.OfType<TabPage>())
            //{
            //    tbcModulo.TabPages.Remove(item);

            //}

            //foreach (DataRow fila in tabla.Rows)
            //{
            //    nombreModulo = fila[0].ToString();
            //    TabPage tbPage = new TabPage();           
            //    tbPage.Text = nombreModulo;
            //    tbPage.BackColor = Color.White;

            //    tbcModulo.Controls.Add(tbPage);
            //}
            #endregion
            lstModulo.DisplayMember = "descripcion";
            lstModulo.DataSource = tabla;
            
            nombreModulo = lstModulo.SelectedItem + "";
            idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);
            
            //tbcModulo.TabPages[0].Controls.Add(dtgHorario);
            //tbcModulo.SelectTab(0);
            //dtgHorario.Location = new Point(-1, 0);

            mostrarHorarios();

            //MessageBox.Show($"matricula{matricula} sede{idSede} curso{idCurso} modalidad{idModalidad} modulo{idModulo} {nombreModulo} {tbcModulo.TabCount} {tabla.Rows.Count}");


        }
      
        //private void colorearListBoxItem(ListBox lst, DrawItemEventArgs e)
        //{
        //    e.DrawBackground();

        //    // Determinar si el elemento está seleccionado
        //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //    {
        //        // Establecer el color de fondo y de primer plano para el elemento seleccionado
        //        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 64, 64)), e.Bounds);
        //        e.Graphics.DrawString(lst.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds);
        //    }
        //    else
        //    {
        //        // Establecer el color de fondo y de primer plano para los elementos no seleccionados
        //        e.Graphics.FillRectangle(Brushes.White, e.Bounds);
        //        e.Graphics.DrawString(lst.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
        //    }

        //    e.DrawFocusRectangle();
        //}

      

      

        //private void lstSede_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    colorearListBoxItem(lstSede, e);
        //}

        //private void lstCurso_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    colorearListBoxItem(lstCurso, e);
        //}

       

        private void tbcModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(tbcModulo.TabCount > 0)
            //{
            //    tbcModulo = (TabControl)sender;
            //    TabPage selectedTabPage = tbcModulo.SelectedTab;
            //    nombreModulo = selectedTabPage.Text;
            //    idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);
            //    mostrarHorarios();
            //    selectedTabPage.Controls.Add(dtgHorario);
            //}
        }


        private void lstSede_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (lstSede.SelectedIndex == -1)
                lstSede.SelectedIndex = 0;

            
            DataRowView fila = lstSede.SelectedItem as DataRowView;
            string nombreSede = fila["descripcion"] + "";

            idSede = sede.obtenerIdDeNombreSede(nombreSede);

            //ListBox lst = (ListBox)sender;
            //if (lst.Items.Count == 1)
            //{
            //    lst.SelectionMode = SelectionMode.None;
            //}
            //else
            //{
            //    lst.SelectionMode = SelectionMode.One;
            //}
          
            mostrarCursos();
        }

        private void lstCurso_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lstCurso.SelectedIndex == -1)
            {
                lstCurso.SelectedIndex = 0;
            }
            
            DataRowView fila = lstCurso.SelectedItem as DataRowView;
            nombreCurso = fila["descripcion"] + "";


            idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);

            tabla = curso.obtenerTandaCurso(matricula, idCurso);

            if (tabla.Rows.Count > 0)
            {
                string horaEntrada = tabla.Rows[0]["hora_entrada"].ToString();
                string tanda = new Regex(@"AM").IsMatch(horaEntrada) ? "Matutina"
                             : new Regex(@"^(12|[0][1-5]):[0-5][0-9] PM$").IsMatch(horaEntrada) ? "Verpertina"
                             : "Nocturna";

                lblTanda.Text = tanda;
            }
            else
            {
                lblTanda.Text = "---------";
            }
      
                
          

            //ListBox lst = (ListBox)sender;

            //if (lst.Items.Count == 1)
            //{
            //    lst.SelectionMode = SelectionMode.None;
            //}
            //else
            //{
            //    lst.SelectionMode = SelectionMode.One;
            //}

            mostrarModalidad();

        }







        //private void dtgHorario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    //    if (e.RowIndex == -1 && e.ColumnIndex >= 0)
        //    //    {
        //    //        e.PaintBackground(e.CellBounds, true);
        //    //        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0,64,64)))
        //    //        {
        //    //            e.Graphics.FillRectangle(brush, e.CellBounds);
        //    //        }

        //    //        // Dibujar el texto una vez después de pintar el fondo
        //    //        if (e.Value != null)
        //    //        {
        //    //            string headerText = e.Value.ToString();
        //    //            using (Font font = new Font(e.CellStyle.Font, FontStyle.Bold))
        //    //            {
        //    //                e.Graphics.DrawString(headerText, font, Brushes.White, e.CellBounds, StringFormat.GenericDefault);
        //    //            }
        //    //        }

        //    //        e.Handled = true;
        //    //    }
        //}








    }
}

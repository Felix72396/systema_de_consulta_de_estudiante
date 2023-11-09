using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmInscripcion : Form
    {
        public frmInscripcion()
        {
            InitializeComponent();
        }

        public frmInscripcion(int matricula)
        {
            InitializeComponent();
            this.matricula = matricula;

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        Curso curso = new Curso();
        Modulo modulo = new Modulo();
        Horario horario = new Horario();
        Estudiante estudiante = new Estudiante();

        List<int> listaIdRangoHorario = new List<int>();
        List<int> listaIdCursos = new List<int>();

        bool cargado = false;
        string nombreSede = "", nombreCurso = "", nombreModulo = "";

        int matricula, idSede = 0, cantidadCursos = 0, 
            idCurso = 0, idModulo = 0, idModulo2 = 0,
            idRangoHorario = 0, indice = -1;

        bool grabbed = false;
        int mx, my;


        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            cbSede.DisplayMember = "descripcion";
            cbSede.DataSource = sede.obtenerTodasLasSedes();
            cbSede.SelectedIndex = -1;
            cargado = true;

            listaIdCursos = curso.obtenerIdCursosInscripcion(matricula);
            cantidadCursos = listaIdCursos.Count;

            if (cantidadCursos > 0)
                crearTab();
        }

        private void frmInscripcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmDatosEstudiante frm = new frmDatosEstudiante(matricula);
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
                switch (listaPermisos[i])
                {
                    case "TO":
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnInscribir.Enabled = true;
                        break;

                    case "EL":
                        btnEliminar.Enabled = true;
                        break;

                    case "ED":
                        btnActualizar.Enabled = true;
                        break;

                    case "IN":
                        btnInscribir.Enabled = true;
                        break;
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedIndex = 0;
            DataRowView fila;

            int posicionSede = -1,
                posicionCurso = -1,
                posicionModulo1 = -1,
                posicionModulo2 = -1,
                posicionHorario = -1;

            for (int i = 0; i < cbSede.Items.Count; i++)
            {
                fila = cbSede.Items[i] as DataRowView;
                nombreSede = fila["descripcion"] + "";

                if (lblSede.Text == nombreSede)
                {
                    cbSede.SelectedIndex = i;
                }
            }

            for (int i = 0; i < cbCurso.Items.Count; i++)
            {
                fila = cbCurso.Items[i] as DataRowView;
                nombreCurso = fila["descripcion"] + "";

                if (lblCurso.Text == nombreCurso)
                {
                    cbCurso.SelectedIndex = i;
                   
                }
            }
  
            for (int i = 0; i < cbModulo.Items.Count; i++)
            {
                fila = cbModulo.Items[i] as DataRowView;
                nombreModulo = fila["descripcion"] + "";

                if (lblModulo1.Text == nombreModulo)
                {
                    cbModulo.SelectedIndex = i;
                   
                }
            }
            //idModuloAct = modulo.obtenerIdDeNombreModulo(lblModulo1.Text);

            for (int i = 0; i < cbModulo2.Items.Count; i++)
            {
                fila = cbModulo2.Items[i] as DataRowView;
                nombreModulo = fila["descripcion"] + "";

                if (lblModulo2.Text == nombreModulo)
                {
                    cbModulo2.SelectedIndex = i;
                   
                }
            }
            ////idModulo2Act = modulo.obtenerIdDeNombreModulo(lblModulo2.Text);

            string rango = horario.obtenerRangoHorario(matricula, idCurso);

            for (int i = 0; i < cbHorario.Items.Count; i++)
            {
                fila = cbHorario.Items[i] as DataRowView;
                string rangoCb = fila["rango"] + "";

                if (rango == rangoCb)
                {
                    cbHorario.SelectedIndex = i;
                    posicionHorario = i;
                }
            }


            posicionSede = cbSede.SelectedIndex;
            posicionCurso = cbCurso.SelectedIndex;
            posicionModulo1 = cbModulo.SelectedIndex;
            posicionModulo2 = cbModulo2.SelectedIndex;
            posicionHorario = cbHorario.SelectedIndex;


            //MessageBox.Show(posicionSede + "  " + posicionCurso + "  " + posicionModulo1 + "  " + posicionModulo2 + " " + posicionHorario);
            //MessageBox.Show($"{posicionSede} {posicionCurso} {posicionModulo1} {posicionModulo2} {posicionHorario}");
            //MessageBox.Show($"m1={posicionModulo1} m2={posicionModulo2}");
            frmActualizarInscripcion frm = new frmActualizarInscripcion(matricula, posicionSede, posicionCurso, posicionModulo1, posicionModulo2, posicionHorario);
            frm.Show();
            this.Hide();
            //actualizar = true;

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Está seguro que desea eliminar a este estudiante?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                indice = tabControl1.SelectedIndex - 1;
                int idC = listaIdCursos[indice];
                bool eliminado = estudiante.eliminarEstudianteInscripcion(matricula, idC);

                if (eliminado)
                {
                    MessageBox.Show("La inscripción fue eliminada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    int indice = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);

                    listaIdCursos.RemoveAt(indice-1);

                    crearTab();
                    if(tabControl1.TabPages.Count > 1)
                    {
                        tabControl1.SelectTab(1);
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                gpbInscripcion.Location = new Point(0, 0);
                TabPage tab = tabControl1.SelectedTab;
            
                tab.Controls.Add(gpbInscripcion);
                cargarInfoInscripcion();
            }
        }

        private void cbModulo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex != -1)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreModulo = fila["descripcion"] + "";
                idModulo2 = modulo.obtenerIdDeNombreModulo(nombreModulo); 
            }
        }

        private void crearTab()
        {

            foreach (TabPage item in tabControl1.TabPages)
            {
                if(item != tabControl1.TabPages[0])
                {
                    tabControl1.TabPages.Remove(item);
                }
            }
            for (int i = 0; i < listaIdCursos.Count; i++)
            {
                TabPage tab = new TabPage();
                tab.Text = $"INSCRIPCIÓN {i + 1}";
                tabControl1.TabPages.Add(tab);
            }
           
        }

        private void cargarInfoInscripcion()
        {
            DataTable tabla = new DataTable();
            indice = tabControl1.SelectedIndex - 1;
            int idC = listaIdCursos[indice];
           
            tabla = estudiante.obtenerInformacionInscripcionEstudiante(matricula, idC);
            //MessageBox.Show($"idC{idC} indice{indice}");

            if (tabla.Rows.Count > 0)
            {
                lblSede.Text = tabla.Rows[0].ItemArray[0] + "";
                lblCurso.Text = tabla.Rows[0].ItemArray[1] + "";
                lblModulo1.Text = tabla.Rows[0].ItemArray[2] + "";

                if (tabla.Rows.Count > 1)
                {
                    lblModulo2.Text = tabla.Rows[1].ItemArray[2] + "";
                }
                else
                {
                    lblModulo2.Text = "-------------------------------------------------------------------------------------------";
                }

                mostrarHorarios(idC);
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void mostrarHorarios(int idCurso)
        {
            DataTable tabla = new DataTable();
            tabla = horario.obtenerHorario(matricula, idCurso);

            dtgHorario.DataSource = tabla;

            configurarTabla();
        }

      
        private void configurarTabla()
        {
            definirAnchoColumnas();
            definirColorFilas();
        }

      

        private void definirAnchoColumnas()
        {

            int ancho = 112;

            dtgHorario.RowsDefaultCellStyle.Font = new Font(dtgHorario.Font.FontFamily, 1, FontStyle.Bold);

            DataGridViewColumn lunes = dtgHorario.Columns["LUNES"];
            lunes.Width = ancho;

            DataGridViewColumn martes = dtgHorario.Columns["MARTES"];
            martes.Width = ancho;

            DataGridViewColumn miercoles = dtgHorario.Columns["MIÉRCOLES"];
            miercoles.Width = ancho;

            DataGridViewColumn jueves = dtgHorario.Columns["JUEVES"];
            jueves.Width = ancho;

            DataGridViewColumn viernes = dtgHorario.Columns["VIERNES"];
            viernes.Width = ancho;

            DataGridViewColumn sabado = dtgHorario.Columns["SÁBADO"];
            sabado.Width = ancho;

            foreach (DataGridViewColumn columna in dtgHorario.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void definirColorFilas()
        {
            dtgHorario.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtgHorario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 64, 64); // Cambia el color de fondo
            dtgHorario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente
        }

        private void limpiarCampos()
        {
            foreach (var item in groupBox1.Controls.OfType<ComboBox>())
            {
                item.SelectedIndex = -1;

                if (item.Name != "cbSede") item.Enabled = false;
            }

            foreach (var item in groupBox1.Controls.OfType<Label>())
            {
                if(item.Tag == "dia")
                    item.Text = "---------------";
            }

            
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            if(tabControl1.TabPages.Count > 2)
            {
                MessageBox.Show("Solo se pueden tener 2 inscripciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DatosInscripcionEstudiante est;
            est.Matricula = matricula;
            est.IdSede = idSede;
            est.IdCurso = idCurso;

            est.IdModulo = idModulo;

            if (cbModulo2.SelectedIndex >= 0)
                est.IdModulo2 = idModulo2;
            else est.IdModulo2 = 0;

            est.IdRangoHorario = idRangoHorario;

            bool insertar = true;
            foreach (ComboBox cb in groupBox1.Controls.OfType<ComboBox>())
            {
                if (cb.SelectedIndex == -1 && cb.Tag == "sede1curso1")
                {
                    insertar = false;
                }
            }

            if (insertar)
            {
                //MessageBox.Show($"matricula-{matricula} sede={nombreSede}  idsede={idSede} curso = {nombreCurso} idcurso = {idCurso} modulo = {nombreModulo} idmodulo = {idModulo} idrango {idRangoHorario}");
                bool insertado = estudiante.insertarInscripcionEstudiante(est);

                if(insertado)
                {
                    limpiarCampos();

                    listaIdCursos = curso.obtenerIdCursosInscripcion(matricula);
                    cantidadCursos = listaIdCursos.Count;

                    cbSede.SelectedIndex = -1;

                    if(cantidadCursos > 0)
                        crearTab();
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void cbSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0 && cargado)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreSede = fila["descripcion"] + "";
                idSede = sede.obtenerIdDeNombreSede(nombreSede);

                cbCurso.DisplayMember = "descripcion";
                cbCurso.DataSource = sede.obtenerTodosLosCursosDeSede(idSede);
                cbCurso.SelectedIndex = -1;

                cbCurso.Enabled = true;
                cbModulo.Enabled = false;
                cbHorario.Enabled = false;

                if (cbModulo.Items.Count > 0)
                {
                    cbModulo.SelectedIndex = -1;
                    cbHorario.SelectedIndex = -1;
                }
            }
        }


        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0 && cargado)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreCurso = fila["descripcion"] + "";
                idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
                //MessageBox.Show(idCurso + "");
                //MessageBox.Show(idCurso + "");
                cbModulo.Enabled = true;
                cbModulo.DisplayMember = "descripcion";
                cbModulo.DataSource = modulo.obtenerModulosDeCurso(idCurso);
                cbModulo.SelectedIndex = -1;

                cbHorario.Enabled = true;
                cbHorario.DisplayMember = "rango";

                DataTable tabla = new DataTable();
                tabla = horario.obtenerRangosHorariosDeCurso(idCurso);
                cbHorario.DataSource = tabla;
                cbHorario.SelectedIndex = -1;

                listaIdRangoHorario.Clear();

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    //MessageBox.Show(tabla.Rows[i].ItemArray[0] + "klk" + tabla.Rows.Count + "kolo"+tabla.Columns.Count);
                    listaIdRangoHorario.Add(Convert.ToInt32(tabla.Rows[i].ItemArray[0]));
                    //MessageBox.Show(tabla.Rows[i]["id"] + "");
                }
                //MessageBox.Show(listaIdRangoHorario.Count + "");

                foreach (Label lbl in groupBox1.Controls.OfType<Label>())
                {
                    if (lbl.Tag == "dia")
                        lbl.Text = "---------------";
                }
            }
        }

        private void cbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex != -1)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreModulo = fila["descripcion"] + "";
                idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);

               if(cb.Items.Count > 1)
               {
                    cbModulo2.Enabled = true;
                    cbModulo2.DataSource = modulo.obtenerModulosDeCurso2(idCurso, idModulo);
                    cbModulo2.DisplayMember = "descripcion";
                    cbModulo2.SelectedIndex = -1;
               }
            }
            else
            {
                cbModulo2.Enabled = false;
            }
        }




        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaIdRangoHorario.Count > 0 && cbHorario.SelectedIndex >= 0)
            {
                idRangoHorario = listaIdRangoHorario[cbHorario.SelectedIndex];
                //MessageBox.Show(idRangoHorario+"");
                DataTable tabla = new DataTable();
                tabla = horario.obtenerDiasRangoHorario(idRangoHorario, idCurso);

                //MessageBox.Show(tabla.Rows.Count + "");
               if(tabla.Rows.Count > 0)
               {
                    lblLunes.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblMartes.Text = tabla.Rows[0].ItemArray[1].ToString();
                    lblMiercoles.Text = tabla.Rows[0].ItemArray[2].ToString();
                    lblJueves.Text = tabla.Rows[0].ItemArray[3].ToString();
                    lblViernes.Text = tabla.Rows[0].ItemArray[4].ToString();
                    lblSabado.Text = tabla.Rows[0].ItemArray[5].ToString();
               }
            }
        }
    }
}

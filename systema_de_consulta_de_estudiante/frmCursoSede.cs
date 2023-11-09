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
    public partial class frmCursoSede : Form
    {
        public frmCursoSede()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        Curso curso = new Curso();

        int idSede = 0;
        string nombreSede = "";
        bool cargado = false;

        bool grabbed = false;
        int mx, my;


        private void frmCursoSede_Load(object sender, EventArgs e)
        {
            cbSede.DisplayMember = "descripcion";
            cbSede.DataSource = sede.obtenerTodasLasSedes();
            cbSede.SelectedIndex = -1;
            cargado = true;
        }

        private void aplicarPermisos()
        {
            List<string> listaPermisos = new List<string>();
            listaPermisos = usuario.obtenerPermisosUsuario(idUsuario);


            if (listaPermisos.Count == 0) return;

            for (int i = 0; i < listaPermisos.Count; i++)
            {
                switch (listaPermisos[i])
                {
                    case "TO":
                        btnVerCursos.Enabled = true;
                        break;

                    case "IN":
                        btnVerCursos.Enabled = true;
                        break;
                }
            }

        }

        private void cbSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargado) return;
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreSede = fila["descripcion"] + "";
                idSede = sede.obtenerIdDeNombreSede(nombreSede);
                cargarCursos();
                configurarTablaCurso();
                
             
                configurarTablaCursosDisponibles();
            }
        }

        private void configurarTablaCurso()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreCurso = dtCurso.Columns["descripcion"];
            nombreCurso.Width = 640;
            nombreCurso.HeaderText = "DOBLE CLICK PARA ELIMINAR";

            foreach (DataGridViewColumn columna in dtCurso.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtCurso.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtCurso.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtCurso.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

            dtCurso.ColumnHeadersDefaultCellStyle.Font = new Font(dtCurso.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void configurarTablaCursosDisponibles()
        {

            DataGridViewColumn cursosDisponibles = dtCursosDisponibles.Columns["descripcion"];
            cursosDisponibles.Width = 640;
            cursosDisponibles.HeaderText = "DOBLE CLICK PARA AÑADIR";

            foreach (DataGridViewColumn columna in dtCursosDisponibles.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtCursosDisponibles.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtCursosDisponibles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtCursosDisponibles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

            dtCursosDisponibles.ColumnHeadersDefaultCellStyle.Font = new Font(dtCursosDisponibles.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void btnVerCursos_Click(object sender, EventArgs e)
        {
            if(cbSede.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una sede", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool estado = dtCursosDisponibles.Visible;
            dtCursosDisponibles.Visible = !estado;
            dtCurso.Visible = estado;
            cargarCursos();
            if(!estado)
            {
                btnVerCursos.Text = "VOLVER";
               
            }
            else
            {
                btnVerCursos.Text = "VER CURSOS";
                //dtCursosDisponibles.DataSource = null;
            }
        }

        private void cargarCursos()
        {
            dtCurso.DataSource = sede.obtenerTodosLosCursosDeSede(idSede);
            dtCursosDisponibles.DataSource = curso.obtenerTodosLosCursos(idSede);

        }

        private void dtCursosDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if(dtCursosDisponibles.RowCount == 0)
            {
                MessageBox.Show("No hay cursos que agregar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cbSede.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una sede", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string nombreCurso = (string)dtCursosDisponibles.SelectedRows[0].Cells[0].Value;
                int idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
                bool insertado = curso.insertarCursoEnSede(idSede, idCurso);

                if(insertado)
                {
                    cargarCursos();
                }

                //dtCursosDisponibles.Visible = false;
                //dtCurso.Visible = true;
            }

        }

        private void dtCurso_DoubleClick(object sender, EventArgs e)
        {
            if (dtCurso.RowCount == 0)
            {
                MessageBox.Show("No hay cursos que eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbSede.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una sede", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreCurso = (string)dtCurso.SelectedRows[0].Cells[0].Value;
            int idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);

            DialogResult resultado = MessageBox.Show("Desea eliminar el curso de la sede?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                curso.eliminarCursoEnSede(idSede, idCurso);
                cargarCursos();
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

        private void dtCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCursoSede_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }
    }
}

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
    public partial class frmModuloCurso : Form
    {
        public frmModuloCurso()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


        Usuario usuario = new Usuario();
        int idUsuario = 0;


        Modulo modulo = new Modulo();
        Curso curso = new Curso();
        int idCurso = 0;
        string nombreCurso = "";
        bool cargado = false;

        bool grabbed = false;
        int mx, my;


        private void frmModuloCurso_Load(object sender, EventArgs e)
        {
            cbCurso.DisplayMember = "descripcion";
            cbCurso.DataSource = curso.obtenerTodosLosCursos();
            cbCurso.SelectedIndex = -1;
            cargado = true;
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
                        btnVerModulos.Enabled = true;
                 
                        break;

                    case "IN":
                        btnVerModulos.Enabled = true;
                        break;
                }
            }

        }

        private void configurarTablaModulo()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreCurso = dtModulo.Columns["descripcion"];
            nombreCurso.Width = 640;
            nombreCurso.HeaderText = "DOBLE CLICK PARA ELIMINAR";

            foreach (DataGridViewColumn columna in dtModulo.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtModulo.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtModulo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtModulo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente
          
            dtModulo.ColumnHeadersDefaultCellStyle.Font = new Font(dtModulo.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void configurarTablaModulosDisponibles()
        {

            DataGridViewColumn cursosDisponibles = dtModulosDisponibles.Columns["descripcion"];
            cursosDisponibles.Width = 640;
            cursosDisponibles.HeaderText = "DOBLE CLICK PARA AÑADIR";

            foreach (DataGridViewColumn columna in dtModulosDisponibles.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtModulosDisponibles.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtModulosDisponibles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtModulosDisponibles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

            dtModulosDisponibles.ColumnHeadersDefaultCellStyle.Font = new Font(dtModulosDisponibles.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void cargarModulos()
        {
            dtModulo.DataSource = curso.obtenerTodosLosModulosDeCurso(idCurso);
            dtModulosDisponibles.DataSource = modulo.obtenerTodosLosModulos(idCurso);

        }

        private void btnVerModulos_Click(object sender, EventArgs e)
        {
            if (cbCurso.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool estado = dtModulosDisponibles.Visible;
            dtModulosDisponibles.Visible = !estado;
            dtModulo.Visible = estado;
            cargarModulos();
            if (!estado)
            {
                btnVerModulos.Text = "VOLVER";

            }
            else
            {
                btnVerModulos.Text = "VER MÓDULOS";
                //dtCursosDisponibles.DataSource = null;
            }
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargado) return;

            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreCurso = fila["descripcion"] + "";
                idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
                cargarModulos();
                configurarTablaModulo();


                configurarTablaModulosDisponibles();
            }
        }

        private void dtModulo_DoubleClick(object sender, EventArgs e)
        {
            if (dtModulo.RowCount == 0)
            {
                MessageBox.Show("No hay módulos que eliminar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCurso.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreModulo = (string)dtModulo.SelectedRows[0].Cells[0].Value;
            int idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);

            DialogResult resultado = MessageBox.Show("Desea eliminar el módulo del curso?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                modulo.eliminarModuloEnCurso(idCurso, idModulo);
                cargarModulos();
            }

        }

        private void dtModulosDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if (dtModulosDisponibles.RowCount == 0)
            {
                MessageBox.Show("No hay módulos que agregar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCurso.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un curso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string nombreModulo = (string)dtModulosDisponibles.SelectedRows[0].Cells[0].Value;
                int idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);
                bool insertado = modulo.insertarModuloEnCurso(idCurso, idModulo);

                if (insertado)
                {
                    cargarModulos();
                }

                //dtCursosDisponibles.Visible = false;
                //dtCurso.Visible = true;
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

        private void frmModuloCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }
    }
}

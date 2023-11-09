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
    public partial class frmCurso : Form
    {
        public frmCurso()
        {
            InitializeComponent();
            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


      

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Curso curso = new Curso();
        DataTable tabla;

        string acronimo = "";

        bool grabbed = false;
        int mx, my;


        private void frmCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void frmCurso_Load(object sender, EventArgs e)
        {
            tabla = curso.obtenerTodosLosCursos();
            dtCurso.DataSource = tabla;
          
            configurarTablaCurso();
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
                        btnAgregar.Enabled = true;
                        break;
                    case "IN":
                        btnAgregar.Enabled = true;
                        break;

                }
            }

        }

        private void configurarTablaCurso()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreCurso = dtCurso.Columns["descripcion"];
            nombreCurso.Width = 540;
            nombreCurso.HeaderText = "CURSO(S)";

            DataGridViewColumn modalidad = dtCurso.Columns["modalidad"];
            modalidad.Width = 200;
            modalidad.HeaderText = "MODALIDAD";

            foreach (DataGridViewColumn columna in dtCurso.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtCurso.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtCurso.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtCurso.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

            dtCurso.ColumnHeadersDefaultCellStyle.Font = new Font(dtCurso.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCurso.Text == "" || cbModalidad.SelectedIndex == -1)
            {
                MessageBox.Show("El campo está vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool insertado = curso.insertarCurso(txtCurso.Text, acronimo);

            if (insertado)
            {
                tabla = curso.obtenerTodosLosCursos();
                dtCurso.DataSource = tabla;
                configurarTablaCurso();
                txtCurso.Clear();
                cbModalidad.SelectedIndex = -1;
                MessageBox.Show("El curso fue insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtCurso_DoubleClick(object sender, EventArgs e)
        {
            if (dtCurso.RowCount > 0)
            {
                string nombreCurso = (string)dtCurso.SelectedRows[0].Cells[0].Value;
                acronimo = (string)dtCurso.SelectedRows[0].Cells[1].Value;
                frmActualizarYEliminarCurso frm = new frmActualizarYEliminarCurso(nombreCurso, acronimo);
                frm.ShowDialog();
                tabla = curso.obtenerTodosLosCursos();
                dtCurso.DataSource = tabla;
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

        private void cbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbModalidad.SelectedIndex)
            {
                case 0:
                    acronimo = "FHP";
                    break;

                case 1:
                    acronimo = "FCP";
                    break;

                case 2:
                    acronimo = "FCC";
                    break;

                case 3:
                    acronimo = "FMT";
                    break;

                case 4:
                    acronimo = "FD";
                    break;

                case 5:
                    acronimo = "D";
                    break;

                case 6:
                    acronimo = "H/C";
                    break;
            }
        }
    }
}

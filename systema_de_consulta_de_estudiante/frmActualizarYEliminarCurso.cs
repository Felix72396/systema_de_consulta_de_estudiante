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
    public partial class frmActualizarYEliminarCurso : Form
    {
        public frmActualizarYEliminarCurso()
        {
            InitializeComponent();
        }

        public frmActualizarYEliminarCurso(string nombreCurso, string acronimo)
        {
            InitializeComponent();
            this.nombreCurso = nombreCurso;
            this.acronimo = acronimo;
            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Curso curso = new Curso();
        string nombreCurso = "", acronimo = "";

        bool grabbed = false;
        int mx, my;


        private void frmActualizarYEliminarCurso_Load(object sender, EventArgs e)
        {
            txtCurso.Text = nombreCurso;
            lblNombreCurso.Text = nombreCurso;
            //MessageBox.Show(acronimo);

            for (int i = 0; i < cbModalidad.Items.Count; i++)
            {
                if(cbModalidad.Items[i].ToString().Contains($"({acronimo})"))
                {
                 
                    cbModalidad.SelectedIndex = i;
                    break;
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Desea eliminar el curso?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                int idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
                bool eliminado = curso.eliminarCurso(idCurso);

                if (eliminado)
                {
                    MessageBox.Show("El curso fue eliminado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

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
                        btnEliminar.Enabled = true;
                        btnActualizar.Enabled = true;
                        break;

                    case "EL":
                        btnEliminar.Enabled = true;
                        break;

                    case "ED":
                        btnActualizar.Enabled = true;
                        break;
                }
            }

        }

        private void cbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbModalidad.SelectedIndex)
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
        }

    
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCurso.Text == "" || cbModalidad.SelectedIndex == -1)
            {
                MessageBox.Show("El campo está vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool actualizado = curso.actualizarCurso(nombreCurso, txtCurso.Text, acronimo);

            if (actualizado)
            {
                MessageBox.Show("El curso fue actualizado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

      
    }
}

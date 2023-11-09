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
    public partial class frmActualizarYEliminarSede : Form
    {
        public frmActualizarYEliminarSede()
        {
            InitializeComponent();
        }

        public frmActualizarYEliminarSede(string nombreSede)
        {
            InitializeComponent();
            this.nombreSede = nombreSede;

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        string nombreSede = "";

        bool grabbed = false;
        int mx, my;


        private void frmActualizarYEliminarSede_Load(object sender, EventArgs e)
        {
            txtSede.Text = nombreSede;
            lblNombreSede.Text = nombreSede;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Desea eliminar la sede?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {
                int idSede = sede.obtenerIdDeNombreSede(nombreSede);
                bool eliminado = sede.eliminarSede(idSede);
       

                if(eliminado)
                {
                    MessageBox.Show("La sede fue eliminada", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtSede.Text == "")
            {
                MessageBox.Show("El campo está vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool actualizado = sede.actualizarSede(nombreSede, txtSede.Text);

            if (actualizado)
            {
                MessageBox.Show("La sede fue actualizada", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }
    }
}

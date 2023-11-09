using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


        Usuario usuario = new Usuario();
        int idUsuario = 0;

        bool grabbed = false;
        int mx, my;

       



        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Application.Run(new frmSede());
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            llamarFormulario("frmLogin");
        }

        private void aplicarPermisos()
        {
            List<string> listaPermisos = new List<string>();
            listaPermisos = usuario.obtenerPermisosUsuario(idUsuario);
          

            if (listaPermisos.Count == 0) return;

            for (int i = 0; i < listaPermisos.Count; i++)
            {
                switch(listaPermisos[i])
                {
                    case "TO":
                        usuarioToolStripMenuItem.Enabled = true;
                        break;
                }
            }

        }


        private void llamarFormulario(string nombreClase)
        {
         
            nombreClase = $"systema_de_consulta_de_estudiante.{nombreClase}";
            Type tipoClase = Type.GetType(nombreClase);

            if (tipoClase.IsSubclassOf(typeof(Form)))
            {
                //object[] args = new object[] { "idUsuario", idUsuario };
                Form frm = (Form)Activator.CreateInstance(tipoClase);
                
                this.Hide();
                frm.Show();
            }
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmLogin");
        }
       

       

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmConsultaEstudiante");
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmConsultaEstudiante");
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmAgregarEditarEstudiante");
        }

     
        private void btnSede_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmSede");
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmCurso");
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmHorario");
        }

        private void btnModulo_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmModulo");
        }

      

        private void sedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmSede");
        }

        private void móduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void informacionCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmCurso");
        }

        private void modalidadCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmModalidadCurso");
        }

        private void cursoSedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmCursoSede");
        }

        private void informaciónMóduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmModulo");
        }

        private void móduloCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmModuloCurso");
        }

        private void horarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void horarioCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmHorario");
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

        private void rangoHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llamarFormulario("frmRangoHorario");
        }
    }
}

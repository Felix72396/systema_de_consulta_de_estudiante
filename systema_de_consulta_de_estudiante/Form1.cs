using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //https://www.youtube.com/watch?v=0B_jbd9kTbk

        Usuario usuario = new Usuario();

        bool grabbed = false;
        int mx, my;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.AutoCompleteCustomSource = usuario.obtenerUsuarios();
            //MessageBox.Show(usuario.obtenerUsuarios()+"");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
           bool resultado = usuario.ValidarUsuario(txtUsuario.Text,txtClave.Text);
            if (resultado)
            {
                frmPrincipal frm = new frmPrincipal();
                this.Hide();
                frm.Show();
                
            }
            else
            {
                MessageBox.Show("Datos incorrectos","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_MouseHover(object sender, EventArgs e)
        {
            //btnOK.ForeColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
                Application.Exit();
            //}
            //catch(Exception ex)
            //{
            //    this.Close();
            //}
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUsuario.TextLength > 0)
                    if(txtClave.TextLength == 0)
                    {
                        //e.SuppressKeyPress = true; // Evita que se procese la tecla Enter por defecto
                        e.SuppressKeyPress = true;
                        txtClave.Focus();
                    }
                    else
                    {
                        btnOK.PerformClick();
                    }
            }

           
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtClave.TextLength > 0)
                    if (txtUsuario.TextLength == 0)
                    {
                        //e.SuppressKeyPress = true; // Evita que se procese la tecla Enter por defecto
                        e.SuppressKeyPress = true;
                        txtUsuario.Focus();
                    }
                    else
                    {
                        btnOK.PerformClick();
                    }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0,1);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
            //w = this.Width;
            //h = this.Height;
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }
    }
}

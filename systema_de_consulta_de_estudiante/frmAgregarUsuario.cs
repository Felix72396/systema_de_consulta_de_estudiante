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
    public partial class frmAgregarUsuario : Form
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();

        bool grabbed = false;
        int mx, my;

        DataTable tabla;



        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            tabla = usuario.obtenerTodosLosUsuarios();
            dtUsuario.DataSource = tabla;
            configurarTablaUsuario();
            foreach (var item in groupBox1.Controls.OfType<CheckBox>())
            {
                item.CheckedChanged += chkChecked;

            }

        }

        private void chkChecked(object sender, EventArgs e)
        {
            //MessageBox.Show("ff");
            CheckBox rdb = (CheckBox)sender;
            if (rdb.Checked)
                rdb.ForeColor = Color.White;
            else
                rdb.ForeColor = Color.FromArgb(0, 64, 64);
        }

        private void configurarTablaUsuario()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreUsuario = dtUsuario.Columns["usuario"];
            nombreUsuario.Width = 290;
            nombreUsuario.HeaderText = "USUARIO(S)";

            foreach (DataGridViewColumn columna in dtUsuario.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtUsuario.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtUsuario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtUsuario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente



            //dtEstudiante.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
            //dtEstudiante.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas


            dtUsuario.ColumnHeadersDefaultCellStyle.Font = new Font(dtUsuario.Font.FontFamily, 20, FontStyle.Bold);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                MessageBox.Show("Inserte el usuario", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtClave.Text == "")
            {
                MessageBox.Show("Inserte la clave", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool permisoAsignado = false;
            List<string> listaPermisos = new List<string>();
            foreach (var item in groupBox1.Controls.OfType<CheckBox>())
            {
                if(item.Checked)
                {
                    listaPermisos.Add(item.Tag.ToString());
                    permisoAsignado = true;
                }
            }

            if(!permisoAsignado)
            {
                MessageBox.Show("Elija al menos un permiso", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool insertado = usuario.insertarUsuario(txtUsuario.Text, txtClave.Text, listaPermisos);

            if(insertado)
            {
                MessageBox.Show("Usuario insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabla = usuario.obtenerTodosLosUsuarios();
                dtUsuario.DataSource = tabla;
            }

        }

        private void frmAgregarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
        }
    }
}

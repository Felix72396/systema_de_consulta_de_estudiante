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
    public partial class frmEditarEliminarUsuario : Form
    {
        public frmEditarEliminarUsuario()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();

        string nombreActualUsuario = "";
        int idUsuario = 0;

        List<string> listaPermisos = new List<string>();

        bool grabbed = false;
        int mx, my;

        DataTable tabla;


        private void frmEditarEliminarUsuario_Load(object sender, EventArgs e)
        {
            cargarDatos();


            foreach (var item in groupBox1.Controls.OfType<CheckBox>())
            {
                item.CheckedChanged += chkChecked;

            }
        }

        private void cargarDatos()
        {
            tabla = usuario.obtenerTodosLosUsuarios();
            dtUsuario.DataSource = tabla;
            configurarTablaUsuario();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            foreach (var item in groupBox1.Controls.OfType<CheckBox>())
            {
                item.Checked = false;
            }

            foreach (var item in this.Controls.OfType<TextBox>())
            {
                item.Clear();
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

            dtUsuario.ColumnHeadersDefaultCellStyle.Font = new Font(dtUsuario.Font.FontFamily, 20, FontStyle.Bold);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
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

        private void frmEditarEliminarUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void dtUsuario_Click(object sender, EventArgs e)
        {
            limpiarCampos();

            nombreActualUsuario = dtUsuario.SelectedRows[0].Cells[0].Value + "";
            txtUsuario.Text = nombreActualUsuario;
            idUsuario = usuario.ObtenerIdUsuario(nombreActualUsuario);

            listaPermisos = usuario.obtenerPermisosUsuario(idUsuario);
            
            for (int i = 0; i < listaPermisos.Count; i++)
            {
                foreach (var item in groupBox1.Controls.OfType<CheckBox>())
                {
                    if (item.Tag.ToString() == listaPermisos[i])
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool eliminado = usuario.eliminarUsuario(idUsuario);

            if(eliminado)
            {
                MessageBox.Show("El usuario fue eliminado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                MessageBox.Show("El campo usuario se encuentra vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtClaveActual.Text == "")
            {
                MessageBox.Show("Digite la clave actual", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtClaveNueva.Text == "")
            {
                MessageBox.Show("Digite la clave nueva", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool permisoAsignado = false;
            foreach (var item in groupBox1.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    listaPermisos.Add(item.Tag.ToString());
                    permisoAsignado = true;
                }
            }

            if (!permisoAsignado)
            {
                MessageBox.Show("Elija al menos un permiso", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool actualizado = usuario.actualizarUsuario(txtUsuario.Text, nombreActualUsuario, txtClaveNueva.Text, txtClaveActual.Text, listaPermisos);

            if(actualizado)
            {
                MessageBox.Show("El usuario fue actualizado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatos();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

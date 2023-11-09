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
    public partial class frmModulo : Form
    {
        public frmModulo()
        {
            InitializeComponent();
            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
          
        }



        Usuario usuario = new Usuario();
        int idUsuario = 0;

        DataTable tabla = new DataTable();
        Modulo modulo = new Modulo();

        bool grabbed = false;
        int mx, my;


        private void frmModulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
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
                        btnAgregar.Enabled = true;
                        break;

                    case "IN":
                        btnAgregar.Enabled = true;
                        break;
                }
            }

        }

        private void dtModulo_DoubleClick(object sender, EventArgs e)
        {
            if (dtModulo.RowCount > 0)
            {
                string nombreModulo = (string)dtModulo.SelectedRows[0].Cells[0].Value;

                frmActualizarYEliminarModulo frm = new frmActualizarYEliminarModulo(nombreModulo);
                frm.ShowDialog();
                tabla = modulo.obtenerTodosLosModulos();
                dtModulo.DataSource = tabla;
            }
        }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            tabla = modulo.obtenerTodosLosModulos();
            dtModulo.DataSource = tabla;

            configurarTablaModulo();
        }

        private void configurarTablaModulo()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreCurso = dtModulo.Columns["descripcion"];
            nombreCurso.Width = 540;
            nombreCurso.HeaderText = "MÓDULO(S)";

            foreach (DataGridViewColumn columna in dtModulo.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtModulo.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtModulo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtModulo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente

            dtModulo.ColumnHeadersDefaultCellStyle.Font = new Font(dtModulo.Font.FontFamily, 20, FontStyle.Bold);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtModulo.Text == "")
            {
                MessageBox.Show("El campo está vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool insertado = modulo.insertarModulo(txtModulo.Text);

            if (insertado)
            {
                tabla = modulo.obtenerTodosLosModulos();
                dtModulo.DataSource = tabla;
                configurarTablaModulo();
                txtModulo.Clear();
            
                MessageBox.Show("El modulo fue insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

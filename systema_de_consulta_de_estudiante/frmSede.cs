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
    public partial class frmSede : Form
    {
        public frmSede()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }

 

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        DataTable tabla;

        bool grabbed = false;
        int mx, my;


        private void frmSede_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void frmSede_Load(object sender, EventArgs e)
        {
            tabla = sede.obtenerTodasLasSedes();
            dtSede.DataSource = tabla;
            configurarTablaSede();
         
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

        private void configurarTablaSede()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreSede = dtSede.Columns["descripcion"];
            nombreSede.Width = 540;
            nombreSede.HeaderText = "SEDE(S)";

            foreach (DataGridViewColumn columna in dtSede.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtSede.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtSede.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtSede.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente



            //dtEstudiante.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
            //dtEstudiante.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas


            dtSede.ColumnHeadersDefaultCellStyle.Font = new Font(dtSede.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtSede.Text == "")
            {
                MessageBox.Show("El campo está vacío", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool insertado = sede.insertarSede(txtSede.Text);

            if(insertado)
            {
                tabla = sede.obtenerTodasLasSedes();
                dtSede.DataSource = tabla;
                configurarTablaSede();
                txtSede.Clear();
                MessageBox.Show("La sede fue insertada", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dtSede_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dtSede.RowCount > 0)
            {
                string nombreSede = (string)dtSede.SelectedRows[0].Cells[0].Value;
                frmActualizarYEliminarSede frm = new frmActualizarYEliminarSede(nombreSede);
                frm.ShowDialog();
                tabla = sede.obtenerTodasLasSedes();
                dtSede.DataSource = tabla;
            }
        }

    }
}

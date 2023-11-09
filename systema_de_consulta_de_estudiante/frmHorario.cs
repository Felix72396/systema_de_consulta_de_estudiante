using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmHorario : Form
    {
        public frmHorario()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Horario horario = new Horario();
        Curso curso = new Curso();

        DataTable tabla;

        int idCurso = 0, idRangoHorario = 0;
        string rango = "", nombreCurso = "";

        bool grabbed = false;
        int mx, my;


        private void frmHorario_Load(object sender, EventArgs e)
        {
            tabla = curso.obtenerTodosLosCursos();
            dtCurso.DataSource = tabla;
            configurarTablaCursos();

           

            foreach (var item in groupBox3.Controls.OfType<CheckBox>())
            {
                item.CheckStateChanged += chkChecked;
            }
        }

        private void frmHorario_FormClosing(object sender, FormClosingEventArgs e)
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
                        btnEliminar.Enabled = true;
                        btnAgregarRhEnCurso.Enabled = true;
                        break;

                    case "EL":
                        btnEliminar.Enabled = true;
                        break;

                    case "ED":
                        btnAgregarRhEnCurso.Enabled = true;
                        break;
                }
            }

        }

        private void chkChecked(object sender, EventArgs e)
        {
            //MessageBox.Show("ff");
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
                chk.ForeColor = Color.White;
            else 
                chk.ForeColor = Color.FromArgb(0, 64, 64);
        }



        private void configurarTablaCursos()
        {
            //dtSede.Visible = true;
            DataGridViewColumn nombreSede = dtCurso.Columns["descripcion"];
            nombreSede.Width = 540;
            nombreSede.HeaderText = "SELECCIONA UN CURSO";

            foreach (DataGridViewColumn columna in dtCurso.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtCurso.EnableHeadersVisualStyles = false; // Deshabilita el estilo visual predeterminado
            dtCurso.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 44, 44); // Cambia el color de fondo
            dtCurso.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Cambia el color de la fuente



            //dtEstudiante.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
            //dtEstudiante.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas


            dtCurso.ColumnHeadersDefaultCellStyle.Font = new Font(dtCurso.Font.FontFamily, 20, FontStyle.Bold);
        }

        private void cargarHorarios()
        {
            cbHorario1.DataSource = horario.obtenerRangosHorarios(idCurso);
            cbHorario1.DisplayMember = "rango";
            cbHorario1.SelectedIndex = -1;

            cbHorario2.DataSource = horario.obtenerRangosHorariosDeCurso(idCurso);
            cbHorario2.DisplayMember = "rango";
            cbHorario2.SelectedIndex = -1;
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

        private void btnAgregarRhEnCurso_Click(object sender, EventArgs e)
        {
            if(cbHorario1.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un rango horario", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> dias = new List<string>();

            foreach (var item in groupBox3.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    dias.Add(item.Text.Substring(0, 2));
                }
            }

            if (dias.Count == 0)
            {
                MessageBox.Show("Elija uno o varios días de la semana", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            string nombreCurso = (string)dtCurso.SelectedRows[0].Cells[0].Value;
            idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);

            DataRowView fila = cbHorario1.SelectedItem as DataRowView;
            rango = fila["rango"] + "";
            idRangoHorario = horario.obtenerIdDeRangoHorario(rango);

            bool insertado = horario.insertarHorarioEnCurso(dias, idCurso, idRangoHorario);

            if(insertado)
            {
                foreach (var item in groupBox3.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }

                MessageBox.Show("Horario insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarHorarios();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            if (cbHorario2.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un rango horario del curso", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Desea eliminar el horario de este curso?", "Pregunta", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                string nombreCurso = (string)dtCurso.SelectedRows[0].Cells[0].Value;
                idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);

                DataRowView fila = cbHorario2.SelectedItem as DataRowView;
                rango = fila["rango"] + "";
                idRangoHorario = horario.obtenerIdDeRangoHorario(rango);

                bool eliminado = horario.eliminarHorarioEnCurso(idCurso, idRangoHorario);

                if(eliminado)
                {
                    MessageBox.Show("Horario eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarHorarios();
                }

            }



        }



        private void dtCurso_SelectionChanged(object sender, EventArgs e)
        {
            if(dtCurso.SelectedRows.Count > 0)
            {
                nombreCurso = (string)dtCurso.SelectedRows[0].Cells[0].Value;
                idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);

                cargarHorarios();
            }
        }
    }
}

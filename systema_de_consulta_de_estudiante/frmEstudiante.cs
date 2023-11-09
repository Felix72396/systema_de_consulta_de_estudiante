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
    public partial class frmEstudiante : Form
    {
        public frmEstudiante()
        {
            InitializeComponent();
        }

        Estudiante estudiante = new Estudiante();
        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            //configurarTabla();
            //dataGridView1.DataSource = estudiante.obtenerEstudiantes();
        }

        //private void definirColorFilas()
        //{
        //    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 64, 64);//color de fondo de la cabecera de las columnas
        //    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;//color de fondo de las letras de la cabecera de las columnas

        //    dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 54, 54);//color de seleccion de las filas
        //    dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;//color de seleccion de las letras de las filas

        //    dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(0, 84, 84);//color por defecto del fondo de las filas
        //    dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White; //color por defecto de las letras de las filas
        //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;//color alternado del fondo de las filas
        //    dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 64, 64);//color alternado de las letras de las filas

        //}

        //private void definirColumnas()
        //{
        //    DataGridViewTextBoxColumn matricula = new DataGridViewTextBoxColumn();
        //    matricula.DataPropertyName = "matricula";
        //    matricula.HeaderText = "MATRÍCULA";
        //    matricula.Width = 170;
        //    matricula.Frozen = true;
        //    matricula.ValueType = typeof(int);
        //    dataGridView1.Columns.Add(matricula);

        //    DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
        //    nombre.DataPropertyName = "nombre";
        //    nombre.HeaderText = "NOMBRE";
        //    nombre.Width = 180;
        //    nombre.Frozen = true;
        //    nombre.ValueType = typeof(string);
        //    dataGridView1.Columns.Add(nombre);

        //    DataGridViewTextBoxColumn apellido = new DataGridViewTextBoxColumn();
        //    apellido.DataPropertyName = "apellido";
        //    apellido.HeaderText = "APELLIDO";
        //    apellido.Width = 180;
        //    apellido.Frozen = true;
        //    apellido.ValueType = typeof(string);
        //    dataGridView1.Columns.Add(apellido);

        //    foreach (DataGridViewColumn columna in dataGridView1.Columns)
        //    {
        //        columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        //    }
        //}

        //private void configurarTabla()
        //{
        //    definirColorFilas();
        //    definirColumnas();
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        //private void consultar()
        //{
        //    string consulta = "select * from Estudiante";
        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DatosEstudiante est;
            est.matricula = txtMatricula.Text.Length > 0 ? txtMatricula.Text : "%%";
            est.cedula = txtCedula.Text.Length > 0 ? txtCedula.Text : "%%";
            est.nombre = txtNombre.Text.Length > 0 ? txtNombre.Text : "%%";
            est.apellido = txtApellido.Text.Length > 0 ? txtApellido.Text : "%%";
            est.nacionalidad = txtNacionalidad.Text.Length > 0 ? txtNacionalidad.Text : "%%";
            est.sede = cbSede.SelectedIndex != -1 ? cbSede.SelectedItem.ToString() : "%%";
            est.curso = txtCurso.Text.Length > 0 ? txtCurso.Text : "%%";
            est.modulo = txtModulo.Text.Length > 0 ? txtModulo.Text : "%%";
           

            switch(cbTanda.SelectedIndex)
            {
                case 0:
                    est.tanda = "%[AM]%";
                    break;

                case 1:
                    est.tanda = "%[0-1][1-5]:[0-5][0-9] PM%";
                    break;

                case 2:
                    est.tanda = "%[0][6-9]:[0-5][0-9] PM%";
                    break;

                default:
                    est.tanda = "%%";
                    break;
            }
            
            est.modalidad = cbModalidad.SelectedIndex == -1 ? cbModalidad.SelectedItem + "" : "%%";
            est.telefono = txtTelefono.Text.Length > 0 ? txtTelefono.Text : "%%";

            //MessageBox.Show(est.matricula + est.cedula + est.nombre + est.apellido + est.nacionalidad + est.sede + est.curso + est.modulo + est.tanda + est.modalidad + est.telefono);

            bool consultar = false;
            foreach (var control in panel1.Controls.OfType<TextBox>())
            {
               if(control.Text.Length > 0)
                consultar = true;
            }

            foreach (var control in panel1.Controls.OfType<ComboBox>())
            {
                if (control.SelectedIndex != -1)
                    consultar = true;
            }

            if (consultar)
            {
                int matricula = estudiante.obtenerMatriculaEstudiante(est);
                frmDatosEstudiante frm = new frmDatosEstudiante(matricula);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Al menos llena un campo para consultar");
            }
            
        }

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
      
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void cbSede_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtModulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void cbTanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void cbModalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.PerformClick();
        }





        //private void rdbTel1_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool state = rdbTel1.Checked;
        //    txtTelefono1.Enabled = state;
        //}

        //private void rdbTel2_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool state = rdbTel2.Checked;

        //    txtTelefono2.Enabled = state;
        //}

        //private void rdbTelEmg_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool state = rdbTelEmg.Checked;
        //    txtTelefonoEmg.Enabled = state;
        //}
    }
    internal struct DatosEstudiante
    {
        internal string matricula, cedula, nombre, apellido, nacionalidad, sede, curso, modulo, tanda, modalidad, telefono;
    }
}

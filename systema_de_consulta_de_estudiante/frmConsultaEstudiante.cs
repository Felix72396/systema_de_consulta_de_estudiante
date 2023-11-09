using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmConsultaEstudiante : Form
    {
        public frmConsultaEstudiante()
        {
            InitializeComponent();
            this.idUsuario = Usuario.IdUsuario;
        }

        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Estudiante estudiante = new Estudiante();
        Sede sede = new Sede();
        Curso curso = new Curso();
        Modalidad modalidad = new Modalidad();
        Modulo modulo = new Modulo();

        DataTable tabla;

        bool grabbed = false;
        int mx, my;



        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            tabla = sede.obtenerTodasLasSedes();
            cbSede.DisplayMember = "descripcion";
            cbSede.DataSource = tabla;

            cbSede.SelectedIndex = -1;

            tabla = modalidad.obtenerTodasLasModalidades();
            cbModalidad.DisplayMember = "modalidad";
            cbModalidad.DataSource = tabla;

            cbModalidad.SelectedIndex = -1;

            txtMatricula.AutoCompleteCustomSource = estudiante.obtenerMatriculas();
            txtCedula.AutoCompleteCustomSource = estudiante.obtenerCedulas(0);
            txtNombre.AutoCompleteCustomSource = estudiante.obtenerNombres();

            txtApellido.AutoCompleteCustomSource = estudiante.obtenerApellidos();
            txtNacionalidad.AutoCompleteCustomSource = estudiante.obtenerNacionalidades();
            txtTelefono.AutoCompleteCustomSource = estudiante.obtenerTelefonos(0);
            txtModulo.AutoCompleteCustomSource = modulo.obtenerModulos();
            txtCurso.AutoCompleteCustomSource = curso.obtenerCursos();
        }

        private void frmEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DatosConsultaEstudiante est;        

            est.Matricula = txtMatricula.Text.Length > 0 ? txtMatricula.Text : "%%";
            est.Cedula = txtCedula.Text.Length > 0 ? txtCedula.Text : "%%";
            est.Nombre = txtNombre.Text.Length > 0 ? txtNombre.Text : "%%";
            est.Apellido = txtApellido.Text.Length > 0 ? txtApellido.Text : "%%";
            est.Nacionalidad = txtNacionalidad.Text.Length > 0 ? txtNacionalidad.Text : "%%";

            
            if (cbSede.SelectedIndex != -1)
            {   
                DataRowView fila = cbSede.SelectedItem as DataRowView;
                est.Sede = fila["descripcion"].ToString();
            }
            else
            {
                est.Sede = "%%";
            }

            if (cbModalidad.SelectedIndex != -1)
            {
                DataRowView fila = cbModalidad.SelectedItem as DataRowView;
                est.Modalidad = fila["modalidad"].ToString();

                switch(est.Modalidad)
                {
                    case "Formación habilitación profesional":
                        est.Modalidad = "FHP";
                        break;
                    case "Formación complementación profesional":
                        est.Modalidad = "FCP";
                        break;
                    case "Formación continua en centro":
                        est.Modalidad = "FCC";
                        break;
                    case "Formación de maestros técnicos":
                        est.Modalidad = "FMT";
                        break;
                    case "Formación dual":
                        est.Modalidad = "FD";
                        break;
                    case "Diplomados":
                        est.Modalidad = "D";
                        break;
                    case "Formación por itinerario":
                        est.Modalidad = "H/C";
                        break;
                }               
            }
            else
            {
                est.Modalidad = "%%";
            }

            est.Curso = txtCurso.Text.Length > 0 ? txtCurso.Text : "%%";
            est.Modulo = txtModulo.Text.Length > 0 ? txtModulo.Text : "%%";       
            
            switch(cbTanda.SelectedIndex)
            {
                case 0:
                    est.Tanda = "%AM%";
                    break;

                case 1:
                    est.Tanda = "%[0-1][1-5]:[0-5][0-9] PM%";
                    break;

                case 2:
                    est.Tanda = "%[0][6-9]:[0-5][0-9] PM%";
                    break;

                default:
                    est.Tanda = "%%";
                    break;
            }          
           
            est.Telefono = txtTelefono.Text.Length > 0 ? txtTelefono.Text : "%%";

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
                //string filtros = obtenerFiltros();
                DataTable tabla = estudiante.obtenerMatriculaEstudiante(est);

                //int matricula = estudiante.obtenerMatriculaEstudiante(est);
            
                if (tabla.Rows.Count <= 1)
                {
                    int matricula = (tabla.Rows.Count == 0) ? 0 :  (int)tabla.Rows[0]["MATRÍCULA"];
                    frmDatosEstudiante frm = new frmDatosEstudiante(matricula);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmDatosEstudiante frm = new frmDatosEstudiante(tabla);
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Al menos llena un campo para consultar");
            }  
        }

        //private string obtenerFiltros()
        //{
        //    List<string> listaCampos = new List<string>();
        //    foreach (var item in panel1.Controls)
        //    {
        //        if(item.GetType() == typeof(TextBox))
        //        {
        //            if (((TextBox)item).Text.Length > 0)
        //            {
                        
        //                listaCampos.Add($"{((TextBox)item).Tag} = @{((TextBox)item).Tag}");
        //            }
        //        }

        //        if (item.GetType() == typeof(ComboBox))
        //        {
        //            if (((ComboBox)item).SelectedIndex != -1)
        //            {
        //                listaCampos.Add($"{((ComboBox)item).Tag} = @{((ComboBox)item).Tag}");
        //            }
        //        }
        //    }

        //    string filtro1 = "", filtro2 = "", filtro3 = "", filtro4 = "", filtro5 = "", filtro6 = "", filtro7 = "";
        //    string filtroTotal = "";

        //    int longitud = listaCampos.Count;
        //    for (int i = 0; i < listaCampos.Count; i++)
        //    {
        //        longitud--;
        //        for (int j = 0; j < listaCampos.Count; j++)
        //        {
        //            filtro1 += j < longitud ? $"{listaCampos[j]} and " : $"{listaCampos[j]}";
        //            filtro2 += j < longitud ? $"{listaCampos[longitud - j]} and " : $"{listaCampos[longitud - j]}";

        //            if (i == 0)
        //            {
        //                filtro3 += j % 2 == 0 ? $"{listaCampos[j]} and " : "";
        //                filtro4 += j % 2 == 1 ? $"{listaCampos[j]} and " : "";
        //                filtro5 += j % 3 == 0 ? $"{listaCampos[j]} and " : "";
        //                filtro6 += j % 3 == 1 ? $"{listaCampos[j]} and " : "";
        //                filtro7 += j < longitud ? $"{listaCampos[j]} or " : "";
        //                if(j == longitud)
        //                {
        //                    filtro3 += filtro3.Length > 0 ? " or " : "";
        //                    filtro4 += filtro4.Length > 0 ? " or " : "";
        //                    filtro5 += filtro5.Length > 0 ? " or " : "";
        //                    filtro6 += filtro6.Length > 0 ? " or " : "";
        //                    filtro7 += filtro7.Length > 0 ? " or " : "";
        //                }
        //            }

        //            if (j == longitud) break;
           
        //        }

        //        filtro1 += " or ";
        //        filtro2 += " or ";
        //    }

            
        //    //filtro1 = Regex.Replace(filtro1, @"\s(or|and)\s(?!([\s]|.)*\s(or|and)\s)", "");

        //    filtroTotal = $"{filtro1}{filtro2}{filtro3}{filtro4}{filtro5}{filtro6}{filtro7}";

        //    MessageBox.Show(filtroTotal);

        //    return filtroTotal;
        //}

        private void txtMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
      
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void cbSede_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtCurso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtModulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void cbTanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void cbModalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar.Focus();
        }

        private void cbSede_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void cbTanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void cbModalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
        }

        private void txtModulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
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
   
}

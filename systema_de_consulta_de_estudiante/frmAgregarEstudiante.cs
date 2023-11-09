﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace systema_de_consulta_de_estudiante
{
    public partial class frmAgregarEstudiante : Form
    {
        public frmAgregarEstudiante()
        {
            InitializeComponent();
        }

        Sede sede = new Sede();
        Curso curso = new Curso();
        Modulo modulo = new Modulo();
        Modalidad modalidad = new Modalidad();
        Estudiante estudiante = new Estudiante();

        int matricula = 0;
        bool fotoCargada = false;

        ErrorProvider error = new ErrorProvider();


        private void txtFechaIngreso_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


        private void frmAgregarEstudiante_Load(object sender, EventArgs e)
        {
            txtFechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyy");

        }

        private bool validar()
        {
            Regex rgTextoSinEspacio = new Regex(@"^([A-Za-z]+)?$");
            Regex rgTextoEspacio = new Regex(@"^([A-Za-z]+(\s[A-Za-z]+)?)*$");
            Regex rgCedula = new Regex(@"^(\d{11})?$");
            Regex rgDireccion = new Regex(@"^[\w#,./\s]*$");
            Regex rgEmail = new Regex(@"^([A-Za-z\d][!#$%&'*+-/=?^_`{|}~.\w]*@[A-Za-z][\w]*((\.)+[A-Za-z]{2,}){1,2})?$");
            Regex rgFecha = new Regex(@"^(([0-3][1-9]|[1][0-9]|[2][0-9]|[3][0-1])\/([0][1-9]|[1][0-2])\/\d{4})?$");
            Regex rgTelefono = new Regex(@"^(\d{10})?$");


            //para eliminar los dobles espacios
            foreach (var txt in groupBox1.Controls.OfType<TextBox>())
            {
                if (txt.TextLength > 0)
                    txt.Text = Regex.Replace(txt.Text, @"\s+", " ");
                //if (new Regex(@"\s+").IsMatch(txt.Text)) MessageBox.Show(txt.Name);
            }

            if (!rgTextoEspacio.IsMatch(txtNombre.Text.Trim()))
            {
                txtNombre.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El nombre no es válido. Solo se aceptan letras y espacios.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTextoEspacio.IsMatch(txtApellido.Text.Trim()))
            {
                txtApellido.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El apellido no es válido. Solo se aceptan letras y espacios.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgCedula.IsMatch(txtCedula.Text.Trim()))
            {
                txtCedula.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La cédula no es válida. Digite 11 dígitos en total.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTextoSinEspacio.IsMatch(txtNacionalidad.Text.Trim()))
            {
                txtNacionalidad.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La nacionalidad no es válida. Solo se aceptan letras sin espacios.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgDireccion.IsMatch(txtDireccion.Text.Trim()))
            {
                txtDireccion.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La dirección no es válida. Solo se aceptan letras(a-zA-Z), números(0-9), guión(-), underscore(_), slash(/), coma(,), punto(.) y espacios", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgEmail.IsMatch(txtEmail.Text.Trim()))
            {
                txtEmail.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El email no es válido.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgFecha.IsMatch(txtFechaNacimiento.Text.Trim()))
            {
                txtFechaNacimiento.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La fecha de nacimiento no es válida. El formato debe cumplir lo siguiente (dd/MM/yyyy).", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgFecha.IsMatch(txtFechaIngreso.Text.Trim()))
            {
                txtFechaIngreso.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La fecha de ingreso no es válida. El formato debe cumplir lo siguiente (dd/MM/yyyy).", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTextoEspacio.IsMatch(txtEnfermedad.Text.Trim()))
            {
                txtEnfermedad.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La enfermedad no es válida. Solo se aceptan letras y espacios.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTextoEspacio.IsMatch(txtOcupacion.Text.Trim()))
            {
                txtOcupacion.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("La ocupación no es válida. Solo se aceptan letras y espacios.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTelefono.IsMatch(txtTelefono1.Text.Trim()))
            {
                txtTelefono1.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El teléfono 1 no es válido. Solo se acptan 10 dígitos en total.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTelefono.IsMatch(txtTelefono2.Text.Trim()))
            {
                txtTelefono2.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El teléfono 2 no es válido. Solo se acptan 10 dígitos en total.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rgTelefono.IsMatch(txtTelefonoEmergencia.Text.Trim()))
            {
                txtTelefonoEmergencia.BackColor = Color.FromArgb(255, 192, 192);
                MessageBox.Show("El teléfono de emergencia no es válido. Solo se acptan 10 dígitos en total.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (string cedula in estudiante.obtenerCedulas())
            {
                if (txtCedula.Text == cedula)
                {
                    MessageBox.Show("Ya existe esta cédula.");
                    return false;
                }
            }

            foreach (string email in estudiante.obtenerEmails())
            {
                if (txtEmail.Text == email)
                {
                    MessageBox.Show("Ya existe este email.");
                    return false;
                }
            }

            foreach (string telefono in estudiante.obtenerTelefonos())
            {
                if (txtTelefono1.Text == telefono || txtTelefono2.Text == telefono || txtTelefonoEmergencia.Text == telefono)
                {
                    MessageBox.Show("Ya existe este teléfono.");
                    return false;
                }
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosInsersionEstudiante est;



            bool agregar = true;
                 

            if (!validar()) return;

            foreach (var item in groupBox1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    if (((TextBox)item).Text.Length == 0 && ((TextBox)item).Tag == "requerido")
                    {
                        error.SetError(((TextBox)item), "Campo requerido");
                        agregar = false;
                    }


                if (item.GetType() == typeof(ComboBox))
                    if (((ComboBox)item).SelectedIndex == -1 && ((ComboBox)item).Tag == "requerido")
                    {
                        error.SetError(((ComboBox)item), "Campo requerido");
                        agregar = false;
                    }

            }

            if (!agregar)
            {
                MessageBox.Show("Complete todos los campos obligatorios", "Campo(s) vacío(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (agregar)
            {
                est.Nombre = txtNombre.Text;
                est.Apellido = txtApellido.Text;

                est.Direccion = txtDireccion.Text;
                est.Email = txtEmail.Text;

                est.Cedula = txtCedula.Text;
                est.Nacionalidad = txtNacionalidad.Text;

                est.FechaNacimiento = txtFechaNacimiento.Text;
                est.FechaIngreso = txtFechaIngreso.Text;
                est.FechaSalida = "";

                est.Enfermedad = txtEnfermedad.Text;
                est.Ocupacion = txtOcupacion.Text;

                est.Status = chkStatus.Checked ? 1 : 0;
                string acronimoEstadoCivil = cbEstadoCivil.SelectedItem.ToString().Substring(0, 1);

                est.EstadoCivil = acronimoEstadoCivil;
                est.TipoSangre = cbTipoDeSangre.SelectedIndex == 0 || cbTipoDeSangre.SelectedIndex == -1 ? "N" : cbTipoDeSangre.SelectedItem.ToString();

                est.NivelAcademico = cbNivelAcademico.SelectedItem.ToString();
                est.Sexo = cbSexo.SelectedIndex == 0 ? "N" : cbSexo.SelectedIndex == 1 ? "M" : "F";


                if(fotoCargada)
                {
                    MemoryStream ms = new MemoryStream();//sirve para convertir a binario mi imagen
                    pictureBox1.Image.Save(ms, ImageFormat.Png);
                    est.Foto = ms.GetBuffer();
                    //MessageBox.Show(est.Foto.ToString());
                }
                else
                {
                    est.Foto = null;
                }
                

                string[] telefonos = new string[3];
                telefonos[0] = txtTelefono1.Text;
                telefonos[1] = txtTelefono2.Text;
                telefonos[2] = txtTelefonoEmergencia.Text;
                
                var resultado = estudiante.insertarEstudiante(est, telefonos);
                bool insertado = resultado.Item1;


                if(insertado)
                {
                    int matricula = resultado.Item2;
                    MessageBox.Show("El estudiante fue insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmDatosEstudiante frm = new frmDatosEstudiante(matricula);
                    this.Hide();
                    frm.Show();
                }
            }




            //errorProvider1.SetError(txtEnfermedad, "campo no");
        }


        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefonoEmergencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        { 
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            error.SetError(comboBox, "");
        }

        private void cbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            error.SetError(comboBox, "");
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtNacionalidad_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void cbTipoDeSangre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            error.SetError(comboBox, "");
        }

        private void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtFechaIngreso_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtEnfermedad_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtOcupacion_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void cbNivelAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            error.SetError(comboBox, "");
        }

        private void txtTelefono1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtTelefono2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }

        private void txtTelefonoEmergencia_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            error.SetError(textBox, "");
        }


        private void cbTipoDeSangre_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void cbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void cbEstadoCivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void cbNivelAcademico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
                e.Handled = true;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscarImagen = new OpenFileDialog();

            string rutaImagen = string.Empty;
            try
            {
                if (buscarImagen.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = buscarImagen.FileName;
                    pictureBox1.Image = null;
                    pictureBox1.Image = Image.FromFile(rutaImagen);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    fotoCargada = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la imagen: {ex.Message}");
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtNacionalidad_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtFechaNacimiento_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtEnfermedad_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void txtOcupacion_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.FromArgb(255, 255, 172);
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void txtTelefono1_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void txtTelefono2_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void txtTelefonoEmergencia_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAgregarEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            this.Hide();
            frm.Show();
        }

        private void txtFechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void txtFechaNacimiento_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtEnfermedad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }


    


}

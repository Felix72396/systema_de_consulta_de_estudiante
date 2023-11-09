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
    public partial class frmRangoHorario : Form
    {
        public frmRangoHorario()
        {
            InitializeComponent();

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }


        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Horario horario = new Horario();
        string formato1 = "AM";
        string formato2 = "AM";

        bool grabbed = false;
        int mx, my;




        private void frmRangoHorario_Load(object sender, EventArgs e)
        {
            cargarHorarios();

            Panel pn = groupBox1.Controls["panel1"] as Panel;
            foreach (var item in pn.Controls.OfType<RadioButton>())
            {
                item.CheckedChanged += chkChecked;
                
            }

            pn = groupBox1.Controls["panel2"] as Panel;
            foreach (var item in pn.Controls.OfType<RadioButton>())
            {
                item.CheckedChanged += chkChecked;

            }
        }

        private void frmRangoHorario_FormClosing(object sender, FormClosingEventArgs e)
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
                        btnAgregarRh.Enabled = true;
                        btnEliminarRh.Enabled = true;
                        break;


                    case "EL":
                        btnEliminarRh.Enabled = true;
                        break;

                    case "IN":
                        btnAgregarRh.Enabled = true;
                        break;
                }
            }

        }

        private bool validar()
        {
            Panel pn = groupBox1.Controls["panel1"] as Panel;
            foreach (TextBox item in pn.Controls.OfType<TextBox>())
            {
                if (item.Text.Length == 1)
                    item.Text = $"0{item.Text}";

                if (item.TextLength == 0)
                {
                    MessageBox.Show("Coloque una hora y minuto de entrada", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            pn = groupBox1.Controls["panel2"] as Panel;
            foreach (TextBox item in pn.Controls.OfType<TextBox>())
            {
                if (item.Text.Length == 1)
                    item.Text = $"0{item.Text}";

                if (item.TextLength == 0)
                {
                    MessageBox.Show("Coloque una hora y minuto de salida", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            Regex rgHora = new Regex(@"^([01][1-9]|10)$");
            Regex rgMinuto = new Regex(@"^([0-5][0-9])$");

            if (!rgHora.IsMatch(txtHoraEntrada.Text))
            {
                MessageBox.Show("Hora de entrada no válida. Solo se aceptan horas entre 01 y 12.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rgHora.IsMatch(txtHoraSalida.Text))
            {
                MessageBox.Show("Hora de salida no válida. Solo se aceptan horas entre 01 y 12.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rgMinuto.IsMatch(txtMinutoEntrada.Text))
            {
                MessageBox.Show("Minutos de entrada no válidos. Solo se aceptan minutos entre 01 a 59.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rgMinuto.IsMatch(txtMinutoSalida.Text))
            {
                MessageBox.Show("Minutos de salida no válidos. Solo se aceptan minutos entre 01 a 59.", "Campo no válido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int valor1 = int.Parse(txtHoraEntrada.Text) + int.Parse(txtMinutoEntrada.Text);
            int valor2 = int.Parse(txtHoraSalida.Text) + int.Parse(txtMinutoSalida.Text);

            if (rdbAm1.Checked && rdbAm2.Checked || rdbPm1.Checked && rdbPm2.Checked)
            {
                if(valor1 > valor2)
                {
                    MessageBox.Show("La hora de entrada es mayor a la hora de salida.", "Hora no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            return true;
        }

        private void chkChecked(object sender, EventArgs e)
        {
            //MessageBox.Show("ff");
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
                rdb.ForeColor = Color.White;
            else
                rdb.ForeColor = Color.FromArgb(0, 64, 64);
        }

        private void cargarHorarios()
        {
            cbHorario.DataSource = horario.obtenerRangosHorarios();
            cbHorario.DisplayMember = "rango";
            cbHorario.SelectedIndex = -1;
        }

        private void btnAgregarRh_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            string horaEntrada = $"{txtHoraEntrada.Text}:{txtMinutoEntrada.Text} {formato1}";

            string horaSalida = $"{txtHoraSalida.Text}:{txtMinutoSalida.Text} {formato2}";

            bool insertado = horario.insertarRangoHorario(horaEntrada, horaSalida);

            if(insertado)
            {
                MessageBox.Show("Rango horario insertado", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarRh_Click(object sender, EventArgs e)
        {
            if (cbHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rango horario", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView fila = cbHorario.SelectedItem as DataRowView;

            string rango = fila["rango"] + "";
            int idRangoHorario = horario.obtenerIdDeRangoHorario(rango);
            bool eliminado = horario.eliminarRangoHorario(idRangoHorario);

            if(eliminado)
            {
                cargarHorarios();
            }


        }

        private void rdbPm1_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbPm1.Checked)
            {
                rdbPm2.Checked = true;
            }
            RadioButton rdb = (RadioButton)sender;
            formato1 = rdb.Tag + "";
        }

        private void rdbPm2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            formato2 = rdb.Tag + "";
        }

        private void rdbAm2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPm1.Checked)
            {
                rdbPm2.Checked = true;
            }

            RadioButton rdb = (RadioButton)sender;
            formato2 = rdb.Tag + "";
        }

        private void rdbAm1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            formato1 = rdb.Tag + "";
        }

        private void txtHoraEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMinutoEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtHoraSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
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

        private void panel3_MouseDown(object sender, MouseEventArgs e)
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

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void txtMinutoSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}

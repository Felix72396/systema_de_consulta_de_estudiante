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
    public partial class frmActualizarInscripcion : Form
    {
        public frmActualizarInscripcion()
        {
            InitializeComponent();
        }

        public frmActualizarInscripcion(int matricula, int posicionSede, int posicionCurso, int posicionModulo1, int posicionModulo2, int posicionHorario)
        {
            InitializeComponent();
            this.posicionSede = posicionSede;
            this.posicionCurso = posicionCurso;
            this.posicionModulo1 = posicionModulo1;
            this.posicionModulo2 = posicionModulo2;
            this.posicionHorario = posicionHorario;
            this.matricula = matricula;

            this.idUsuario = Usuario.IdUsuario;
            aplicarPermisos();
        }
        Usuario usuario = new Usuario();
        int idUsuario = 0;

        Sede sede = new Sede();
        Curso curso = new Curso();
        Modulo modulo = new Modulo();
        Horario horario = new Horario();
        Estudiante estudiante = new Estudiante();
       
        List<int> listaIdRangoHorario = new List<int>();

        string nombreSede = "", nombreCurso = "", nombreModulo = "";

        bool cargado = false;

        int matricula, idSede = 0, idSedeAct = 0,
            idCurso = 0, idCursoAct = 0, idModulo = 0, idModuloAct = 0, 
            idModulo2 = 0, idModulo2Act = 0,
            idRangoHorario = 0, idRangoHorarioAct = 0;

        bool grabbed = false;
        int mx, my;


        int posicionSede = -1,
            posicionCurso = -1,
            posicionModulo1 = -1,
            posicionModulo2 = -1,
            posicionHorario = -1;



        private void aplicarPermisos()
        {
            List<string> listaPermisos = new List<string>();
            listaPermisos = usuario.obtenerPermisosUsuario(idUsuario);


            if (listaPermisos.Count == 0) return;

            for (int i = 0; i < listaPermisos.Count; i++)
            {
                switch (listaPermisos[i])
                {
                    case "TO":
                        btnActualizarInscripcion.Enabled = true;
                        break;

                    case "ED":
                        btnActualizarInscripcion.Enabled = true;
                        break;
                }
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed)
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
        }

        private void lblTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = false;
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            grabbed = true;
            mx = e.X;
            my = e.Y;
        }



        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmActualizarInscripcion_Load(object sender, EventArgs e)
        {
            cbSede.DisplayMember = "descripcion";
            cbSede.DataSource = sede.obtenerTodasLasSedes();
            //MessageBox.Show(posicionSede + "");
            cbSede.SelectedIndex = posicionSede;
            //cbSede.Enabled = false;

            DataRowView fila = cbSede.SelectedItem as DataRowView;
            nombreSede = fila["descripcion"] + "";
            idSede = sede.obtenerIdDeNombreSede(nombreSede);
            idSedeAct = idSede;

            cbCurso.Enabled = true;
            cbCurso.DisplayMember = "descripcion";
            cbCurso.DataSource = sede.obtenerTodosLosCursosDeSede(idSede);
            cbCurso.SelectedIndex = posicionCurso;
            fila = cbCurso.SelectedItem as DataRowView;
            nombreCurso = fila["descripcion"] + "";
            idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
            idCursoAct = idCurso;

            cbModulo.Enabled = true;
            cbModulo.DisplayMember = "descripcion";
            cbModulo.DataSource = modulo.obtenerModulosDeCurso(idCurso);
            //MessageBox.Show(posicionModulo1 + "klk");

            cbModulo.SelectedIndex = posicionModulo1;
           

            fila = cbModulo.SelectedItem as DataRowView;
            nombreModulo = fila["descripcion"] + "";
          
            idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);
            //MessageBox.Show(idModulo + "");
            idModuloAct = idModulo;
         
            if (posicionModulo2 > -1)
            {
           
                cbModulo2.Enabled = true;
                cbModulo2.DataSource = modulo.obtenerModulosDeCurso2(idCurso, idModulo);
                cbModulo2.DisplayMember = "descripcion";
                cbModulo2.SelectedIndex = posicionModulo2;
                nombreModulo = fila["descripcion"] + "";
                idModulo2 = modulo.obtenerIdDeNombreModulo(nombreModulo);
                idModulo2Act = idModulo2;
            }

           

            cbHorario.Enabled = true;
            DataTable tabla = new DataTable();
            tabla = horario.obtenerRangosHorariosDeCurso(idCurso);
            //MessageBox.Show(tabla.Rows.Count + "");
            cbHorario.DataSource = tabla;
            cbHorario.DisplayMember = "rango";
            cbHorario.SelectedIndex = posicionHorario;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                //MessageBox.Show(tabla.Rows[i].ItemArray[0] + "klk" + tabla.Rows.Count + "kolo"+tabla.Columns.Count);
                listaIdRangoHorario.Add(Convert.ToInt32(tabla.Rows[i].ItemArray[0]));
                //MessageBox.Show(tabla.Rows[i]["id"] + "");
            }

            if (listaIdRangoHorario.Count > 0 && cbHorario.SelectedIndex >= 0)
            {
                idRangoHorario = listaIdRangoHorario[cbHorario.SelectedIndex];
                idRangoHorarioAct = idRangoHorario;
                //MessageBox.Show(idRangoHorario+"");
                //tabla = new DataTable();
                tabla = horario.obtenerDiasRangoHorario(idRangoHorario, idCurso);
                //MessageBox.Show(tabla.Rows.Count + "");
                //MessageBox.Show(tabla.Rows.Count + "");
                if (tabla.Rows.Count > 0)
                {
                    lblLunes.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblMartes.Text = tabla.Rows[0].ItemArray[1].ToString();
                    lblMiercoles.Text = tabla.Rows[0].ItemArray[2].ToString();
                    lblJueves.Text = tabla.Rows[0].ItemArray[3].ToString();
                    lblViernes.Text = tabla.Rows[0].ItemArray[4].ToString();
                    lblSabado.Text = tabla.Rows[0].ItemArray[5].ToString();
                }
            }

            cargado = true;

            //MessageBox.Show($"sede = {idSede} curso = {idCurso} modulo = {idModulo} modulo2 = {idModulo2}");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitulo.Text = lblTitulo.Text.Substring(1) + lblTitulo.Text.Substring(0, 1);
        }

        private void frmActualizarInscripcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmInscripcion frm = new frmInscripcion(matricula);
            frm.Show();
            this.Hide();
        }

        private void btnActualizarInscripcion_Click(object sender, EventArgs e)
        {
            DatosActualizacionInscripcionEstudiante est;
            est.Matricula = matricula;

            est.IdSede = idSede;
            est.IdSedeAct = idSedeAct;

            est.IdCurso = idCurso;
            est.IdCursoAct = idCursoAct;

            est.IdModulo = idModulo;
            est.IdModuloAct = idModuloAct;

            

            if (cbModulo2.SelectedIndex >= 0)
            {
                est.IdModulo2 = idModulo2;
                est.IdModulo2Act = idModulo2Act;
           
            }
            else
            {
                est.IdModulo2 = 0;
                est.IdModulo2Act = idModulo2Act;
              
            }

        

            est.IdRangoHorario = idRangoHorario;
            est.IdRangoHorarioAct = idRangoHorarioAct;


            bool actualizar = true;
            foreach (ComboBox cb in groupBox1.Controls.OfType<ComboBox>())
            {
                if (cb.SelectedIndex == -1 && cb.Tag == "sede1curso1")
                {
                    actualizar = false;
                }
            }

            //MessageBox.Show(est.IdSede + " " + idCurso + " " + est.IdModulo + " " + est.IdModulo2 + " | " + est.IdSedeAct + " " + idCursoAct + " " + est.IdModuloAct + " " + est.IdModulo2Act);

            if (actualizar)
            {
                //MessageBox.Show($"m1={cbModulo.SelectedIndex} m2={cbModulo2.SelectedIndex}");
                bool actualizado = estudiante.actualizarInscripcionEstudiante(est);

                if (actualizado)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }


        private void cbSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0 && cargado)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreSede = fila["descripcion"] + "";
                idSede = sede.obtenerIdDeNombreSede(nombreSede);

                cbCurso.DisplayMember = "descripcion";
                cbCurso.DataSource = sede.obtenerTodosLosCursosDeSede(idSede);
                cbCurso.SelectedIndex = -1;

                cbCurso.Enabled = true;
              
                cbModulo.Enabled = false;
                cbHorario.Enabled = false;

                if (cbModulo.Items.Count > 0)
                {
                    cbModulo.SelectedIndex = -1;
                    cbHorario.SelectedIndex = -1;
                }
            }

        

      
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex >= 0 && cargado)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreCurso = fila["descripcion"] + "";
                idCurso = curso.obtenerIdDeNombreCurso(nombreCurso);
                //MessageBox.Show(idCurso + "");
                //MessageBox.Show(idCurso + "");
                cbModulo.Enabled = true;
                cbModulo.DisplayMember = "descripcion";
                cbModulo.DataSource = modulo.obtenerModulosDeCurso(idCurso);
                cbModulo.SelectedIndex = -1;

                cbHorario.Enabled = true;
                cbHorario.DisplayMember = "rango";

                DataTable tabla = new DataTable();
                tabla = horario.obtenerRangosHorariosDeCurso(idCurso);
                cbHorario.DataSource = tabla;
                cbHorario.SelectedIndex = -1;

                listaIdRangoHorario.Clear();

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    //MessageBox.Show(tabla.Rows[i].ItemArray[0] + "klk" + tabla.Rows.Count + "kolo"+tabla.Columns.Count);
                    listaIdRangoHorario.Add(Convert.ToInt32(tabla.Rows[i].ItemArray[0]));
                    //MessageBox.Show(tabla.Rows[i]["id"] + "");
                }
                //MessageBox.Show(listaIdRangoHorario.Count + "");

                foreach (Label lbl in groupBox1.Controls.OfType<Label>())
                {
                    if (lbl.Tag == "dia")
                        lbl.Text = "---------------";
                }
            }
        }




        private void cbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex != -1)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreModulo = fila["descripcion"] + "";
                idModulo = modulo.obtenerIdDeNombreModulo(nombreModulo);

                if (cb.Items.Count > 1)
                {
                    cbModulo2.Enabled = true;
                    cbModulo2.DataSource = modulo.obtenerModulosDeCurso2(idCurso, idModulo);
                    cbModulo2.DisplayMember = "descripcion";
                    cbModulo2.SelectedIndex = -1;
                }
            }
            else
            {
                cbModulo2.Enabled = false;
            }
        }

        private void cbModulo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex != -1)
            {
                DataRowView fila = cb.SelectedItem as DataRowView;
                nombreModulo = fila["descripcion"] + "";
                idModulo2 = modulo.obtenerIdDeNombreModulo(nombreModulo);

            }
            else
            {
                idModulo2 = 0;
            }
        }


        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaIdRangoHorario.Count > 0 && cbHorario.SelectedIndex >= 0)
            {
                idRangoHorario = listaIdRangoHorario[cbHorario.SelectedIndex];
                //MessageBox.Show(idRangoHorario+"");
                DataTable tabla = new DataTable();
                tabla = horario.obtenerDiasRangoHorario(idRangoHorario, idCurso);

                //MessageBox.Show(tabla.Rows.Count + "");
                if (tabla.Rows.Count > 0)
                {
                    lblLunes.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblMartes.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblMiercoles.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblJueves.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblViernes.Text = tabla.Rows[0].ItemArray[0].ToString();
                    lblSabado.Text = tabla.Rows[0].ItemArray[0].ToString();
                }
            }
        }

 

       

    }
}

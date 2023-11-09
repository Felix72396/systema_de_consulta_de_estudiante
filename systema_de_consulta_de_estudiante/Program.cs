using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLogin());
            //Application.Run(new frmPrincipal());
            //Application.Run(new frmHorario());
            //Application.Run(new frmRangoHorario());
            //Application.Run(new frmModuloCurso());
            //Application.Run(new frmCursoSede());
            //Application.Run(new frmConsultaEstudiante());
            //Application.Run(new frmAgregarEditarEstudiante());
            //Application.Run(new frmInscripcion());
        }
    }
}

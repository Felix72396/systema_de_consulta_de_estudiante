using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Data.SQLite;

namespace systema_de_consulta_de_estudiante
{
    internal class ConexionSQL
    {
        //.\SQLEXPRESS
        //fpg72396@gmail.com

        private string CadenaConexion = @"server=FELIX-PANIAGUA\SQLEXPRESS; Database=estudiantedb; Integrated Security=true";
        //private string CadenaConexion = @"server=TECSUP-\SQLEXPRESS; Database=estudiantedb; Integrated Security=true";
        protected SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            
            try 
            {
                cn.ConnectionString = CadenaConexion; 
                cn.Open();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
   
            return cn;
        }
    }
}

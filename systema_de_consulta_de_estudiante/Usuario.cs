using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    internal class Usuario : ConexionSQL
    {

        internal bool ValidarUsuario(string usuario, string clave)
        {
            using (var cn = Conectar())
            {
                string consulta = $"select * from login where usuario=@usuario and contrasena=@clave";
                using(SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@clave", clave);

                    SqlDataReader lector = comando.ExecuteReader();
                    return lector.HasRows;
                }
                
            }                    
        }

        internal int ObtenerIdUsuario(string usuario)
        {
            using (var cn = Conectar())
            {
                string consulta = $"select id from login where usuario=@usuario";
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    var resultado = comando.ExecuteScalar();
                    if(resultado != null)
                    {
                        int idUsuario = (int)resultado;
                        return idUsuario;
                    }
                }
            }
            return 0;
        }

        internal AutoCompleteStringCollection obtenerUsuarios()
        {
            var cn = Conectar();
  
            string consulta = $"select usuario from login";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();
            
            while(lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal List<string> obtenerPermisosUsuario(int idUsuario)
        {
            var cn = Conectar();

            string consulta = $"select permiso from permiso_login where id_usuario = @id_usuario;";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@id_usuario", idUsuario);
            SqlDataReader lector = comando.ExecuteReader();
            List<string> listaPermisos = new List<string>();

            while (lector.Read())
            {
                listaPermisos.Add(lector.GetString(0));
            }

            return listaPermisos;
        }

        internal static int IdUsuario;

    }
}

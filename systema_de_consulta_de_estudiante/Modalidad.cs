using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Data;

namespace systema_de_consulta_de_estudiante
{
    internal class Modalidad: ConexionSQL
    {
        internal DataTable obtenerModalidad(int matricula, int idSede, int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_modalidad_curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal DataTable obtenerTodasLasModalidades()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_modalidad";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        //internal int obtenerIdDeNombreModalidad(string nombreModalidad)
        //{
        //    int idModalidad = 0;

        //    using (var cn = Conectar())
        //    {
        //        //cn.Open();
        //        string consulta = "select id from modalidad where descripcion = @descripcion";

        //        using (SqlCommand comando = new SqlCommand(consulta, cn))
        //        {
        //            //comando.CommandType = CommandType.Text;
        //            comando.Parameters.AddWithValue("@descripcion", nombreModalidad);
        //            var id = comando.ExecuteScalar();
        //            idModalidad = (int)id;
        //        }
        //    }
        //    return idModalidad;
        //}
    }
}

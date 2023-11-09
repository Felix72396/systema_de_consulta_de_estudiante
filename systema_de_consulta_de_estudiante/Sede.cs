using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Data;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    internal class Sede: ConexionSQL
    {
        internal DataTable obtenerSedes(int matricula)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_sede_estudiante";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal DataTable obtenerTodasLasSedes()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select descripcion from sede order by id desc";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal DataTable obtenerTodosLosCursosDeSede(int idSede)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_cursos_sede";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_sede", idSede);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal int obtenerIdDeNombreSede(string nombreSede)
        {
            int idSede = 0;
       
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select id from sede where descripcion = @descripcion order by id";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    //comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreSede);
                    var id = comando.ExecuteScalar();
                    idSede = (int)id;  
                }
            }
            return idSede;
        }

        internal bool insertarSede(string nombreSede)
        {

            int numeroFilasAfectadas = 0;
            string consulta = "select * from sede where descripcion = @descripcion";

            using (var cn = Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreSede);

                    SqlDataReader lector = comando.ExecuteReader();
                    if(lector.Read())
                    {
                        MessageBox.Show("Ya existe esta sede");
                        return false;
                    }
                }
            }

            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "insert into sede values (@descripcion)";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreSede);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool eliminarSede(int idSede)
        {
            string consulta = "with matriculas as (select matricula from estudiante_inscripcion where id_sede = @id_sede group by matricula having count(distinct id_sede) = 1) update estudiante set [status] = 0 where matricula in (select * from matriculas);";
            using (var cn = Conectar())
            {
                //cn.Open();

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_sede", idSede);
                    comando.ExecuteNonQuery();
                }
            }

            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "delete from sede where id = @id_sede";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_sede", idSede);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool actualizarSede(string nombreSedeActual, string nuevoNombre)
        {
            int numeroFilasAfectadas = 0;
  
            string consulta = "select * from sede where descripcion = @descripcion";

            using (var cn = Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nuevoNombre);

                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        MessageBox.Show("Ya existe esta sede");
                        return false;
                    }
                }
            }


            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "update sede set descripcion = @nuevoNombre where descripcion = @descripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    comando.Parameters.AddWithValue("@descripcion", nombreSedeActual);
                   
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }
    }
}

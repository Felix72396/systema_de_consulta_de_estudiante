using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Data;

namespace systema_de_consulta_de_estudiante
{
    internal class Modulo: ConexionSQL
    {
        internal DataTable obtenerModulos(int matricula, int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_modulo_curso";

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

        internal DataTable obtenerTodosLosModulos(int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select descripcion from modulo where id not in (select id_modulo from modulo_curso mc where id_curso = @id_curso);";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
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

        internal int obtenerIdDeNombreModulo(string nombreModulo)
        {
            int idModulo = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select id from modulo where descripcion = @descripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    //comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreModulo);
                    var id = comando.ExecuteScalar();
                    if(id != null)
                    {
                        idModulo = (int)id;
                    }
                }
            }
            return idModulo;
        }

        internal AutoCompleteStringCollection obtenerModulos()
        {
            var cn = Conectar();

            string consulta = $"select descripcion from modulo";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal DataTable obtenerTodosLosModulos()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select descripcion from modulo order by id desc";

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

        internal DataTable obtenerModulosDeCurso(int idCurso)
        {
            DataTable tabla = new DataTable();
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_modulos_curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
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

        internal DataTable obtenerModulosDeCurso2(int idCurso, int idModulo)
        {
            DataTable tabla = new DataTable();
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_modulos_curso2";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                 
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.Parameters.AddWithValue("@id_modulo", idModulo);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
            return null;
        }

        internal bool insertarModulo(string nombreModulo)
        {
            int numeroFilasAfectadas = 0;
            string consulta = "select * from modulo where descripcion = @descripcion";

            using (var cn = Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreModulo);

                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        MessageBox.Show("Ya existe este módulo");
                        return false;
                    }
                }
            }


            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "insert into modulo values (@descripcion);";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreModulo);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();

                }
            }


            return numeroFilasAfectadas > 0;
        }

        internal bool insertarModuloEnCurso(int idCurso, int idModulo)
        {
            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "insert into modulo_curso values (@id_modulo, @id_curso)";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_modulo", idModulo);
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }



        internal bool eliminarModulo(int idModulo)
        {
            string consulta = "with matriculas as (select matricula from estudiante_inscripcion group by matricula having count(id_modulo) = 1), matriculas2 as (select matricula from estudiante_inscripcion where id_modulo = @id_modulo and matricula in (select * from matriculas)) update estudiante set[status] = 0 where matricula in (select * from matriculas2);";
            using (var cn = Conectar())
            {
                //cn.Open();

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_modulo", idModulo);
                    comando.ExecuteNonQuery();
                }
            }

            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "delete from modulo where id = @id_modulo";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_modulo", idModulo);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool eliminarModuloEnCurso(int idCurso, int idModulo)
        {
            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "delete from modulo_curso where id_modulo = @id_modulo and id_curso = @id_curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_modulo", idModulo);
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool actualizarModulo(string nombreModuloActual, string nuevoNombre)
        {
            int numeroFilasAfectadas = 0;
            string consulta = "select * from modulo where descripcion = @descripcion";
            int idCurso = obtenerIdDeNombreModulo(nombreModuloActual);

            if (nuevoNombre != nombreModuloActual)
                using (var cn = Conectar())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@descripcion", nuevoNombre);

                        SqlDataReader lector = comando.ExecuteReader();
                        if (lector.Read())
                        {
                            MessageBox.Show("Ya existe este módulo");
                            return false;
                        }
                    }
                }



            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "update modulo set descripcion = @nuevoNombre where descripcion = @descripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    comando.Parameters.AddWithValue("@descripcion", nombreModuloActual);

                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

    }
}

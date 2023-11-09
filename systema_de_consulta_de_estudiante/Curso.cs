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
    internal class Curso: ConexionSQL
    {
        internal DataTable obtenerCursos(int matricula, int idSede)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_sede_curso_estudiante";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
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

        internal DataTable obtenerTodosLosModulosDeCurso(int idCurso)
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



        internal DataTable obtenerTodosLosCursos(int idSede)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select descripcion from curso where id not in (select id_curso from curso_sede cs where id_sede = @id_sede);";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
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

        internal DataTable obtenerTodosLosCursos()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select c.descripcion, case when mc.modalidad is null then 'No asignado' else mc.modalidad end as modalidad from curso c left join modalidad_curso mc on c.id = mc.id_curso order by c.id desc";

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



        internal int obtenerIdDeNombreCurso(string nombreCurso)
        {
            int idCurso = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select id from curso where descripcion = @descripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    //comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreCurso);
                    var resultado = comando.ExecuteScalar();
                    if(resultado != null)
                        idCurso = (int)resultado;
                }
            }
            return idCurso;
        }

        internal List<int> obtenerIdCursosInscripcion(int matricula)
        {
            List<int> listIdCursos = new List<int>();

           
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_obtener_id_cursos_inscripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);

                    SqlDataReader lector = comando.ExecuteReader();
                    //MessageBox.Show(lector.FieldCount + "");
                    while(lector.Read())
                    {
                        listIdCursos.Add(lector.GetInt32(0));
                    }
                }
            }
            return listIdCursos;
        }



        internal DataTable obtenerTandaCurso(int matricula, int idCurso)
        {
            DataTable tabla = new DataTable();
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_tanda_Curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    comando.Parameters.AddWithValue("@id_curso",idCurso);
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
            return null;
        }

        internal AutoCompleteStringCollection obtenerCursos()
        {
            var cn = Conectar();

            string consulta = $"select descripcion from curso";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal bool insertarCurso(string nombreCurso, string acronimo)
        {
            int numeroFilasAfectadas = 0;
            string consulta = "select * from curso where descripcion = @descripcion";

            using (var cn = Conectar())
            {
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreCurso);

                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        MessageBox.Show("Ya existe este curso");
                        return false;
                    }
                }
            }

        
            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "insert into curso values (@descripcion);";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@descripcion", nombreCurso);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                   
                }
            }


            int idCurso = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "select max(id) from curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    comando.CommandType = CommandType.Text;
                    var resultado = comando.ExecuteScalar();

                    if(resultado != null)
                    {
                        idCurso = (int)resultado;

                    }

                }
            }




            using (var cn = Conectar())
            {
                consulta = "insert into modalidad_curso (id_curso, modalidad) values (@id_curso, @acronimoModalidad)";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_Curso", idCurso);
                    comando.Parameters.AddWithValue("@acronimoModalidad", acronimo);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }



        internal bool insertarCursoEnSede(int idSede, int idCurso)
        {
            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "insert into curso_sede values (@id_curso, @id_sede)";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.Parameters.AddWithValue("@id_sede", idSede);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }



        internal bool eliminarCurso(int idCurso)
        {
            string consulta = "with matriculas as (select matricula from estudiante_inscripcion where id_curso = @id_curso group by matricula having count(distinct id_curso) = 1) update estudiante set [status] = 0 where matricula in (select * from matriculas);";
            using (var cn = Conectar())
            {
                //cn.Open();

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.ExecuteNonQuery();
                }
            }


            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "delete from curso where id = @id_curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool eliminarCursoEnSede(int idSede, int idCurso)
        {
            int numeroFilasAfectadas = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "delete from curso_sede where id_curso = @id_curso and id_sede = @id_sede";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.Parameters.AddWithValue("@id_sede", idSede);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool actualizarCurso(string nombreCursoActual, string nuevoNombre, string acronimo)
        {
            int numeroFilasAfectadas = 0;
            string consulta = "select * from curso where descripcion = @descripcion";
            int idCurso = obtenerIdDeNombreCurso(nombreCursoActual);

            if (nuevoNombre != nombreCursoActual)
                using (var cn = Conectar())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@descripcion", nuevoNombre);

                        SqlDataReader lector = comando.ExecuteReader();
                        if (lector.Read())
                        {
                            MessageBox.Show("Ya existe este curso");
                            return false;
                        }
                    }
                }

           

            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "update curso set descripcion = @nuevoNombre where descripcion = @descripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    comando.Parameters.AddWithValue("@descripcion", nombreCursoActual);

                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            
         
            using (var cn = Conectar())
            {
                //cn.Open();
                consulta = "update modalidad_curso set modalidad = @acronimo where id_curso = @id_curso";
                MessageBox.Show(acronimo + " " + idCurso);
                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.Parameters.AddWithValue("@acronimo", acronimo);

                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }


            return numeroFilasAfectadas > 0;
        }



    }//class
}//namespace

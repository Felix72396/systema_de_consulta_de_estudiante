using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systema_de_consulta_de_estudiante
{
    internal class Horario: ConexionSQL
    {
        internal DataTable obtenerHorario(int matricula, int idCurso)
        {
            DataTable tabla = new DataTable();
            
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_horario_curso";

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

        internal string obtenerRangoHorario(int matricula, int idCurso)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select CONCAT(rh.hora_entrada, ' - ', rh.hora_salida) as rango from estudiante_curso_horario ech inner join rango_horario rh on ech.id_rango_horario = rh.id where matricula = @matricula and id_curso = @id_curso";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                            return lector.GetString(0);
                        else return "";
                    }
                }
            }
            
        }

        internal int obtenerIdDeRangoHorario(string rangoHorario)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select id from rango_horario where CONCAT(hora_entrada, ' - ', hora_salida) = @rangoHorario";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@rangoHorario", rangoHorario);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                            return lector.GetInt32(0);
                        else return 0;
                    }
                }
            }

        }

        internal DataTable obtenerDiasRangoHorario(int idRangoHorario, int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_dias_rango_horario";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id_rango_horario", idRangoHorario);
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

        internal DataTable obtenerRangosHorariosDeCurso(int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_rangos_horarios_curso";

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

        internal DataTable obtenerRangosHorarios()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select CONCAT(hora_entrada, ' - ', hora_salida) rango from rango_horario;";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal DataTable obtenerRangosHorarios(int idCurso)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select CONCAT(hora_entrada, ' - ', hora_salida) rango from rango_horario where id not in(select id_rango_horario from horario_curso where id_curso = @id_curso);";

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

        internal bool insertarHorarioEnCurso(List<string> dias, int idCurso, int idRangoHorario)
        {
            int numeroFilasAfectadas = 0;

            for (int i = 0; i < dias.Count; i++)
            {
                if (dias[i] == "SÁ") 
                    dias[i] = "SA";
                //MessageBox.Show(dias[i]);
                using (var cn = Conectar())
                {
                    //cn.Open();
                    string consulta = "insert into horario_curso values (@dia, @id_curso, @id_rango_horario)";

                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        comando.CommandType = CommandType.Text;

                        comando.Parameters.AddWithValue("@dia", dias[i]);
                        comando.Parameters.AddWithValue("@id_curso", idCurso);
                        comando.Parameters.AddWithValue("@id_rango_horario", idRangoHorario);
                        numeroFilasAfectadas = comando.ExecuteNonQuery();
                    }
                }
            }

       

            return numeroFilasAfectadas > 0;
        }


        internal bool insertarRangoHorario(string horaEntrada, string horaSalida)
        {

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "select * from rango_horario where hora_entrada = @hora_entrada and hora_salida = @hora_salida";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@hora_entrada", horaEntrada);
                    comando.Parameters.AddWithValue("@hora_salida", horaSalida);

                    SqlDataReader lector = comando.ExecuteReader();
                    if(lector.Read())
                    {
                        MessageBox.Show("Ya existe este rango horario", "Valor existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            int numeroFilasAfectadas = 0;

                using (var cn = Conectar())
                {
                    //cn.Open();
                    string consulta = "insert into rango_horario values (@hora_entrada, @hora_salida)";

                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@hora_entrada", horaEntrada);
                        comando.Parameters.AddWithValue("@hora_salida", horaSalida);


                        numeroFilasAfectadas = comando.ExecuteNonQuery();
                    }
                }
  

            return numeroFilasAfectadas > 0;
        }

        internal bool eliminarHorarioEnCurso(int idCurso, int idRangoHorario)
        {
            int numeroFilasAfectadas = 0;
     
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "delete from horario_curso where id_curso = @id_curso and id_rango_horario = @id_rango_horario";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_curso", idCurso);
                    comando.Parameters.AddWithValue("@id_rango_horario", idRangoHorario);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }

        internal bool eliminarRangoHorario(int idRangoHorario)
        {
            int numeroFilasAfectadas = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "delete from rango_horario where id = @id_rango_horario;";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@id_rango_horario", idRangoHorario);
                    numeroFilasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return numeroFilasAfectadas > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace systema_de_consulta_de_estudiante
{
    internal class Estudiante : ConexionSQL
    {
        //ConexionSQL conexionSQL = new ConexionSQL();

        internal DataTable obtenerInformacionEstudiante(int matricula)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_informacion_estudiante";

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

        internal DataTable obtenerInformacionInscripcionEstudiante()
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"select matricula, nombre, apellido from estudiante";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando.CommandText, cn))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }

            return null;
        }

        internal DataTable obtenerTelefonosEstudiante(int matricula)
        {
            DataTable tabla = new DataTable();

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_telefonos_estudiante";

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

        internal MemoryStream obtenerDatosFoto(int matricula)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = "sp_foto_estudiante";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {

                    //byte[] binFoto = new byte[0];
                    //binFoto = (byte[])dt.Rows[indiceFila]["foto"];
                    //MemoryStream ms = new MemoryStream(binFoto);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    var resultado = comando.ExecuteScalar();
                    Byte[] bytesFoto = new Byte[0];
                    bytesFoto = (Byte[])(resultado);

                    MemoryStream datosFoto;
                    if (bytesFoto != null)
                    {
                        datosFoto = new MemoryStream(bytesFoto);
                        //MessageBox.Show("gg");
                    }
                    else return null;

                    return datosFoto;

                }
            }
        }

        internal DataTable obtenerMatriculaEstudiante(DatosConsultaEstudiante est)
        {
            //MessageBox.Show(est.matricula + "" + est.nombre + "" + est.apellido + "" + est.modalidad + "" + est.nacionalidad + est.telefono + est.sede + est.tanda + est.modulo);
            DataTable tabla = new DataTable();
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_matricula_nombre_estudiantes";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", est.Matricula);
                    comando.Parameters.AddWithValue("@cedula", est.Cedula);
                    comando.Parameters.AddWithValue("@nombre", est.Nombre);
                    comando.Parameters.AddWithValue("@apellido", est.Apellido);
                    comando.Parameters.AddWithValue("@nacionalidad", est.Nacionalidad);
                    comando.Parameters.AddWithValue("@sede", est.Sede);
                    comando.Parameters.AddWithValue("@curso", est.Curso);
                    comando.Parameters.AddWithValue("@modulo", est.Modulo);
                    comando.Parameters.AddWithValue("@patronTanda", est.Tanda);
                    comando.Parameters.AddWithValue("@modalidad", est.Modalidad);
                    comando.Parameters.AddWithValue("@telefono", est.Telefono);

                    //object resultado = comando.ExecuteScalar();


                    //int matricula = (resultado != null) ? int.Parse(resultado.ToString()) : 0;
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }

                return null;
            }
        }

        internal bool verificarInscripcion(int matricula)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"select * from estudiante_inscripcion where matricula = @matricula";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        return lector.Read();
                    }
                }
            }
        }

        //internal int obtenerCantidadInscripciones(int matricula)
        //{
        //    string consulta = $"select count(distinct id_curso) nInscipciones from estudiante_inscripcion where matricula = @matricula";
        //    using (var cn = Conectar())
        //    {
        //        using (SqlCommand comando = new SqlCommand(consulta, cn))
        //        {
        //            comando.CommandType = CommandType.Text;
        //            comando.Parameters.AddWithValue("@matricula", matricula);
        //            var cantidad = comando.ExecuteScalar();
        //            if (cantidad == null) return 0;
        //            else return (int)cantidad;
        //        }
        //    }
        //}



        internal DataTable obtenerInformacionInscripcionEstudiante(int matricula, int idCurso)
        {
            //MessageBox.Show(est.matricula + "" + est.nombre + "" + est.apellido + "" + est.modalidad + "" + est.nacionalidad + est.telefono + est.sede + est.tanda + est.modulo);
            DataTable tabla = new DataTable();
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_informacion_estudiante_inscripcion";

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

        internal AutoCompleteStringCollection obtenerMatriculas()
        {
            var cn = Conectar();

            string consulta = $"select matricula from estudiante";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetValue(0) + "");
            }

            return listaUsuario;
        }

        internal AutoCompleteStringCollection obtenerCedulas(int matricula)
        {
            var cn = Conectar();

            string consulta = $"select cedula from estudiante where matricula != @matricula";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@matricula", matricula);
            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal AutoCompleteStringCollection obtenerNombres()
        {
            var cn = Conectar();

            string consulta = $"select nombre from estudiante";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal AutoCompleteStringCollection obtenerApellidos()
        {
            var cn = Conectar();

            string consulta = $"select apellido from estudiante";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal AutoCompleteStringCollection obtenerNacionalidades()
        {
            var cn = Conectar();

            string consulta = $"select nacionalidad from estudiante";
            SqlCommand comando = new SqlCommand(consulta, cn);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }

        internal List<string> obtenerEmails(int matricula)
        {
            var cn = Conectar();

            string consulta = $"select email from estudiante where email is not null and matricula != @matricula";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@matricula", matricula);

            SqlDataReader lector = comando.ExecuteReader();
            List<string> listaEmails = new List<string>();

            while (lector.Read())
            {
                listaEmails.Add(lector.GetString(0));
            }

            return listaEmails;
        }

        internal AutoCompleteStringCollection obtenerTelefonos(int matricula)
        {
            var cn = Conectar();

            string consulta = $"sp_telefonos";
            SqlCommand comando = new SqlCommand(consulta, cn);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@matricula", matricula);

            SqlDataReader lector = comando.ExecuteReader();
            AutoCompleteStringCollection listaUsuario = new AutoCompleteStringCollection();

            while (lector.Read())
            {
                listaUsuario.Add(lector.GetString(0));
            }

            return listaUsuario;
        }



        internal (bool, int) insertarActualizarEstudiante(DatosInsersionYActualizacionEstudiante est, string[] telefonos, bool insertar)
        {
            int numeroFila = 0;
            int matricula = 0;
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = insertar ? $"sp_insertar_estudiante" : $"sp_actualizar_estudiante";

                try
                {
                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        if (!insertar) comando.Parameters.AddWithValue("@matricula", est.Matricula);
                        comando.Parameters.AddWithValue("@nombre", est.Nombre);
                        comando.Parameters.AddWithValue("@apellido", est.Apellido);
                        comando.Parameters.AddWithValue("@sexo", est.Sexo);
                        comando.Parameters.AddWithValue("@direccion", est.Direccion);

                        if (est.Email == "")
                            comando.Parameters.AddWithValue("@email", DBNull.Value);
                        else comando.Parameters.AddWithValue("@email", est.Email);

                        comando.Parameters.AddWithValue("@cedula", est.Cedula);
                        comando.Parameters.AddWithValue("@nacionalidad", est.Nacionalidad);
                        comando.Parameters.AddWithValue("@fecha_nacimiento", est.FechaNacimiento);
                        comando.Parameters.AddWithValue("@fecha_ingreso", est.FechaIngreso);

                        if (est.FechaSalida == "") comando.Parameters.AddWithValue("@fecha_salida", DBNull.Value);
                        else comando.Parameters.AddWithValue("@fecha_salida", est.FechaSalida);

                        comando.Parameters.AddWithValue("@status", est.Status);
                        comando.Parameters.AddWithValue("@tipo_de_sangre", est.TipoSangre);

                        if (est.Enfermedad == "")
                            comando.Parameters.AddWithValue("@enfermedad", DBNull.Value);
                        else comando.Parameters.AddWithValue("@enfermedad", est.Enfermedad);

                        comando.Parameters.AddWithValue("@ocupacion", est.Ocupacion);
                        comando.Parameters.AddWithValue("@estado_civil", est.EstadoCivil);
                        comando.Parameters.AddWithValue("@nivel_academico", est.NivelAcademico);

                        numeroFila = comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (insertar)
                {
                    consulta = "select max(matricula) as matricula from estudiante";
                    if (numeroFila > 0)
                        using (SqlCommand comando = new SqlCommand(consulta, cn))
                        {
                            comando.CommandType = CommandType.Text;
                            var resultado = comando.ExecuteScalar();
                            if (resultado != null)
                            {
                                matricula = (int)(resultado);
                            }
                        }
                }
                else
                {
                    matricula = est.Matricula;
                }


                //insertando telefonos y foto
                if (matricula != 0)
                {
                    try
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            //if (telefonos[i] == "")
                            //    continue;
                            int idTipoTelefono = i + 1;
                            string telefono = Regex.IsMatch(telefonos[i], @"\d{10}") ? telefonos[i] : "";
                            //MessageBox.Show(telefono.Length+"");

                            //if(insertar)
                            //    consulta = $"insert into telefono_estudiante (matricula, id_tipo_telefono, telefono) values ({matricula}, {idTipoTelefono}, {telefonos[i]})";
                            //else consulta = $"update telefono_estudiante set telefono = '{telefonos[i]}' where matricula = {matricula} and id_tipo_telefono = {idTipoTelefono}";

                            consulta = "sp_insertar_actualizar_telefonos_estudiante";

                            using (SqlCommand comando = new SqlCommand(consulta, cn))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@matricula", matricula);
                                comando.Parameters.AddWithValue("@id_tipo_telefono", idTipoTelefono);
                                comando.Parameters.AddWithValue("@telefono", telefono);
                                comando.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    if (est.Foto != null)
                    {
                        //if(insertar)
                        consulta = $"sp_insertar_actualizar_foto_estudiante";
                        //else
                        //    consulta = $"update foto_estudiante set foto = @foto where matricula = @matricula";

                        using (SqlCommand comando = new SqlCommand(consulta, cn))
                        {
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@matricula", matricula);
                            comando.Parameters.AddWithValue("@foto", est.Foto);
                            comando.ExecuteNonQuery();
                        }
                    }
                }
            }

            return (numeroFila > 0, matricula);
        }


        internal bool verificarExistenciaInscripcion(int matricula, int idCurso)
        {
            int numeroFila = 0;
            SqlDataReader lector;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"select * from estudiante_inscripcion where matricula = @matricula and id_curso = @id_curso";
               
                try
                {
                    using (SqlCommand comando = new SqlCommand(consulta, cn))
                    {

                        comando.CommandType = CommandType.Text;
                        comando.Parameters.AddWithValue("@matricula", matricula);
              
                        comando.Parameters.AddWithValue("@id_curso", idCurso);

                        lector = comando.ExecuteReader();
                        return lector.Read();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return false;
        }



        internal bool insertarInscripcionEstudiante(DatosInscripcionEstudiante est)
        {
            bool existe = verificarExistenciaInscripcion(est.Matricula, est.IdCurso);
            //MessageBox.Show(est.Matricula + " " + est.IdSede + " " + est.IdCurso + "  " + listIdsModulo[i] + " " + existe);
            if (existe)
            {
                MessageBox.Show("El estudiante ya está en este curso", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int numeroFila = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_insertar_inscripcion";

                try
                {
                    List<int> listIdsModulo = new List<int>();
                    listIdsModulo.Add(est.IdModulo);


                    if (est.IdModulo2 > 0)
                        listIdsModulo.Add(est.IdModulo2);


                    for (int i = 0; i < listIdsModulo.Count; i++)
                    {
                      

                        using (SqlCommand comando = new SqlCommand(consulta, cn))
                        {

                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@matricula", est.Matricula);
                            comando.Parameters.AddWithValue("@id_sede", est.IdSede);
                            comando.Parameters.AddWithValue("@id_curso", est.IdCurso);
                            comando.Parameters.AddWithValue("@id_modulo", listIdsModulo[i]);
                            comando.Parameters.AddWithValue("@id_rango_horario", est.IdRangoHorario);

                            numeroFila = comando.ExecuteNonQuery();

                        }
                    }

                    MessageBox.Show("Inscripción realizada", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            return (numeroFila > 0);
        }

      

        internal bool actualizarInscripcionEstudiante(DatosActualizacionInscripcionEstudiante est)
        {
            if (est.IdCurso != est.IdCursoAct)
            {
                bool existe = verificarExistenciaInscripcion(est.Matricula, est.IdCurso);
                if (existe)
                {
                    MessageBox.Show("El estudiante ya está en este curso", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            int numeroFila = 0;

            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_actualizar_inscripcion";

                try
                {
                    List<int> listIdsModulo = new List<int>();
                    List<int> listIdsModuloAct = new List<int>();
                    listIdsModulo.Add(est.IdModulo);
                    listIdsModuloAct.Add(est.IdModuloAct);


                    if (est.IdModulo2 > 0)
                    {
                        listIdsModulo.Add(est.IdModulo2);
                        listIdsModuloAct.Add(est.IdModulo2Act);
                    }

              

                    for (int i = 0; i < listIdsModulo.Count; i++)
                    {
                     

                        using (SqlCommand comando = new SqlCommand(consulta, cn))
                        {
                            //MessageBox.Show(listIdsModulo[i] + "  act=" + listIdsModuloAct[i]);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("@matricula", est.Matricula);
                            comando.Parameters.AddWithValue("@id_sede", est.IdSede);
                            comando.Parameters.AddWithValue("@id_curso", est.IdCurso);
                            comando.Parameters.AddWithValue("@id_modulo", listIdsModulo[i]);
                            comando.Parameters.AddWithValue("@id_rango_horario", est.IdRangoHorario);

                            comando.Parameters.AddWithValue("@id_sede_act", est.IdSedeAct);
                            comando.Parameters.AddWithValue("@id_curso_act", est.IdCursoAct);       
                            comando.Parameters.AddWithValue("@id_modulo_act", listIdsModuloAct[i]);
                            comando.Parameters.AddWithValue("@id_rango_horario_act", est.IdRangoHorarioAct);

                            numeroFila = comando.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Inscripción actualizada", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            return (numeroFila > 0);
        }


        internal bool eliminarEstudiante(int matricula)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"delete from estudiante where matricula = @matricula";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@matricula", matricula);

                    int numeroFila = comando.ExecuteNonQuery();

                    return numeroFila > 0;
                }
            }
        }

        internal bool eliminarEstudianteInscripcion(int matricula, int idCurso)
        {
            using (var cn = Conectar())
            {
                //cn.Open();
                string consulta = $"sp_eliminar_inscripcion";

                using (SqlCommand comando = new SqlCommand(consulta, cn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    comando.Parameters.AddWithValue("@id_curso", idCurso);

                    int numeroFila = comando.ExecuteNonQuery();

                    return numeroFila > 0;
                }
            }
        }
    }

    internal struct DatosInscripcionEstudiante
    {
        internal int Matricula, IdSede, IdCurso, IdModulo, IdModulo2, IdRangoHorario;
    }

    internal struct DatosActualizacionInscripcionEstudiante
    {
        internal int Matricula, IdSede, IdSedeAct, IdCurso, IdCursoAct, IdModulo, IdModulo2, IdModuloAct, IdModulo2Act, IdRangoHorario, IdRangoHorarioAct;
    }

    internal struct DatosInsersionYActualizacionEstudiante
    {
        internal int Matricula;
        internal string Cedula, Nombre, Apellido, Nacionalidad,
                        Sexo, EstadoCivil, Email, Direccion,
                        FechaNacimiento, FechaIngreso, FechaSalida,
                        TipoSangre, Enfermedad, Ocupacion, NivelAcademico;
        internal int Status;
        internal byte[] Foto;
    }

    internal struct DatosConsultaEstudiante
    {
        internal string Matricula, Cedula, Nombre, Apellido,
                        Nacionalidad, Sede, Curso, Modulo, Tanda,
                        Modalidad, Telefono;
    }
}

using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> listaAlumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllAlumnosInscripciones", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();

                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (string)dr["condicion"];
                    ai.Nota = (int)dr["nota"];
                    ai.LegajoAlumno = (int)dr["legajo"];
                    ai.DescripcionCurso = (string)dr["descripcion"];
                    listaAlumnoInscripciones.Add(ai);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al las inscripciones de los alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaAlumnoInscripciones;
        }
        public AlumnoInscripcion GetOne(int iD)
        {
            AlumnoInscripcion alumnoInscripcion = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOneAlumnoInscripcion", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", iD);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    alumnoInscripcion = new AlumnoInscripcion();

                    alumnoInscripcion.ID = (int)dr["id_inscripcion"];
                    alumnoInscripcion.IDAlumno = (int)dr["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)dr["id_curso"];
                    alumnoInscripcion.Condicion = (string)dr["condicion"];
                    alumnoInscripcion.Nota = (int)dr["nota"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al inscripcion de dicho alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripcion;
        }
        private void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertAlumnoInscripcion", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_alumno", alumnoInscripcion.IDAlumno);
                cmd.Parameters.AddWithValue("@id_curso", alumnoInscripcion.IDCurso);
                cmd.Parameters.AddWithValue("@condicion", alumnoInscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", alumnoInscripcion.Nota);
                cmd.Parameters.Add("@notificacion", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@exito", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string notificacion = cmd.Parameters["@notificacion"].Value.ToString();
                bool exito = Convert.ToBoolean(cmd.Parameters["@exito"].Value);
                if (!exito)
                {
                    throw new Exception(notificacion);
                }
            }
            catch (Exception Ex)
            {
                string mensaje = "CODIGO 1 - Error al registrar inscripcion en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdateAlumnoInscripcion", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = alumnoInscripcion.ID;
                cmd.Parameters.AddWithValue("@id_alumno", alumnoInscripcion.IDAlumno);
                cmd.Parameters.AddWithValue("@id_curso", alumnoInscripcion.IDCurso);
                cmd.Parameters.AddWithValue("@condicion", alumnoInscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", alumnoInscripcion.Nota);
                cmd.Parameters.Add("@notificacion", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@exito", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string notificacion = cmd.Parameters["@notificacion"].Value.ToString();
                bool exito = Convert.ToBoolean(cmd.Parameters["@exito"].Value);
                if (!exito)
                {
                    throw new Exception(notificacion);
                }
            }
            catch (Exception Ex)
            {
                string mensaje = "CODIGO 1 - Error al editar en base de datos inscripcion de alumno: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("sp_DeleteAlumnoInscripcion", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 547 - No se puede eliminar esta inscripcion debido a restricciones de clave externa.", Ex);
                throw ExcepcionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 1 - Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                if (alumnoInscripcion.State == BusinessEntity.States.New)
                {
                    this.Insert(alumnoInscripcion);
                }
                else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
                {
                    this.Update(alumnoInscripcion);
                }
                else if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(alumnoInscripcion.ID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AlumnoInscripcion> GetAll(Persona persona)
        {
            List<AlumnoInscripcion> listaAlumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                SqlCommand cmd;
                this.OpenConnection();
                if(persona.TipoPersona == 2)
                   cmd  = new SqlCommand("sp_GetAllAlumnosInscripcionesForAlumn", sqlConn);
                else
                    cmd = new SqlCommand("sp_GetAllAlumnosInscripcionesForDocente", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();

                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (string)dr["condicion"];
                    ai.Nota = (int)dr["nota"];
                    ai.LegajoAlumno = (int)dr["legajo"];
                    ai.DescripcionCurso = (string)dr["descripcion"];
                    listaAlumnoInscripciones.Add(ai);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al las inscripciones de los alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaAlumnoInscripciones;
        }
    }
}

using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllCursos", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)dr["id_curso"];
                    curso.Descripcion = (string)dr["descripcion"];
                    curso.IDMateria = (int)dr["id_materia"];
                    curso.IDComision = (int)dr["id_comision"];
                    curso.AnioCalendario = (int)dr["anio_calendario"];
                    curso.Cupo = (int)dr["cupo"];
                    curso.DescripcionMateria = (string)dr["desc_materia"];
                    curso.DescripcionComision = (string)dr["desc_comision"];

                    listaCursos.Add(curso);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar los cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaCursos;
        }
        public Curso GetOne(int id)
        {
            Curso curso = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOneCurso", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    curso = new Curso();

                    curso.ID = (int)dr["id_curso"];
                    curso.Descripcion = (string)dr["descripcion"];
                    curso.IDMateria = (int)dr["id_materia"];
                    curso.IDComision = (int)dr["id_comision"];
                    curso.AnioCalendario = (int)dr["anio_calendario"];
                    curso.Cupo = (int)dr["cupo"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("sp_DeleteCurso", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 547 - No se puede eliminar esta especialidad debido a restricciones de clave externa.", Ex);
                throw ExcepcionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 1 - Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdateCurso", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmd.Parameters.AddWithValue("@id_materia", curso.IDMateria);
                cmd.Parameters.AddWithValue("@descripcion", curso.Descripcion);
                cmd.Parameters.AddWithValue("@id_comision", curso.IDComision);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
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
                string mensaje = "CODIGO 1 - Error al guardar curso en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertCurso", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_materia", curso.IDMateria);
                cmd.Parameters.AddWithValue("@descripcion", curso.Descripcion);
                cmd.Parameters.AddWithValue("@id_comision", curso.IDComision);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
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
                string mensaje = "CODIGO 1 - Error al guardar curso en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Curso curso)
        {
            try
            {
                if (curso.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(curso.ID);
                }
                else if (curso.State == BusinessEntity.States.New)
                {
                    this.Insert(curso);
                }
                else if (curso.State == BusinessEntity.States.Modified)
                {
                    this.Update(curso);
                }
                //usuario.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Curso> GetAll(int iDPlan)
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllCursosForPlan", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPlan", iDPlan);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)dr["id_curso"];
                    curso.Descripcion = (string)dr["descripcion"];
                    curso.IDMateria = (int)dr["id_materia"];
                    curso.IDComision = (int)dr["id_comision"];
                    curso.AnioCalendario = (int)dr["anio_calendario"];
                    curso.Cupo = (int)dr["cupo"];
                    curso.DescripcionMateria = (string)dr["desc_materia"];
                    curso.DescripcionComision = (string)dr["desc_comision"];

                    listaCursos.Add(curso);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar los cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaCursos;
        }
    }
}

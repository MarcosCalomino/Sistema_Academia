using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Data.Database
{
    public class CursoDocenteAdapter: Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> listaDocentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllDocentesCursos", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DocenteCurso docenteCurso = new DocenteCurso();

                    docenteCurso.ID = (int)dr["id_dictado"];
                    docenteCurso.IDCurso = (int)dr["id_curso"];
                    docenteCurso.IDDocente = (int)dr["id_docente"];
                    docenteCurso.Cargo = (DocenteCurso.tipoCargo)(int)dr["cargo"];
                    docenteCurso.LegajoDocente = (int)dr["legajo"];
                    docenteCurso.DescripcionCurso = (string)dr["descripcion"];
                    listaDocentesCursos.Add(docenteCurso);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar los Docentes-Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaDocentesCursos;
        }
        public DocenteCurso GetOne(int id)
        {
            DocenteCurso docenteCurso = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOneDocenteCurso", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    docenteCurso = new DocenteCurso();

                    docenteCurso.ID = (int)dr["id_dictado"];
                    docenteCurso.IDCurso = (int)dr["id_curso"];
                    docenteCurso.IDDocente = (int)dr["id_docente"];
                    docenteCurso.Cargo = (DocenteCurso.tipoCargo)(int)dr["cargo"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar Docente-Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCurso;
        }
        private void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertDocenteCurso", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_curso", docenteCurso.IDCurso);
                cmd.Parameters.AddWithValue("@id_docente", docenteCurso.IDDocente);
                cmd.Parameters.AddWithValue("@cargo", docenteCurso.Cargo);
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
                string mensaje = "CODIGO 1 - Error al guardar docente-curso en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdateDocenteCurso", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.ID;
                cmd.Parameters.AddWithValue("@id_curso", docenteCurso.IDCurso);
                cmd.Parameters.AddWithValue("@id_docente", docenteCurso.IDDocente);
                cmd.Parameters.AddWithValue("@cargo", docenteCurso.Cargo);
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
                string mensaje = "CODIGO 1 - Error al editar docente-curso en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Delete(int iD)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("sp_DeleteDocenteCurso", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = iD;
                cmdDelete.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 547 - No se puede eliminar este registro debido a restricciones de clave externa.", Ex);
                throw ExcepcionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 1 - Error al eliminar registro", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso docenteCurso)
        {
            try
            {
                if (docenteCurso.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(docenteCurso.ID);
                }
                else
                if (docenteCurso.State == BusinessEntity.States.New)
                {
                    this.Insert(docenteCurso);
                }
                else if (docenteCurso.State == BusinessEntity.States.Modified)
                {
                    this.Update(docenteCurso);
                }
                //usuario.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

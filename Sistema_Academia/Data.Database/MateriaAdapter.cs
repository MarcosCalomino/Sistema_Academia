using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> listaMaterias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllMaterias", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Materia materia = new Materia();

                    materia.ID = (int)dr["id_materia"];
                    materia.Descripcion = (string)dr["desc_materia"];
                    materia.HSSemanales = (int)dr["hs_semanales"];
                    materia.HSTotales = (int)dr["hs_totales"];
                    materia.IDPlan = (int)dr["id_plan"];
                    materia.DescripcionPlan = (string)dr["desc_plan"];
                    listaMaterias.Add(materia);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar las materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaMaterias;
        }
        public Materia GetOne(int id)
        {
            Materia materia = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOneMateria", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    materia = new Materia();

                    materia.ID = (int)dr["id_materia"];
                    materia.Descripcion = (string)dr["desc_materia"];
                    materia.HSSemanales = (int)dr["hs_semanales"];
                    materia.HSTotales = (int)dr["hs_totales"];
                    materia.IDPlan = (int)dr["id_plan"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }
        private void Insert(Materia materiaActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertMateria", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", materiaActual.Descripcion);
                cmd.Parameters.AddWithValue("@hsSemanales", materiaActual.HSSemanales);
                cmd.Parameters.AddWithValue("@hsTotales", materiaActual.HSTotales);
                cmd.Parameters.AddWithValue("@idPlan", materiaActual.IDPlan);        
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
                string mensaje = "CODIGO 1 - Error al guardar materia en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void Update(Materia materiaActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdateMateria", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = materiaActual.ID;
                cmd.Parameters.AddWithValue("@descripcion", materiaActual.Descripcion);
                cmd.Parameters.AddWithValue("@hsSemanales", materiaActual.HSSemanales);
                cmd.Parameters.AddWithValue("@hsTotales", materiaActual.HSTotales);
                cmd.Parameters.AddWithValue("@idPlan", materiaActual.IDPlan);
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
                string mensaje = "CODIGO 1 - Error al editar materia en base de datos: " + Ex.Message;
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
                SqlCommand cmdDelete = new SqlCommand("sp_DeleteMateria", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = iD;
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
                new Exception("CODIGO 1 - Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia materiaActual)
        {
            try
            {
                if (materiaActual.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(materiaActual.ID);
                }
                else
                if (materiaActual.State == BusinessEntity.States.New)
                {
                    this.Insert(materiaActual);
                }
                else if (materiaActual.State == BusinessEntity.States.Modified)
                {
                    this.Update(materiaActual);
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

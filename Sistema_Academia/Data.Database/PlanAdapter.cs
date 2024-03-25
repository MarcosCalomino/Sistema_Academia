using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> listaPlanes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllPlanes", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Plan p = new Plan();

                    p.ID = (int)dr["id_plan"];
                    p.Descripcion = (string)dr["desc_plan"];
                    p.IDEspecialidad = (int)dr["id_especialidad"];
                    p.DescripcionEspecialidad = (string)dr["desc_especialidad"];
                    listaPlanes.Add(p);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar los planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaPlanes;
        }
        public Plan GetOne(int iD)
        {
            Plan plan = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOnePlan", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", iD);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    plan = new Plan();

                    plan.ID = (int)dr["id_plan"];
                    plan.Descripcion = (string)dr["desc_plan"];
                    plan.IDEspecialidad = (int)dr["id_especialidad"];       
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }
        private void Insert(Plan planActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertPlan", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", planActual.Descripcion);
                cmd.Parameters.AddWithValue("@idEspecialidad", planActual.IDEspecialidad);
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
                string mensaje = "CODIGO 1 - Error al guardar plan en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdatePlan", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmd.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                cmd.Parameters.AddWithValue("@idEspecialidad", plan.IDEspecialidad);
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
                string mensaje = "CODIGO 1 - Error al editar plan en base de datos: " + Ex.Message;
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
                SqlCommand cmdDelete = new SqlCommand("sp_DeletePlan", sqlConn);
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
                new Exception("CODIGO 1 - Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan planActual)
        {
            try
            {
                if(planActual.State == BusinessEntity.States.New)
                {
                    this.Insert(planActual);
                }
                else if (planActual.State == BusinessEntity.States.Modified)
                {
                    this.Update(planActual);
                }
                else if (planActual.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(planActual.ID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

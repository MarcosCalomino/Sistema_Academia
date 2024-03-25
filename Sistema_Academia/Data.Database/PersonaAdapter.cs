using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class PersonaAdapter: Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> listaPersonas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllPersonas", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona p = new Persona();
                    p.ID = (int)dr["id_persona"];
                    p.Nombre = (string)dr["nombre"];
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.Telefono = (string)dr["telefono"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.Legajo = (int)dr["legajo"];
                    p.TipoPersona = (int)dr["tipo_persona"];
                    p.IDPlan = (int)dr["id_plan"];
                    p.DescripcionPlan = (string)dr["desc_plan"];
                    listaPersonas.Add(p);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO ERROR 1 - Error al recuperar las personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaPersonas;
        }
        public List<Persona> GetAll(int? tipoPersona)
        {
            List<Persona> listaPersonas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllForType", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipoPersona", tipoPersona);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona p = new Persona();
                    p.ID = (int)dr["id_persona"];
                    p.Nombre = (string)dr["nombre"];
                    p.Apellido = (string)dr["apellido"];
                    p.Direccion = (string)dr["direccion"];
                    p.Email = (string)dr["email"];
                    p.Telefono = (string)dr["telefono"];
                    p.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    p.Legajo = (int)dr["legajo"];
                    p.TipoPersona = (int)dr["tipo_persona"];
                    p.IDPlan = (int)dr["id_plan"];
                    //p.DescripcionPlan = (string)dr["desc_plan"];
                    listaPersonas.Add(p);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO ERROR 1 - Error al recuperar las personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaPersonas;
        }
        public Persona GetOne(int id_Persona)
        {
            Persona persona = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetOnePersona", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id_Persona);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    persona = new Persona();

                    persona.ID = (int)dr["id_persona"];
                    persona.Nombre = (string)dr["nombre"];
                    persona.Apellido = (string)dr["apellido"];
                    persona.Direccion = (string)dr["direccion"];
                    persona.Email = (string)dr["email"];
                    persona.Telefono = (string)dr["telefono"];
                    persona.FechaNacimiento = Convert.ToDateTime(dr["fecha_nac"]);
                    persona.Legajo = (int)dr["legajo"];       
                    persona.TipoPersona = (int)dr["tipo_persona"];
                    persona.IDPlan = (int)dr["id_plan"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO ERROR 1 - Error al recuperar Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("sp_DeletePersona", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 547 - No se puede eliminar esta persona debido a restricciones de clave externa.", Ex);
                throw ExcepcionManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("CODIGO 1 - Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertPersona", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@email", persona.Email);
                cmd.Parameters.AddWithValue("@id_plan", persona.IDPlan);
                cmd.Parameters.AddWithValue("@legajo", persona.Legajo);
                cmd.Parameters.AddWithValue("@tipoPersona", persona.TipoPersona);
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
                string mensaje = "CODIGO 1 - Error al guardar persona en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdatePersona", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmd.Parameters.AddWithValue("@direccion", persona.Direccion);
                cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@email", persona.Email);
                cmd.Parameters.AddWithValue("@id_plan", persona.IDPlan);
                cmd.Parameters.AddWithValue("@legajo", persona.Legajo);
                cmd.Parameters.AddWithValue("@tipoPersona", persona.TipoPersona);
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
                string mensaje = "CODIGO 1 - Error al modificar persona en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Persona personaActual)
        {
            try
            {
                if (personaActual.State == BusinessEntity.States.New)
                {
                    this.Insert(personaActual);
                }
                else if (personaActual.State == BusinessEntity.States.Modified)
                {
                    this.Update(personaActual);
                }
                else if (personaActual.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(personaActual.ID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Persona GetOneForLegajo(int legajo)
        {
            Persona persona = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetOnePersonaForLegajo", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Legajo", legajo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    persona = new Persona();

                    persona.ID = (int)dr["id_persona"];
                    persona.Nombre = (string)dr["nombre"];
                    persona.Apellido = (string)dr["apellido"];
                    persona.Direccion = (string)dr["direccion"];
                    persona.Email = (string)dr["email"];
                    persona.Telefono = (string)dr["telefono"];
                    persona.FechaNacimiento = Convert.ToDateTime(dr["fecha_nac"]);
                    persona.Legajo = (int)dr["legajo"];
                    persona.TipoPersona = (int)dr["tipo_persona"];
                    persona.IDPlan = (int)dr["id_plan"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO ERROR 1 - Error al recuperar Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }
    }
}

using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class UsuarioAdapter: Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_GetAllUsuarios", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Email = (string)dr["email"];
                    usr.Id_Persona = (int)dr["id_persona"];
                    listaUsuarios.Add(usr);
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al recuperar los usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaUsuarios;
        }
        public Usuario GetOne(int id)
        {
            Usuario usr = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_GetOneUsuario", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    usr = new Usuario();

                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Email = (string)dr["email"];
                    usr.Id_Persona = (int)dr["id_persona"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =new Exception("CODIGO 1 - Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("sp_DeleteUsuario", sqlConn);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
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
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_UpdateUsuario", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
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
                string mensaje = "CODIGO 1 - Error al guardar usuario en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_InsertUsuario", sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@id_persona", usuario.Id_Persona);
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
                string mensaje = "CODIGO 1 - Error al guardar usuario en base de datos: " + Ex.Message;
                Exception ExcepcionManejada = new Exception(mensaje, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            try
            {
                if (usuario.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(usuario.ID);
                }
                else if (usuario.State == BusinessEntity.States.New)
                {
                    this.Insert(usuario);
                }
                else if (usuario.State == BusinessEntity.States.Modified)
                {
                    this.Update(usuario);
                }
                //usuario.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public Usuario Loguin(string nombreUsuario, string password)
        {
            Usuario usr = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("sp_Loguin", sqlConn);
                cmdUsuarios.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuarios.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmdUsuarios.Parameters.AddWithValue("@password", password);
                SqlDataReader dr = cmdUsuarios.ExecuteReader();
                if (dr.Read())
                {
                    usr = new Usuario();

                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.Nombre = (string)dr["nombre"];
                    usr.Apellido = (string)dr["apellido"];
                    usr.Email = (string)dr["email"];
                    usr.Id_Persona = (int)dr["id_persona"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("CODIGO 1 - Error al loguearse", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
    }
}

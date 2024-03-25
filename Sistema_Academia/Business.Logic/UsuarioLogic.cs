using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        UsuarioAdapter UsuarioData { get; set; }
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }
        public List<Usuario> GetAll()
        {
            try
            {
                List <Usuario> listaUsuarios = UsuarioData.GetAll();
                if (listaUsuarios == null) throw new Exception("No existen Usuarios registrados");
                return listaUsuarios;
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
        public Usuario GetOne(int id)
        {
            try
            {
                Usuario usuario = UsuarioData.GetOne(id);
                if(usuario == null) throw new Exception("No existe usuario");
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Usuario usuario)
        {
            try
            {
                UsuarioData.Save(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
        public Usuario Loguin(string nombreUsuario, string password)
        {
            try
            {
                Usuario usuario = UsuarioData.Loguin(nombreUsuario, password);
                if (usuario == null) throw new Exception("No se encontró dicho usuario");
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

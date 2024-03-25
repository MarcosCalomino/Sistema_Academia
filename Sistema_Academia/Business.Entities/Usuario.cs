using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Usuario: BusinessEntity
    {
        private string nombreUsuario;
        private bool habilitado;
        private string clave;
        private string nombre;
        private string apellido;
        private string email;
        private int id_Persona;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public int Id_Persona { get => id_Persona; set => id_Persona = value; }
    }
}

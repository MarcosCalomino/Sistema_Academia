using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Plan: BusinessEntity
    {
        private string descripcion;
        private int idEspecialidad;
        private string descripcionEspecialidad; //No mapeado a base de datos

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IDEspecialidad { get => idEspecialidad; set => idEspecialidad = value; }
        public string DescripcionEspecialidad { get => descripcionEspecialidad; set => descripcionEspecialidad = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Especialidad: BusinessEntity
    {
        private string descripcion;

        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}

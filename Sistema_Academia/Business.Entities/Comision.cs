using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Comision: BusinessEntity
    {
        private int anioEspecialidad;
        private string descripcion;
        private int idPlan;
        private string descripcionPlan; //No mapeado a base de datp

        public int AnioEspecialidad { get => anioEspecialidad; set => anioEspecialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IDPlan { get => idPlan; set => idPlan = value; }
        public string DescripcionPlan { get => descripcionPlan; set => descripcionPlan = value; }
    }
}

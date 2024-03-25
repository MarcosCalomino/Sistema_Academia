using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Materia: BusinessEntity
    {
        private string descripcion;
        private int hsSemanales;
        private int hsTotales;
        private int idPlan;

        private string descripcionPlan; //No mapeado a base de datos

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int HSSemanales { get => hsSemanales; set => hsSemanales = value; }
        public int HSTotales { get => hsTotales; set => hsTotales = value; }
        public int IDPlan { get => idPlan; set => idPlan = value; }

        public string DescripcionPlan { get => descripcionPlan; set => descripcionPlan = value; }
    }
}

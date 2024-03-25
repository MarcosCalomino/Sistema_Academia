using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Curso: BusinessEntity
    {
        private string descripcion;
        private int anioCalendario;
        private int cupo;
        private int idComision;
        private int idMateria;

        //no mapeados a base de datos
        private string descripcionMateria;
        private string descripcionComision;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int AnioCalendario { get => anioCalendario; set => anioCalendario = value; }
        public int Cupo { get => cupo; set => cupo = value; }
        public int IDComision { get => idComision; set => idComision = value; }
        public int IDMateria { get => idMateria; set => idMateria = value; }
        public string DescripcionMateria { get => descripcionMateria; set => descripcionMateria = value; }
        public string DescripcionComision { get => descripcionComision; set => descripcionComision = value; }
        
    }
}

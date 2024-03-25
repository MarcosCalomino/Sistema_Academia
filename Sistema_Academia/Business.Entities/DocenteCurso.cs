using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        private tipoCargo cargo;
        private int idCurso;
        private int idDocente;
        public enum tipoCargo
        {
            DocentePractica = 1,
            DocenteTeoria = 2,
            Ayudante = 3,
        }
        //no mapeados a bases de datos
        private int legajoDocente;
        private string descripcionCurso;

        public int IDCurso { get => idCurso; set => idCurso = value; }
        public int IDDocente { get => idDocente; set => idDocente = value; }
        public tipoCargo Cargo { get => cargo; set => cargo = value; }

        public int LegajoDocente { get => legajoDocente; set => legajoDocente = value; }
        public string DescripcionCurso { get => descripcionCurso; set => descripcionCurso = value; }
    }
}

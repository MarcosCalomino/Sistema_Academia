using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion: BusinessEntity
    {
        private string condicion;
        private int idAlumno;
        private int idCurso;
        private int nota;
        //no mapeados a base de datos
        private string descripcionCurso;
        private int legajoAlumno;

        public string Condicion { get => condicion; set => condicion = value; }
        public int IDAlumno { get => idAlumno; set => idAlumno = value; }
        public int IDCurso { get => idCurso; set => idCurso = value; }
        public int Nota { get => nota; set => nota = value; }
        //
        public string DescripcionCurso { get => descripcionCurso; set => descripcionCurso = value; }
        public int LegajoAlumno { get => legajoAlumno; set => legajoAlumno = value; }
    }
}

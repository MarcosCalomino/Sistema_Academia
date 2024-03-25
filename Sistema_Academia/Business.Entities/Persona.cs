using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Persona: BusinessEntity
    {
        private string apellido;
        private string direccion;
        private string email;
        private string nombre;
        private string telefono;
        private DateTime fechaNacimiento;
        private int idPlan;
        private int legajo;
        private int tipoPersona;//1-Profesor 2-Alumno 3-Admin
        private string descripcionPlan; //no mapeado en base de atos

        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int IDPlan { get => idPlan; set => idPlan = value; }
        public int Legajo { get => legajo; set => legajo = value; }
        public int TipoPersona { get => tipoPersona; set => tipoPersona = value; }

        //No mapeados
        public string DescripcionPlan { get => descripcionPlan; set => descripcionPlan = value; }
        public string TipoPersonaString
        {
            get
            {
                switch (tipoPersona)
                {
                    case 1:
                        return "Profesor";
                    case 2:
                        return "Alumno";
                    case 3:
                        return "Admin";
                    default:
                        return "Desconocido";
                }
            }
        }


    }
}

using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic: BusinessLogic
    {
        AlumnoInscripcionAdapter AlumnoInscripcionData { get; set; }
        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }
        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return AlumnoInscripcionData.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AlumnoInscripcion GetOne(int iD)
        {
            try
            {
                AlumnoInscripcion inscripcion = AlumnoInscripcionData.GetOne(iD);
                if (inscripcion == null) throw new Exception("No existe inscripcion");
                return inscripcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(AlumnoInscripcion inscripcion)
        {
            try
            {
                AlumnoInscripcionData.Save(inscripcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<AlumnoInscripcion> GetAll(Persona persona)
        {
            try
            {
                return AlumnoInscripcionData.GetAll(persona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

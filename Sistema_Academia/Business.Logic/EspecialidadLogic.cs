using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        EspecialidadAdapter especialidadData { get; set; }
        public EspecialidadLogic()
        {
            especialidadData = new EspecialidadAdapter();
        }
        public List<Especialidad> GetAll()
        {
            try
            {
                return  especialidadData.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Especialidad GetOne(int iD)
        {
            try
            {
                Especialidad especialidad = especialidadData.GetOne(iD);
                if (especialidad == null) throw new Exception("No existe dicha especialidad");
                return especialidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Especialidad especialidadActual)
        {
            try
            {
                especialidadData.Save(especialidadActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}

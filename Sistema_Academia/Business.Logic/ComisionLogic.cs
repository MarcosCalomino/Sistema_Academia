using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class ComisionLogic: BusinessLogic
    {
        ComisionAdapter comisionData { get; set; }
        public ComisionLogic()
        {
            comisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            try
            {
                return comisionData.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(Comision comisionActual)
        {
            try
            {
                comisionData.Save(comisionActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comision GetOne(int iD)
        {
            try
            {
                Comision comision = comisionData.GetOne(iD);
                if (comision == null) throw new Exception("No existe comision");
                return comision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

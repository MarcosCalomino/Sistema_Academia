using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        MateriaAdapter MateriaData { get; set; }
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public List<Materia> GetAll()
        {
			try
			{
                return MateriaData.GetAll();
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }
        public Materia GetOne(int iD)
        {
            try
            {
                Materia materia = MateriaData.GetOne(iD);
                if (materia == null) throw new Exception("No existe materia");
                return materia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Materia materiaActual)
        {
            try
            {
                MateriaData.Save(materiaActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

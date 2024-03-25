using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class DocenteCursoLogic: BusinessLogic
    {
        CursoDocenteAdapter CursoDocenteData { get; set; }
        public DocenteCursoLogic()
        {
            CursoDocenteData = new CursoDocenteAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                List<DocenteCurso> listaDocentesCursos = CursoDocenteData.GetAll();
                if (listaDocentesCursos == null) throw new Exception("No existen registros");
                return listaDocentesCursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DocenteCurso GetOne(int id)
        {
            try
            {
                DocenteCurso docenteCurso = CursoDocenteData.GetOne(id);
                if (docenteCurso == null) throw new Exception("No existe registro");
                return docenteCurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(DocenteCurso docenteCurso)
        {
            try
            {
                CursoDocenteData.Save(docenteCurso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

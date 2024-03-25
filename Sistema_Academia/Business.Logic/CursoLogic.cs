using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {
        CursoAdapter cursoData { get; set; }

        public CursoLogic()
        {
            cursoData = new CursoAdapter();        
        }
        public List<Curso> GetAll()
        {
            try
            {
                return cursoData.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Curso> GetAll(int iDPlan)
        {
            try
            {
                return cursoData.GetAll(iDPlan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Curso GetOne(int id)
        {
            try
            {
                Curso curso = cursoData.GetOne(id);
                if (curso == null) throw new Exception("No existe curso");
                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Curso curso)
        {
            try
            {
                cursoData.Save(curso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

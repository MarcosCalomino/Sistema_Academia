using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        PlanAdapter planData { get; set; }
        public PlanLogic()
        {
            planData = new PlanAdapter();
        }
        public List<Plan> GetAll()
        {
            try
            {
                return planData.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Plan GetOne(int iD)
        {
            try
            {
                Plan plan = planData.GetOne(iD);
                if (plan == null) throw new Exception("No existe plan");
                return plan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Plan planActual)
        {
            try
            {
                planData.Save(planActual);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

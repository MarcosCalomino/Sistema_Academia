using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        PersonaAdapter PersonaData { get; set; }
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }
        public List<Persona> GetAll()
        {
            try
            {
                List<Persona> listaPersonas =  PersonaData.GetAll();
                if (listaPersonas == null) throw new Exception("No existen personas registradas");
                return listaPersonas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Persona> GetAll(int? tipoPersona)
        {
            try
            {
                List<Persona> listaPersonas = PersonaData.GetAll(tipoPersona);
                if (listaPersonas == null) throw new Exception("No existen personas registradas");
                return listaPersonas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Persona GetOne(int id_Persona)
        {
            try
            {
                Persona persona = PersonaData.GetOne(id_Persona);
                if (persona == null) throw new Exception("No existe persona");
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Save(Persona personaActual)
        {
            try
            {
                PersonaData.Save(personaActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Persona GetOneForLegajo(int legajo)
        {
            try
            {
                Persona persona = PersonaData.GetOneForLegajo(legajo);
                if (persona == null) throw new Exception("No existe");
                return persona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public abstract class BusinessEntity
    {
        private int _ID;
        private States _State;
        public enum States { Deleted, New, Modified, Unmodified }
        public BusinessEntity()
        {
            this.State = States.New;
        }   
        public States State { get => _State; set => _State = value; }
        public int ID { get => _ID; set => _ID = value; }
    }
}

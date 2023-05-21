using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class DieselCar : Car
    {
        private DieselEngine m_engine { get; set; }

        public DieselCar(string i_Type) : base(i_Type)
        {
            
        }
    }
}

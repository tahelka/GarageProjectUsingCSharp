using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }

        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_Type) : base(i_Type)
        {

        }



    }
}

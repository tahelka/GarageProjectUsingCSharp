using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string m_Model { get; set; }
        public string m_PlateNumber { get; set; }
        public float m_EnergyPrecentleft { get; set; }
        public List<Wheel> m_Wheels { get; set; }
        public Engine m_Engine { get; set; }

        protected Vehicle(string i_Type)
        {
            if (i_Type == "electric")
            {
                m_Engine = new ElectricEngine();
            }
            else
            {
                m_Engine = new DieselEngine();
            }
        }

        public void SetTirePressure(int tirePressure)
        {

        }

    }
}

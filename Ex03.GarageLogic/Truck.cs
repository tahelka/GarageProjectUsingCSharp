using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool m_DoesContainDangerousMaterials { get; set; }
        private float m_PayloadCapacity { get; set; }

        public Truck() : base("electric")
        {

        }
    }
}

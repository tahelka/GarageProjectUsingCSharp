using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static int Main()
        {
            ConsoleUI.GarageUI userInterface = new ConsoleUI.GarageUI();
            userInterface.ChooseAction();
            return 0;
        }
    }
}

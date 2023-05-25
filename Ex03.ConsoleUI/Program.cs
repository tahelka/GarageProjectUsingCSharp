
namespace Ex03.ConsoleUI
{
    class Program
    {
        public static int Main()
        {
            ConsoleUI.GarageUI userInterface = new ConsoleUI.GarageUI();

            while (userInterface.IsGarageInAction)
            {
                userInterface.ChooseAction();
            }

            return 0;
        }
    }
}

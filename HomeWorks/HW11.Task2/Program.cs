using System;
using HW11.Task2.Repositories;
using HW11.Task2.Services;

namespace HW11.Task2
{
    class Program
    {
        static void Main()
        {
            LoggingService.AddEventToLog($"Start application {typeof(Program)}");
            using (var db = new ApplicationContext())
            {
                IMotorcycleRepository motorcycleRepository = new MotorcycleRepository(db);
                while (IsRepeat())
                {
                    MotorcycleService.MotorcycleEvents(motorcycleRepository);
                }
            }
            LoggingService.AddEventToLog($"Termination of the application {typeof(Program)}");
        }

        private static bool IsRepeat()
        {
            Console.WriteLine($"{new string('-', 50)}\nTo continue working with Motorcycles objects press Y.\nFor closing, enter N.\n[Y/N]\n{new string('-', 50)}");
            string value = Console.ReadLine()?.ToUpper();

            while (!value.Equals("Y") && !value.Equals("N"))
            {
                Console.WriteLine("Enter either Y or N to continue.");
                value = Console.ReadLine()?.ToUpper();
            }
            return (value.Equals("Y"));
        }
    }
}

using System;
using HM12.Task1.Services;

namespace HM12.Task1
{
    class Program
    {
        static void Main()
        {
            LoggingService.AddEventToLog($"Start application {typeof(Program)}");
            using (var db = new ApplicationContext())
            {
                while (IsRepeat())
                {
                    new ItemService(db).ItemEvent();
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

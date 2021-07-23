using System;
using HW11.Task2.Repositories;
using HW11.Task2.Services;

namespace HW11.Task2
{
    class Program
    {
        static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                IMotorcycleRepository motorcycleRepository = new MotorcycleRepository(db);
                while (IsRepeat())
                {
                    var moto = new MotorcycleService().GetMotorcycle();
                    motorcycleRepository.CreateMotorcycle(moto);
                }
            }
            Console.ReadLine();
        }

        private static bool IsRepeat()
        {
            Console.WriteLine($"{new string('-', 50)}\nIf you want to create a Motorcycle object, enter Y.\nFor closing, enter N.\n[Y/N]\n{new string('-', 50)}");
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

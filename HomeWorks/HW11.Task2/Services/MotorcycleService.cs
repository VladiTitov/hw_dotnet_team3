using System;
using HW11.Task2.Models;

namespace HW11.Task2.Services
{
    public class MotorcycleService
    {
        public Motorcycle GetMotorcycle()
        {
            return new Motorcycle()
            {
                Name = InputOutput("Enter motocycle name:"),
                Model = InputOutput("Enter motocycle model:"),
                Year = GetIntValue("Enter motocycle year:")
            };
        }

        private string InputOutput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private int GetIntValue(string message)
        {
            int result;
            while (!int.TryParse(InputOutput(message), out result))
            {
                Console.WriteLine("Enter valid value!");
            }

            return result;
        }
    }
}

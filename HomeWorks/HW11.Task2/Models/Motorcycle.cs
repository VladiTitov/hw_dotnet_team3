using System;
using System.ComponentModel.DataAnnotations;
using HW11.Task2.Services;

namespace HW11.Task2.Models
{
    public class Motorcycle
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        
        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                while (value <= 0 || value > DateTime.Now.Year)
                {
                    Console.WriteLine("Enter correct year value!");
                    LoggingService.AddEventToLog($"Incorrect data entered. Data = {value}");
                    value = GetYearValidValue();
                }

                _year = value;
            }
        }

        public int Odometer { get; set; } = 0;

        private int GetYearValidValue()
        {
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Enter correct year value!");
                LoggingService.AddEventToLog($"Incorrect data entered. Integer type expected. Data={year}");
            }
            return year;
        }

        public override string ToString() => $"ID = {ID}, Name = {Name}, Model = {Model}, Year = {Year}, Odometer = {Odometer}";
    }
}

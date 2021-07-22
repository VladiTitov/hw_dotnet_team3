using System;
using System.ComponentModel.DataAnnotations;

namespace HW11.Task2.Models
{
    class Motorcycle
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Odometer { get; set; }
    }
}

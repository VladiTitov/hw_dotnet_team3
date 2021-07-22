using System;
using System.Collections.Generic;
using HW11.Task2.Models;

namespace HW11.Task2
{
    class Program
    {
        static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Motorcycles.Add(new Motorcycle()
                {
                    Model = "R1000",
                    Name = "BMW",
                    Odometer = 0,
                    Year = 1990
                });
                db.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}

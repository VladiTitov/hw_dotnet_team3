using System;
using System.Collections.Generic;

namespace HM12.Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Today;

            Queue<DateTime> dates = new Queue<DateTime>();

            dates.Enqueue(date1);
            dates.Enqueue(date2);

            try
            {
                DateTime dequeueElementDate = dates.Dequeue();
                Console.WriteLine($"Dequeued element: {dequeueElementDate}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Can't deque the element. Details: {ex.Message}");
            }

            try
            {
                DateTime peekElementDate = dates.Peek();
                Console.WriteLine($"Peeked element: {peekElementDate}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Can't peek the element. Details: {ex.Message}");
            }
        }
    }
}
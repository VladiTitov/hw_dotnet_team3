using System;
using HM12.Task2._3.Collections;
using HM12.Task2._3.Models;

namespace HM12.Task2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Today;

            CustomQueue<Employee> customQueue = new CustomQueue<Employee>();
            customQueue.Enqueue(new Actor());
            customQueue.Enqueue(new Teacher());
            customQueue.Enqueue(new Employee());

            try
            {
                object dequeueElementDate = customQueue.Dequeue();
                Console.WriteLine($"Dequeued element: {dequeueElementDate}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Can't deque the element. Details: {ex.Message}");
            }

            try
            {
                object peekElementDate = customQueue.Peek();
                Console.WriteLine($"Peeked element: {peekElementDate}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Can't peek the element. Details: {ex.Message}");
            }
        }
    }
}

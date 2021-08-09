using System;
using System.Collections.Generic;

namespace HM12.Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<object> queueObj = new Queue<object>();

            queueObj.Enqueue(22);
            queueObj.Enqueue(new int[] { 12, 15, 32 });
            queueObj.Enqueue("test string");
            queueObj.Enqueue(new userClass());

            object[] objArray = new object[queueObj.Count];

            while (queueObj.Count != 0)
            {
                Console.WriteLine("Type of the first element in collection: {0}. Collection lenght: {1}.", queueObj.Peek().GetType(), queueObj.Count);
                objArray[queueObj.Count - 1] = queueObj.Dequeue();
            }
        }
        class userClass { }
    }
}

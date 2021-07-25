using System;
using System.Diagnostics;
using System.IO;

namespace HW11_01
{
    public class JsonServices
    {
        public void NewtosoftService(object track)
        {
            Stopwatch newtonsoft = new();
            newtonsoft.Start();
            string newtonsoftResult = Newtonsoft.Json.JsonConvert.SerializeObject(track);
            newtonsoft.Stop();
            Console.WriteLine(newtonsoftResult);
            string jsonFile = "jsonFileSong.json";
            File.WriteAllText(jsonFile, newtonsoftResult);
            Console.WriteLine("Newtonsoft.Json: {0} ms", newtonsoft.ElapsedMilliseconds);
        }
        public void SystemTextService(object track)
        {
            Stopwatch systemText = new();
            systemText.Start();
            string systemTextResult = System.Text.Json.JsonSerializer.Serialize(track);
            systemText.Stop();
            Console.WriteLine(systemTextResult);
            Console.WriteLine("System.Text.Json: {0} ms", systemText.ElapsedMilliseconds);
        }
    }
}

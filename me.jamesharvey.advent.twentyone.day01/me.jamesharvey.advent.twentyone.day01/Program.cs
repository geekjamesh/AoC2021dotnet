using System;
using System.Collections.Generic;
using System.IO;

namespace me.jamesharvey.advent.twentyone.day01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputValues = new List<string>();
            using (var reader = new StreamReader("input.txt"))
            {
                string item = reader.ReadLine();
                while(item != null) {
                    inputValues.Add(item);
                    item = reader.ReadLine();
                }
            }
            try
            {
                SonarScan scanProcesser = new SonarScan(inputValues);
                Console.WriteLine($"Number of Times a depth measurement increases = {scanProcesser.CalculateDepthIncreases()}");   
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }
            
        }
    }
}

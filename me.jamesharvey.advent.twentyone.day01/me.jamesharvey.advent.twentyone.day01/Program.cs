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
                Console.WriteLine($"Day 1 a - Number of Times a depth measurement increases = {scanProcesser.CalculateDepthIncreases()}");
                Console.WriteLine($"Day 1 b - Number of Times a combined depth measurement increases = {scanProcesser.CalculateSlidingDepthIncreases()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }
            
        }
    }
}

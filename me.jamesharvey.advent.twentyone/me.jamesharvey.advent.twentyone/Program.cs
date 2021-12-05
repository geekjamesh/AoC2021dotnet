using System;
using me.jamesharvey.advent.twentyone.Utilities;

namespace me.jamesharvey.advent.twentyone
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SonarScan scanProcesser = new SonarScan(FileReader.ReadIntegerInputFromFile("InputData/SonarScanInput.txt"));
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

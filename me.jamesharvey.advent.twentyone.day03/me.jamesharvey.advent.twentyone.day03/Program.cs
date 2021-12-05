using System;
using System.Collections.Generic;
using System.IO;

namespace me.jamesharvey.advent.twentyone.day03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputValues = new List<string>();
            using (var reader = new StreamReader("input.txt"))
            {
                string item = reader.ReadLine();
                while (item != null)
                {
                    inputValues.Add(item);
                    item = reader.ReadLine();
                }
            }
            try
            {
                DignosticReportReader powerDiagnostics = new DignosticReportReader(inputValues);

                Console.WriteLine($"Day 3 a - Power Consumption = {powerDiagnostics.PowerConsumption}");

                Console.WriteLine($"Day 3 b - Life Support rating = {powerDiagnostics.LifeSupportRating}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }

        }
    }
}

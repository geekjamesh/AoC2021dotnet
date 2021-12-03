using System;
using System.Collections.Generic;
using System.IO;

namespace me.jamesharvey.advent.twentyone.day02
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
                BasicNavigator subNavigation = new BasicNavigator();
                foreach(string instruction in inputValues)
                {
                    subNavigation.ParseInstruction(instruction);
                }
                Console.WriteLine($"Day 2 a - Location Reference = {subNavigation.LocationReference}");
                AimingNavigator secondSubNavigation = new AimingNavigator();
                foreach (string instruction in inputValues)
                {
                    secondSubNavigation.ParseInstruction(instruction);
                }
                Console.WriteLine($"Day 2 a - Location Reference = {secondSubNavigation.LocationReference}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }

        }
    }
}

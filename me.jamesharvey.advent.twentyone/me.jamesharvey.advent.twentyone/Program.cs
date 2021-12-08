using System;
using System.Collections.Generic;
using me.jamesharvey.advent.twentyone.Utilities;

namespace me.jamesharvey.advent.twentyone
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Day 1
                SonarScan scanProcesser = new SonarScan(FileReader.ReadIntegerInputFromFile("InputData/SonarScanInput.txt"));
                Console.WriteLine($"Day 1 a - Number of Times a depth measurement increases = {scanProcesser.CalculateDepthIncreases()}");
                Console.WriteLine($"Day 1 b - Number of Times a combined depth measurement increases = {scanProcesser.CalculateSlidingDepthIncreases()}");

                // Day 2
                List<string> navigationInstructions = FileReader.ReadStringInputFromFile("InputData/NavigationInstructions.txt");
                BasicNavigator subNavigation = new BasicNavigator();
                foreach (string instruction in navigationInstructions)
                {
                    subNavigation.ParseInstruction(instruction);
                }
                Console.WriteLine($"Day 2 a - Location Reference = {subNavigation.LocationReference}");
                AimingNavigator secondSubNavigation = new AimingNavigator();
                foreach (string instruction in navigationInstructions)
                {
                    secondSubNavigation.ParseInstruction(instruction);
                }
                Console.WriteLine($"Day 2 b - Location Reference = {secondSubNavigation.LocationReference}");

                // Day 3
                List<string> diagnosticData = FileReader.ReadStringInputFromFile("InputData/DiagnosticData.txt");
                DignosticReportReader powerDiagnostics = new DignosticReportReader(diagnosticData);
                Console.WriteLine($"Day 3 a - Power Consumption = {powerDiagnostics.PowerConsumption}");
                Console.WriteLine($"Day 3 b - Life Support rating = {powerDiagnostics.LifeSupportRating}");

                // Day 4
                BingoService classUnderTest = new BingoService();
                classUnderTest.CreateCards(FileReader.ReadStringInputFromFile("InputData/BingoData.txt"));
                Console.WriteLine($"Day 4 a - Winning Bingo Card's Score = {classUnderTest.RunBingoGame()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }
        }
    }
}

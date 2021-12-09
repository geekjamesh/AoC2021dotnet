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
                BingoService winningBingoGame = new BingoService();
                winningBingoGame.CreateCards(FileReader.ReadStringInputFromFile("InputData/BingoData.txt"));
                BingoService losingBingoGame = new BingoService();
                losingBingoGame.CreateCards(FileReader.ReadStringInputFromFile("InputData/BingoData.txt"));
                Console.WriteLine($"Day 4 a - Winning Bingo Card's Score = {winningBingoGame.RunBingoGame(BingoService.GameStyle.PlayToWin)}");
                Console.WriteLine($"Day 4 b - Losing Bingo Card's Score = {losingBingoGame.RunBingoGame(BingoService.GameStyle.PlayToLose)}");

                // Day 5
                // TODO: Complete Day 5

                // Day 6
                // TODO: Complete Day 6

                // Day 7
                // TODO: Complete Day 7

                // Day 8
                // TODO: Complete Day 8

                // Day 9
                SmokeRiskService smokeRiskService = new SmokeRiskService(FileReader.ReadStringInputFromFile("InputData/HeightMap.txt"));
                Console.WriteLine($"Day 9 a - Smoke Risk = {smokeRiskService.CalculateSmokeRisk()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - {ex.Message}");
            }
        }
    }
}

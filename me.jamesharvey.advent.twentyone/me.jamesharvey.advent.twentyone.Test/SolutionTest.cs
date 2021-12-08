using me.jamesharvey.advent.twentyone.Utilities;
using Xunit;

namespace me.jamesharvey.advent.twentyone.test
{
    /// <summary>
    /// Ensure all previous solutions still pass
    /// </summary>
    public class SolutionTest
    {
        [Fact]
        public void Day1_Part1()
        {
            SonarScan scanProcesser = new SonarScan(FileReader.ReadIntegerInputFromFile("InputData/SonarScanInput.txt"));
            Assert.Equal(1228, scanProcesser.CalculateDepthIncreases());
        }

        [Fact]
        public void Day1_Part2()
        {
            SonarScan scanProcesser = new SonarScan(FileReader.ReadIntegerInputFromFile("InputData/SonarScanInput.txt"));
            Assert.Equal(1257, scanProcesser.CalculateSlidingDepthIncreases());
        }

        [Fact]
        public void Day2_Part1()
        {
            BasicNavigator subNavigation = new BasicNavigator();
            foreach (string instruction in FileReader.ReadStringInputFromFile("InputData/NavigationInstructions.txt"))
            {
                subNavigation.ParseInstruction(instruction);
            }
            Assert.Equal(1636725, subNavigation.LocationReference);
        }

        [Fact]
        public void Day2_Part2()
        {
            AimingNavigator secondSubNavigation = new AimingNavigator();
            foreach (string instruction in FileReader.ReadStringInputFromFile("InputData/NavigationInstructions.txt"))
            {
                secondSubNavigation.ParseInstruction(instruction);
            }
            Assert.Equal(1872757425, secondSubNavigation.LocationReference);
        }

        [Fact]
        public void Day3_Part1()
        {
            DignosticReportReader powerDiagnostics = new DignosticReportReader(FileReader.ReadStringInputFromFile("InputData/DiagnosticData.txt"));
            Assert.Equal(4147524, powerDiagnostics.PowerConsumption);
        }

        [Fact]
        public void Day3_Part2()
        {
            DignosticReportReader powerDiagnostics = new DignosticReportReader(FileReader.ReadStringInputFromFile("InputData/DiagnosticData.txt"));
            Assert.Equal(3570354, powerDiagnostics.LifeSupportRating);
        }

        [Fact]
        public void Day4_Part1()
        {
            BingoService classUnderTest = new BingoService();
            classUnderTest.CreateCards(FileReader.ReadStringInputFromFile("InputData/BingoData.txt"));
            Assert.Equal(87456, classUnderTest.RunBingoGame());
        }
    }
}

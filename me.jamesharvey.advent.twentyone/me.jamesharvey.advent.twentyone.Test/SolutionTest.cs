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
    }
}

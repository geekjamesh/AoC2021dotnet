using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace me.jamesharvey.advent.twentyone.test
{
    public class SonarScanTest
    {
        [Theory,
            InlineData(new int[] { 1, 2, 3 }, 2),
            InlineData(new int[] { 3, 2, 1 }, 0),
            InlineData(new int[] { 1, 3, 2 }, 1),
            InlineData(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7)
        ]
        public void CalculateDepthIncreases_CalculatesCorrectValues_Given_NumericInput(int[] values, int expected)
        {
            List<int> testVals = values.ToList();
            SonarScan testClass = new SonarScan(testVals);
            Assert.Equal(expected, testClass.CalculateDepthIncreases());
        }

        [Theory,
            InlineData(new int[] { 1, 2, 3, 4 }, 1),
            InlineData(new int[] { 4, 3, 2, 1 }, 0),
            InlineData(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 5)
        ]
        public void CalculateSlidingDepthIncreases_CalculatesCorrectValues_Given_NumericInput(int[] values, int expected)
        {
            List<int> testVals = values.ToList();
            SonarScan testClass = new SonarScan(testVals);
            Assert.Equal(expected, testClass.CalculateSlidingDepthIncreases());
        }
    }
}

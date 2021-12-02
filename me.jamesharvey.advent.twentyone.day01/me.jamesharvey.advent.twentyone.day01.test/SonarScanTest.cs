using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace me.jamesharvey.advent.twentyone.day01.test
{
    public class SonarScanTest
    {
        [Theory,
            InlineData(new string[]{"1", "2", "3"}, 2),
            InlineData(new string[]{"3", "2", "1"}, 0),
            InlineData(new string[]{"1", "3", "2"}, 1),
            InlineData(new string[]{"199", "200", "208", "210", "200", "207", "240", "269", "260", "263"}, 7)
        ]
        public void CalculateDepthIncreases_CalculatesCorrectValues_Given_NumericInput(string[] values, int expected)
        {
            List<string> testVals = values.ToList();
            SonarScan testClass = new SonarScan(testVals);
            Assert.Equal(expected, testClass.CalculateDepthIncreases());
        }

        [Fact]
        public void CalculateDepthIncreases_Throws_Exception_Given_NonNumericInput()
        {
            try
            {
                SonarScan testClass = new SonarScan(new List<string> { "INVALID" });
                var result = testClass.CalculateDepthIncreases();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Theory,
            InlineData(new string[] { "1", "2", "3", "4" }, 1),
            InlineData(new string[] { "4", "3", "2", "1" }, 0),
            InlineData(new string[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" }, 5)
        ]
        public void CalculateSlidingDepthIncreases_CalculatesCorrectValues_Given_NumericInput(string[] values, int expected)
        {
            List<string> testVals = values.ToList();
            SonarScan testClass = new SonarScan(testVals);
            Assert.Equal(expected, testClass.CalculateSlidingDepthIncreases());
        }

        [Fact]
        public void CalculateAverageDepthIncreases_Throws_Exception_Given_NonNumericInput()
        {
            try
            {
                SonarScan testClass = new SonarScan(new List<string> { "INVALID" });
                var result = testClass.CalculateSlidingDepthIncreases();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}

using System.Collections.Generic;
using Xunit;

namespace me.jamesharvey.advent.twentyone.test
{
    public class DignosticReportReaderTest
    {
        [Fact]
        public void CalculateGammaEpsilonRates_DetectsMostCommon_GivenSingleCharList()
        {
            List<string> testData = new List<string> { "1", "0", "1" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            classUnderTest.CalculateGammaEpsilonRates();
            Assert.Equal("1", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("0", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void CalculateGammaEpsilonRates_DetectsMostCommon_GivenMultiCharList()
        {
            List<string> testData = new List<string> { "101", "010", "110" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            classUnderTest.CalculateGammaEpsilonRates();
            Assert.Equal("110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("001", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void PowerConsumption_ReturnsValue_GivenNoneZeroBinaryStrings()
        {
            List<string> testData = new List<string> { "101", "010", "110" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal(6, classUnderTest.PowerConsumption);
            Assert.Equal("110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("001", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void PowerConsumption_ReturnsValue_GivenSampleInput()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal(198, classUnderTest.PowerConsumption);
            Assert.Equal("10110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("01001", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void FindMostCommonBit_Returns1_GivenListMostCommonBit1()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal("1", classUnderTest.FindMostCommonBit(testData, 0));
        }

        [Fact]
        public void FindMostCommonBit_Returns0_GivenListMostCommonBit0()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal("0", classUnderTest.FindMostCommonBit(testData, 1));
        }

        [Fact]
        public void FilterValues_ReturnsListStartingIn1_GivenListMostCommonBit1_MostCommon()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            List<string> result = classUnderTest.FilterValues(testData, true, 0);
            Assert.NotNull(result);
            foreach (var resultitem in result)
            {
                Assert.Equal("1", resultitem.Substring(0, 1));
            }
        }

        [Fact]
        public void FilterValues_ReturnsListStartingIn0_GivenListMostCommonBit1_LeastCommon()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            List<string> result = classUnderTest.FilterValues(testData, false, 0);
            Assert.NotNull(result);
            foreach (var resultitem in result)
            {
                Assert.Equal("0", resultitem.Substring(0, 1));
            }
        }

        [Fact]
        public void FilterValues_ReturnsListStartingIn0_GivenListMostCommonBit0_MostCommon()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            List<string> result = classUnderTest.FilterValues(testData, true, 1);
            Assert.NotNull(result);
            foreach (var resultitem in result)
            {
                Assert.Equal("0", resultitem.Substring(1, 1));
            }
        }

        [Fact]
        public void FilterValues_ReturnsListStartingIn1_GivenListMostCommonBit0_LeastCommon()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            List<string> result = classUnderTest.FilterValues(testData, false, 1);
            Assert.NotNull(result);
            foreach (var resultitem in result)
            {
                Assert.Equal("1", resultitem.Substring(1, 1));
            }
        }

        [Fact]
        public void OxygenGenRating_ReturnsAnswer_GivenSampleInput()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal(23, classUnderTest.OxygenGenRating);
        }

        [Fact]
        public void CO2ScrubberRating_ReturnsAnswer_GivenSampleInput()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal(10, classUnderTest.CO2ScrubberRating);
        }

        [Fact]
        public void LifeSupportRating_ReturnsAnswer_GivenSampleInput()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            DignosticReportReader classUnderTest = new DignosticReportReader(testData);
            Assert.Equal(230, classUnderTest.LifeSupportRating);
        }
    }
}

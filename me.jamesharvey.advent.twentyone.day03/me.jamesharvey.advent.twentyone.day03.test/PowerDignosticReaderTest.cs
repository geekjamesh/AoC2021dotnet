using System.Collections.Generic;
using Xunit;

namespace me.jamesharvey.advent.twentyone.day03.test
{
    public class PowerDignosticReaderTest
    {
        [Fact]
        public void CalculateGammaEpsilonRates_DetectsMostCommon_GivenSingleCharList()
        {
            List<string> testData = new List<string> { "1", "0", "1" };
            PowerDignosticReader classUnderTest = new PowerDignosticReader(testData);
            classUnderTest.CalculateGammaEpsilonRates();
            Assert.Equal("1", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("0", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void CalculateGammaEpsilonRates_DetectsMostCommon_GivenMultiCharList()
        {
            List<string> testData = new List<string> { "101", "010", "110" };
            PowerDignosticReader classUnderTest = new PowerDignosticReader(testData);
            classUnderTest.CalculateGammaEpsilonRates();
            Assert.Equal("110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("001", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void PowerConsumption_ReturnsValue_GivenNoneZeroBinaryStrings()
        {
            List<string> testData = new List<string> { "101", "010", "110" };
            PowerDignosticReader classUnderTest = new PowerDignosticReader(testData);
            Assert.Equal(6, classUnderTest.PowerConsumption);
            Assert.Equal("110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("001", classUnderTest.BinaryEpsilonRate.ToString());
        }

        [Fact]
        public void PowerConsumption_ReturnsValue_GivenSampleInput()
        {
            List<string> testData = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            PowerDignosticReader classUnderTest = new PowerDignosticReader(testData);
            Assert.Equal(198, classUnderTest.PowerConsumption);
            Assert.Equal("10110", classUnderTest.BinaryGammaRate.ToString());
            Assert.Equal("01001", classUnderTest.BinaryEpsilonRate.ToString());
        }
    }
}

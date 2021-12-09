using System;
using System.Collections.Generic;
using Xunit;

namespace me.jamesharvey.advent.twentyone.Test
{
    public class SmokeRiskServiceTest
    {
        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf2_GivenSimple3x3GridCentralLowPoint1()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "999",
                "219",
                "358"
            });
            Assert.Equal(2, classUnderTest.CalculateSmokeRisk());
        }

        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf2_GivenSimple2x3GridCentreTopLowPoint1()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "219",
                "358"
            });
            Assert.Equal(2, classUnderTest.CalculateSmokeRisk());
        }

        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf2_GivenSimple3x3GridCentreLeftLowPoint1()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "999",
                "129",
                "358"
            });
            Assert.Equal(2, classUnderTest.CalculateSmokeRisk());
        }

        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf2_GivenSimple3x3GridCentreRightLowPoint1()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "999",
                "321",
                "458"
            });
            Assert.Equal(2, classUnderTest.CalculateSmokeRisk());
        }

        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf2_GivenSimple2x3GridCentreBottomLowPoint1()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "358",
                "219"
            });
            Assert.Equal(2, classUnderTest.CalculateSmokeRisk());
        }

        [Fact]
        public void CalculateSmokeRisk_ReturnsRiskOf15_GivenSample10x5GridMultipleLowPoints()
        {
            SmokeRiskService classUnderTest = new SmokeRiskService(new List<string>
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            });
            Assert.Equal(15, classUnderTest.CalculateSmokeRisk());
        }
    }
}

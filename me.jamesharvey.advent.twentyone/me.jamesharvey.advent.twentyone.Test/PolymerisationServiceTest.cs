using System.Collections.Generic;
using Xunit;
namespace me.jamesharvey.advent.twentyone.Test
{
    public class PolymerisationServiceTest
    {
        private List<string> sampleInput = new List<string>{
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
            };

        [Fact]
        public void PolymerisationService_LoadsTemplate_GivenSampleInput()
        {
            PolymerisationService service = new PolymerisationService(sampleInput);
            Assert.Equal("NNCB", service.PolymerTemplate);
            Assert.NotEmpty(service.PolymerisationRules);
            Assert.Equal(16, service.PolymerisationRules.Count);
            Assert.True(service.PolymerisationRules.ContainsKey("CH"));
            Assert.Equal("B", service.PolymerisationRules["CH"]);
        }

        [Fact]
        public void ProcessChain_InsertsCorrectChar_GivenSingleCombination()
        {
            PolymerisationService service = new PolymerisationService();
            service.PolymerisationRules.Add("CH", "B");
            string result = service.ProcessChain("CH");
            Assert.Equal("CBH", result);
        }

        [Fact]
        public void ProcessChain_InsertsCorrectChar_GivenMultipleCombination()
        {
            PolymerisationService service = new PolymerisationService();
            service.PolymerisationRules.Add("CH", "B");
            service.PolymerisationRules.Add("HH", "N");
            string result = service.ProcessChain("CHH");
            Assert.Equal("CBHNH", result);
        }

        [Fact]
        public void ProcessChain_InsertsCorrectChars_GivenSampleInput()
        {
            PolymerisationService service = new PolymerisationService(sampleInput);
            string result = service.ProcessChain(service.PolymerTemplate);
            Assert.Equal("NCNBCHB", result);
        }

        [Fact]
        public void ProcessChainSequence_HasCorrectlength_GivenSampleInput()
        {
            PolymerisationService service = new PolymerisationService(sampleInput);
            string result = service.ProcessChainSequence();
            Assert.Equal(3073, result.Length);
        }

        [Theory,
            InlineData("A", 1),
            InlineData("AA", 2),
            InlineData("BAA", 2),
            InlineData("AABABBB", 4)]
        public void CalculateMostCommonElementCount_ReturnsExpectedCount_GivenMockPolymerChain(string chain, int expectedCount)
        {
            PolymerisationService service = new PolymerisationService();
            int result = service.CalculateMostCommonElementCount(chain);
            Assert.Equal(expectedCount, result);
        }

        [Theory,
            InlineData("A", 1),
            InlineData("AA", 2),
            InlineData("BAA", 1),
            InlineData("AABABBB", 3)]
        public void CalculateLeastCommonElementCount_ReturnsExpectedCount_GivenMockPolymerChain(string chain, int expectedCount)
        {
            PolymerisationService service = new PolymerisationService();
            int result = service.CalculateLeastCommonElementCount(chain);
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void ProcessPolymerisation_GivesExpecedResult_GivenSampleInput()
        {
            PolymerisationService service = new PolymerisationService(sampleInput);
            Assert.Equal(1588, service.ProcessPolymerisation());
        }
    }
}

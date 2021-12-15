using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace me.jamesharvey.advent.twentyone
{
    public class PolymerisationService
    {
        public string PolymerTemplate { get; set; }

        public Dictionary<string, string> PolymerisationRules { get; set; }

        public PolymerisationService()
        {
            PolymerisationRules = new Dictionary<string, string>();
        }

        public PolymerisationService(List<string> polymerisationData)
        {
            PolymerisationRules = new Dictionary<string, string>();
            PolymerTemplate = polymerisationData[0];
            for (int i = 2; i < polymerisationData.Count; i++)
            {
                var dataLine = polymerisationData[i].Split(" -> ");
                PolymerisationRules.Add(dataLine[0], dataLine[1]);
            }
        }

        public string ProcessChain(string chain)
        {
            StringBuilder newChain = new StringBuilder(chain.Substring(0, 1));
            for (int i = 0; i < chain.Length-1; i++)
            {
                string left = chain.Substring(i, 1);
                string right = chain.Substring(i + 1, 1);
                string newElement = "";
                if (PolymerisationRules.ContainsKey(left + right))
                {
                    newElement = PolymerisationRules[left + right];
                }
                newChain.Append(newElement).Append(right);
            }

            return newChain.ToString();
        }

        public string ProcessChainSequence()
        {
            string newChain = PolymerTemplate;
            for (int i = 0; i < 10; i++)
            {
                newChain = ProcessChain(newChain);
            }

            return newChain;
        }

        public int CalculateMostCommonElementCount(string chain)
        {
            var occurrances = chain.ToCharArray().ToList().GroupBy(x => x)
            .ToDictionary(y => y.Key, y => y.Count())
            .OrderByDescending(z => z.Value);
            return occurrances.ElementAt(0).Value;
        }

        public int CalculateLeastCommonElementCount(string chain)
        {
            var occurrances = chain.ToCharArray().ToList().GroupBy(x => x)
            .ToDictionary(y => y.Key, y => y.Count())
            .OrderBy(z => z.Value);
            return occurrances.ElementAt(0).Value;
        }

        public int ProcessPolymerisation()
        {
            string polymerChain = ProcessChainSequence();
            return CalculateMostCommonElementCount(polymerChain) - CalculateLeastCommonElementCount(polymerChain);
        }
    }
}

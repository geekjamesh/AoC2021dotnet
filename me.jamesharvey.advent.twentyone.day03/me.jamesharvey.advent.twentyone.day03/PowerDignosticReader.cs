using System;
using System.Collections.Generic;
using System.Text;

namespace me.jamesharvey.advent.twentyone.day03
{
    public class PowerDignosticReader
    {
        private List<string> _diagnosticInput;

        public StringBuilder BinaryGammaRate { get; set; } = new StringBuilder();

        public StringBuilder BinaryEpsilonRate { get; set; } = new StringBuilder();

        public PowerDignosticReader(List<string> input)
        {
            _diagnosticInput = input;
        }

        public void CalculateGammaEpsilonRates()
        {
            List<char[]> diagnosticValues = new List<char[]>();
            foreach (string diagnosticLine in _diagnosticInput)
            {
                diagnosticValues.Add(diagnosticLine.ToCharArray());
            }
            for (int i = 0; i < diagnosticValues[0].Length; i++)
            {
                string mostCommon = FindMostCommonBit(diagnosticValues, i);
                if (mostCommon.Equals("1"))
                {
                    BinaryGammaRate.Append("1");
                    BinaryEpsilonRate.Append("0");
                }
                else
                {
                    BinaryGammaRate.Append("0");
                    BinaryEpsilonRate.Append("1");
                }
            }

        }

        private string FindMostCommonBit(List<char[]> diagnosticValues, int charIndex)
        {
            if (diagnosticValues != null && diagnosticValues.Count > 0)
            {
                int countOfOne = 0;
                int countOfZero = 0;
                foreach (char[] line in diagnosticValues)
                {
                    switch (line[charIndex])
                    {
                        case '1':
                            countOfOne++;
                            break;
                        case '0':
                            countOfZero++;
                            break;
                    }
                }
                if (countOfOne > countOfZero)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("diagnosticValues");
            }
        }

        public int PowerConsumption
        {
            get
            {
                CalculateGammaEpsilonRates();
                int gammaRate = Convert.ToInt32(BinaryGammaRate.ToString(), 2);
                int epsilonRate = Convert.ToInt32(BinaryEpsilonRate.ToString(), 2);
                return gammaRate * epsilonRate;
            }
        }

        public int OxygenGenRating
        {
            get
            {
                return 0;
            }
        }
    }
}

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

            for (int i = 0; i < _diagnosticInput[0].Length; i++)
            {
                string mostCommon = FindMostCommonBit(_diagnosticInput, i);
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

        public string FindMostCommonBit(List<string> diagnosticValues, int charIndex)
        {
            if (diagnosticValues != null && diagnosticValues.Count > 0)
            {
                int countOfOne = 0;
                int countOfZero = 0;
                foreach (string line in diagnosticValues)
                {
                    switch (line.Substring(charIndex,1))
                    {
                        case "1":
                            countOfOne++;
                            break;
                        case "0":
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
                List<string> filteredValues = _diagnosticInput;
                int charindex = 0;
                do
                {
                    filteredValues = FilterValues(filteredValues, true, charindex);
                    charindex++;
                } while (filteredValues.Count > 1);
                string binaryValue = filteredValues[0];
                return Convert.ToInt32(binaryValue, 2);
            }
        }

        public int CO2ScrubberRating
        {
            get
            {
                List<string> filteredValues = _diagnosticInput;
                int charindex = 0;
                do
                {
                    filteredValues = FilterValues(filteredValues, false, charindex);
                    charindex++;
                } while (filteredValues.Count > 1);
                string binaryValue = filteredValues[0];
                return Convert.ToInt32(binaryValue, 2);
            }
        }

        public List<string> FilterValues(List<string> valueList, bool mostCommon, int charIndex)
        {
            List<string> valuesChar1 = new List<string>();
            List<string> valuesChar0 = new List<string>();
            if (valueList != null && valueList.Count > 0)
            {
                int countOfOne = 0;
                int countOfZero = 0;
                foreach (string line in valueList)
                {
                    switch (line.Substring(charIndex, 1))
                    {
                        case "1":
                            countOfOne++;
                            valuesChar1.Add(line);
                            break;
                        case "0":
                            countOfZero++;
                            valuesChar0.Add(line);
                            break;
                    }
                }
                
                if (mostCommon)
                {
                    if (valuesChar1.Count >= valuesChar0.Count)
                    {
                        return valuesChar1;
                    }
                    else
                    {
                        return valuesChar0;
                    }
                }
                else
                {
                    if (valuesChar1.Count < valuesChar0.Count)
                    {
                        return valuesChar1;
                    }
                    else
                    {
                        return valuesChar0;
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("diagnosticValues");
            }
        }

        public int LifeSupportRating
        {
            get
            {
                return OxygenGenRating * CO2ScrubberRating;
            }
        }
    }
}

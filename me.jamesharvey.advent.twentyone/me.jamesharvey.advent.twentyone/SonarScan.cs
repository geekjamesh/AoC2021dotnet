using System.Collections.Generic;

namespace me.jamesharvey.advent.twentyone
{
    public class SonarScan
    {
        private List<int> ScanReadings;

        public SonarScan(List<int> scanReadings)
        {
            ScanReadings = scanReadings;
        }

        public int CalculateDepthIncreases()
        {
            int count = 0;
            for (int i = 1; i < ScanReadings.Count; i++)
            {
                if (ScanReadings[i] > ScanReadings[i - 1])
                {
                    count++;
                }
            }

            return count;
        }

        public int CalculateSlidingDepthIncreases()
        {
            int count = 0;
            int current;
            int? previous = null;
            for (int i = 0; i < ScanReadings.Count - 2; i++)
            {
                current = ScanReadings[i] + ScanReadings[i + 1] + ScanReadings[i + 2];
                if (previous != null && current > previous)
                {
                    count++;
                }
                previous = current;
            }

            return count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace me.jamesharvey.advent.twentyone.day01
{
    public class SonarScan
    {
        private List<string> ScanReadings;

        public SonarScan(List<string> scanReadings) {
            ScanReadings = scanReadings;
        }

        public int CalculateDepthIncreases() {
            int count = 0;
            for(int i=1; i < ScanReadings.Count; i++) {
                if (int.Parse(ScanReadings[i]) > int.Parse(ScanReadings[i-1])) {
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
            for (int i = 0; i < ScanReadings.Count-2; i++)
            {
                current = int.Parse(ScanReadings[i]) + int.Parse(ScanReadings[i + 1]) + int.Parse(ScanReadings[i + 2]);
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
using System;
using System.Collections.Generic;

namespace me.jamesharvey.advent.twentyone
{
    public class SmokeRiskService
    {
        private int[,] _heightMapGrid;
        private int _lastCol;
        private int _lastRow;

        public SmokeRiskService(List<string> heightMapInput)
        {
            _heightMapGrid = new int[heightMapInput.Count, heightMapInput[0].Length];
            for (int row=0; row < heightMapInput.Count; row++)
            {
                for (int col = 0; col < heightMapInput[row].Length; col++)
                {
                    _heightMapGrid[row, col] = int.Parse(heightMapInput[row].Substring(col, 1));
                }
            }
            _lastCol = heightMapInput[0].Length - 1;
            _lastRow = heightMapInput.Count - 1;
        }

        public int CalculateSmokeRisk()
        {
            int riskSum = 0;

            for (int row = 0; row <= _lastRow; row++)
            {
                for (int col = 0; col <= _lastCol; col++)
                {
                    int above = 9;
                    int below = 9;
                    int left = 9;
                    int right = 9;
                    if (row > 0)
                    {
                        above = _heightMapGrid[row - 1, col];
                    }
                    if (row < _lastRow)
                    {
                        below = _heightMapGrid[row + 1, col];
                    }
                    if (col > 0)
                    {
                        left = _heightMapGrid[row, col - 1];
                    }
                    if (col < _lastCol)
                    {
                        right = _heightMapGrid[row, col + 1];
                    }
                    int currentSquare = _heightMapGrid[row, col];
                    if (currentSquare < above && currentSquare < below && currentSquare < left && currentSquare < right)
                    {
                        riskSum += currentSquare + 1;
                    }
                }
            }

            return riskSum;
        }
    }
}

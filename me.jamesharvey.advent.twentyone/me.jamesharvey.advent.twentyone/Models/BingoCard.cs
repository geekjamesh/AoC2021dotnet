using System;
using System.Collections.Generic;

namespace me.jamesharvey.advent.twentyone.Models
{
    public class BingoCard
    {
        public BingoNumber[,] CardGrid { get; set; }

        public BingoCard()
        {
            CardGrid = new BingoNumber[5, 5];
        }

        public void LoadCard(List<string> cardInput)
        {
            if (CardGrid == null)
            {
                throw new ArgumentNullException("cardInput");
            }
            if (cardInput.Count == 0 || cardInput.Count > 5)
            {
                throw new ArgumentOutOfRangeException("cardInput", $"cardInput contains {cardInput.Count} lines");
            }
            int cardLineIndex = 0;
            foreach(string cardLine in cardInput)
            {
                if (cardLine.Length != 14)
                {
                    throw new ArgumentOutOfRangeException("cardInput", $"cardInput line contains line of {cardLine.Length} length - {cardLine}");
                }
                int cardColIndex = 0;
                for (int i = 0; i < cardLine.Length; i += 3){
                    CardGrid[cardLineIndex, cardColIndex] = new BingoNumber(int.Parse(cardLine.Substring(i, 2).Trim()));
                    cardColIndex++;
                }
                cardLineIndex++;
            }
        }

        public void MarkCard(int calledNumber)
        {
            for (int rowIdx = 0; rowIdx < 5; rowIdx++)
            {
                for (int colIdx = 0; colIdx < 5; colIdx++)
                {
                    if (calledNumber == CardGrid[rowIdx, colIdx].Number)
                    {
                        CardGrid[rowIdx, colIdx].Marked = true;
                        continue;
                    }
                }
            }
        }

        public bool WinningCard
        {
            get
            {
                int rowIdx = 0;
                int colIdx;
                do
                {
                    bool possibleWin = true;
                    colIdx = 0;
                    do
                    {
                        if (CardGrid[rowIdx, colIdx].Marked == false)
                        {
                            possibleWin = false;
                        }
                        else
                        {
                            if (colIdx == 4)
                            {
                                return true;
                            }
                        }
                        colIdx++;
                    } while (possibleWin == true && colIdx < 5 );
                    rowIdx++;
                } while (rowIdx < 5);

                colIdx = 0;
                do
                {
                    bool possibleWin = true;
                    rowIdx = 0;
                    do
                    {
                        if (CardGrid[rowIdx, colIdx].Marked == false)
                        {
                            possibleWin = false;
                        }
                        else
                        {
                            if (rowIdx == 4)
                            {
                                return true;
                            }
                        }
                        rowIdx++;
                    } while (possibleWin == true && rowIdx < 5);
                    colIdx++;
                } while (colIdx < 5);

                return false;
            }
            
        }

        public int CalculateCardScore(int calledNumber)
        {
            int unmarkedNumberTotal = 0;
            for (int rowIdx = 0; rowIdx < 5; rowIdx++)
            {
                for (int colIdx = 0; colIdx < 5; colIdx++)
                {
                    if (!CardGrid[rowIdx, colIdx].Marked)
                    {
                        unmarkedNumberTotal+= CardGrid[rowIdx, colIdx].Number;
                    }
                }
            }
            return calledNumber * unmarkedNumberTotal;
        }
    }
}

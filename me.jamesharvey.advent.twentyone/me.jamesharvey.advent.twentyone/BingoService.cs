﻿using System.Collections.Generic;
using me.jamesharvey.advent.twentyone.Models;
using me.jamesharvey.advent.twentyone.Utilities;

namespace me.jamesharvey.advent.twentyone
{
    public class BingoService
    {
        public List<BingoCard> BingoCards { get; set; }

        public List<int> CalledNumbers { get; set; }

        public BingoService()
        {
            BingoCards = new List<BingoCard>();
            CalledNumbers = new List<int>();
        }

        public BingoService(string inputFile)
        {
            BingoCards = new List<BingoCard>();
            CalledNumbers = new List<int>();
            CreateCards(FileReader.ReadStringInputFromFile(inputFile));   
        }

        public void CreateCards(List<string> fileInput)
        {
            string[] numbers = fileInput[0].Split(',');
            foreach (string number in numbers)
            {
                CalledNumbers.Add(int.Parse(number));
            }
            for (int i = 2; i < fileInput.Count; i += 6)
            {
                BingoCard card = new BingoCard();
                List<string> cardInput = new List<string>
                {
                    fileInput[i],
                    fileInput[i+1],
                    fileInput[i+2],
                    fileInput[i+3],
                    fileInput[i+4]
                };
                card.LoadCard(cardInput);
                BingoCards.Add(card);
            }
        }

        public int RunBingoGame()
        {
            foreach (int numberCalled in CalledNumbers)
            {
                for (int i = 0; i < BingoCards.Count; i++)
                {
                    BingoCards[i].MarkCard(numberCalled);
                    if (BingoCards[i].WinningCard)
                    {
                        return BingoCards[i].CalculateCardScore(numberCalled);
                    }
                }
            }

            return 0;
        }
    }
}

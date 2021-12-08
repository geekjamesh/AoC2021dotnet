using System;
using System.Collections.Generic;
using me.jamesharvey.advent.twentyone.Models;
using Xunit;

namespace me.jamesharvey.advent.twentyone.Test.Models
{
    public class BingoCardTest
    {
        [Fact]
        public void LoadCard_CreatesGrid_GivenValidInput()
        {
            List<string> testData = new List<string>
            {
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            Assert.Equal(22, bingoCard.CardGrid[0, 0].Number);
            Assert.Equal(13, bingoCard.CardGrid[0, 1].Number);
            Assert.Equal(17, bingoCard.CardGrid[0, 2].Number);
            Assert.Equal(11, bingoCard.CardGrid[0, 3].Number);
            Assert.Equal(0, bingoCard.CardGrid[0, 4].Number);
            Assert.Equal(8, bingoCard.CardGrid[1, 0].Number);
            Assert.Equal(2, bingoCard.CardGrid[1, 1].Number);
            Assert.Equal(23, bingoCard.CardGrid[1, 2].Number);
            Assert.Equal(4, bingoCard.CardGrid[1, 3].Number);
            Assert.Equal(24, bingoCard.CardGrid[1, 4].Number);
            Assert.Equal(21, bingoCard.CardGrid[2, 0].Number);
            Assert.Equal(9, bingoCard.CardGrid[2, 1].Number);
            Assert.Equal(14, bingoCard.CardGrid[2, 2].Number);
            Assert.Equal(16, bingoCard.CardGrid[2, 3].Number);
            Assert.Equal(7, bingoCard.CardGrid[2, 4].Number);
            Assert.Equal(6, bingoCard.CardGrid[3, 0].Number);
            Assert.Equal(10, bingoCard.CardGrid[3, 1].Number);
            Assert.Equal(3, bingoCard.CardGrid[3, 2].Number);
            Assert.Equal(18, bingoCard.CardGrid[3, 3].Number);
            Assert.Equal(5, bingoCard.CardGrid[3, 4].Number);
            Assert.Equal(1, bingoCard.CardGrid[4, 0].Number);
            Assert.Equal(12, bingoCard.CardGrid[4, 1].Number);
            Assert.Equal(20, bingoCard.CardGrid[4, 2].Number);
            Assert.Equal(15, bingoCard.CardGrid[4, 3].Number);
            Assert.Equal(19, bingoCard.CardGrid[4, 4].Number);
            Assert.False(bingoCard.CardGrid[0, 0].Marked);
        }

        [Fact]
        public void MarkCard_FlagsNumberAsMarked_GivenMatchingSingleNumber_FirstNumber()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            Assert.Equal(14, bingoCard.CardGrid[0, 0].Number);
            Assert.False(bingoCard.CardGrid[0, 0].Marked);
            bingoCard.MarkCard(14);
            Assert.True(bingoCard.CardGrid[0, 0].Marked);
        }

        [Fact]
        public void MarkCard_FlagsNumberAsMarked_GivenMatchingSingleNumber_SecondNumber()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            Assert.Equal(16, bingoCard.CardGrid[1, 1].Number);
            Assert.False(bingoCard.CardGrid[1, 1].Marked);
            bingoCard.MarkCard(16);
            Assert.True(bingoCard.CardGrid[1, 1].Marked);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When1stRowMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(14);
            bingoCard.MarkCard(21);
            bingoCard.MarkCard(17);
            bingoCard.MarkCard(24);
            bingoCard.MarkCard(4);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When2ndRowMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(10);
            bingoCard.MarkCard(16);
            bingoCard.MarkCard(15);
            bingoCard.MarkCard(9);
            bingoCard.MarkCard(19);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When5thRowMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(2);
            bingoCard.MarkCard(0);
            bingoCard.MarkCard(12);
            bingoCard.MarkCard(3);
            bingoCard.MarkCard(7);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When1stColMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(14);
            bingoCard.MarkCard(10);
            bingoCard.MarkCard(18);
            bingoCard.MarkCard(22);
            bingoCard.MarkCard(2);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When2ndColMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(21);
            bingoCard.MarkCard(16);
            bingoCard.MarkCard(8);
            bingoCard.MarkCard(11);
            bingoCard.MarkCard(0);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsTrue_When5thColMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(4);
            bingoCard.MarkCard(19);
            bingoCard.MarkCard(20);
            bingoCard.MarkCard(5);
            bingoCard.MarkCard(7);
            Assert.True(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsFalse_WhenDiagMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(14);
            bingoCard.MarkCard(16);
            bingoCard.MarkCard(23);
            bingoCard.MarkCard(6);
            bingoCard.MarkCard(7);
            Assert.False(bingoCard.WinningCard);
        }

        [Fact]
        public void WinningCard_ReturnsFalse_WhenOppositeDiagMatches()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(2);
            bingoCard.MarkCard(11);
            bingoCard.MarkCard(23);
            bingoCard.MarkCard(9);
            bingoCard.MarkCard(4);
            Assert.False(bingoCard.WinningCard);
        }

        [Fact]
        public void CalculateCardScore_ReturnsCorrectScore_SampleNumbersCalled()
        {
            List<string> testData = new List<string>
            {
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                " 2  0 12  3  7",
            };
            BingoCard bingoCard = new BingoCard();
            bingoCard.LoadCard(testData);
            bingoCard.MarkCard(14);
            bingoCard.MarkCard(21);
            bingoCard.MarkCard(17);
            bingoCard.MarkCard(4);
            bingoCard.MarkCard(9);
            bingoCard.MarkCard(23);
            bingoCard.MarkCard(11);
            bingoCard.MarkCard(5);
            bingoCard.MarkCard(2);
            bingoCard.MarkCard(0);
            bingoCard.MarkCard(7);
            bingoCard.MarkCard(24);
            Assert.True(bingoCard.WinningCard);
            Assert.Equal(4512, bingoCard.CalculateCardScore(24));
        }
    }
}

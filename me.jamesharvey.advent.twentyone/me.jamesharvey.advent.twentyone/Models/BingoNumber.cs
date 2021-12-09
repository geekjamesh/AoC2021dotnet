namespace me.jamesharvey.advent.twentyone.Models
{
    public class BingoNumber
    {
        public int Number { get; set; }

        public bool Marked { get; set; }

        public BingoNumber(int number)
        {
            Number = number;
            Marked = false;
        }
    }
}

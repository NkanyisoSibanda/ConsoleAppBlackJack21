using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppBlackJack21
{
    public enum CardSuits
    {
        SPADES,
        HEARTS,
        DIAMONDS,
        CLUBS
    }
    public enum CardRanks
    {
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    }
    public class Card
    {
        public CardSuits CardSuit {get; set; }
        public CardRanks CardRank { get; set; }
        public int[] ArrCardValue { get; private set; } = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        public Card()
        {          
        }

        public override string ToString()
        {
            return CardRank + " of " + CardSuit;
        }
    }
}

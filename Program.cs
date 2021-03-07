using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppBlackJack21
{
    class Program
    {
        /// <summary>
        /// Determine the player's results against the dealer and display results
        /// </summary>
        /// <param name="PlayerHand"></param>
        /// <param name="DealerHand"></param>
        /// <returns></returns>
        public static string DisplayResult(CardHand PlayerHand, CardHand DealerHand)
        {
            if (PlayerHand.CountNumberOfCardInhand() == Constants.NumberOfCardsAutomaticWin)
            {
                //Automatic win
                if (PlayerHand.DetermineHandValue() <= Constants.TargetHandValue)
                {
                    return "Beats dealer automatically";
                }
            }

            if (PlayerHand.DetermineHandValue() >= DealerHand.DetermineHandValue())
            {
                if (PlayerHand.DetermineHandValue() <= Constants.TargetHandValue)
                {
                    return "Beats dealer";
                }
                else
                {
                    return "Loses";
                }
            }

            if (PlayerHand.DetermineHandValue() < DealerHand.DetermineHandValue())
            {
                if (PlayerHand.DetermineHandValue() <= Constants.TargetHandValue)
                {
                    if (DealerHand.DetermineHandValue() <= Constants.TargetHandValue)
                    {
                        return "Loses";
                    }
                    else
                    {
                        return "Beats dealer";
                    }
                }
                else //Player Hand Value more than TargetHandValue
                {
                    return "Loses";
                }
            }
            return "Unknown";
        }      
                 

        public static List<Card> GenerateAHand()
        {
            //Auto generate number of Cards in Dealer's hand
            var Generator = new RandomNumberGenerator();

            List<Card> ListOfCards = new List<Card>();
            //Random number of cards
            int NumberOfCards = Generator.RandomNumber(1, 6);
            for (int i = 0; i < NumberOfCards; i++)
            {
                //Random card faces
                int Rank = Generator.RandomNumber(0, 13);
                Card c = new Card
                {
                    //Random suit
                    CardSuit = (CardSuits)Generator.RandomNumber(0, 4),
                    CardRank = (CardRanks)Rank
                };
                ListOfCards.Add(c);
            }
            return ListOfCards;
        }


        static void Main()
        {
            CardHand DealerHand = new CardHand("Dealer", GenerateAHand());
            Console.WriteLine(DealerHand.Name);
            foreach (Card card in DealerHand.CardList)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine(DealerHand.DetermineHandValue());
            Console.WriteLine("*************************************************************************");

            CardHand PlayerHand = new CardHand("Player", GenerateAHand());
            Console.WriteLine(PlayerHand.Name);
            foreach (Card card in PlayerHand.CardList)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine(PlayerHand.DetermineHandValue());
            Console.WriteLine(DisplayResult(PlayerHand, DealerHand));      
        }
    }
}

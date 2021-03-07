using System;
using System.Collections;
using System.Collections.Generic;


namespace ConsoleAppBlackJack21
{

    public class CardHand
    {
        public string Name { get; set; }
        //List of cards in the hand
        public List<Card> CardList { get; set; }

        public CardHand(string name, List<Card> cardlist)
        {
            Name = name;
            CardList = new List<Card>(cardlist);
           // CardList = cardlist;
        }
                   

        /// <summary>
        /// Return the number of cards in the hand
        /// </summary>
        /// <returns></returns>
        public int CountNumberOfCardInhand()
        {
            return CardList.Count;
        }

        /// <summary>
        /// Determine and return the hand value
        /// </summary>
        /// <returns></returns>
        public int DetermineHandValue()
        {
            int HandValue = 0;
            foreach (Card c in CardList)
            {
                HandValue += (int)c.ArrCardValue[(int)c.CardRank];
                //HandValue += (int) c.CardRank;
            }

            //Check for Aces
            int NumberOfAces = CheckNumberOfAces();
            
            //Adjust the hand value in case we have ACE(S) and hand value greter than 21 
            while (NumberOfAces > 0  && HandValue > Constants.TargetHandValue)
            {
                if (HandValue > Constants.TargetHandValue)
                {
                    //Swap the value of ACE
                    HandValue -= 10;                     
                    NumberOfAces -= 1;
                }
                else
                {
                    break;
                }
            }
            return HandValue; 
        }

        /// <summary>
        /// Count and return the number of ACEs
        /// </summary>
        /// <returns></returns>
        public int CheckNumberOfAces()
        {
            int NumberOfAce = 0;
            foreach (Card c in CardList)
            {
               if( c.CardRank == CardRanks.ACE) //
                {
                    NumberOfAce += 1;
                }
            }            
            return NumberOfAce;
        }                 
    }
}

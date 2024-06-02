using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontebankGame
{
    public class CardController
    {
        public int balance = 10000;
        
        public void GetCard(List<Card> cardDeck, List<Layout> cardLayout) 
        {
            Random rnd = new Random();

            for (int i = 0; i < 2; i++)
            {
                int randomNum = rnd.Next(cardDeck.Count);

                Card card1 = cardDeck[randomNum];
                cardDeck.RemoveAt(randomNum);

                randomNum = rnd.Next(cardDeck.Count);

                Card card2 = cardDeck[randomNum];
                cardDeck.RemoveAt(randomNum);

                cardLayout[i].tuplecard = new Tuple<Card, Card>(card1, card2);
            }      
        }

        public Card GetLastCard(List<Card> cardDeck, List<Layout> cardLayout)
        {
            Random rnd = new Random();

            int cardNum = rnd.Next(cardDeck.Count);

            Card cardLast = cardDeck[cardNum];
            cardDeck.RemoveAt(cardNum);

            for (int i = 0; i < 2; i++) 
            {
                if(cardLayout[i].sumBet != 0)
                {
                    cardLayout[i].chekCard(cardLast);
                }
            }

            return cardLast;
        }
    }
}

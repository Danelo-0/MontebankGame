using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontebankGame
{
    public class Layout
    {
        public Tuple<Card, Card> tuplecard;

        public int sumBet;

        public bool statusChekCard = false;

        public void chekCard(Card cardLast)
        {
            if ((cardLast.color == tuplecard.Item1.color) || (cardLast.color == tuplecard.Item2.color))
            {
                this.statusChekCard = true;
            }
        }

    }
}

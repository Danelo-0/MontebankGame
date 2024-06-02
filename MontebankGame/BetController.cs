using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontebankGame
{
    public class BetController
    {
        public void SetBet(Bet bet, Layout cardLayout, CardController cardController) 
        {
            if (bet.ratingBet <= cardController.balance)
            {
                cardLayout.sumBet += bet.RatingBet;
                cardController.balance -= bet.RatingBet;
            }
        }

    }
}

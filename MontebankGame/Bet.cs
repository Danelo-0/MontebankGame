using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontebankGame
{
    public class Bet
    {
        public int ratingBet = 10;

        public int RatingBet
        {
            get 
            { 
                return ratingBet; 
            }
            set 
            { 
                ratingBet = value;
            }
        }
    }
}

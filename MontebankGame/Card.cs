using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontebankGame
{
    public class Card
    {
        public int rating;

        public string color;
        public Card(int rating, string color) 
        { 
            this.rating = rating;
            this.color = color;
        }
    }
}

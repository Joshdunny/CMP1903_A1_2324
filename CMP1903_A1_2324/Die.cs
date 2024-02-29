using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        //Property(s)
        //DieValue property holding the value of the die
        private int DieValue
        {
            //encapsulated using get an set methods 
            get{ return DieValue; }
            set{ DieValue = value; }
        }
        //Method(s)            
        //RollDie methods "rolls" the die generating a random value between 1,6
        public int RollDie()
        {
            //generates random int between 1,6
            Random r = new Random();
            DieValue = r.Next(1, 7);
            //returns integer DieValue
            return DieValue;
        }
    }
}

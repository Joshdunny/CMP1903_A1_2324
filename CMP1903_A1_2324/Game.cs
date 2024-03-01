using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        //Methods
        public Game()
        {
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            int sum = -1;


            bool roll = true;

            while(roll) 
            {
                die1.RollDie();
                die2.RollDie();
                die3.RollDie();

                sum = die1.DieValue + die2.DieValue + die1.DieValue;
                Console.WriteLine("The sum of the rolled dice >>> {0}", sum);
                
                string Rollquery = "";
                while (Rollquery != "Y" || Rollquery != "N")
                {
                    Console.WriteLine("Would you like to roll again, [Y] or [N]");
                    Rollquery = Console.ReadLine();
                }

                if (Console.ReadLine() == "N")
                {
                    roll = false;
                }
            }
        }
    }
}

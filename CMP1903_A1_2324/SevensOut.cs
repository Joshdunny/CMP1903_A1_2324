using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut : Game
    {
        /// <summary>
        /// Sevens Out
        /// 2 x dice
        /// Rules:
        /// Roll the two dice, noting the total rolled each time.
        /// If it is a 7 - stop.
        /// If it is any other number - add it to your total.
        /// If it is a double - add double the total to your score (3,3 would add 12 to your total)
        /// </summary>
        private List<Die> gameDice = new List<Die>()
        {
            new Die()
            ,new Die()
        };
        protected override void MainMenu()
        {
            //Method for displaying a menu to the user for the game Sevens Out 
            Console.WriteLine("\n" +
                "  Welcome to Sevens Out, Rules:                     \n" +
                ">--------------------------------------------------<\n" +
                "  Roll 2 dice, counting the total                   \n" +
                "  If the total is 7, Game Over!                     \n" +
                "  Any other number, it's added to your total        \n" +
                "  If a double is rolled, double the total is added  \n" +
                ">--------------------------------------------------<\n");
        }
        protected void MainMenu(bool testing)
        {
            //Method for displaying a testing menu to the user for the game Sevens Out 
            Console.WriteLine("\n" +
                "  Welcome to Sevens Out Testing:                  \n" +
                ">------------------------------------------------<\n" +
                "  The game will Roll both dice                    \n" +
                "  This will continue until the sum is equal to 7  \n" +
                "  When this happens the game SHOULD end           \n" +
                "  and dice total returned should be 7             \n" +
                ">------------------------------------------------<\n");
        }
        public override int PlayGame(bool testing)
        {
            //Main method for Playing SevensOut
            //Overriding the Game class version having its own iteration of the method
            if (testing)
            {
                MainMenu(testing);
                Console.WriteLine("Press any key and or enter to begin testing...");
                Console.ReadLine();
            }
            else
            {
                MainMenu();
            }

            //Loop until a total of dice is 7 declaring GameOver to be true
            //Roll() both dice in list
            //add them together and check for a 7 and end game
            //No 7, check for a double and add double total of dice to total
            //No double, add total of dice to total

            int overallTotal = 0;
            int diceTotal = 0;
            while (diceTotal != 7)
            {                               
                if( testing )
                {                    
                    while (diceTotal != 7)
                    {                        
                        gameDice[0].Roll();
                        gameDice[1].Roll();
                        diceTotal = gameDice[0].DieValue + gameDice[1].DieValue;
                    }
                }
                else
                {
                    Console.WriteLine("\nPress any key and or enter to roll both dice...");
                    Console.ReadLine();
                    gameDice[0].Roll();
                    gameDice[1].Roll();
                    diceTotal = gameDice[0].DieValue + gameDice[1].DieValue;
                }
                            
                if (diceTotal == 7)
                {
                    Console.WriteLine(" Game Over: You have rolled a 7!\n" +
                        " >>> Your overall total was: {0}", overallTotal);
                }
                else
                {
                    if (gameDice[0].DieValue == gameDice[1].DieValue)
                    {
                        diceTotal *= 2;
                        overallTotal += diceTotal;
                    }
                    else
                    {
                        diceTotal = gameDice[0].DieValue + gameDice[1].DieValue;
                        overallTotal += diceTotal;
                    }
                    Console.WriteLine(" You have rolled a {0} + {1} = {2} points\n" +
                        " >>> Your overall total is: {3}", gameDice[0].DieValue, gameDice[1].DieValue, diceTotal, overallTotal);
                }
            }
            if (testing)
            {
                return diceTotal;
            }
            else
            {
                return overallTotal;
            }
        }
    }
}

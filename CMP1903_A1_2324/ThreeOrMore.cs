using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore : Game
    {
        /// <summary>
        /// Three or More
        /// 5 x dice
        /// Rules:
        /// Roll all 5 dice hoping for a 3-of-a-kind or better.
        /// If(2/3/4)-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
        /// There may only be two dice rolls in total.
        /// 3-of-a-kind: 3 points
        /// 4-of-a-kind: 6 points
        /// 5-of-a-kind: 12 points
        /// First to a total of 20.
        /// </summary>
        private List<Die> gameDice = new List<Die>()
        {
            new Die()
            ,new Die()
            ,new Die()
            ,new Die()
            ,new Die()

        };
        protected override void MainMenu()
        {
            //Method for displaying a menu to the user to the game Three Or More 
            Console.WriteLine("\n" +
                "  Welcome to ThreeOrMore, Rules:                  \n" +
                ">------------------------------------------------<\n" +
                "  Roll 5 dice, Looking for 3-of-a-kind or better  \n" +
                "  If (2/3/4)-of-a-kind is rolled, then 2 options  \n" +
                "  Rethrow all dice or the remaining dice          \n" +
                "  3-of-a-kind: 3 points                           \n" +
                "  4-of-a-kind: 6 points                           \n" +
                "  5-of-a-kind: 12 points                          \n" +
                "  First to a total of 20                          \n" +
                ">------------------------------------------------<\n");
        }
        protected void MainMenu(bool testing)
        {
            //Method for displaying a testing menu to the user for the game Sevens Out 
            Console.WriteLine("\n" +
                "  Welcome to ThreeOrMore Testing:                   \n" +
                ">--------------------------------------------------<\n" +
                "  The game will set play automatically              \n" +
                "  And always rerolling remaining dice               \n" +
                "  If correctly implemented three or more            \n" +
                "  the game SHOULD end and return total >= 20        \n" +
                "  Once the game has reached a total >= 20           \n" +
                ">--------------------------------------------------<\n");
        }
        public override int PlayGame(bool testing)
        {
            //Main method for Playing ThreeOrMore
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
            //Loop until player has 20 points
            //Roll all 5 dice in a list<Dice>
            //check dice for x | x >= 2 -of-a-kind 
            //If so present options of Rethrow of hand or remaining dice
            //If Rethrow Leave List of Dice as is
            //If remaining dice Roll Dice not part of x-of-a-kind
            //After check what x-of-a-kind and add points accordingly

            int total = 0;
            int totalRolls = 0;
            while (total < 20)
            {
                if (testing)
                {
                    Console.WriteLine("Auto playing rolls for testing...");
                }
                else
                {
                    Console.WriteLine("Press any key and or enter to roll the dice...");
                    Console.ReadLine();
                }
                RollAllDice(ref totalRolls);

                int mostCommonValue = mostCommonValueQuery();
                int xOfAKind = xOfAKindQuery();

                Console.WriteLine(" > {0} - Of - A - Kind", xOfAKind);
                Console.WriteLine(" > With Value: {0}", mostCommonValue);

                Thread.Sleep(1000);
                int rerollChoice = -1;
                if (xOfAKind > 1 && !testing)
                {
                    Console.WriteLine("You have rolled {0} - Of - A - Kind\n" +
                        " Would you like to:\n" +
                        " 1. Reroll all dice\n" +
                        " 2. Reroll remaining dice", xOfAKind);
                    while (rerollChoice < 1 || rerollChoice > 2)
                    {
                        try
                        {
                            rerollChoice = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Enter a valid type");
                        }
                    }
                }
                if (rerollChoice == 1)
                {
                    Console.WriteLine("Rerolling all Dice...\n");
                    RollAllDice(ref totalRolls);

                    mostCommonValue = mostCommonValueQuery();
                    xOfAKind = xOfAKindQuery();
                    Console.WriteLine(" > {0} - Of - A - Kind", xOfAKind);
                    Console.WriteLine(" > With Value: {0}", mostCommonValue); ;
                }
                else if (rerollChoice == 2)
                {
                    RollAllDice(mostCommonValue, ref totalRolls);

                    mostCommonValue = mostCommonValueQuery();
                    xOfAKind = xOfAKindQuery();
                    Console.WriteLine(" > {0} - Of - A - Kind", xOfAKind);
                    Console.WriteLine(" > With Value: {0}", mostCommonValue);
                }
                else if (rerollChoice == -1)
                {
                    RollAllDice(mostCommonValue, ref totalRolls);

                    mostCommonValue = mostCommonValueQuery();
                    xOfAKind = xOfAKindQuery();
                }
                switch (xOfAKind)
                {
                    case 3:
                        {
                            total += 3;
                            break;
                        }
                    case 4:
                        {
                            total += 6;
                            break;
                        }
                    case 5:
                        {
                            total += 12;
                            break;
                        }
                }
                    Console.WriteLine("\n --> Your current total : {0}", total);
                    Console.WriteLine(" --> Current total rolls: {0}\n", totalRolls);                
            }            
            if (testing)
            {
                return total;
            }
            else
            {
                Console.WriteLine("Game Over! - Congrats you have reached the target\n");
                return totalRolls;
            }
        }
        protected int mostCommonValueQuery()
        {
            int mostCommonValue = (from Die in gameDice
                                   group Die.DieValue by Die.DieValue into dieValues
                                   orderby dieValues.Count() descending
                                   select dieValues.Key).First();            
            return mostCommonValue; 
        }
        protected int xOfAKindQuery()
        {
            int xOfAKind = (from Die in gameDice
                                 group Die.DieValue by Die.DieValue into dieValues
                                 orderby dieValues.Count() descending
                                 select dieValues.Count()).First();
            return xOfAKind;
        }
        protected void OutputRolls()
        {
            for (int i = 0; i < gameDice.Count(); i++)
            {
                Console.WriteLine("Rolled : {0}", gameDice[i].DieValue);
                Thread.Sleep(200);
            }
        }
        protected void RollAllDice(ref int totalRolls)
        {
            for (int i = 0; i < gameDice.Count(); i++)
            {
                gameDice[i].Roll();
                totalRolls += 1;
            }
            OutputRolls();
        }
        protected void RollAllDice(int diceNotToRoll, ref int totalRolls)
        {
            for (int i = 0; i < gameDice.Count(); i++)
            {
                if (gameDice[i].DieValue != diceNotToRoll)
                {
                    gameDice[i].Roll();
                    totalRolls += 1;
                }                
            }
            OutputRolls();
        }
    }
}

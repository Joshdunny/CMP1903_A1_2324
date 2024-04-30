using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game : IPlayable
    {
        /// <summary>
        /// The Game class has a menu which allows user to:
        /// Instantiate the Sevens Out game
        /// Instantiate the Three Or More game
        /// View Statistics data
        /// And Perform tests in testing class
        /// </summary>        
        protected virtual void MainMenu()
        {
            //Method for displaying a menu to the user to their choices
            Console.WriteLine("\n" +
                "  Main Menu - Select an option below  \n" +
                ">------------------------------------<\n" +
                "  1  >>>  Play Sevens Out             \n" +
                "  2  >>>  Play Three or More          \n" +
                "  3  >>>  View current game statistics\n" +
                "  4  >>>  Perform tests for games     \n" +
                ">------------------------------------<\n");
        }
        public virtual int PlayGame(bool testing)
        {
            //Main method for playing the selected games
            //Each method having their own version of this method in order to implement the unique rules
            SevensOut sevensOutGame = new SevensOut();
            ThreeOrMore threeOrMoreGame = new ThreeOrMore(); 
            Statistics GameStats = new Statistics();
            Testing GameTesting = new Testing();
            bool keepPlaying = true;
            int choice;
            while (keepPlaying)
            {
                choice = -1;
                MainMenu();
                while (choice < 1 || choice > 5)
                {
                    try
                    {
                        Console.WriteLine("Enter your choice here:");
                        choice = int.Parse(Console.ReadLine());
                        if (choice < 1 || choice > 5)
                        {
                            Console.WriteLine("Enter a choice that is displayed");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid type");
                    }
                }
                
                switch (choice)
                {
                    case 1:
                        {
                            int sevensOutUpdateValue = sevensOutGame.PlayGame(false);
                            GameStats.UpdateSevensOutStatistics(sevensOutUpdateValue);
                            break;
                        }
                    case 2:
                        {
                            int threeOrMoreUpdateValue = threeOrMoreGame.PlayGame(false);
                            GameStats.UpdateThreeOrMoreStatistics(threeOrMoreUpdateValue);
                            break;
                        }
                    case 3:
                        {
                            GameStats.ViewGameStatistics();
                            break;
                        }
                    case 4:
                        {
                            GameTesting.InitialiseTesting();
                            break;
                        }
                }
                keepPlaying = Continue();
            }
            return -1;
        }
        protected bool Continue()
        {
            Console.WriteLine("\n" +
                "To exit the program enter < Y/y >\n" +
                "To Return to the Main menu press any key and or enter...");
            string decision = Console.ReadLine();
            if (decision == "Y" || decision == "y")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

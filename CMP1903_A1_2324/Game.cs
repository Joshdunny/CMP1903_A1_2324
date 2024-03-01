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
         * rolls could be continuous, and the totals and other statistics could be summarised for example.
         */

        //variables used later in the loop for calculating statistics
        //all encapsulated to the class
        public int numOfRolls;
        public int numOfSums;
        public int totalSum;
        public int averageSum;
        public int averageRoll;
        public int highestSum;
        private int NumOfRolls
        {
            get{ return numOfRolls;}
            set{ numOfRolls = value;}
        }
        private int NumOfSums
        {
            get { return numOfSums;}
            set { numOfSums = value;}
        }
        private int TotalSum
        {
            get { return totalSum;}
            set { totalSum = value;}
        }
        private int AverageSum
        {
            get { return averageSum;}
            set { averageSum = value;}
        }
        private int AverageRoll
        {
            get { return averageRoll;}
            set { averageRoll = value;}
        }
        private int HighestSum
        {
            get { return highestSum;}
            set { highestSum = value;}
        }

        //Methods
        public void GameStart()
        {
           
            //creates a sum variable set as -1 so if sum is not calculated -1 will be displayed 
            int sum = -1;

            //creates a bool variable for continuous rolls 
            bool roll = true;

            //variables set for later in the loop for calculating statistics
            numOfRolls = 0;
            numOfSums = 0;
            totalSum = 0;
            averageSum = 0;
            averageRoll = 0;
            highestSum = 0;

            //main loop for rolling 3 dice and calculating + reporting sum
            while (roll) 
            {
                //calls method Roll3Dice to roll 3 dice and return the sum of them
                sum = Roll3Dice();       
                
                //reports the sum of each roll
                Console.WriteLine("The sum of the rolled dice >>> {0}", sum);

                //Statistics to be calculated (Mean Roll, Mean sum, Highest sum)
                //calculates average sum
                averageSum = totalSum / numOfSums;
                //calculates average roll
                averageRoll = totalSum / numOfRolls;
                //changes highest sum if the newest sum is larger then the current highest sum
                if (highestSum < sum)
                {
                    highestSum = sum;
                }
                
                string rollQuery = "";
                //Loops until a correct input of Y or N is given
                while (rollQuery != "Y" && rollQuery != "N")
                {
                    //querys the user for continuous rolls
                    Console.WriteLine("Would you like to roll again, [Y] or [N]");
                    rollQuery = Console.ReadLine();
                }
                //checks the users input for N if so roll is changed to false and the loop will end
                if (rollQuery == "N")
                {
                    roll = false;
                }
            }
            ReportStats();
        }
        public int Roll3Dice()
        {
            //creates 3 "die" objects 
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();

            //calls the roll method for each dice object created 
            //reports each roll made after being generated
            die1.RollDie();
            Console.WriteLine("First Die rolled: {0}", die1.DieValue);
            die2.RollDie();
            Console.WriteLine("Second Die rolled: {0}", die2.DieValue);
            die3.RollDie();
            Console.WriteLine("Third Die rolled: {0}", die3.DieValue);

            //increments numOfRolls counter by 3 everyTime 3 dice are rolled 
            numOfRolls += 3;

            //calls each DieValue of each dice object created and calculates the sum
            int sum = die1.DieValue + die2.DieValue + die1.DieValue;

            //increments numOfSums everytime sum is calculated and adding the sum to the total sums made
            numOfSums++;
            totalSum += sum;

            return sum;
        }
        public void ReportStats()
        {
            //displays a summary of the rolls made displaying, average roll, sum and highest sum
            Console.WriteLine("<-> Summary of rolls <->");
            Console.WriteLine("Average Roll: {0}", averageRoll);
            Console.WriteLine("Average Sum: {0}", averageSum);
            Console.WriteLine("Highest Sum: {0}", highestSum);
        }
    }
}

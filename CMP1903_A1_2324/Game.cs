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
        private int _numOfRolls;
        private int _numOfSums;
        private int _totalSum;
        private int _averageSum;
        private int _averageRoll;
        private int _highestSum;
        public int NumOfRolls
        {
            get { return _numOfRolls; }
            private set { _numOfRolls = value; }
        }
        public int NumOfSums
        {
            get { return _numOfSums; }
            private set { _numOfSums = value; }
        }
        public int TotalSum
        {
            get { return _totalSum; }
            private set { _totalSum = value; }
        }
        public int AverageSum
        {
            get { return _averageSum; }
            private set { _averageSum = value; }
        }
        public int AverageRoll
        {
            get { return _averageRoll; }
            private set { _averageRoll = value; }
        }
        public int HighestSum
        {
            get { return _highestSum; }
            private set { _highestSum = value; }
        }

        //Methods
        public void GameStart()
        {

            //creates a sum variable set as -1 so if sum is not calculated -1 will be displayed 
            int sum = -1;

            //creates a bool variable for continuous rolls 
            bool roll = true;

            //variables set for later in the loop for calculating statistics
            _numOfRolls = 0;
            _numOfSums = 0;
            _totalSum = 0;
            _averageSum = 0;
            _averageRoll = 0;
            _highestSum = 0;

            //main loop for rolling 3 dice and calculating + reporting sum
            while (roll)
            {
                //calls method Roll3Dice to roll 3 dice and return the sum of them
                sum = Roll3Dice();

                //reports the sum of each roll
                Console.WriteLine("The sum of the rolled dice >>> {0}", sum);

                //Statistics to be calculated (Mean Roll, Mean sum, Highest sum)
                _averageSum = CalculateAverageSum();
                _averageRoll = CalculateAverageRoll();
                _highestSum = CalculateHighestSum(sum);

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
        private int CalculateHighestSum(int sum)
        {
            //changes highest sum if the newest sum is larger then the current highest sum
            if (_highestSum < sum)
            {
                return sum;
            }
            else
            {
                return _highestSum;
            }
        }

        private int CalculateAverageRoll()
        {
            //calculates average roll
            return (_totalSum / _numOfSums);
        }
        private int CalculateAverageSum()
        {
            //calculates average sum
            return (_totalSum / _numOfSums);
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
            _numOfRolls += 3;

            //calls each DieValue of each dice object created and calculates the sum
            int sum = die1.DieValue + die2.DieValue + die3.DieValue;

            //increments numOfSums everytime sum is calculated and adding the sum to the total sums made
            _numOfSums++;
            _totalSum += sum;

            return sum;
        }
        public void ReportStats()
        {
            //displays a summary of the rolls made displaying, average roll, sum and highest sum
            Console.WriteLine("<-> Summary of rolls <->");
            Console.WriteLine("Average Roll: {0}", _averageRoll);
            Console.WriteLine("Average Sum: {0}", _averageSum);
            Console.WriteLine("Highest Sum: {0}", _highestSum);
        }
    }
}

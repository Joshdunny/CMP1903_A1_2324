using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
  internal class Testing
    {
    /*
    * This class should test the Game and the Die class.
    * Create a Game object, call the methods and compare their output to expected output.
    * Create a Die object and call its method.
    * Use debug.assert() to make the comparisons and tests.
    */

    //Method
    //
    //method for creating the Game class to be tested and ensure the values are expected 
    public void TestingGameClass() {
      Console.WriteLine("Initiating testing of Game class");

      Game testGame = new Game();
      //Tests to make sure after 3 dice are rolled the total is neither below 2 or above 19
      //As all expected values should be minimum 3 and maximum 18            
      int total = testGame.Roll3Dice();
      Debug.Assert(total > 2 && total < 19, "Does not meet expected values");

    }
    //method for creating the Die class to be tested and ensure the values are expected 
    public void TestingDieClass() {
      Console.WriteLine("Initiating testing of Die class");

      Die testDie = new Die();
      //If testDie.RollDie() > 0 or > 7 comes back as false a message will be displayed
      //testing the expected values of the dice to be between 1 and 6
      Console.WriteLine("Testing dice rolls to be between 1 and 6");
      int dievalue = testDie.RollDie();
      Debug.Assert(dievalue > 0 && dievalue < 7, "Does not meet expected values");
    }
  }
}

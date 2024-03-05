using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
  internal class Program {
    static void Main(string[] args)
    {
      /*
      * Create a Game object and call its methods.
      * Create a Testing object to verify the output and operation of the other classes.
      */

      //creates the game object calling the Game constructor 
      Game startGame = new Game();
      //calls the gamestart method to begin the game and rolling the dice
      startGame.GameStart();

      //creates the testing object for verifying the testing the Game and Die classes
      Testing test = new Testing();
      //calls both methods to test game class and die class 
      test.TestingGameClass();
      test.TestingDieClass();

      //Displays the end of the program
      Console.WriteLine("" +
        " <<< Program has finished >>>");
      Console.ReadLine();
    }
  }
}

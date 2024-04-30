using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        /// <summary>
        /// The Main method only instantiates a Game object 
        /// and calls its PlayGame method
        /// </summary>
        static void Main(string[] args)
        {            
            Game initialiseGames = new Game();
            initialiseGames.PlayGame(false);
        }
    }
}

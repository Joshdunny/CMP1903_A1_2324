using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        /// <summary>
        /// The Statistics class should:
        /// Store game statistics for each game type (number of plays, high-scores, etc)
        /// </summary>        
        private int sevensOutGames;
        private int sevensOutTotalScore;
        private int sevensOutAverageScore;
        private int sevensOutHighScore;
        private int threeOrMoreGames;
        private int threeOrMoreTotalRolls;
        private int threeOrMoreAverageRolls;
        private int threeOrMoreLowestRolls;
        private int totalGames;
        protected void MainMenu()
        {
            //This will be the main section for displaying the statistics data to the console
            Console.WriteLine("\n" +
                "  Statistics Menu: Displaying both game data  \n" +
                ">--------------------------------------------<\n" +
                "  Sevens Out:                                 \n" +
                "    >>>  Total Games: {0}                     \n" +
                "    >>>  Total Score: {1}                     \n" +
                "    >>>  Average Score: {2}                   \n" +
                "    >>>  High Score: {3}                      \n" +
                "  Three or More:                              \n" +
                "    >>>  Total Games: {4}                     \n" +
                "    >>>  Total Rolls: {5}                     \n" +
                "    >>>  Average Rolls: {6}                   \n" +
                "    >>>  Lowest Rolls: {7}                    \n" +
                ">--------------------------------------------<\n" +
                "", sevensOutGames, sevensOutTotalScore, sevensOutAverageScore, sevensOutHighScore,
                threeOrMoreGames, threeOrMoreTotalRolls, threeOrMoreAverageRolls, threeOrMoreLowestRolls);
        }
        public void ViewGameStatistics()
        {
            MainMenu();
        }
        public void UpdateSevensOutStatistics(int totalScore)
        {
            totalGames = totalGames + 1;
            sevensOutGames = sevensOutGames + 1;
            sevensOutTotalScore = sevensOutTotalScore + totalScore;
            sevensOutAverageScore = AverageScore(sevensOutTotalScore, sevensOutGames);
            sevensOutHighScore = SevensOutHighScore(sevensOutHighScore, totalScore);
        }
        public void UpdateThreeOrMoreStatistics(int totalRolls)
        {
            totalGames = totalGames + 1;
            threeOrMoreGames = threeOrMoreGames + 1;
            threeOrMoreTotalRolls += totalRolls;
            threeOrMoreAverageRolls = AverageScore(threeOrMoreTotalRolls, threeOrMoreGames);
            threeOrMoreLowestRolls = ThreeOrMoreLowestRolls(threeOrMoreLowestRolls, totalRolls);
        }
        private int AverageScore(int totalScore, int games)
        {
            return totalScore / games;
        }
        private int SevensOutHighScore(int prevScore, int newScore)
        {
            if (newScore > prevScore) return newScore; 
            else return prevScore;
        }
        private int ThreeOrMoreLowestRolls(int prevScore, int newScore)
        {
            if (newScore < prevScore || prevScore == 0) return newScore;
            else return prevScore;
        }

    }
}

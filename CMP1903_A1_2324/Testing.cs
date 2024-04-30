using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /// <summary>
        /// The testing class does:
        /// Create a Game object(Sevens Out and or Three Or More)
        /// using debug.assert to verify:
        /// Sevens Out: Total of sum, stop if total = 7
        /// Three Or More: Scores set and added correctly, recognise when total >= 20.
        /// </summary>
        protected void ReportMenu()
        {
            Console.WriteLine("\n" +
                "  Testing Main Menu         \n" +
                ">--------------------------<\n" +
                "  1 : Test Sevens Out       \n" +
                "  2 : Test Three Or More    \n" +
                "  3 : Test Both             \n" +
                "  4 : Show Past Test Results\n");
        }
        protected void ReportMenu(string gameName, string testConducted, string testResult)
        {
            Console.WriteLine("\n" +
                "  Testing Report for: {0}  \n" +
                ">-------------------------<\n" +
                "  Test Conducted : {1}     \n" +
                "  Test Result : {2}",gameName, testConducted, testResult);
        }
        public void InitialiseTesting()
        {
            int choice = -1;
            ReportMenu();
            while (choice < 1 || choice > 4)
            {
                try
                {
                    Console.WriteLine("Enter your choice here:");
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 4)
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
                        TestSevensOut();
                        break;
                    }
                case 2:
                    {
                        TestThreeOrMore();
                        break;
                    }
                case 3:
                    {
                        TestSevensOut();
                        TestThreeOrMore();
                        break;
                    }
                case 4:
                    {
                        OutputTestResults();
                        break;
                    }
            }
        }
        protected void TestSevensOut()
        {
            SevensOut testInstanceOfSevensOut = new SevensOut();
            int testValue = -1;
            try
            {
                testValue = testInstanceOfSevensOut.PlayGame(true);
            }
            catch
            {
                Console.WriteLine("Error, SevensOut was unsuccessful when testing");
            }
            Debug.Assert(testValue == 7, "Game has ended prematurely");
            if (testValue == 7)
            {
                ReportMenu("Sevens Out", "Game ending when dice total is 7", "PASSED");
                LogTestResults("Sevens Out", "Game ending when dice total is 7", "PASSED");
            }
            else
            {
                ReportMenu("Sevens Out", "Game ending when dice total is 7", "FAILED");
                LogTestResults("Sevens Out", "Game ending when dice total is 7", "FAILED");
            }
        }
        protected void TestThreeOrMore()
        {
            ThreeOrMore testInstanceOfThreeOrMore = new ThreeOrMore();
            int testValue = -1;
            try
            {
                testValue = testInstanceOfThreeOrMore.PlayGame(true);
            }
            catch
            {
                Console.WriteLine("Error, SevensOut was unsuccessful when testing");
            }
            Debug.Assert(testValue >= 20, "Game has ended prematurely");
            if (testValue >= 20)
            {
                ReportMenu("Three Or More", "Game ending when score is >= 20", "PASSED");
                LogTestResults("Three Or More", "Game ending when score is >= 20", "PASSED");
            }
            else
            {
                ReportMenu("Three Or More", "Game ending when score is >= 20", "FAILED");
                LogTestResults("Three Or More", "Game ending when score is >= 20", "FAILED");
            }
        }
        private void LogTestResults(string gameName, string testConducted, string testResult)
        {
            string path = Path.GetFullPath("TestLogs.txt");
            string testLog = "\n  Testing Report for: " + gameName +
                             "\n>-------------------------<" +
                             "\n  Test Conducted : " + testConducted +
                             "\n  Test Result : " + testResult;
            File.AppendAllText(path, testLog);

        }
        private void OutputTestResults()
        {
            string path = Path.GetFullPath("TestLogs.txt");
            Console.WriteLine("<==Outputting Test Logs==>");
            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("<=========================>");    
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using AOC2016.Tools;

namespace AOC2016.Day06
{
    class Day06
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private IList<Dictionary<char, int>> _codeRecs;

        // CONSTANTS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        const int CODE_LEN = 8;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day06()
        {
            _codeRecs = new List<Dictionary<char, int>>();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // split input
            var inputLines = MyTools.SplitByLine(inData);

            // parse input into records
            BuildRecords(inputLines);

            // get answers
            var answer1 = GetMostCommonCode();
            var answer2 = GetLeastCommonCode();

            // display results
            Console.WriteLine("   the first answer is {0}", answer1);
            Console.WriteLine("   the second answer is {0}", answer2);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void BuildRecords(string[] inLines)
        {
            for (int i = 0; i < CODE_LEN; i++)
            {
                var newDict = new Dictionary<char, int>();

                foreach (var line in inLines)
                {
                    var thisChar = line[i];
                    int thisCharCount;

                    if (newDict.TryGetValue(thisChar, out thisCharCount))
                    {
                        thisCharCount++;
                        newDict[thisChar] = thisCharCount;
                    }
                    else
                    {
                        newDict.Add(thisChar, 1);
                    }
                }

                    // add dict to list
                    _codeRecs.Add(newDict);
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string GetMostCommonCode()
        {
            var outVal = string.Empty;
            
            for (int i = 0; i < CODE_LEN; i++)
            {
                var highest = 0;
                var thisDict = _codeRecs[i];
                var codeChar = '-';

                foreach (var rec in thisDict)
                {
                    if (rec.Value > highest)
                    {
                        highest = rec.Value;
                        codeChar = rec.Key;
                    }
                }

                outVal += codeChar;
            }

            return outVal;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string GetLeastCommonCode()
        {
            var outVal = string.Empty;

            for (int i = 0; i < CODE_LEN; i++)
            {
                var lowest = 0;
                var thisDict = _codeRecs[i];
                var codeChar = '-';

                foreach (var rec in thisDict)
                {
                    if (rec.Value < lowest || lowest == 0)
                    {
                        lowest = rec.Value;
                        codeChar = rec.Key;
                    }
                }

                outVal += codeChar;
            }

            return outVal;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

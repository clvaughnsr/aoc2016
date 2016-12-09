using System;
using System.IO;
using AOC2016.Tools;

namespace AOC2016.Day07
{
    class Day07
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        

        // CONSTANTS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        const char OPEN = '[';
        const char CLOSE = ']';

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day07()
        {
            // unused
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // split input
            var inputLines = MyTools.SplitByLine(inData);

            var tlsSupportCount = 0;
            var sslSupportCount = 0;

            // count number of lines supporting TLS
            foreach (var line in inputLines)
            {
                if (DoesSupportTLS(line))
                {
                    tlsSupportCount++;
                }

                if (DoesSupportSSL(line))
                {
                    sslSupportCount++;
                }
            }

            // display results
            Console.WriteLine("   the first answer is {0}", tlsSupportCount);
            Console.WriteLine("   the second answer is {0}", sslSupportCount);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool DoesSupportTLS(string inVal)
        {
            // ASSUMES: input contains at least 4 characters

            bool bHasGoodAbba = false;
            bool bHasBadAbba = false;
            bool bIsOpen = false;

            for (int i = 0; i < inVal.Length; i++)
            {
                if (inVal[i] == OPEN)
                {
                    bIsOpen = true;
                }
                else if (inVal[i] == CLOSE)
                {
                    bIsOpen = false;
                }
                else if (i < inVal.Length - 3)
                {
                    // evaluate this 4 char substring as abba
                    var substr = inVal.Substring(i, 4);
                    var bIsAbba = IsABBA(substr);

                    // set bools according
                    if (bIsAbba)
                    {
                        if (bIsOpen)
                        {
                            bHasBadAbba = true;
                        }
                        else
                        {
                            bHasGoodAbba = true;
                        }      
                    }
                }
            }
           
            return bHasGoodAbba && !bHasBadAbba;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool DoesSupportSSL(string inLine)
        {
            // ASSUMES: input contains at least 3 characters

            bool bDoesSupport = false;
            bool bIsOpen = false;

            for (int i = 0; i < inLine.Length && !bDoesSupport; i++)
            {
                if (inLine[i] == OPEN)
                {
                    bIsOpen = true;
                }
                else if (inLine[i] == CLOSE)
                {
                    bIsOpen = false;
                }
                else if (bIsOpen && i < inLine.Length - 2)
                {
                    // evaluate this 3 char substring as aba
                    var substr = inLine.Substring(i, 3);
                    var bIsABA = IsABA(substr);

                    // set bools according
                    if (bIsABA && IsBAB(inLine, substr))
                    {
                        bDoesSupport = true;
                    }
                }
            }

            return bDoesSupport;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool IsABBA(string inVal)
        {
            bool bIsAbba = false;

            if (inVal.Length == 4 && !inVal.Contains(OPEN.ToString()) &&
                !inVal.Contains(CLOSE.ToString()))
            {
                // subdivide input
                var char1 = inVal[0];
                var char2 = inVal[1];
                var char3 = inVal[2];
                var char4 = inVal[3];

                // evaluate
                if (char1 == char4 && char2 == char3 && char1 != char2)
                {
                    bIsAbba = true;
                }
            }

            return bIsAbba;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool IsABA(string inVal)
        {
            bool bAnswer = false;

            if (inVal.Length == 3 && !inVal.Contains(OPEN.ToString()) &&
                !inVal.Contains(CLOSE.ToString()))
            {
                // subdivide input
                var char1 = inVal[0];
                var char2 = inVal[1];
                var char3 = inVal[2];

                // evaluate
                if (char1 == char3 && char1 != char2)
                {
                    bAnswer = true;
                }
            }

            return bAnswer;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool IsBAB(string inLine, string inRefVal)
        {
            var bIsBAB = false;
            var bIsOpen = false;

            var ref1 = inRefVal[0];
            var ref2 = inRefVal[1];

            for (int i = 0; i < inLine.Length && !bIsBAB; i++)
            {
                if (inLine[i] == OPEN)
                {
                    bIsOpen = true;
                }
                else if (inLine[i] == CLOSE)
                {
                    bIsOpen = false;
                }
                else if (!bIsOpen && i < inLine.Length - 2)
                {
                    // evaluate this 3 char substring as aba
                    var char1 = inLine[i];
                    var char2 = inLine[i+1];
                    var char3 = inLine[i+2];

                    // set bools according
                    if (char1 == ref2 && char2 == ref1 && char3 == ref2)
                    {
                        bIsBAB = true;
                    }
                }
            }

            return bIsBAB;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

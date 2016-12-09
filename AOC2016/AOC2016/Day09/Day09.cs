using System;
using System.IO;

namespace AOC2016.Day09
{
    class Day09
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // CONSTANTS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        const char OPEN = '(';
        const char CLOSE = ')';
        const char DELIM = 'x';

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day09()
        {
            // unused
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            var bUseRecursion = false;
            long regularLength = GetTokenLength(inData, bUseRecursion);

            bUseRecursion = true;
            long recursiveLength = GetTokenLength(inData, bUseRecursion);

            // display answer 1
            Console.WriteLine("   the first answer is: {0}", regularLength);

            // display answer 2
            Console.WriteLine("   the second answer is: {0}", recursiveLength);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private long GetTokenLength(string inData, bool bUseRecursion)
        {
            var currIndex = 0;
            long totalLen = 0;

            if (inData.Contains(OPEN.ToString()))
            {
                while (currIndex < inData.Length)
                {
                    var thisChar = inData[currIndex];

                    if (thisChar == OPEN)
                    {
                        // get marker and token
                        var marker = GetMarker(currIndex, inData);
                        var token = GetToken(currIndex, inData, marker);

                        // get marker reps
                        var markerReps = GetMarkerRepeat(marker);

                        // update total length
                        if (bUseRecursion)
                        {
                            totalLen += GetTokenLength(token, bUseRecursion) * markerReps;
                        }
                        else
                        {
                            totalLen += token.Length * markerReps;
                        }
                        

                        // update current index
                        currIndex += marker.Length + token.Length;
                    }
                    else
                    {
                        totalLen++;
                        currIndex++;
                    }
                }
            }
            else
            {
                totalLen = inData.Length;
            }

            return totalLen;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string GetMarker(int inStartIndex, string inData)
        {
            string outMarker = string.Empty;
            var bFound = false;

            for (int i = inStartIndex + 1; i < inData.Length && !bFound; i++)
            {
                if (inData[i] == CLOSE)
                {
                    var markerLen = i - inStartIndex + 1;
                    outMarker = inData.Substring(inStartIndex, markerLen);
                    bFound = true;
                }
            }

            if (!bFound)
            {
                throw new Exception("Cannot find end of marker.");
            }

            return outMarker;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string GetToken(int inStartIndex, string inData, string inMarker)
        {
            // ASSUMES: Marker is formatted as "(AxB)"

            // parse marker
            var tokenLen = GetMarkerCount(inMarker);

            // get token
            var tokenStartIndex = inStartIndex + inMarker.Length;
            var outToken = inData.Substring(tokenStartIndex, tokenLen);

            return outToken;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private int GetMarkerCount(string inMarker)
        {
            // ASSUMES: Marker is formatted as "(AxB)"

            // remove marker parens
            var tempStr = inMarker.Substring(1, inMarker.Length - 2);

            // split values
            var strA = tempStr.Split(DELIM)[0];

            return Convert.ToInt32(strA);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private int GetMarkerRepeat(string inMarker)
        {
            // ASSUMES: Marker is formatted as "(AxB)"

            // remove marker parens
            var tempStr = inMarker.Substring(1, inMarker.Length - 2);

            // split values
            var strB = tempStr.Split(DELIM)[1];

            return Convert.ToInt32(strB);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

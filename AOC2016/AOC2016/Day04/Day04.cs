using System;
using System.IO;
using AOC2016.Tools;
using System.Collections.Generic;
using System.Linq;

namespace AOC2016.Day04
{
    class Day04
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private IList<RoomRec> roomRecs;
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day04()
        {
            roomRecs = new List<RoomRec>();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // constants
            const string ANSWER_KEY = "storage";

            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // split input
            var inputLines = MyTools.SplitByLine(inData);

            // parse input into records
            foreach (var line in inputLines)
            {
                var newRec = BuildRoomRec(line);
                roomRecs.Add(newRec);
            }

            // add sector ids of all valid rooms
            var idTotal = 0;

            foreach (var room in roomRecs)
            {
                if (BuildChecksum(room.name).Equals(room.checksum))
                {
                    idTotal += room.sectorId;

                    var decodedRoomName = room.DecodedName();

                    if (decodedRoomName.Contains(ANSWER_KEY))
                    {
                        Console.WriteLine("ID: " + room.sectorId + " | DecodedName: " + room.DecodedName());
                    }
                }
            }

            // display results
            Console.WriteLine("   the first answer is {0}", idTotal);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private RoomRec BuildRoomRec(string inVal)
        {
            const char DASH = '-';
            const char OPEN = '[';
            const string CLOSE = "]";

            // parse using '['
            var tempList = inVal.Split(OPEN);
            var front = tempList[0];
            var checksum = tempList[1];

            // create checksum
            checksum = checksum.Replace(CLOSE, string.Empty);

            // create name and sector id
            var lastDash = front.LastIndexOf(DASH);
            var name = front.Substring(0, lastDash);
            var sectorId = Convert.ToInt32(front.Substring(lastDash + 1));

            // build new rec
            var newRec = new RoomRec();
            newRec.name = name;
            newRec.sectorId = sectorId;
            newRec.checksum = checksum;

            return newRec;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string BuildChecksum(string inVal)
        {
            // constants
            const int LOWER_A = 97;
            const int LOWER_Z = 122;
            const int CHECK_LEN = 5;

            IDictionary<char, int> alphaCount = new Dictionary<char, int>();

            // count all occurances of lowercase chars
            for (int i = LOWER_A; i <= LOWER_Z; i++)
            {
                var charCount = 0;
                var thisChar = (char) i;

                foreach (var testChar in inVal)
                {
                    if (thisChar == testChar)
                    {
                        charCount++;
                    }
                }

                if (charCount > 0)
                {
                    alphaCount.Add(thisChar, charCount);
                }
            }

            // build checksum

            var outVal = string.Empty;

            for (int i = 0; i < CHECK_LEN; i++)
            {
                outVal += GetNextCheckSumDigit(alphaCount);
            }

            return outVal;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private char GetNextCheckSumDigit(IDictionary<char, int> inList)
        {
            // find highest count

            var highCount = 0;

            foreach (var record in inList)
            {
                if (record.Value > highCount)
                {
                    highCount = record.Value;
                }
            }

            // find lowest char matching high count

            var lowChar = 'z';

            foreach (var record in inList)
            {
                if (record.Value == highCount && record.Key < lowChar)
                {
                    lowChar = record.Key;
                }
            }

            // remove rec from list
            inList.Remove(lowChar);

            return lowChar;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~    
    }
}

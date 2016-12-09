using System;
using System.Security.Cryptography;
using System.Text;

namespace AOC2016.Day05
{
    class Day05
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day05()
        {
            // unused
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void SolvePart1(string inInput)
        {
            const int CODE_LEN = 8;
            const int CODE_INDEX = 5;
            const int LOG_INTERVAL = 100000;

            string passcode = string.Empty;
            int index = 0;

            for (int i = 0; i < CODE_LEN; i++)
            {
                string thisHash;

                do
                {
                    thisHash = GetHash(inInput + index);
                    index++;

                    if (index%LOG_INTERVAL == 0)
                    {
                        Console.WriteLine("Processing index: {0}", index);
                    }

                } while (!IsValidHash(thisHash));

                var thisDigit = thisHash.Substring(CODE_INDEX, 1);
                passcode += thisDigit;

                Console.WriteLine("Found digit {0}: {1}", i, thisDigit);
            }      
 
            // display results
            Console.WriteLine("   the first answer is {0}", passcode);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void SolvePart2(string inInput)
        {
            const int PASSCODE_LEN = 8;
            const int CODE_INDEX = 6;
            const int POS_INDEX = 5;
            const int LOG_INTERVAL = 100000;

            char[] passcode = "--------".ToCharArray();
            int index = 0;
            int foundCharCount = 0;

            do
            {
                string thisHash;
                char thisPos;
                bool bIsValidHash;
                bool bIsOpenPos;

                do
                {
                    // get hash code
                    thisHash = GetHash(inInput + index);
                    index++;

                    //// log entry
                    //if (index % LOG_INTERVAL == 0)
                    //{
                    //    Console.WriteLine("Processing index: {0}", index);
                    //}

                    // evaluate hash
                    bIsValidHash = IsValidHash(thisHash);

                    // check position is filled
                    thisPos = thisHash[POS_INDEX];
                    bIsOpenPos = IsOpenPosition(passcode, thisPos);

                } while (!bIsValidHash || !bIsOpenPos);

                // set single digit code within passcode
                char thisCode = thisHash[CODE_INDEX];
                int thisPosIndex = Convert.ToInt32(thisPos) - 48;
                passcode[thisPosIndex] = thisCode;
                foundCharCount++;

                // log entry
                Console.WriteLine("Found code: {0}", new string(passcode));

            } while (foundCharCount < PASSCODE_LEN);

            // display results
            Console.WriteLine("   the second answer is {0}", new string(passcode));
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private string GetHash(string inVal)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inVal));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool IsValidHash(string inHash)
        {
            const string TARGET = "00000";

            // get first 4 chars of input
            var front = inHash.Substring(0, 5);

            return front.Equals(TARGET);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool IsOpenPosition(char[] inPasscode, char inPos)
        {
            const char DASH = '-';

            var bIsOpenPos = false;

            if (inPos >= '0' && inPos <= '7')
            {
                var codeIndex = Convert.ToInt32(inPos) - 48;
                if (inPasscode[codeIndex] == DASH)
                {
                    bIsOpenPos = true;
                }
            }

            return bIsOpenPos;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2016.Day04
{
    class RoomRec
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string name { get; set; }
        public int sectorId { get; set; }
        public string checksum { get; set; }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string DecodedName()
        {
            // constants
            const char DASH = '-';
            const int ALPHA_CT = 26;
            const int LOWER_Z = 122;

            var outVal = string.Empty;

            // decode each char in name
            foreach (var thisChar in name)
            {
                if (thisChar == DASH)
                {
                    outVal += ' ';
                }
                else
                {
                    var shiftVal = sectorId % ALPHA_CT;

                    var newChar = thisChar + shiftVal;

                    if (newChar > LOWER_Z)
                    {
                        newChar -= ALPHA_CT;
                    }

                    outVal += (char) newChar;
                }
            }

            return outVal;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override string ToString()
        {
            return "name: " + name + " | sectorId: " + sectorId + " | checksum: " + checksum;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

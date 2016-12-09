using System;

namespace AOC2016.Tools
{
    class MyTools
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static string[] SplitByLine(string inVal)
        {
            // constants
            const string LINE_DELIMS = "\r\n";

            // build list of lines
            var lines = inVal.Split(new[] { LINE_DELIMS }, StringSplitOptions.RemoveEmptyEntries);

            return lines;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

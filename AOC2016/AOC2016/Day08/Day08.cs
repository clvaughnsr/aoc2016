using System;
using System.IO;
using AOC2016.Tools;

namespace AOC2016.Day08
{
    class Day08
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Display myDisplay;

        // CONSTANTS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        const int DISPLAY_WIDTH = 50;
        const int DISPLAY_HEIGHT = 6;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day08()
        {
            myDisplay = new Display(DISPLAY_WIDTH, DISPLAY_HEIGHT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            const string RECT_KEY = "rect";
            const string ROTATE_ROW_KEY = "rotate row";
            const string ROTATE_COL_KEY = "rotate column";

            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // split input
            var inputLines = MyTools.SplitByLine(inData);

            // count number of lines supporting TLS
            foreach (var line in inputLines)
            {
                if (line.Contains(RECT_KEY))
                {
                    ExecuteRectangle(line);
                }
                else if (line.Contains(ROTATE_ROW_KEY))
                {
                    ExecuteRotateRow(line);
                }
                else if (line.Contains(ROTATE_COL_KEY))
                {
                    ExecuteRotateCol(line);
                }
                else
                {
                    throw new Exception("Cannot process command: " + line);
                }
            }

            // display answer 1
            Console.WriteLine("   the first answer is: {0}", myDisplay.Count());

            // display answer 2
            Console.WriteLine("   the second answer is:");
            Console.WriteLine();
            myDisplay.Output();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void ExecuteRectangle(string inLine)
        {
            // ASSSUMES: input format is "rect AxB"

            const char SPACE = ' ';
            const char X_CHAR = 'x';

            // split by space
            var tempStr = inLine.Split(SPACE)[1];

            // split by 'x'
            var strA = tempStr.Split(X_CHAR)[0];
            var strB = tempStr.Split(X_CHAR)[1];

            // convert to ints
            var width = Convert.ToInt32(strA);
            var height = Convert.ToInt32(strB);

            myDisplay.Rectangle(width, height);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void ExecuteRotateRow(string inLine)
        {
            // ASSUMES: input format is "rotate row y=A by B"

            const char SPACE = ' ';
            const char EQUALS_CHAR = '=';

            // split by space
            var strA = inLine.Split(SPACE)[2];
            var strB = inLine.Split(SPACE)[4];

            // split by equals symbol
            strA = strA.Split(EQUALS_CHAR)[1];

            // convert to ints
            var row = Convert.ToInt32(strA);
            var val = Convert.ToInt32(strB);

            myDisplay.RotateRow(row, val);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void ExecuteRotateCol(string inLine)
        {
            // ASSUMES: input format is "rotate column x=A by B"

            const char SPACE = ' ';
            const char EQUALS_CHAR = '=';

            // split by space
            var strA = inLine.Split(SPACE)[2];
            var strB = inLine.Split(SPACE)[4];

            // split by equals symbol
            strA = strA.Split(EQUALS_CHAR)[1];

            // convert to ints
            var col = Convert.ToInt32(strA);
            var val = Convert.ToInt32(strB);

            myDisplay.RotateColumn(col, val);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

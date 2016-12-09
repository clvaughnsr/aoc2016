using System;
using System.IO;
using AOC2016.Tools;

namespace AOC2016.Day02
{
    class Day02
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private char currNum;
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day02()
        {
            currNum = '5';
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // initialize output
            var outCode = string.Empty;

            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // build list of lines
            var keyLines = MyTools.SplitByLine(inData);

            // PART 1 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // cycle thru all lines
            foreach (var keyLine in keyLines)
            {
                // cycle thru each move in line
                foreach (var thisMove in keyLine)
                {
                    Move(thisMove);
                }

                outCode += currNum;
            }

            // display results
            Console.WriteLine("   the first code is " + outCode);

            // PART 2 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //reset values
            currNum = '5';
            outCode = string.Empty;

            // cycle thru all lines
            foreach (var keyLine in keyLines)
            {
                // cycle thru each move in line
                foreach (var thisMove in keyLine)
                {
                    AltMove(thisMove);
                }

                outCode += currNum;
            }

            // display results
            Console.WriteLine("   the second code is " + outCode);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void Move(char inMove)
        {
            switch (inMove)
            {
                case 'U':
                    MoveUp();
                    break;
                case 'L':
                    MoveLeft();
                    break;
                case 'D':
                    MoveDown();
                    break;
                case 'R':
                    MoveRight();
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void MoveUp()
        {
            switch (currNum)
            {
                case '4':
                    currNum = '1';
                    break;
                case '5':
                    currNum = '2';
                    break;
                case '6':
                    currNum = '3';
                    break;
                case '7':
                    currNum = '4';
                    break;
                case '8':
                    currNum = '5';
                    break;
                case '9':
                    currNum = '6';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void MoveDown()
        {
            switch (currNum)
            {
                case '4':
                    currNum = '7';
                    break;
                case '5':
                    currNum = '8';
                    break;
                case '6':
                    currNum = '9';
                    break;
                case '1':
                    currNum = '4';
                    break;
                case '2':
                    currNum = '5';
                    break;
                case '3':
                    currNum = '6';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void MoveLeft()
        {
            switch (currNum)
            {
                case '2':
                    currNum = '1';
                    break;
                case '5':
                    currNum = '4';
                    break;
                case '8':
                    currNum = '7';
                    break;
                case '3':
                    currNum = '2';
                    break;
                case '6':
                    currNum = '5';
                    break;
                case '9':
                    currNum = '8';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void MoveRight()
        {
            switch (currNum)
            {
                case '2':
                    currNum = '3';
                    break;
                case '5':
                    currNum = '6';
                    break;
                case '8':
                    currNum = '9';
                    break;
                case '1':
                    currNum = '2';
                    break;
                case '4':
                    currNum = '5';
                    break;
                case '7':
                    currNum = '8';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void AltMove(char inMove)
        {
            switch (inMove)
            {
                case 'U':
                    AltMoveUp();
                    break;
                case 'L':
                    AltMoveLeft();
                    break;
                case 'D':
                    AltMoveDown();
                    break;
                case 'R':
                    AltMoveRight();
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void AltMoveUp()
        {
            switch (currNum)
            {
                case '3':
                    currNum = '1';
                    break;
                case '6':
                    currNum = '2';
                    break;
                case '7':
                    currNum = '3';
                    break;
                case '8':
                    currNum = '4';
                    break;
                case 'A':
                    currNum = '6';
                    break;
                case 'B':
                    currNum = '7';
                    break;
                case 'C':
                    currNum = '8';
                    break;
                case 'D':
                    currNum = 'B';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void AltMoveDown()
        {
            switch (currNum)
            {
                case '1':
                    currNum = '3';
                    break;
                case '2':
                    currNum = '6';
                    break;
                case '3':
                    currNum = '7';
                    break;
                case '4':
                    currNum = '8';
                    break;
                case '6':
                    currNum = 'A';
                    break;
                case '7':
                    currNum = 'B';
                    break;
                case '8':
                    currNum = 'C';
                    break;
                case 'B':
                    currNum = 'D';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void AltMoveLeft()
        {
            switch (currNum)
            {
                case '3':
                    currNum = '2';
                    break;
                case '4':
                    currNum = '3';
                    break;
                case '6':
                    currNum = '5';
                    break;
                case '7':
                    currNum = '6';
                    break;
                case '8':
                    currNum = '7';
                    break;
                case '9':
                    currNum = '8';
                    break;
                case 'B':
                    currNum = 'A';
                    break;
                case 'C':
                    currNum = 'B';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void AltMoveRight()
        {
            switch (currNum)
            {
                case '2':
                    currNum = '3';
                    break;
                case '3':
                    currNum = '4';
                    break;
                case '5':
                    currNum = '6';
                    break;
                case '6':
                    currNum = '7';
                    break;
                case '7':
                    currNum = '8';
                    break;
                case '8':
                    currNum = '9';
                    break;
                case 'A':
                    currNum = 'B';
                    break;
                case 'B':
                    currNum = 'C';
                    break;
                default:
                    break;
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

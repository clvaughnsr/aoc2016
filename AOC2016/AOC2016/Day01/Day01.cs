using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2016.Day01
{
    class Day01
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Direction myDirection;
        private Coord currCoord;
        private Coord dupeCoord;
        private bool bFoundDupe;
        private IList<Coord> prevCoords;

        // ENUMS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        enum Direction
        {
            North, East, South, West
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day01()
        {
            myDirection = Direction.North;
            currCoord = new Coord();
            dupeCoord = new Coord();
            bFoundDupe = false;
            prevCoords = new List<Coord>();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // constants
            const char DELIM = ',';

            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // build list of moves
            inData = inData.Replace(" ", "");
            var moves = inData.Split(DELIM);

            // cycle thru all moves
            for (int i = 0; i < moves.Length; i++)
            {
                // get values from this move
                var thisMove = moves[i];
                var thisTurn = thisMove[0];
                var thisDistance = Convert.ToInt32(thisMove.Substring(1));

                // change direction
                ChangeDirection(thisTurn);

                // move
                Move(thisDistance);
            }

            // display results
            Console.WriteLine("   The first distance is " + currCoord.Distance());
            Console.WriteLine("   The second distance is " + dupeCoord.Distance());
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void ChangeDirection(char inTurn)
        {
            // constants
            const char LEFT = 'L';
            const char RIGHT = 'R';

            if (inTurn == LEFT)
            {
                if (myDirection == Direction.North)
                {
                    myDirection = Direction.West;
                }
                else if (myDirection == Direction.East)
                {
                    myDirection = Direction.North;
                }
                else if (myDirection == Direction.South)
                {
                    myDirection = Direction.East;
                }
                else if (myDirection == Direction.West)
                {
                    myDirection = Direction.South;
                }
                else
                {
                    throw new Exception("Invalid Direction");
                }
            }
            else if (inTurn == RIGHT)
            {
                if (myDirection == Direction.North)
                {
                    myDirection = Direction.East;
                }
                else if (myDirection == Direction.East)
                {
                    myDirection = Direction.South;
                }
                else if (myDirection == Direction.South)
                {
                    myDirection = Direction.West;
                }
                else if (myDirection == Direction.West)
                {
                    myDirection = Direction.North;
                }
                else
                {
                    throw new Exception("Invalid Direction");
                }
            }
            else
            {
                throw new Exception("Error making turn");
            }

        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void Move(int inDist)
        {
            if (myDirection == Direction.North)
            {
                for (int i = 0; i < inDist; i++)
                {
                    currCoord.posNorth++;
                    CheckForDuplicatePosition();
                }
            }
            else if (myDirection == Direction.East)
            {
                for (int i = 0; i < inDist; i++)
                {
                    currCoord.posEast++;
                    CheckForDuplicatePosition();
                }
            }
            else if (myDirection == Direction.South)
            {
                for (int i = 0; i < inDist; i++)
                {
                    currCoord.posNorth--;
                    CheckForDuplicatePosition();
                }
            }
            else if (myDirection == Direction.West)
            {
                for (int i = 0; i < inDist; i++)
                {
                    currCoord.posEast--;
                    CheckForDuplicatePosition();
                }
            }
            else
            {
                throw new Exception("Error making move");
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void CheckForDuplicatePosition()
        {
            if (FoundCoord(currCoord) && bFoundDupe == false)
            {
                dupeCoord.posEast = currCoord.posEast;
                dupeCoord.posNorth = currCoord.posNorth;
                bFoundDupe = true;
            }
            else
            {
                var newCoord = new Coord();
                newCoord.posEast = currCoord.posEast;
                newCoord.posNorth = currCoord.posNorth;
                prevCoords.Add(newCoord);
            }
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private bool FoundCoord(Coord inCoord)
        {
            var bFound = false;

            for (int i = 0; i < prevCoords.Count && !bFound; i++)
            {
                if (inCoord.posNorth == prevCoords[i].posNorth &&
                    inCoord.posEast == prevCoords[i].posEast)
                {
                    bFound = true;
                }
            }

            return bFound;
        }
    }
}

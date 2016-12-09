namespace AOC2016.Day01
{
    class Coord
    {
        public int posNorth { set; get; }
        public int posEast { get; set; }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int Distance()
        {
            var outVal = 0;

            if (posEast < 0)
            {
                posEast = 0 - posEast;
            }

            if (posNorth < 0)
            {
                posNorth = 0 - posNorth;
            }

            outVal += posNorth + posEast;

            return outVal;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override string ToString()
        {
            return "N: " + posNorth + " | E: " + posEast;
        }
    }
}

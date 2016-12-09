namespace AOC2016.Day03
{
    class Spec
    {
        public int sideA { get; set; }
        public int sideB { get; set; }
        public int sideC { get; set; }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override string ToString()
        {
            return "sideA: " + sideA + " | sideB: " + sideB + " | sideC: " + sideC;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public bool IsTriangle()
        {
            bool answer;

            if (sideA + sideB > sideC &&
                sideA + sideC > sideB &&
                sideB + sideC > sideA)
            {
                answer = true;
            }
            else
            {
                answer = false;
            }

            return answer;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

using System;
using System.IO;

namespace AOC2016
{
    class Program
    {
        // constants
        const int DAY_TO_SOLVE = 9;
        const string INPUT_FILEPATH = "C:\\Users\\clvaughn\\Documents\\visual studio 2013\\Projects\\AOC2016\\AOC2016\\INPUT_FILES\\";

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        static void Main(string[] args)
        {
            // header
            Console.WriteLine("SOLUTION FOR DAY {0}:", DAY_TO_SOLVE);
            Console.WriteLine();

            // solve puzzle
            switch (DAY_TO_SOLVE)
            {
                case 1:
                    SolveDay01();
                    break;
                case 2:
                    SolveDay02();
                    break;
                case 3:
                    SolveDay03();
                    break;
                case 4:
                    SolveDay04();
                    break;
                case 5:
                    SolveDay05();
                    break;
                case 6:
                    SolveDay06();
                    break;
                case 7:
                    SolveDay07();
                    break;
                case 8:
                    SolveDay08();
                    break;
                case 9:
                    SolveDay09();
                    break;
                case 10:
                    SolveDay10();
                    break;
                case 11:
                    SolveDay11();
                    break;
                case 12:
                    SolveDay12();
                    break;
                case 13:
                    SolveDay13();
                    break;
                case 14:
                    SolveDay14();
                    break;
                case 15:
                    SolveDay15();
                    break;
                case 16:
                    SolveDay16();
                    break;
                case 17:
                    SolveDay17();
                    break;
                case 18:
                    SolveDay18();
                    break;
                case 19:
                    SolveDay19();
                    break;
                case 20:
                    SolveDay20();
                    break;
                case 21:
                    SolveDay21();
                    break;
                case 22:
                    SolveDay22();
                    break;
                case 23:
                    SolveDay23();
                    break;
                case 24:
                    SolveDay24();
                    break;
                case 25:
                    SolveDay25();
                    break;
                default:
                    Console.WriteLine("There is no solution for Day " + DAY_TO_SOLVE);
                    break;
            }

            // pause
            Console.ReadKey();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay01()
        {
            const string DAY01_INPUT = "input_01.txt";

            var day01 = new Day01.Day01();
            day01.Solve(INPUT_FILEPATH, DAY01_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay02()
        {
            const string DAY02_INPUT = "input_02.txt";

            var day02 = new Day02.Day02();
            day02.Solve(INPUT_FILEPATH, DAY02_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay03()
        {
            const string DAY03_INPUT = "input_03.txt";

            var day03 = new Day03.Day03();
            day03.Solve(INPUT_FILEPATH, DAY03_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay04()
        {
            const string DAY04_INPUT = "input_04.txt";

            var day04 = new Day04.Day04();
            day04.Solve(INPUT_FILEPATH, DAY04_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay05()
        {
            const string DAY05_INPUT = "ugkcyxxp";

            var day05 = new Day05.Day05();
            //day05.SolvePart1(DAY05_INPUT);
            day05.SolvePart2(DAY05_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay06()
        {
            const string DAY06_INPUT = "input_06.txt";

            var day06 = new Day06.Day06();
            day06.Solve(INPUT_FILEPATH, DAY06_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay07()
        {
            const string DAY07_INPUT = "input_07.txt";

            var day07 = new Day07.Day07();
            day07.Solve(INPUT_FILEPATH, DAY07_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay08()
        {
            const string DAY08_INPUT = "input_08.txt";

            var day08 = new Day08.Day08();
            day08.Solve(INPUT_FILEPATH, DAY08_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay09()
        {
            const string DAY09_INPUT = "input_09.txt";

            var day09 = new Day09.Day09();
            day09.Solve(INPUT_FILEPATH, DAY09_INPUT);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay10()
        {
            const string DAY10_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay11()
        {
            const string DAY11_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay12()
        {
            const string DAY12_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay13()
        {
            const string DAY13_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay14()
        {
            const string DAY14_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay15()
        {
            const string DAY15_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay16()
        {
            const string DAY16_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay17()
        {
            const string DAY17_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay18()
        {
            const string DAY18_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay19()
        {
            const string DAY19_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay20()
        {
            const string DAY20_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay21()
        {
            const string DAY21_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay22()
        {
            const string DAY22_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay23()
        {
            const string DAY23_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay24()
        {
            const string DAY24_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static void SolveDay25()
        {
            const string DAY25_INPUT = "";


        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

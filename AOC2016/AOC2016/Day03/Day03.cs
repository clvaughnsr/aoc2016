using System;
using System.IO;
using AOC2016.Tools;
using System.Collections.Generic;

namespace AOC2016.Day03
{
    class Day03
    {
        // PDMs ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private IList<Spec> horizSpecs;
        private IList<Spec> vertSpecs;
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public Day03()
        {
            horizSpecs = new List<Spec>();
            vertSpecs = new List<Spec>();
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void Solve(string inFilePath, string inFileName)
        {
            // get input data
            var inData = File.ReadAllText(inFilePath + inFileName);

            // build list of lines
            var inputLines = MyTools.SplitByLine(inData);

            // convert all lines to horiz specs
            foreach (var line in inputLines)
            {
                var spec = BuildHorizSpec(line);
                horizSpecs.Add(spec);
            }

            // count valid horz triangles

            var validHorizCount = 0;

            foreach (var spec in horizSpecs)
            {
                if (spec.IsTriangle())
                {
                    validHorizCount++;
                }
            }

            // convert horiz specs to vert specs
            for (int i = 0; i < horizSpecs.Count; i += 3)
            {
                var spec1 = horizSpecs[i];
                var spec2 = horizSpecs[i+1];
                var spec3 = horizSpecs[i+2];

                vertSpecs.Add(BuildVertSpec(spec1, spec2, spec3, 0));
                vertSpecs.Add(BuildVertSpec(spec1, spec2, spec3, 1));
                vertSpecs.Add(BuildVertSpec(spec1, spec2, spec3, 2));
            }

            // count valid vert triangles

            var validVertCount = 0;

            foreach (var spec in vertSpecs)
            {
                if (spec.IsTriangle())
                {
                    validVertCount++;
                }
            }

            // display results
            Console.WriteLine("   the first answer is {0}", validHorizCount);
            Console.WriteLine("   the second answer is {0}", validVertCount);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Spec BuildHorizSpec(string inVal)
        {
            // constants
            const string DELIM = " ";

            // split input using spaces
            var nums = inVal.Split(new[] { DELIM }, StringSplitOptions.RemoveEmptyEntries); 

            // create new object
            var newSpec = new Spec();
            newSpec.sideA = Convert.ToInt32(nums[0]);
            newSpec.sideB = Convert.ToInt32(nums[1]);
            newSpec.sideC = Convert.ToInt32(nums[2]);

            return newSpec;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private Spec BuildVertSpec(Spec inSpec1, Spec inSpec2, Spec inSpec3, int inPos)
        {
            int sideA;
            int sideB;
            int sideC;

            switch (inPos)
            {
                case 0:
                    sideA = inSpec1.sideA;
                    sideB = inSpec2.sideA;
                    sideC = inSpec3.sideA;
                    break;
                case 1:
                    sideA = inSpec1.sideB;
                    sideB = inSpec2.sideB;
                    sideC = inSpec3.sideB;
                    break;
                case 2:
                    sideA = inSpec1.sideC;
                    sideB = inSpec2.sideC;
                    sideC = inSpec3.sideC;
                    break;
                default:
                    throw new Exception("ERROR building vert spec");
                    break;
            }

            // create new object
            var newSpec = new Spec();
            newSpec.sideA = sideA;
            newSpec.sideB = sideB;
            newSpec.sideC = sideC;

            return newSpec;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

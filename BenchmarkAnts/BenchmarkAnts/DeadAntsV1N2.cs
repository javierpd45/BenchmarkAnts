using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkAnts
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class DeadAntsV1N2
    {
        [Params("...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t", "...ant...ant..nat.ant.t..ant...ant..ant..ant.anan")]
        public string ants;

        [Benchmark]
        public int V2DeadCounterAnts()
        {
            if (string.IsNullOrEmpty(ants))
                return 0;

            int heads = 0;
            int bodies = 0;
            int tails = 0;
            int deadAnts;

            for (int i = 0; i < ants.Length; i++)
            {
                if (ants[i] == 'a') heads++;
                else if (ants[i] == 'n') bodies++;
                else if (ants[i] == 't') tails++;

                if (i >= 2 && ants[i - 2] == 'a' && ants[i - 1] == 'n' && ants[i] == 't')
                {
                    heads--;
                    bodies--;
                    tails--;
                    continue;
                }
            }

            deadAnts = Math.Max(heads, bodies);
            deadAnts = Math.Max(deadAnts, tails);

            return deadAnts;
        }

        [Benchmark(Baseline = true)]
        public int V1DeadCounterAnts()
        {
            if (string.IsNullOrEmpty(ants))
                return 0;

            string replaceAnts = ants.Replace("ant", string.Empty);

            int aCount = replaceAnts.Count(x => x == 'a');
            int nCount = replaceAnts.Count(x => x == 'n');
            int tCount = replaceAnts.Count(x => x == 't');

            return Math.Max(aCount, Math.Max(nCount, tCount));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class TournamentSelectionStrategy : ISelectionStrategy
    {
        Random random = new Random();
        EvaluateStrategy evaluateStrategy;
        private readonly int tournamentSize;

        public TournamentSelectionStrategy(EvaluateStrategy evaluateStrategy, int tournamentSize)
        {
            this.evaluateStrategy = evaluateStrategy;
            this.tournamentSize = tournamentSize;
        }

        public int[,] Select(int[][,] population)
        {
            int[] tournamentMembers = Enumerable.Repeat(-1, tournamentSize).ToArray();
            int[,] bestSolution = population[0];
            int bestEvaluate = int.MaxValue;
            for (int i = 0; i < tournamentSize; i++)
            {
                int index;
                do
                {
                    index = random.Next(population.Length);
                } while (tournamentMembers.Contains(index));
                tournamentMembers[i] = index;
                int evaluate = evaluateStrategy.Evaluate(population[index]);
                if (evaluate < bestEvaluate)
                {
                    bestSolution = population[index];
                    bestEvaluate = evaluate;
                }
            }
            return bestSolution;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class RandomMethod
    {
        Random random = new Random();
        public RandomMethod(EvaluateStrategy strategy, Problem problem)
        {
            Strategy = strategy;
            Problem = problem;
        }

        public EvaluateStrategy Strategy { get; }
        public Problem Problem { get; }
        public int BestSolutionEvaluate { get; private set; }
        public int[,] BestSolution { get; private set; }

        internal void Run(int v)
        {
            BestSolutionEvaluate = int.MaxValue;
            int[,] solution;
            int evaluate;
            for(int i = 0; i < v; i++)
            {
                solution = GenerateSolution(Problem.X, Problem.Y, Problem.Machines);
                evaluate = Strategy.Evaluate(solution);
                if(evaluate < BestSolutionEvaluate)
                {
                    BestSolutionEvaluate = evaluate;
                    BestSolution = solution;
                }
            }
        }

        private int[,] GenerateSolution(int x, int y, int machines)
        {
            int[,] solution = new int[machines, 2];
            /*for (int i = 0; i < machines; i++)
            {
                solution[i, 0] = -1;
                solution[i, 1] = -1;   
            }*/
            List<int> free_solutions = Enumerable.Range(0, machines).ToList();
            int index;
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    index = random.Next(free_solutions.Count);
                    solution[free_solutions[index], 0] = i;
                    solution[free_solutions[index], 1] = j;
                    free_solutions.RemoveAt(index);
                }
            }
            return solution;
        }

    }
}

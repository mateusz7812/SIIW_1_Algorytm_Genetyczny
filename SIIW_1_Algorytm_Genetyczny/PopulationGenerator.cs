using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class PopulationGenerator
    {
        Random random = new Random();

        private int[,] GenerateSolution(int x, int y, int machines)
        {
            int[,] solution = new int[machines, 2];
            for (int i = 0; i < machines; i++)
            {
                solution[i, 0] = -1;
                solution[i, 1] = -1;
            }
            List<int> free_solutions = Enumerable.Range(0, machines).ToList();
            int index;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    index = random.Next(free_solutions.Count);
                    solution[free_solutions[index], 0] = i;
                    solution[free_solutions[index], 1] = j;
                    free_solutions.RemoveAt(index);
                }
            }
            return solution;
        }

        public int[][,] GeneratePopulation(int size, int x, int y, int machines)
        {
            int[][,] population = new int[size][,];
            for (int i = 0; i < size; i++)
            {
                population[i] = GenerateSolution(x, y, machines);
            }
            return population;
        }
        public int[][,] GeneratePopulation(int size, Problem problem) => GeneratePopulation(size, problem.X, problem.Y, problem.Machines);

    }


}

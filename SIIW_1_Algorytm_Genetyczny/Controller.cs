using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class Controller
    {
        private int population_size;
        private double Px;
        private double Pm;
        private ISelectionStrategy selectionStrategy;
        private ICrossoverStrategy crossoverStrategy;
        private EvaluateStrategy evaluateStrategy;
        private MutationStrategy mutationStrategy;
        private int populations_number;

        public Controller(EvaluateStrategy evaluateStrategy, ISelectionStrategy selectionStrategy, MutationStrategy mutationStrategy, int population_size, double px, double pm, int populations_number, ICrossoverStrategy crossoverStrategy)
        {
            this.population_size = population_size;
            this.selectionStrategy = selectionStrategy;
            this.mutationStrategy = mutationStrategy;
            Px = px;
            Pm = pm;
            this.evaluateStrategy = evaluateStrategy;
            this.populations_number = populations_number;
            this.crossoverStrategy = crossoverStrategy;
        }

        public (int[,], int) GetSolution(int[][,] first_population)
        {
            int[][][,] populations = new int[populations_number][][,];

            populations[0] = first_population;

            int[,] BestSolution = first_population[0];
            int BestSolutionEvaluation = int.MaxValue;

            for(int t = 0; t + 1 < populations_number; t++)
            {
                populations[t + 1] = new int[population_size][,];
                for(int i = 0; i < population_size; i++)
                {
                    int[,] P1 = selectionStrategy.Select(populations[t]);
                    int[,] P2 = selectionStrategy.Select(populations[t]);
                    int[,] O1;
                    if (new Random().NextDouble() < Px)
                    {
                        O1 = crossoverStrategy.Crossover(P1, P2);
                    }
                    else
                    {
                        O1 = new int[P1.Length, 2];
                        Array.Copy(P1, O1, P1.Length);
                    }

                    if (new Random().NextDouble() < Pm)
                        mutationStrategy.Mutate(O1);
                    populations[t + 1][i] = O1;
                    
                    int evaluation = evaluateStrategy.Evaluate(O1);
                    if (BestSolutionEvaluation > evaluation)
                    {
                        BestSolution = O1;
                        BestSolutionEvaluation = evaluation;
                    }
                }
            }
            return (BestSolution, BestSolutionEvaluation);
        }

    }
}

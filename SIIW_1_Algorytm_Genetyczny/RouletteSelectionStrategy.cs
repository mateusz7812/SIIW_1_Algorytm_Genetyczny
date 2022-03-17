using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class RouletteSelectionStrategy : ISelectionStrategy
    {
        EvaluateStrategy evaluateStrategy;
        Random random = new Random();

        public RouletteSelectionStrategy(EvaluateStrategy evaluateStrategy)
        {
            this.evaluateStrategy = evaluateStrategy;
        }

        public int[,] Select(int[][,] population)
        {
            double[] evaluations = new double[population.Length];
            double EvaluationsSum = 0;
            for (int i = 0; i < population.Length; i++)
            {
                evaluations[i] = 1.0 / evaluateStrategy.Evaluate(population[i]);
                EvaluationsSum += evaluations[i];
            }
            double[] weights = new double[population.Length];
            for(int i = 0; i < population.Length; i++)
            {
                weights[i] = evaluations[i] / EvaluationsSum;
            }
            double val = random.NextDouble();
            double weightsSum = 0;
            for(int i = 0; i < population.Length; i++)
            {
                weightsSum += weights[i];
                if(val < weightsSum)
                {
                    return population[i];
                }
            }
            throw new NotImplementedException();
        }
    }
}

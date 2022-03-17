using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class EvaluateStrategy
    {
        public EvaluateStrategy(Problem problem)
        {
            Flows = problem.CostFlow;
        }

        public List<CostFlow> Flows { get; }

        public int Evaluate(int[,] solution)
        {
            int sum = 0;
            foreach(CostFlow flow in Flows)
            {
                int sourceX = solution[flow.source, 0];
                int sourceY = solution[flow.source, 1];
                int destX = solution[flow.dest, 0];
                int destY = solution[flow.dest, 1];
                int distance = Math.Abs(sourceX - destX) + Math.Abs(sourceY - destY);
                sum += flow.amount * flow.cost * distance;
            }
            return sum;
        }

    }
}

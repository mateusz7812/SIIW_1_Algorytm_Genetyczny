using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SIIW_1_Algorytm_Genetyczny
{
    class Program
    {
        static void Main(string[] args)
        {

            Problem problem = new Problem("easy", 3, 3, 9);
            problem.LoadData();

            EvaluateStrategy strategy = new EvaluateStrategy(problem);
            
            RandomMethod method = new RandomMethod(strategy, problem);
            
            method.Run(1000);

            for (int i = 0; i < method.BestSolution.GetLength(0); i++)
            {
                Console.WriteLine($"{i} => ({method.BestSolution[i, 0]}, {method.BestSolution[i, 1]})");
            }

            Console.WriteLine();
            Console.WriteLine(method.BestSolutionEvaluate);
            Console.ReadKey();
        }


    }
}

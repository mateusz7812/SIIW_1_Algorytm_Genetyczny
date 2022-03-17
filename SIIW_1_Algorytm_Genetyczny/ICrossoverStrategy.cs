using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    interface ICrossoverStrategy
    {
        int[,] Crossover(int[,] P1, int[,] P2);
    }
}

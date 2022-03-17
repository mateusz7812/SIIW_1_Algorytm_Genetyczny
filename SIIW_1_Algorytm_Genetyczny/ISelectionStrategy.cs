using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    interface ISelectionStrategy
    {
        int[,] Select(int[][,] population);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class MutationStrategy
    {
        Random random = new Random();

        public void Mutate(in int[,] P)
        {
            int index1 = random.Next(0, P.Length/2);
            int index2;
            do{
                index2 = random.Next(0, P.Length/2);
            } while (index1 == index2);
            
            int x = P[index1, 0];
            int y = P[index1, 1];
            
            P[index1, 0] = P[index2, 0];
            P[index1, 1] = P[index2, 1];

            P[index2, 0] = x;
            P[index2, 1] = y;
        }
    }
}

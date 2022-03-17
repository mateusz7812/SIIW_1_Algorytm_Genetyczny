using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class OnePointCrossoverStrategy : ICrossoverStrategy
    {
        int xLength;
        int yLength;
        int size;
        Random random = new Random();

        public OnePointCrossoverStrategy(int xLength, int yLength, int size)
        {
            this.xLength = xLength;
            this.yLength = yLength;
            this.size = size;
        }

        public int[,] Crossover(int[,] P1, int[,] P2)
        {
            int[,] P3 = new int[size, 2];
            Dictionary<(int, int), int> taken_fields = new Dictionary<(int, int), int>();
            int point = random.Next(size);
            for(int i = 0; i < point; i++)
            {
                P3[i, 0] = P1[i, 0];
                P3[i, 1] = P1[i, 1];
                taken_fields.Add((P1[i, 0], P1[i, 1]), i);
            }
            for (int i = point; i < size; i++)
            {
                (int, int) pair = (P2[i, 0], P2[i, 1]);
                if (taken_fields.ContainsKey(pair))
                {
                    int free_index;
                    do
                    {
                        free_index = taken_fields[pair];
                        pair = (P2[free_index, 0], P2[free_index, 1]);
                    } while (taken_fields.ContainsKey(pair));
                    P3[i, 0] = P2[free_index, 0];
                    P3[i, 1] = P2[free_index, 1];
                }
                else
                {
                    P3[i, 0] = P2[i, 0];
                    P3[i, 1] = P2[i, 1];
                }
            }
            return P3;
        }
    }
}

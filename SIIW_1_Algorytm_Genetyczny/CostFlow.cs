using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class CostFlow: Flow
    {
        public CostFlow(Flow flow, int cost)
        {
            source = flow.source;
            dest = flow.dest;
            amount = flow.amount;
            this.cost = cost;
        }
        public int cost;
    }
}

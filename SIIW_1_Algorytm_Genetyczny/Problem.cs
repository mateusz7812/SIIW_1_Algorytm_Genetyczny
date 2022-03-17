using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIW_1_Algorytm_Genetyczny
{
    class Problem
    {
        static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string cost_file_name;
        string flow_file_name;
        public Problem(string instance, int x, int y, int machines)
        {
            Instance = instance;
            X = x;
            Y = y;
            Machines = machines;
            cost_file_name = $"{path}\\Data\\{instance}_cost.json";
            flow_file_name = $"{path}\\Data\\{instance}_flow.json";
        }

        public string Instance { get; }
        public int X { get; }
        public int Y { get; }
        public int Machines { get; }
        public List<CostFlow> CostFlow { get; private set; }

        public void LoadData()
        {
            List<Cost> costs = LoadJson<Cost>(cost_file_name);
            List<Flow> flows = LoadJson<Flow>(flow_file_name);

            CostFlow = flows
                .Select(flow => new CostFlow(
                        flow,
                        costs.First(cost => cost.source == flow.source && cost.dest == flow.dest).cost
                    )).ToList();
        }
        public static List<Item> LoadJson<Item>(string file_name)
        {
            using (StreamReader r = new StreamReader(file_name))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
    }
}

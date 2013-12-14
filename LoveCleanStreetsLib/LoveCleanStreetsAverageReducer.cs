using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsAverageReducer: ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            double total = 0;
            double count = 0;

            foreach (var item in values)
            {
                count++;
                total += double.Parse(item);
            }

            context.EmitKeyValue(key, Math.Round(total / count, 2).ToString());
        }
    }
}

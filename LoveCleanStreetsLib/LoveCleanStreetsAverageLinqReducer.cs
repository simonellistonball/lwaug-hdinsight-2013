using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;
using System.Globalization;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsAverageLinqReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            var average = values.Select(s => s.Split(','))
                .Select(x => (DateTime.Parse(x[1]) - DateTime.Parse(x[0])).TotalMinutes)
                .Average();

            context.EmitKeyValue(key, average.ToString());
        }
    }
}

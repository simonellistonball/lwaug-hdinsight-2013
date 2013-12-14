using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;
using System.Globalization;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            context.EmitKeyValue(key,values.Count().ToString(CultureInfo.InvariantCulture));
        }
    }
}

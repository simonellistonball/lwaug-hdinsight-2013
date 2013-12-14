using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsAverageJob : HadoopJob<LoveCleanStreetsAverageMapper, LoveCleanStreetsAverageReducer>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            return new HadoopJobConfiguration()
            {
                InputPath = "/input/LoveCleanStreets.csv",
                OutputFolder = "/average/LoveCleanStreets"
            };
        }

    }
}

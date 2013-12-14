using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsAverageMapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            try
            {
                var parts = inputLine.Split(',');
                if (parts.Length != 16)
                    return;
                if (parts[13].Equals(""))
                    return;
                if (parts[8].Equals(""))
                    return;
                
                    // avoid culture problems
                    string formatString = "dd/MM/yyyy HH:mm";
                    var start = DateTime.ParseExact(parts[4], formatString, null);
                    var end = DateTime.ParseExact(parts[8], formatString, null);
                    
                    var key = String.Format("{0},{1}", parts[10], parts[13]);
                    var value = String.Format("{0},{1}", start.ToString(), end.ToString());
                    context.EmitKeyValue(key, value);
            }
            catch (Exception)
            {
            }


        }
    }
}

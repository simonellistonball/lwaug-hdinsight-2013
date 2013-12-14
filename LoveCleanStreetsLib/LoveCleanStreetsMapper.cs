using System;
using System.Collections.Generic;
using Microsoft.Hadoop.MapReduce;

namespace LoveCleanStreetsLib
{
    public class LoveCleanStreetsMapper: MapperBase 
    {
        public override void Map(string inputLine, MapperContext context)
        {
            try
            {
                var parts = inputLine.Split(',');
                if (parts.Length != 16)
                    return;
                if (!parts[13].Equals("")) 
                {
                    var key = String.Format("{0},{1}", parts[13], DateTime.Parse(parts[4]).ToString("yyyy-MM-dd"));
                    context.EmitKeyValue(key, "1");
                }
            }
            catch (Exception)
            {
            }


        }
    }
}

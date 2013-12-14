using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;
using LoveCleanStreetsLib;

namespace LoveCleanStreets
{
    class Program
    {
        static void Main(string[] args)
        {

            Environment.SetEnvironmentVariable("HADOOP_HOME", @"c:\hadoop");
            Environment.SetEnvironmentVariable("Java_HOME", @"c:\hadoop\jvm");


            var hadoop = Hadoop.Connect(new Uri("https://simonellistonball.azurehdinsight.net"), 
                "simonellistonball", 
                "bob", 
                "bD9/6+WoP0d:eI%25lT'", 
                "sebhdinsight", "XygTMN16161vt63tTyvQbMvpoNTDUi8HYyP91Mz6Vll4i4e71s2c29QZs7FVte4jUXuAkq8/wD8KL1CTh5kkxA==", 
                "cluster", false);
            var result = hadoop.MapReduceJob.ExecuteJob<LoveCleanStreetsAverageLinqJob>();

            if (result.Info.ExitCode != 0)
            {
                Console.WriteLine("Returned with unexpected exit code of " +
               result.Info.ExitCode);
            }
            Console.ReadLine();
        }
    }
}
